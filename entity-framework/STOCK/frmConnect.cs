using data_layer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOCK
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        SqlConnection GetCon(string server, string username, string pass, string database)
        {
            return new SqlConnection("Data Source=" + server + "; Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetCon(txtServer.Text, txtUser.Text, txtPassword.Text, cboDatabase.Text);
            try
            {
                con.Open();
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string enCryptServ = Encryptor.Encrypt(txtServer.Text, "qwertyuiop", true);
            string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop", true);
            string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "qwertyuiop", true);
            string enCryptUser = Encryptor.Encrypt(txtUser.Text, "qwertyuiop", true);

            connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
            cn.ConnectData();
            MessageBox.Show("Lưu thông tin kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboDatabase_Click(object sender, EventArgs e)
        {
            cboDatabase.Items.Clear();
            try
            {
                string Conn = "server=" + txtServer.Text + "; User Id=" + txtUser.Text + ";pwd=" + txtPassword.Text + ";";
                SqlConnection con = new SqlConnection(Conn);
                con.Open();
                string sql = "select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                SqlCommand cmd = new SqlCommand(sql, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboDatabase.Items.Add(dr[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}