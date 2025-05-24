

using System.Windows.Forms;  

namespace travelVista12
{

    // Add this to make sure Label is recognized.

        partial class Form5
        {
            private System.ComponentModel.IContainer components = null;
            private Label labelSource;
            private Label labelDestination;
            private Label labelFlightName;
            private Label labelTravelDate;
            private Label labelPrice;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelFlightName = new System.Windows.Forms.Label();
            this.labelTravelDate = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(50, 50);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(79, 16);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source: N/A";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(50, 80);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(103, 16);
            this.labelDestination.TabIndex = 1;
            this.labelDestination.Text = "Destination: N/A";
            // 
            // labelFlightName
            // 
            this.labelFlightName.AutoSize = true;
            this.labelFlightName.Location = new System.Drawing.Point(50, 110);
            this.labelFlightName.Name = "labelFlightName";
            this.labelFlightName.Size = new System.Drawing.Size(108, 16);
            this.labelFlightName.TabIndex = 2;
            this.labelFlightName.Text = "Flight Name: N/A";
            // 
            // labelTravelDate
            // 
            this.labelTravelDate.AutoSize = true;
            this.labelTravelDate.Location = new System.Drawing.Point(50, 140);
            this.labelTravelDate.Name = "labelTravelDate";
            this.labelTravelDate.Size = new System.Drawing.Size(107, 16);
            this.labelTravelDate.TabIndex = 3;
            this.labelTravelDate.Text = "Travel Date: N/A";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(56, 178);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(101, 25);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Price: N/A";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Enter  your customer details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1056, 626);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelTravelDate);
            this.Controls.Add(this.labelFlightName);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Name = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        private Button button1;
    }
    }

 