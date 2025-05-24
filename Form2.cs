using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;";

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();  // Dispose of the current form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Person (Userperson,password) VALUES (@Value1, @Value2 )";
                    cmd.Parameters.AddWithValue("@Value1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Value2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Value3", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Add initialization logic here if needed
        }
    }
}
