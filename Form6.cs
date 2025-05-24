using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form6 : Form
    {
        private int flightId;
        private string flightName;
        private string source;
        private string destination;
        private DateTime bookingDate;

        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;";

        public Form6()
        {
            InitializeComponent();
        }

        // Set the flight details from the previous form
        public void SetFlightDetails(int flightId, string flightName, string source, string destination, DateTime bookingDate)
        {
            this.flightId = flightId;
            this.flightName = flightName;
            this.source = source;
            this.destination = destination;
            this.bookingDate = bookingDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect personal details from input fields
            string name = textBoxName.Text.Trim();    // Corrected to use Textboxes
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string address = textBoxAddress.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if phone number is valid
           // if (!IsValidPhoneNumber(phone))
           // {
              // MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              // return;
         //   }

            // Check if email is valid
            //if (!IsValidEmail(email))
            //{
            //    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // Insert customer details into the database and retrieve the generated CustomerId
            int customerId = SavePersonalDetailsToDb(name, email, phone, flightId, bookingDate, address);

            if (customerId > 0)
            {
                MessageBox.Show("Booking details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Transition to Form7 and pass the Customer ID
                Form7 form7 = new Form7();
                form7.SetCustomerId(customerId);
                form7.SetFlightId(flightId); // Pass the Customer ID to Form7
                form7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An error occurred while saving your details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Insert customer details into the database
        private int SavePersonalDetailsToDb(string name, string email, string phone, int flightId, DateTime bookingDate, string address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Customer (CustomerName, Email, Phone, FlightId, BookingDate, Address) " +
                                   "VALUES (@CustomerName, @Email, @Phone, @FlightId, @BookingDate, @Address); " +
                                   "SELECT SCOPE_IDENTITY();"; // Get the last inserted CustomerId

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Safely add parameters
                        cmd.Parameters.AddWithValue("@CustomerName", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@FlightId", flightId);
                        cmd.Parameters.AddWithValue("@BookingDate", bookingDate);
                        cmd.Parameters.AddWithValue("@Address", address);

                        con.Open();
                        object result = cmd.ExecuteScalar();  // Get the last inserted CustomerId

                        if (result != null)
                        {
                            int customerId = Convert.ToInt32(result);
                            return customerId;  // Return the generated CustomerId
                        }
                        else
                        {
                            return 0;  // Return 0 if the insert failed
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;  // Return 0 if an exception occurs
            }
        }

        // Validate phone number (must be exactly 10 digits)
       // private bool IsValidPhoneNumber(string phone)
        //{
            // Remove any non-digit characters (like spaces, dashes, parentheses)     
           // string cleanedPhone = Regex.Replace(phone, @"\D", "");

        //    // Check if the cleaned phone number has exactly 10 digits
           // return cleanedPhone.Length == 10 && Regex.IsMatch(cleanedPhone, @"^\d{10}$");
       // }

        // Validate email address (simple regex for basic validation)
        //private bool IsValidEmail(string email)
        //{
        //    return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Basic email validation
        //}

        private void Form6_Load(object sender, EventArgs e)
        {
            // Logic to execute when the form loads (if needed)
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
