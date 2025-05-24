namespace travelVista12
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelTrainName = new System.Windows.Forms.Label();
            this.labelTravelDate = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(38, 54);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(50, 16);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(41, 101);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(74, 16);
            this.labelDestination.TabIndex = 1;
            this.labelDestination.Text = "Destination";
            // 
            // labelTrainName
            // 
            this.labelTrainName.AutoSize = true;
            this.labelTrainName.Location = new System.Drawing.Point(44, 150);
            this.labelTrainName.Name = "labelTrainName";
            this.labelTrainName.Size = new System.Drawing.Size(75, 16);
            this.labelTrainName.TabIndex = 2;
            this.labelTrainName.Text = "TrainName";
            // 
            // labelTravelDate
            // 
            this.labelTravelDate.AutoSize = true;
            this.labelTravelDate.Location = new System.Drawing.Point(41, 204);
            this.labelTravelDate.Name = "labelTravelDate";
            this.labelTravelDate.Size = new System.Drawing.Size(75, 16);
            this.labelTravelDate.TabIndex = 3;
            this.labelTravelDate.Text = "TravelDate";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(44, 254);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(38, 16);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Price";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(142, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "ENTER YOUR PERSONAL DEATILS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelTravelDate);
            this.Controls.Add(this.labelTrainName);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Name = "Form10";
            this.Text = "Form10";
            this.Load += new System.EventHandler(this.Form10_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelTrainName;
        private System.Windows.Forms.Label labelTravelDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button button1;
    }
}