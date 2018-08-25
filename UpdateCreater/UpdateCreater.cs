using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml.Linq;
using DevExpress.XtraEditors;

namespace UpdateCreater
{
    public partial class UpdateCreater : Form
    {
        MySqlConnection conn;
        String TBg_Table;

        /// <summary>
        /// 0: nnv 1: nv
        /// </summary>
        public int versionType { get; set; } = 0;



        public UpdateCreater()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.textEdit1.Text = dlg.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string storageTable = (versionType == 0) ? "TBL_NNV_STORAGE" : "TBL_PKG_STORAGE";
            int result = MySqlHelper.ExecuteNonQuery(conn, "DELETE  FROM " + storageTable);

            if (result < 0)
            {
                XtraMessageBox.Show("An error found in uploading the package.", "Error");
                return;
            }

            
            string filePath = this.textEdit1.Text;
            string description =  string.Format("{0}\n\n\n{1}", this.newVersionRichTextBox.Text, this.historyRichTextBox.Text);

            MySqlDataAdapter da = new MySqlDataAdapter("Select * from " + storageTable, conn);

            DataSet ds = new DataSet("binaryData");
            

            MySqlCommandBuilder MyCb = new MySqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "binaryData");
            

            DataRow newRow = ds.Tables["binaryData"].NewRow();
            


            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = new byte[fs.Length];
            br.Read(bytes, 0, (int)fs.Length);

            br.Close();
            fs.Close();

     
            newRow["BINARY_DATA"] = bytes;
            newRow["UPDATE_TIME"] = DateTime.Now;
            newRow["DESCRIPTION"] = description;
            
            ds.Tables["binaryData"].Rows.Add(newRow);
            da.Update(ds, "binaryData");


            StringBuilder insertQuery = new StringBuilder();
            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                insertQuery.AppendLine("INSERT INTO TBL_GREENLOCK_UPDATE_HITORY");                
                insertQuery.AppendLine("(");
                insertQuery.AppendLine("    Id,");
                insertQuery.AppendLine("    VersionType,");
                insertQuery.AppendLine("    RegDate,");
                insertQuery.AppendLine("    Discription,");
                insertQuery.AppendLine("    Version");
                insertQuery.AppendLine(")");
                insertQuery.AppendLine("VALUES");
                insertQuery.AppendLine("(");
                insertQuery.AppendLine("    @Id,");
                insertQuery.AppendLine("    @VersionType,");
                insertQuery.AppendLine("    @RegDate,");
                insertQuery.AppendLine("    @Discription,");
                insertQuery.AppendLine("    @Version");
                insertQuery.AppendLine(")");

                MySqlCommand command = new MySqlCommand(insertQuery.ToString(), conn);
                command.Transaction = transaction;

                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@VersionType", versionType);
                    command.Parameters.AddWithValue("@RegDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Discription", description);
                    command.Parameters.AddWithValue("@Version", this.textBox1.Text);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                    XtraMessageBox.Show("The package has been uploaded successfully.", "Uploading");
                    this.Enabled = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    XtraMessageBox.Show("Failed.", ex.Message);
                }
            }

            updateInfo_Init();
        }

        private void UpdateCreater_Load(object sender, EventArgs e)
        {
            //TBg_Table = "TBL_NNV_STORAGE";
            TBg_Table = "TBL_GREENLOCK_UPDATE_HITORY";
            
            string startPath = Application.StartupPath;
            string updateInfoPath = Path.Combine(startPath, "UpdateInfo.xml");

            XElement root = XElement.Load(updateInfoPath);

            string ipAddress = root.Element("Database").Element("IP").Value;
            string port = root.Element("Database").Element("Port").Value;
            string userId = root.Element("Database").Element("User").Value;
            string password = root.Element("Database").Element("Password").Value;
            string databaseName = root.Element("Database").Element("DatabaseName").Value;

            string connString = string.Format("server={0};Port={1};User Id={2}; Password={3}; Database={4}; pooling=true;Charset=euckr;",
                ipAddress, port, userId, password, databaseName);

            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                //comboBox1.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(string.Format("There was a critical error. The updator is terminated:\n{0}", exception.Message), "Error");
                Application.Exit();
            }

        }

        private void updateInfo_Init()
        {
            newVersionRichTextBox.Clear();
            historyRichTextBox.Clear();

            DataSet dataset = MySqlHelper.ExecuteDataset(conn, "SELECT * FROM " + TBg_Table + " ORDER BY RegDate DESC");

            

            if (dataset == null)
                return;

            if (dataset.Tables[0].Rows.Count == 0)
                return;

            this.textBox2.Text = dataset.Tables[0].Rows[0].Field<string>("Version");

            double nextVersion;
            if (double.TryParse(this.textBox2.Text , out nextVersion))
            {
                nextVersion = nextVersion + 0.01;
                textBox1.Text = nextVersion.ToString();
            }


            StringBuilder history = new StringBuilder();
            // 히스토리를 조합한다
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                history.AppendLine($"[일시:{row.Field<DateTime>("RegDate").ToString("yyyy.MM.dd HH:mm:ss")}]");
                history.AppendLine($"[버전:{row.Field<string>("Version")}]");                            
                history.AppendLine(row.Field<string>("Discription"));
            }

            //this.historyRichTextBox.Text = dataset.Tables[0].Rows[0].Field<string>("DESCRIPTION");
            this.historyRichTextBox.Text = history.ToString();
        }

        private void UpdateCreater_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch(comboBox1.SelectedIndex)
            //{
            //    case 0: // nvv버전                    
            //        TBg_Table = "TBL_NNV_STORAGE";
            //        updateInfo_Init();
            //        break;
            //    case 1: // nv 버전 TBL_PKG_STORAGE
            //        TBg_Table = "TBL_PKG_STORAGE";
            //        updateInfo_Init();
            //        break;
            //}

            versionType = comboBox1.SelectedIndex;
            updateInfo_Init();
        }
    }
}
