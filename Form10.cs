using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form10 : Form
    {
        private int route_id; // Store the route_id for the train
        private string source;
        private string destination;
        private string trainName;
        private DateTime travelDate;
        private decimal price;

        // Constructor that accepts train details
        public Form10(string source, string destination, string trainName, DateTime travelDate, decimal price)
        {
            InitializeComponent();

            // Set the train details passed from Form4
            this.source = source;
            this.destination = destination;
            this.trainName = trainName;
            this.travelDate = travelDate;
            this.price = price;

            // Display the train details on the labels
            labelSource.Text = "Source: " + source;
            labelDestination.Text = "Destination: " + destination;
            labelTrainName.Text = "Train Name: " + trainName;
            labelTravelDate.Text = "Travel Date: " + travelDate.ToShortDateString();
            labelPrice.Text = "Price: " + price.ToString("C");

            // Get the Route ID from the database
            route_id = GetRouteIdFromDb(trainName, source, destination, travelDate);
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // Additional code to handle when Form10 is loaded (if needed)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Example: Passing train details to Form11 for booking and personal information
            DateTime bookingDate = DateTime.Now;  // Current date for the booking

            // Create Form11 and set train details
            Form11 form11 = new Form11();
            form11.SetTrainDetails(route_id, trainName, source, destination, bookingDate);  // Pass route_id directly
            form11.Show();
            this.Hide();  // Hide Form10 after opening Form11
        }

        private int GetRouteIdFromDb(string trainName, string source, string destination, DateTime travelDate)
        {
            int route_id = -1;  // Default value in case the route_id isn't found
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS02;Database=Travelbookings;Integrated Security=SSPI;TrustServerCertificate=True;"))
                {
                    string query = "SELECT route_id FROM RAILWAYS WHERE TrainName = @TrainName AND Source = @Source AND Destination = @Destination AND TravelDate = @TravelDate";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainName", trainName);
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        cmd.Parameters.AddWithValue("@TravelDate", travelDate.Date);

                        con.Open();  // Open the database connection
                        object result = cmd.ExecuteScalar();  // Retrieve the route_id
                        if (result != null)
                        {
                            route_id = Convert.ToInt32(result);  // Set the route_id from the query result
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return route_id;
        }
    }
}
