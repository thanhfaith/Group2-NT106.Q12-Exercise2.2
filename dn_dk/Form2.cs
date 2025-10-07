using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace signin_signup
{
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            formdangky f1 = new formdangky();
            f1.ShowDialog();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btndn_Click(object sender, EventArgs e)
        {
            string email = txte.Text;
            string password = txtmk.Text;
            if (email == "" || password == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string dinhdang = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, dinhdang))
            {
                MessageBox.Show("Định dạng email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //string MaHoa = hashedPassword(password);
                string connectionString = "Server=localhost;Database=mydatabase;UserId=myuser;Password=mypassword;";
                string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlConnection connect = new SqlConnection(connectionString))
                {

                    connect.Open();
                    SqlCommand command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Email", email);
                    //command.Parameters.AddWithValue("@Password", MaHoa);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Formthongtin main = new Formthongtin();
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

        private void txte_TextChanged(object sender, EventArgs e)
        {

        }
    }
}