using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace travelVista12
{
    public partial class Form7 : Form
    {
        private string connectionString = "Data Source=LENOVO\\SQLEXPRESS02;Database=TRAVELBOOKING;Integrated Security=SSPI;TrustServerCertificate=True;";

        private int CustomerId; // This will store the customer ID
        private int FlightId;

        public Form7()
        {
            InitializeComponent();
        }

        // SetCustomerId is called from Form8 to set the CustomerId
        public void SetCustomerId(int customerId)
        {
            this.CustomerId = customerId;
        }

        public void SetFlightId(int flightId)
        {
            this.FlightId = flightId;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Add card types to ComboBox
            comboBoxCardType.Items.Add("Visa");
            comboBoxCardType.Items.Add("MasterCard");
            comboBoxCardType.Items.Add("American Express");
            comboBoxCardType.Items.Add("Discover");
            comboBoxCardType.Items.Add("Diners Club");
            comboBoxCardType.Items.Add("JCB");

            // Optional: Select default value (e.g., Visa)
            comboBoxCardType.SelectedIndex = 0; // Set default selected card type to "Visa"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cardName = txtCardName.Text;
            string cardNumber = txtCardNumber.Text;
            string cvv = txtCVV.Text;
            string expirationDate = txtExpirationDate.Text; // Format: MM/YY
            string cardType = comboBoxCardType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(cardName) || string.IsNullOrEmpty(cardNumber) ||
                string.IsNullOrEmpty(cvv) || string.IsNullOrEmpty(expirationDate))
            {
                MessageBox.Show("Please enter all payment details.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(cardName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Card name must only contain letters and spaces.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, @"^\d{16}$"))
            {
                MessageBox.Show("Card number must be exactly 16 digits.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(cvv, @"^\d{3}$"))
            {
                MessageBox.Show("CVV must be exactly 3 digits.");
                return;
            }

            DateTime expiration;
            if (!DateTime.TryParseExact(expirationDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out expiration))
            {
                MessageBox.Show("Expiration date must be in MM/YY format.");
                return;
            }

            if (expiration < DateTime.Now)
            {
                MessageBox.Show("The card has expired. Please use a valid card.");
                return;
            }

            bool paymentSuccess = ProcessPayment(cardName, cardNumber, cvv, expiration);

            if (paymentSuccess)
            {
                MessageBox.Show("Payment details successfully submitted!");
                SavePaymentDetailsToDb(cardName, cardNumber, cvv, expiration, cardType);

                var confirmResult = MessageBox.Show("Payment Successful! Would you like to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.Yes)
                {
                    Form8 form8 = new Form8();
                    form8.SetCustomerId(CustomerId);
                  
                    form8.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Payment processing failed. Please try again.");
            }
        }

        private bool ProcessPayment(string cardName, string cardNumber, string cvv, DateTime expiration)
        {
            return true; // Simulating successful payment
        }

        private string EncryptData(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateRandomKey();
                aesAlg.IV = GenerateRandomIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(aesAlg.IV) + ":" + Convert.ToBase64String(encrypted);
                }
            }
        }

        private byte[] GenerateRandomKey()
        {
            byte[] key = new byte[32];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        private byte[] GenerateRandomIV()
        {
            byte[] iv = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }
            return iv;
        }

        private void SavePaymentDetailsToDb(string cardName, string cardNumber, string cvv, DateTime expiration, string cardType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string encryptedCardNumber = EncryptData(cardNumber);
                    string encryptedCVV = EncryptData(cvv);

                    string query = "INSERT INTO PaymentDetails1 (CustomerId, CardName, CardNumber, CVV, ExpirationDate, CardType,FlightId) " +
                                   "VALUES (@CustomerId, @CardName, @CardNumber, @CVV, @ExpirationDate, @CardType,@FlightId); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmd.Parameters.AddWithValue("@CardName", cardName);
                        cmd.Parameters.AddWithValue("@CardNumber", encryptedCardNumber);
                        cmd.Parameters.AddWithValue("@CVV", encryptedCVV);
                        cmd.Parameters.AddWithValue("@ExpirationDate", expiration);
                        cmd.Parameters.AddWithValue("@CardType", cardType);
                        cmd.Parameters.AddWithValue("@FlightId", FlightId);

                        con.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int paymentId = Convert.ToInt32(result);
                            InsertBookingDetails(paymentId);
                        }
                        else
                        {
                            MessageBox.Show("Failed to save payment details.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertBookingDetails(int paymentId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT FlightName, Source, Destination, Price FROM Flights WHERE FlightId = @FlightId";
                    string flightName = string.Empty, source = string.Empty, destination = string.Empty;
                    decimal price = 0;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FlightId", FlightId);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                flightName = reader["FlightName"].ToString();
                                source = reader["Source"].ToString();
                                destination = reader["Destination"].ToString();
                                price = Convert.ToDecimal(reader["Price"]);
                            }
                            else
                            {
                                MessageBox.Show("Flight not found.");
                                return;
                            }
                        } // Close the reader
                    }

                    string bookingDetails = $"{flightName} from {source} to {destination}, Price: {price}";
                    string bookingQuery = "INSERT INTO Booking (CustomerId, PaymentId,  BookingDate, FlightID) " +
                                          "VALUES (@CustomerId, @PaymentId,  @BookingDate , @FlightID)";

                    using (SqlCommand bookingCmd = new SqlCommand(bookingQuery, con))
                    {
                        bookingCmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        bookingCmd.Parameters.AddWithValue("@PaymentId", paymentId);
                        bookingCmd.Parameters.AddWithValue("@FlightID", FlightId);
                        bookingCmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                        int rowsAffected = bookingCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking successfully created!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to create booking.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
