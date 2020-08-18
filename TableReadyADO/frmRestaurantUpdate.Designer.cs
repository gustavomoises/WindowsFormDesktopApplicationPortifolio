namespace TableReadyADO
{
    partial class frmRestaurantUpdate
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
            System.Windows.Forms.Label restaurantIdLabel;
            System.Windows.Forms.Label restaurantNameLabel;
            System.Windows.Forms.Label layoutActiveLabel;
            this.RU_restaurantIdTextBox = new System.Windows.Forms.TextBox();
            this.RU_restaurantNameTextBox = new System.Windows.Forms.TextBox();
            this.RU_layoutActiveComboBox = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.reservationEntriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restaurantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            restaurantIdLabel = new System.Windows.Forms.Label();
            restaurantNameLabel = new System.Windows.Forms.Label();
            layoutActiveLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reservationEntriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // restaurantIdLabel
            // 
            restaurantIdLabel.AutoSize = true;
            restaurantIdLabel.Location = new System.Drawing.Point(53, 38);
            restaurantIdLabel.Name = "restaurantIdLabel";
            restaurantIdLabel.Size = new System.Drawing.Size(97, 17);
            restaurantIdLabel.TabIndex = 2;
            restaurantIdLabel.Text = "Restaurant Id:";
            // 
            // restaurantNameLabel
            // 
            restaurantNameLabel.AutoSize = true;
            restaurantNameLabel.Location = new System.Drawing.Point(53, 66);
            restaurantNameLabel.Name = "restaurantNameLabel";
            restaurantNameLabel.Size = new System.Drawing.Size(123, 17);
            restaurantNameLabel.TabIndex = 4;
            restaurantNameLabel.Text = "Restaurant Name:";
            // 
            // layoutActiveLabel
            // 
            layoutActiveLabel.AutoSize = true;
            layoutActiveLabel.Location = new System.Drawing.Point(53, 96);
            layoutActiveLabel.Name = "layoutActiveLabel";
            layoutActiveLabel.Size = new System.Drawing.Size(97, 17);
            layoutActiveLabel.TabIndex = 5;
            layoutActiveLabel.Text = "Layout Active:";
            // 
            // RU_restaurantIdTextBox
            // 
            this.RU_restaurantIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.restaurantBindingSource, "RestaurantId", true));
            this.RU_restaurantIdTextBox.Location = new System.Drawing.Point(182, 35);
            this.RU_restaurantIdTextBox.Name = "RU_restaurantIdTextBox";
            this.RU_restaurantIdTextBox.ReadOnly = true;
            this.RU_restaurantIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.RU_restaurantIdTextBox.TabIndex = 3;
            // 
            // RU_restaurantNameTextBox
            // 
            this.RU_restaurantNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.restaurantBindingSource, "RestaurantName", true));
            this.RU_restaurantNameTextBox.Location = new System.Drawing.Point(182, 63);
            this.RU_restaurantNameTextBox.Name = "RU_restaurantNameTextBox";
            this.RU_restaurantNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.RU_restaurantNameTextBox.TabIndex = 5;
            // 
            // RU_layoutActiveComboBox
            // 
            this.RU_layoutActiveComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.restaurantBindingSource, "LayoutActive", true));
            this.RU_layoutActiveComboBox.FormattingEnabled = true;
            this.RU_layoutActiveComboBox.Location = new System.Drawing.Point(181, 93);
            this.RU_layoutActiveComboBox.Name = "RU_layoutActiveComboBox";
            this.RU_layoutActiveComboBox.Size = new System.Drawing.Size(101, 24);
            this.RU_layoutActiveComboBox.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(56, 146);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(78, 34);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // reservationEntriesBindingSource
            // 
            this.reservationEntriesBindingSource.DataMember = "ReservationEntries";
            this.reservationEntriesBindingSource.DataSource = this.restaurantBindingSource;
            // 
            // restaurantBindingSource
            // 
            this.restaurantBindingSource.DataSource = typeof(TableReadyADO.Restaurant);
            // 
            // frmRestaurantUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 207);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(layoutActiveLabel);
            this.Controls.Add(this.RU_layoutActiveComboBox);
            this.Controls.Add(restaurantIdLabel);
            this.Controls.Add(this.RU_restaurantIdTextBox);
            this.Controls.Add(restaurantNameLabel);
            this.Controls.Add(this.RU_restaurantNameTextBox);
            this.Name = "frmRestaurantUpdate";
            this.Text = "Restaurant";
            this.Load += new System.EventHandler(this.frmRestaurantUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservationEntriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource restaurantBindingSource;
        private System.Windows.Forms.BindingSource reservationEntriesBindingSource;
        private System.Windows.Forms.TextBox RU_restaurantIdTextBox;
        private System.Windows.Forms.TextBox RU_restaurantNameTextBox;
        private System.Windows.Forms.ComboBox RU_layoutActiveComboBox;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}