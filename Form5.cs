using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace travelVista12
{
   
        public partial class Form5 : Form
        {
            private int selectedFlightId; // Store the flight ID
            private string source;
            private string destination;
            private string flightName;
            private DateTime travelDate;
            private decimal price;

            // Constructor that accepts flight details
            public Form5(string source, string destination, string flightName, DateTime travelDate, decimal price)
            {
                InitializeComponent();

                // Set the flight details passed from Form4
                this.source = source;
                this.destination = destination;
                this.flightName = flightName;
                this.travelDate = travelDate;
                this.price = price;

                // Display the flight details on the labels
                labelSource.Text = "Source: " + source;
                labelDestination.Text = "Destination: " + destination;
                labelFlightName.Text = "Flight Name: " + flightName;
                labelTravelDate.Text = "Travel Date: " + travelDate.ToShortDateString();
                labelPrice.Text = "Price: " + price.ToString("C");

                // Get the Flight ID from the database
                selectedFlightId = GetFlightIdFromDb(flightName, source, destination, travelDate);
            }

            private void Form5_Load(object sender, EventArgs e)
            {
                // Additional code to handle when Form5 is loaded (if needed)
            }

            private void button1_Click(object sender, EventArgs e)
            {
                // Example: Passing flight details to Form6 for booking and personal information
                DateTime bookingDate = DateTime.Now;  // Current date for the booking

            // Create Form6 and set flight details
            // Example: Add flight details to the parameters when calling SetFlightDetails
            Form6 form6 = new Form6();
            form6.SetFlightDetails(selectedFlightId, flightName, source, destination, bookingDate);
            form6.Show();
            this.Hide();  // Hide Form5 after opening Form6
                          // Hide Form5 after opening Form6
        }

        private int GetFlightIdFromDb(string flightName, string source, string destination, DateTime travelDate)
        {
            int flightId = -1;  // Default value in case the flight ID isn't found
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;"))
                {
                    string query = "SELECT FlightId FROM Flights WHERE FlightName = @FlightName AND Source = @Source AND Destination = @Destination AND TravelDate = @TravelDate";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FlightName", flightName);
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@TravelDate", travelDate.Date);

                        con.Open();  // Open the database connection
                        object result = cmd.ExecuteScalar();  // Retrieve the FlightId
                        if (result != null)
                        {
                            flightId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flightId;
        }

    }
}





