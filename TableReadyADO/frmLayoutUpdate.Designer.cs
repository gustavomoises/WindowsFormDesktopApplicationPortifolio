namespace TableReadyADO
{
    partial class frmLayoutUpdate
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
            System.Windows.Forms.Label layoutImageLabel;
            System.Windows.Forms.Label layoutNameLabel;
            System.Windows.Forms.Label layoutIdLabel;
            System.Windows.Forms.Label restaurantIDLabel;
            System.Windows.Forms.Label restaurantNameLabel;
            this.LU_layoutImageTextBox = new System.Windows.Forms.TextBox();
            this.layoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LU_layoutNameTextBox = new System.Windows.Forms.TextBox();
            this.btnAddLayoutUpdate = new System.Windows.Forms.Button();
            this.btnCancelLayoutUpdate = new System.Windows.Forms.Button();
            this.LU_IdTextBox = new System.Windows.Forms.TextBox();
            this.LU_restaurantIDComboBox = new System.Windows.Forms.ComboBox();
            this.LU_restaurantNameTextBox = new System.Windows.Forms.TextBox();
            this.restaurantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            layoutImageLabel = new System.Windows.Forms.Label();
            layoutNameLabel = new System.Windows.Forms.Label();
            layoutIdLabel = new System.Windows.Forms.Label();
            restaurantIDLabel = new System.Windows.Forms.Label();
            restaurantNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutImageLabel
            // 
            layoutImageLabel.AutoSize = true;
            layoutImageLabel.Location = new System.Drawing.Point(9, 109);
            layoutImageLabel.Name = "layoutImageLabel";
            layoutImageLabel.Size = new System.Drawing.Size(97, 17);
            layoutImageLabel.TabIndex = 3;
            layoutImageLabel.Text = "Layout Image:";
            // 
            // layoutNameLabel
            // 
            layoutNameLabel.AutoSize = true;
            layoutNameLabel.Location = new System.Drawing.Point(9, 137);
            layoutNameLabel.Name = "layoutNameLabel";
            layoutNameLabel.Size = new System.Drawing.Size(96, 17);
            layoutNameLabel.TabIndex = 5;
            layoutNameLabel.Text = "Layout Name:";
            // 
            // layoutIdLabel
            // 
            layoutIdLabel.AutoSize = true;
            layoutIdLabel.Location = new System.Drawing.Point(9, 28);
            layoutIdLabel.Name = "layoutIdLabel";
            layoutIdLabel.Size = new System.Drawing.Size(70, 17);
            layoutIdLabel.TabIndex = 8;
            layoutIdLabel.Text = "Layout Id:";
            // 
            // restaurantIDLabel
            // 
            restaurantIDLabel.AutoSize = true;
            restaurantIDLabel.Location = new System.Drawing.Point(8, 56);
            restaurantIDLabel.Name = "restaurantIDLabel";
            restaurantIDLabel.Size = new System.Drawing.Size(99, 17);
            restaurantIDLabel.TabIndex = 9;
            restaurantIDLabel.Text = "Restaurant ID:";
            // 
            // restaurantNameLabel
            // 
            restaurantNameLabel.AutoSize = true;
            restaurantNameLabel.Location = new System.Drawing.Point(8, 80);
            restaurantNameLabel.Name = "restaurantNameLabel";
            restaurantNameLabel.Size = new System.Drawing.Size(123, 17);
            restaurantNameLabel.TabIndex = 10;
            restaurantNameLabel.Text = "Restaurant Name:";
            // 
            // LU_layoutImageTextBox
            // 
            this.LU_layoutImageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "LayoutImage", true));
            this.LU_layoutImageTextBox.Location = new System.Drawing.Point(152, 106);
            this.LU_layoutImageTextBox.Name = "LU_layoutImageTextBox";
            this.LU_layoutImageTextBox.Size = new System.Drawing.Size(121, 22);
            this.LU_layoutImageTextBox.TabIndex = 4;
            // 
            // layoutBindingSource
            // 
            this.layoutBindingSource.DataSource = typeof(TableReadyADO.Layout);
            // 
            // LU_layoutNameTextBox
            // 
            this.LU_layoutNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "LayoutName", true));
            this.LU_layoutNameTextBox.Location = new System.Drawing.Point(152, 134);
            this.LU_layoutNameTextBox.Name = "LU_layoutNameTextBox";
            this.LU_layoutNameTextBox.Size = new System.Drawing.Size(122, 22);
            this.LU_layoutNameTextBox.TabIndex = 6;
            // 
            // btnAddLayoutUpdate
            // 
            this.btnAddLayoutUpdate.Location = new System.Drawing.Point(89, 176);
            this.btnAddLayoutUpdate.Name = "btnAddLayoutUpdate";
            this.btnAddLayoutUpdate.Size = new System.Drawing.Size(89, 33);
            this.btnAddLayoutUpdate.TabIndex = 7;
            this.btnAddLayoutUpdate.Text = "&Add";
            this.btnAddLayoutUpdate.UseVisualStyleBackColor = true;
            this.btnAddLayoutUpdate.Click += new System.EventHandler(this.btnAddLayoutUpdate_Click);
            // 
            // btnCancelLayoutUpdate
            // 
            this.btnCancelLayoutUpdate.Location = new System.Drawing.Point(184, 176);
            this.btnCancelLayoutUpdate.Name = "btnCancelLayoutUpdate";
            this.btnCancelLayoutUpdate.Size = new System.Drawing.Size(89, 33);
            this.btnCancelLayoutUpdate.TabIndex = 8;
            this.btnCancelLayoutUpdate.Text = "&Cancel";
            this.btnCancelLayoutUpdate.UseVisualStyleBackColor = true;
            this.btnCancelLayoutUpdate.Click += new System.EventHandler(this.btnCancelLayoutUpdate_Click);
            // 
            // LU_IdTextBox
            // 
            this.LU_IdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "LayoutId", true));
            this.LU_IdTextBox.Enabled = false;
            this.LU_IdTextBox.Location = new System.Drawing.Point(151, 25);
            this.LU_IdTextBox.Name = "LU_IdTextBox";
            this.LU_IdTextBox.ReadOnly = true;
            this.LU_IdTextBox.Size = new System.Drawing.Size(121, 22);
            this.LU_IdTextBox.TabIndex = 9;
            // 
            // LU_restaurantIDComboBox
            // 
            this.LU_restaurantIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "RestaurantID", true));
            this.LU_restaurantIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.layoutBindingSource, "RestaurantID", true));
            this.LU_restaurantIDComboBox.FormattingEnabled = true;
            this.LU_restaurantIDComboBox.Location = new System.Drawing.Point(152, 53);
            this.LU_restaurantIDComboBox.Name = "LU_restaurantIDComboBox";
            this.LU_restaurantIDComboBox.Size = new System.Drawing.Size(121, 24);
            this.LU_restaurantIDComboBox.TabIndex = 10;
            this.LU_restaurantIDComboBox.SelectedIndexChanged += new System.EventHandler(this.LU_restaurantIDComboBox_SelectedIndexChanged);
            // 
            // LU_restaurantNameTextBox
            // 
            this.LU_restaurantNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.restaurantBindingSource, "RestaurantName", true));
            this.LU_restaurantNameTextBox.Enabled = false;
            this.LU_restaurantNameTextBox.Location = new System.Drawing.Point(152, 80);
            this.LU_restaurantNameTextBox.Name = "LU_restaurantNameTextBox";
            this.LU_restaurantNameTextBox.ReadOnly = true;
            this.LU_restaurantNameTextBox.Size = new System.Drawing.Size(120, 22);
            this.LU_restaurantNameTextBox.TabIndex = 11;
            // 
            // restaurantBindingSource
            // 
            this.restaurantBindingSource.DataSource = typeof(TableReadyADO.Restaurant);
            // 
            // frmLayoutUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 232);
            this.Controls.Add(restaurantNameLabel);
            this.Controls.Add(this.LU_restaurantNameTextBox);
            this.Controls.Add(restaurantIDLabel);
            this.Controls.Add(this.LU_restaurantIDComboBox);
            this.Controls.Add(layoutIdLabel);
            this.Controls.Add(this.LU_IdTextBox);
            this.Controls.Add(this.btnCancelLayoutUpdate);
            this.Controls.Add(this.btnAddLayoutUpdate);
            this.Controls.Add(layoutNameLabel);
            this.Controls.Add(this.LU_layoutNameTextBox);
            this.Controls.Add(layoutImageLabel);
            this.Controls.Add(this.LU_layoutImageTextBox);
            this.Name = "frmLayoutUpdate";
            this.Text = "frmLayoutUpdate";
            this.Load += new System.EventHandler(this.frmLayoutUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource layoutBindingSource;
        private System.Windows.Forms.TextBox LU_layoutImageTextBox;
        private System.Windows.Forms.TextBox LU_layoutNameTextBox;
        private System.Windows.Forms.Button btnAddLayoutUpdate;
        private System.Windows.Forms.Button btnCancelLayoutUpdate;
        private System.Windows.Forms.TextBox LU_IdTextBox;
        private System.Windows.Forms.ComboBox LU_restaurantIDComboBox;
        private System.Windows.Forms.BindingSource restaurantBindingSource;
        private System.Windows.Forms.TextBox LU_restaurantNameTextBox;
    }
}