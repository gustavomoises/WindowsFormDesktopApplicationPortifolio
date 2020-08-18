namespace TableReadyADO
{
    partial class frmCustomerUpdate
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label customerFirstNameLabel;
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label customerLastNameLabel;
            this.customerFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.customerLastNameTextBox = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            customerFirstNameLabel = new System.Windows.Forms.Label();
            customerIDLabel = new System.Windows.Forms.Label();
            customerLastNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customerFirstNameLabel
            // 
            customerFirstNameLabel.AutoSize = true;
            customerFirstNameLabel.Location = new System.Drawing.Point(38, 66);
            customerFirstNameLabel.Name = "customerFirstNameLabel";
            customerFirstNameLabel.Size = new System.Drawing.Size(144, 17);
            customerFirstNameLabel.TabIndex = 1;
            customerFirstNameLabel.Text = "Customer First Name:";
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(38, 32);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(89, 17);
            customerIDLabel.TabIndex = 3;
            customerIDLabel.Text = "Customer ID:";
            // 
            // customerLastNameLabel
            // 
            customerLastNameLabel.AutoSize = true;
            customerLastNameLabel.Location = new System.Drawing.Point(38, 99);
            customerLastNameLabel.Name = "customerLastNameLabel";
            customerLastNameLabel.Size = new System.Drawing.Size(144, 17);
            customerLastNameLabel.TabIndex = 5;
            customerLastNameLabel.Text = "Customer Last Name:";
            // 
            // customerFirstNameTextBox
            // 
            this.customerFirstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CustomerFirstName", true));
            this.customerFirstNameTextBox.Location = new System.Drawing.Point(188, 63);
            this.customerFirstNameTextBox.Name = "customerFirstNameTextBox";
            this.customerFirstNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.customerFirstNameTextBox.TabIndex = 2;
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CustomerID", true));
            this.customerIDTextBox.Enabled = false;
            this.customerIDTextBox.Location = new System.Drawing.Point(188, 29);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.ReadOnly = true;
            this.customerIDTextBox.Size = new System.Drawing.Size(100, 22);
            this.customerIDTextBox.TabIndex = 4;
            // 
            // customerLastNameTextBox
            // 
            this.customerLastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CustomerLastName", true));
            this.customerLastNameTextBox.Location = new System.Drawing.Point(188, 96);
            this.customerLastNameTextBox.Name = "customerLastNameTextBox";
            this.customerLastNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.customerLastNameTextBox.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(41, 152);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(86, 33);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&Add";
            this.btnAccept.UseVisualStyleBackColor = true;
//            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
        //    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(TableReadyADO.Customer);
            // 
            // frmCustomerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 207);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(customerFirstNameLabel);
            this.Controls.Add(this.customerFirstNameTextBox);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDTextBox);
            this.Controls.Add(customerLastNameLabel);
            this.Controls.Add(this.customerLastNameTextBox);
            this.Name = "frmCustomerUpdate";
            this.Text = "Customer";
          //  this.Load += new System.EventHandler(this.frmCustomerUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.TextBox customerFirstNameTextBox;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.TextBox customerLastNameTextBox;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}