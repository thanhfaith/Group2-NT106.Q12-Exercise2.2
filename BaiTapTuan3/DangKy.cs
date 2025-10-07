using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTuan3
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text;
            string password = tb_password.Text;
            if (email == "" || password == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string MaHoa = hashedPassword(password);
            string connectionString = "Server=localhost;Database=mydatabase;UserId=myuser;Password=mypassword;";
            string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", MaHoa);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        btn_main main = new btn_main();
                        main.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
}
