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
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(txtServer.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(cboDatabase.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin kết nối!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mã hóa thông tin
                string enCryptServ = Encryptor.Encrypt(txtServer.Text, "qwertyuiop", true);
                string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "qwertyuiop", true);
                string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop", true);
                string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "qwertyuiop", true);

                // Tạo đối tượng connect và lưu file
                connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
                cn.SaveFile();
                MessageBox.Show("Lưu thông tin kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void btnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        private void cboDatabase_Click_1(object sender, EventArgs e)
        {
            cboDatabase.Items.Clear();

            try
            {
                // Xây dựng chuỗi kết nối từ thông tin nhập vào
                string connStr = $"Data Source={txtServer.Text};User ID={txtUsername.Text};Password={txtPassword.Text};TrustServerCertificate=True;";
                Console.WriteLine($"Chuỗi kết nối: {connStr}");

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    // Thử mở kết nối
                    con.Open();
                    Console.WriteLine("Kết nối thành công!");

                    // Truy vấn danh sách database
                    string query = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Thêm database vào ComboBox
                    while (reader.Read())
                    {
                        cboDatabase.Items.Add(reader["name"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                // Hiển thị chi tiết lỗi SQL
                Console.WriteLine($"Lỗi SQL: {sqlEx.Message}");
                MessageBox.Show($"Lỗi SQL: {sqlEx.Message}\nChi tiết: {sqlEx.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi khác
                Console.WriteLine($"Lỗi khác: {ex.Message}");
                MessageBox.Show($"Lỗi khác: {ex.Message}\nChi tiết: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}