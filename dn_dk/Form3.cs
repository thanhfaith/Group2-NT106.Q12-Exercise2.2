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

namespace signin_signup
{
    public partial class Formthongtin : Form
    {
        private int _userId;

        public Formthongtin(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private void LoadUserInfo()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT HoTen, SoDienThoai, Email, NgaySinh FROM Users WHERE UserId = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", _userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblht.Text = reader["HoTen"].ToString();
                        labsdt.Text = reader["SoDienThoai"].ToString();
                        lble.Text = reader["Email"].ToString();
                        DateTime ns = Convert.ToDateTime(reader["NgaySinh"]);
                        lblns.Text = ns.ToString("dd/MM/yyyy");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message);
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
             LoadUserInfo();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void labsdt_Click(object sender, EventArgs e)
        {

        }

        private void lblht_Click(object sender, EventArgs e)
        {

        }

        private void lble_Click(object sender, EventArgs e)
        {

        }

        private void lblns_Click(object sender, EventArgs e)
        {

        }
    }
}
