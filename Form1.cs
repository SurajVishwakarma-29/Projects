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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace travelVista12
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                try
                {
                    
                    con.Open();

                    string username = textBox1.Text;
                    string password = textBox2.Text;

                   
                    string query = "SELECT count(1) from person where  Userperson = @username and password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("Password", password);

                        int userExits = (int)cmd.ExecuteScalar();
                        

                        if (userExits != null)
                        {
                            
                            if (userExits == 1)
                            { 
                                Form3 form3 = new Form3();
                                form3.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox2.Text = string.Empty;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();   
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

