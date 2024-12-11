using DataLayer;
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

		private void frmConnect_Load(object sender,  EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnection con = GetCon(txtServer.Text, txtUsername.Text, txtPassword.Text, cboDatabase.Text);
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

		private void btnLuu_Click(object sender, EventArgs e)
		{
			string enCryptServ = Encryptor.Encrypt(txtServer.Text, "qwertyuiop", true);
			string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop", true);
			string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "qwertyuiop", true);
			string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "qwertyuiop", true);

			connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
			cn.SaveFile();
			MessageBox.Show("Lưu thông tin kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}