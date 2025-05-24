namespace travelVista12
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.Label();
            this.txtExpirationDate = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Items.AddRange(new object[] {
            "Visa",
            "MasterCard",
            "American Express",
            "Discover",
            "Diners Club",
            "JCB"});
            this.comboBoxCardType.Location = new System.Drawing.Point(180, 366);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCardType.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "card type";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 24;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoSize = true;
            this.txtCustomerName.Location = new System.Drawing.Point(31, 308);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(99, 16);
            this.txtCustomerName.TabIndex = 23;
            this.txtCustomerName.Text = "customer name";
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.Location = new System.Drawing.Point(180, 235);
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.Size = new System.Drawing.Size(100, 22);
            this.txtExpirationDate.TabIndex = 22;
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(180, 167);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(79, 22);
            this.txtCVV.TabIndex = 21;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(180, 94);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(401, 22);
            this.txtCardNumber.TabIndex = 20;
            // 
            // txtCardName
            // 
            this.txtCardName.Location = new System.Drawing.Point(180, 39);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(401, 22);
            this.txtCardName.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "CONFIRM PAYMENT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Expirationdate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "CVV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Card Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Card holder name";
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxCardType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtExpirationDate);
            this.Controls.Add(this.txtCVV);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form12";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtCustomerName;
        private System.Windows.Forms.TextBox txtExpirationDate;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}