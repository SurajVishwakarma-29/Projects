namespace travelVista12
{
    partial class Form8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblFlightName = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.lblPaymentInfo = new System.Windows.Forms.Label();
            this.lblBookingDate = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(44, 44);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 16);
            this.lblCustomerName.TabIndex = 0;
            // 
            // lblFlightName
            // 
            this.lblFlightName.AutoSize = true;
            this.lblFlightName.Location = new System.Drawing.Point(44, 110);
            this.lblFlightName.Name = "lblFlightName";
            this.lblFlightName.Size = new System.Drawing.Size(0, 16);
            this.lblFlightName.TabIndex = 1;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(48, 61);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(50, 16);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "Source";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(44, 110);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(74, 16);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Destination";
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.Location = new System.Drawing.Point(43, 177);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(75, 16);
            this.lblTravelDate.TabIndex = 4;
            this.lblTravelDate.Text = "TravelDate";
            // 
            // lblPaymentInfo
            // 
            this.lblPaymentInfo.AutoSize = true;
            this.lblPaymentInfo.Location = new System.Drawing.Point(43, 238);
            this.lblPaymentInfo.Name = "lblPaymentInfo";
            this.lblPaymentInfo.Size = new System.Drawing.Size(81, 16);
            this.lblPaymentInfo.TabIndex = 5;
            this.lblPaymentInfo.Text = "PaymentInfo";
            this.lblPaymentInfo.Click += new System.EventHandler(this.lblPaymentInfo_Click);
            // 
            // lblBookingDate
            // 
            this.lblBookingDate.AutoSize = true;
            this.lblBookingDate.Location = new System.Drawing.Point(37, 293);
            this.lblBookingDate.Name = "lblBookingDate";
            this.lblBookingDate.Size = new System.Drawing.Size(87, 16);
            this.lblBookingDate.TabIndex = 6;
            this.lblBookingDate.Text = "Booking date";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(60, 353);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 16);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            this.lblPrice.Click += new System.EventHandler(this.lblPrice_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblBookingDate);
            this.Controls.Add(this.lblPaymentInfo);
            this.Controls.Add(this.lblTravelDate);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblFlightName);
            this.Controls.Add(this.lblCustomerName);
            this.Name = "Form8";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblFlightName;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblTravelDate;
        private System.Windows.Forms.Label lblPaymentInfo;
        private System.Windows.Forms.Label lblBookingDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ListBox listBoxBookings;
        private System.Windows.Forms.Button button1;
    }
}