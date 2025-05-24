using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form9 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=Travelbookings;Integrated Security=SSPI;TrustServerCertificate=True";

        public Form9()
        {
            InitializeComponent();

            // Populate ComboBoxes with railway station names
            comboBox1.Items.AddRange(new string[] {
                "Howrah Junction", "Chennai Egmore", "Mumbai CST", "New Delhi", "Bangalore City",
                "Hyderabad Deccan", "Lucknow Charbagh", "Kochi", "Patna Junction", "Jaipur Junction",
                "Agra Cantt.", "Ahmedabad Junction", "Varanasi Junction", "Surat", "Kolkata Sealdah"
            });

            comboBox2.Items.AddRange(new string[] {
                "Howrah Junction", "Chennai Egmore", "Mumbai CST", "New Delhi", "Bangalore City",
                "Hyderabad Deccan", "Lucknow Charbagh", "Kochi", "Patna Junction", "Jaipur Junction",
                "Agra Cantt.", "Ahmedabad Junction", "Varanasi Junction", "Surat", "Kolkata Sealdah"
            });

            comboBox1.SelectedIndex = 0; // Set a default selection for Source
            comboBox2.SelectedIndex = 0; // Set a default selection for Destination
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string source = comboBox1.SelectedItem?.ToString();
                string destination = comboBox2.SelectedItem?.ToString();
                DateTime travelDate = dateTimePicker1.Value; // Get selected date from DateTimePicker

                // Validate selections
                if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
                {
                    MessageBox.Show("Please select both source and destination!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (source == destination)
                {
                    MessageBox.Show("Source and destination cannot be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve train details
                var trainDetails = GetTrainDetailsFromDb(source, destination, travelDate);
                if (trainDetails == null)
                {
                    MessageBox.Show("No trains available for the selected route and date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string trainName = trainDetails.Value.trainName;
                decimal price = trainDetails.Value.price;

                // Insert selected date and train details into the database
                InsertTrainBookingIntoDb(source, destination, trainName, travelDate, price);

                // Pass train details to Form10
                Form10 form10 = new Form10(source, destination, trainName, travelDate, price);
                form10.Show();
                this.Hide(); // Hide the current form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (string trainName, decimal price)? GetTrainDetailsFromDb(string source, string destination, DateTime travelDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT trainName, price FROM RAILWAYS WHERE source = @Source AND destination = @Destination";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string trainName = reader["trainName"].ToString();
                                decimal price = Convert.ToDecimal(reader["price"]);
                                return (trainName, price);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void InsertTrainBookingIntoDb(string source, string destination, string trainName, DateTime travelDate, decimal price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO RAILWAYS (source, destination, trainName, travel_date, price) " +
                                   "VALUES (@Source, @Destination, @TrainName, @Travel_date, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add the necessary parameters
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@TrainName", trainName);
                        cmd.Parameters.AddWithValue("@Travel_date", travelDate);  // Insert selected travel date
                        cmd.Parameters.AddWithValue("@Price", price);

                        con.Open();
                        cmd.ExecuteNonQuery(); // Execute the query to insert data into the database
                    }
                }

                MessageBox.Show("Train booking details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting train details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Other event handlers can remain as is
    

private void Form9_Load(object sender, EventArgs e)
        {
            // Code to handle form load
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle source ComboBox selection change
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle destination ComboBox selection change
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Handle date change
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
