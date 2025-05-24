using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form11 : Form
    {
        private int route_id;
        private string trainName;
        private string source;
        private string destination;
        private DateTime bookingDate;

        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=Travelbookings;Integrated Security=SSPI;TrustServerCertificate=True;";

        public Form11()
        {
            InitializeComponent();
        }

        // Set the train details from the previous form
        public void SetTrainDetails(int route_id, string trainName, string source, string destination, DateTime bookingDate)
        {
            this.route_id = route_id;
            this.trainName = trainName;
            this.source = source;
            this.destination = destination;
            this.bookingDate = bookingDate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Collect personal details from input fields
            string firstName = labelFirstName.Text.Trim();    // First name input
            string lastName = textBoxLastName.Text.Trim();      // Last name input
            string email = labelEmail.Text.Trim();            // Email input
            string phone = labelPhone.Text.Trim();            // Phone input
            string address = textBoxAddress.Text.Trim();        // Address input
            string gender = comboBox1.SelectedItem?.ToString(); // Gender selection from ComboBox
            //int routeId = Convert.ToInt32(textBoxRouteId.Text.Trim()); // Route ID input

            // Validate input fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(gender) )
                
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if phone number is valid (must be 10 digits)
            //if (!IsValidPhoneNumber(phone))
            //{
                //MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return;
           // }

            // Check if email is valid (simple email validation)
           // if (!IsValidEmail(email))
           // {
               // MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return;
           // }

            // Insert customer details into the database and retrieve the generated CustomerId
            int customerId = SavePersonalDetailsToDb(firstName, lastName, email, phone, route_id, gender, address);

            if (customerId > 0)
            {
                MessageBox.Show("Booking details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Transition to Form7 and pass the Customer ID
                Form12 form12 = new Form12();
                form12.SetCustomerId(customerId);
                form12.Setroute_id(route_id); // Pass the Customer ID to Form7
                form12.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An error occurred while saving your details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (comboBox1 != null && comboBox1.SelectedItem != null)
            {
                gender = comboBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a gender.");
                return; // Stop execution if gender is not selected
            }

            // Proceed with the logic
            MessageBox.Show("Gender selected: " + gender);
        }

        // Insert customer details into the database
        private int SavePersonalDetailsToDb(string firstName, string lastName, string email, string phone, int route_id, string gender, string address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Customer (FirstName, LastName, Email, Phone, route_id, Gender, Address) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone, @route_id, @Gender, @Address); " +
                                   "SELECT SCOPE_IDENTITY();"; // Get the last inserted CustomerId

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Safely add parameters
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@route_id", route_id);
                        cmd.Parameters.AddWithValue("@Gender", gender);
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
        // {
        // Remove any non-digit characters (like spaces, dashes, parentheses)     
        //string cleanedPhone = System.Text.RegularExpressions.Regex.Replace(phone, @"\D", "");

        // Check if the cleaned phone number has exactly 10 digits
        // return cleanedPhone.Length == 10 && System.Text.RegularExpressions.Regex.IsMatch(cleanedPhone, @"^\d{10}$");
        // }

        // Validate email address (simple regex for basic validation)
       // private bool IsValidEmail(string email)
       // {
            // Trim the email string to remove any extra spaces
          //  email = email.Trim();

            // Check if the email matches a more reliable regex pattern
           // return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
      //  }


        private void Form11_Load(object sender, EventArgs e)
        {
            // Logic to execute when the form loads (if needed)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
