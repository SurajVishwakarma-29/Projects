using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True";

        public Form4()
        {
            InitializeComponent();

            // Populate ComboBoxes with airport names
            comboBox1.Items.AddRange(new string[]
            {
                "Goa Dabolim International Airport",
                "Kempegowda International Airport Bengaluru",
                "Prayagraj Airport",
                "Lal Bahadur Shastri Airport",
                "Chhatrapati Shivaji Maharaj International Airport Mumbai",
                "Heathrow Airport",
                "Charles de Gaulle Airport",
                "Sydney Kingsford Smith Airport",
                "Changi Airport",
                "Dubai International Airport",
                "Toronto Pearson International Airport",
                "Los Angeles International Airport",
                "Indira Gandhi International Airport",
                "Suvarnabhumi International Airport"
            });

            comboBox2.Items.AddRange(new string[]
            {
                "Changi Airport",
                "Dubai International Airport",
                "Incheon International Airport",
                "Sheremetyevo International Airport",
                "Vancouver International Airport",
                "Cairo International Airport",
                "Indira Gandhi International Airport",
                "Narita International Airport",
                "Fiumicino Airport Rome",
                "John F. Kennedy International Airport",
                "Lal Bahadur Shastri Airport",
                "Kempegowda International Airport Bengaluru"
            });

            comboBox1.SelectedIndex = 0; // Set a default selection for Source
            comboBox2.SelectedIndex = 0; // Set a default selection for Destination
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string source = comboBox1.SelectedItem?.ToString();
                string destination = comboBox2.SelectedItem?.ToString();
                DateTime travelDate = dateTimePicker1.Value;

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

                // Retrieve flight details
                var flightDetails = GetFlightDetailsFromDb(source, destination, travelDate);
                if (flightDetails == null)
                {
                    MessageBox.Show("No flights available for the selected route and date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string flightName = flightDetails.Value.flightName;
                decimal price = flightDetails.Value.price;

                // Pass flight details to Form5
                Form5 form5 = new Form5(source, destination, flightName, travelDate, price);
                form5.Show();
                this.Hide(); // Hide the current form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (string flightName, decimal price)? GetFlightDetailsFromDb(string source, string destination, DateTime travelDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT FlightName, Price FROM Flights WHERE Source = @Source AND Destination = @Destination AND TravelDate = @TravelDate";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@TravelDate", travelDate.Date);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string flightName = reader["FlightName"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                return (flightName, price);
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

        private void Form4_Load(object sender, EventArgs e)
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
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 was clicked!");
        }

        private void lblDestination_Click(object sender, EventArgs e)
        {

        }

        private void lblFlightName_Click(object sender, EventArgs e)
        {

        }
    }
}
