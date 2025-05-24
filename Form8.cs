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
using System.Windows.Forms.DataVisualization.Charting;

namespace travelVista12
{

    public partial class Form8 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;";

        private int customerId; // Store customer ID

        public Form8()
        {
            InitializeComponent();
        }

        // SetCustomerId is called from Form7 to set the CustomerId
        public void SetCustomerId(int customerId)
        {
            this.customerId = customerId;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadBookingDetails(); // Load booking details when Form8 is loaded
        }

        private void LoadBookingDetails()
        {
            try
            {
                // Check if customerId is valid (e.g., it should be a positive number)
                if (customerId <= 0)
                {
                    MessageBox.Show("Invalid Customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // SQL query to get flight details, booking date, etc.
                    string query = "SELECT " +
                                   "c.CustomerName, " +
                                   "f.FlightName, " +
                                   "f.Source, " +
                                   "f.Destination, " +
                                   "f.Price, " +
                                   "f.TravelDate, " +
                                   "b.BookingDate " +
                                   "FROM [dbo].[Booking] b " +
                                   "JOIN [dbo].[Customer] c ON b.CustomerId = c.CustomerId " +
                                   "JOIN [dbo].[Flights] f ON b.FlightId = f.FlightId " +
                                   "WHERE b.CustomerId = @CustomerId"; // Use @CustomerId for parameterized query

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Pass the CustomerId to the SQL query
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int bookingCount = 0; // Counter for booking records
                            while (reader.Read())
                            {
                                // Retrieve flight details from the query result
                                string customerName = reader["CustomerName"].ToString();
                                string flightName = reader["FlightName"].ToString();
                                string source = reader["Source"].ToString();
                                string destination = reader["Destination"].ToString();
                                decimal price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Price"]);
                                DateTime travelDate = reader["TravelDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["TravelDate"]);
                                DateTime bookingDate = reader["BookingDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BookingDate"]);

                                // Display the first booking in labels
                                if (bookingCount == 0)
                                {
                                    // Display customer information
                                    lblCustomerName.Text = "Customer Name: " + customerName;
                                    lblPrice.Text = "Price: " + price.ToString("C");
                                    lblTravelDate.Text = "Travel Date: " + travelDate.ToShortDateString();

                                    // Display additional information for Flight and Booking details
                                    lblFlightName.Text = "Flight Name: " + flightName;
                                    lblSource.Text = "Source: " + source;
                                    lblDestination.Text = "Destination: " + destination;
                                    lblBookingDate.Text = "Booking Date: " + bookingDate.ToShortDateString();
                                }
                                else
                                {
                                    // Add the booking details to the ListBox for multiple bookings
                                    listBoxBookings.Items.Add($"{flightName} from {source} to {destination}, Booking Date: {bookingDate.ToShortDateString()}");
                                }

                                bookingCount++;
                            }

                            // If no bookings were found for the given customerId
                            if (bookingCount == 0)
                            {
                                MessageBox.Show($"No bookings found for Customer ID: {customerId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related exceptions (e.g., connectivity issues, syntax errors)
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any general exceptions that occur during the process
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblPaymentInfo_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }
    }
}


















