namespace travelVista12
{
        partial class Form4
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
            /// Required method for Designer support - do not modify the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.lblDestination = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.lblFlightName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(67, 165);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(187, 29);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "DESTINATION";
            this.lblDestination.Click += new System.EventHandler(this.lblDestination_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(261, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Flight details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(551, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 6;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(67, 30);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(121, 29);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "SOURCE";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Goa Dabolim International Airport  ",
            "Prayagraj Airport ",
            "Chhatrapati Shivaji Maharaj International Airport Mumbai ",
            "Chicago O\'Hare International Airport",
            "Pulkovo Airport  ",
            "Heathrow Airport  ",
            "Charles de Gaulle Airport",
            "Sydney Kingsford Smith Airport",
            "Changi Airport ",
            "Dubai International Airport ",
            " Toronto Pearson International Airport  ",
            "Chhatrapati Shivaji Maharaj International Airport Mumbai  ",
            "Los Angeles International Airport",
            " Indira Gandhi International Airport ",
            " Suvarnabhumi International Airport "});
            this.comboBox1.Location = new System.Drawing.Point(72, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(546, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Changi Airport",
            " Dubai International Airport",
            "Incheon International Airport",
            "Sheremetyevo International Airport",
            "Vancouver International Airport",
            " Cairo International Airport",
            " Indira Gandhi International Airport",
            " Narita International Airport",
            " Fiumicino Airport Rome",
            "John F. Kennedy International Airport",
            " Dubai International Airport",
            "Lal Bahadur Shastri Airport",
            "Kempegowda International Airport Bengaluru"});
            this.comboBox2.Location = new System.Drawing.Point(72, 228);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(546, 24);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 300);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(255, 22);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.Location = new System.Drawing.Point(72, 278);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(44, 16);
            this.lblTravelDate.TabIndex = 10;
            this.lblTravelDate.Text = "label1";
            // 
            // lblFlightName
            // 
            this.lblFlightName.AutoSize = true;
            this.lblFlightName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightName.Location = new System.Drawing.Point(67, 350);
            this.lblFlightName.Name = "lblFlightName";
            this.lblFlightName.Size = new System.Drawing.Size(0, 29);
            this.lblFlightName.TabIndex = 11;
            this.lblFlightName.Click += new System.EventHandler(this.lblFlightName_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFlightName);
            this.Controls.Add(this.lblTravelDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label lblDestination;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Label lblSource;
            private System.Windows.Forms.ComboBox comboBox1;
            private System.Windows.Forms.ComboBox comboBox2;
            private System.Windows.Forms.DateTimePicker dateTimePicker1;
            private System.Windows.Forms.Label lblTravelDate;
            private System.Windows.Forms.Label lblFlightName;  // New Label for Flight Name
        }
    }
