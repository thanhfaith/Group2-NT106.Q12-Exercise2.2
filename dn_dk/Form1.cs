using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace signin_signup
{
    public partial class formdangky : Form
    {
        public formdangky()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formdangnhap f2 = new Formdangnhap();
            f2.ShowDialog();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textht_TextChanged(object sender, EventArgs e)
        {

        }

        private void textsdt_TextChanged(object sender, EventArgs e)
        {

        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btndk_Click(object sender, EventArgs e)
        {
            string hoTen = textht.Text.Trim();
            string sdt = textsdt.Text.Trim();
            string email = texte.Text.Trim();
            string ngaySinhText = textns.Text.Trim();
            string matKhau = textmk.Text;
            string nhapLai = textnlmk.Text;

            // 1. Kiểm tra dữ liệu trống
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau)
                || string.IsNullOrEmpty(nhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau != nhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaySinh;
            try
            {
                ngaySinh = DateTime.ParseExact(ngaySinhText, "dd/MM/yyyy", null);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ! (định dạng: dd/MM/yyyy)", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = HashPassword(matKhau);

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO Users (HoTen, SoDienThoai, Email, NgaySinh, MatKhau) " +
                      "VALUES (@HoTen, @SDT, @Email, @NgaySinh, @MatKhau)";

                    using (SqlCommand Cmd = new SqlCommand(query, conn))
                    {

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@HoTen", textht.Text);
                        cmd.Parameters.AddWithValue("@SDT", textsdt.Text);
                        cmd.Parameters.AddWithValue("@Email", texte.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@MatKhau", hashedPassword);
                        cmd.ExecuteNonQuery();

                    }

                    MessageBox.Show("Đăng ký thành công!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            
        private void textns_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
