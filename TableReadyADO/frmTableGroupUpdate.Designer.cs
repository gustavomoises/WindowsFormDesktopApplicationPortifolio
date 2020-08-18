namespace TableReadyADO
{
    partial class frmTableGroupUpdate
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
            System.Windows.Forms.Label layoutIDLabel;
            System.Windows.Forms.Label tableGroupActiveLabel;
            System.Windows.Forms.Label tableGroupIDLabel;
            System.Windows.Forms.Label tableGroupPriorityLabel;
            System.Windows.Forms.Label restaurantIDLabel;
            System.Windows.Forms.Label tableGroupPosXLabel;
            System.Windows.Forms.Label tableGroupPosYLabel;
            System.Windows.Forms.Label tableGroupImageLabel;
            System.Windows.Forms.Label tableGroupNameLabel;
            this.layoutIDTextBox = new System.Windows.Forms.TextBox();
            this.tableGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableGroupActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.tableGroupIDTextBox = new System.Windows.Forms.TextBox();
            this.tableGroupPriorityTextBox = new System.Windows.Forms.TextBox();
            this.restaurantIDTextBox = new System.Windows.Forms.TextBox();
            this.tableGroupPosXTextBox = new System.Windows.Forms.TextBox();
            this.tableGroupImageTextBox = new System.Windows.Forms.TextBox();
            this.tableGroupPosYTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.tableInGroupDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableInGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            layoutIDLabel = new System.Windows.Forms.Label();
            tableGroupActiveLabel = new System.Windows.Forms.Label();
            tableGroupIDLabel = new System.Windows.Forms.Label();
            tableGroupPriorityLabel = new System.Windows.Forms.Label();
            restaurantIDLabel = new System.Windows.Forms.Label();
            tableGroupPosXLabel = new System.Windows.Forms.Label();
            tableGroupPosYLabel = new System.Windows.Forms.Label();
            tableGroupImageLabel = new System.Windows.Forms.Label();
            tableGroupNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableGroupBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableInGroupDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutIDLabel
            // 
            layoutIDLabel.AutoSize = true;
            layoutIDLabel.Location = new System.Drawing.Point(38, 60);
            layoutIDLabel.Name = "layoutIDLabel";
            layoutIDLabel.Size = new System.Drawing.Size(72, 17);
            layoutIDLabel.TabIndex = 1;
            layoutIDLabel.Text = "Layout ID:";
            // 
            // tableGroupActiveLabel
            // 
            tableGroupActiveLabel.AutoSize = true;
            tableGroupActiveLabel.Location = new System.Drawing.Point(39, 118);
            tableGroupActiveLabel.Name = "tableGroupActiveLabel";
            tableGroupActiveLabel.Size = new System.Drawing.Size(134, 17);
            tableGroupActiveLabel.TabIndex = 3;
            tableGroupActiveLabel.Text = "Table Group Active:";
            // 
            // tableGroupIDLabel
            // 
            tableGroupIDLabel.AutoSize = true;
            tableGroupIDLabel.Location = new System.Drawing.Point(38, 90);
            tableGroupIDLabel.Name = "tableGroupIDLabel";
            tableGroupIDLabel.Size = new System.Drawing.Size(109, 17);
            tableGroupIDLabel.TabIndex = 5;
            tableGroupIDLabel.Text = "Table Group ID:";
            // 
            // tableGroupPriorityLabel
            // 
            tableGroupPriorityLabel.AutoSize = true;
            tableGroupPriorityLabel.Location = new System.Drawing.Point(38, 170);
            tableGroupPriorityLabel.Name = "tableGroupPriorityLabel";
            tableGroupPriorityLabel.Size = new System.Drawing.Size(140, 17);
            tableGroupPriorityLabel.TabIndex = 15;
            tableGroupPriorityLabel.Text = "Table Group Priority:";
            // 
            // restaurantIDLabel
            // 
            restaurantIDLabel.AutoSize = true;
            restaurantIDLabel.Location = new System.Drawing.Point(38, 31);
            restaurantIDLabel.Name = "restaurantIDLabel";
            restaurantIDLabel.Size = new System.Drawing.Size(99, 17);
            restaurantIDLabel.TabIndex = 23;
            restaurantIDLabel.Text = "Restaurant ID:";
            // 
            // tableGroupPosXLabel
            // 
            tableGroupPosXLabel.AutoSize = true;
            tableGroupPosXLabel.Location = new System.Drawing.Point(41, 71);
            tableGroupPosXLabel.Name = "tableGroupPosXLabel";
            tableGroupPosXLabel.Size = new System.Drawing.Size(133, 17);
            tableGroupPosXLabel.TabIndex = 11;
            tableGroupPosXLabel.Text = "Table Group Pos X:";
            // 
            // tableGroupPosYLabel
            // 
            tableGroupPosYLabel.AutoSize = true;
            tableGroupPosYLabel.Location = new System.Drawing.Point(41, 99);
            tableGroupPosYLabel.Name = "tableGroupPosYLabel";
            tableGroupPosYLabel.Size = new System.Drawing.Size(133, 17);
            tableGroupPosYLabel.TabIndex = 13;
            tableGroupPosYLabel.Text = "Table Group Pos Y:";
            // 
            // tableGroupImageLabel
            // 
            tableGroupImageLabel.AutoSize = true;
            tableGroupImageLabel.Location = new System.Drawing.Point(41, 37);
            tableGroupImageLabel.Name = "tableGroupImageLabel";
            tableGroupImageLabel.Size = new System.Drawing.Size(134, 17);
            tableGroupImageLabel.TabIndex = 7;
            tableGroupImageLabel.Text = "Table Group Image:";
            // 
            // tableGroupNameLabel
            // 
            tableGroupNameLabel.AutoSize = true;
            tableGroupNameLabel.Location = new System.Drawing.Point(39, 145);
            tableGroupNameLabel.Name = "tableGroupNameLabel";
            tableGroupNameLabel.Size = new System.Drawing.Size(133, 17);
            tableGroupNameLabel.TabIndex = 25;
            tableGroupNameLabel.Text = "Table Group Name:";
            // 
            // layoutIDTextBox
            // 
            this.layoutIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "LayoutID", true));
            this.layoutIDTextBox.Location = new System.Drawing.Point(184, 57);
            this.layoutIDTextBox.Name = "layoutIDTextBox";
            this.layoutIDTextBox.ReadOnly = true;
            this.layoutIDTextBox.Size = new System.Drawing.Size(104, 22);
            this.layoutIDTextBox.TabIndex = 2;
            // 
            // tableGroupBindingSource
            // 
            this.tableGroupBindingSource.DataSource = typeof(TableReadyADO.TableGroup);
            // 
            // tableGroupActiveCheckBox
            // 
            this.tableGroupActiveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tableGroupBindingSource, "TableGroupActive", true));
            this.tableGroupActiveCheckBox.Location = new System.Drawing.Point(184, 115);
            this.tableGroupActiveCheckBox.Name = "tableGroupActiveCheckBox";
            this.tableGroupActiveCheckBox.Size = new System.Drawing.Size(104, 24);
            this.tableGroupActiveCheckBox.TabIndex = 4;
            this.tableGroupActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableGroupIDTextBox
            // 
            this.tableGroupIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupID", true));
            this.tableGroupIDTextBox.Location = new System.Drawing.Point(184, 87);
            this.tableGroupIDTextBox.Name = "tableGroupIDTextBox";
            this.tableGroupIDTextBox.ReadOnly = true;
            this.tableGroupIDTextBox.Size = new System.Drawing.Size(104, 22);
            this.tableGroupIDTextBox.TabIndex = 6;
            // 
            // tableGroupPriorityTextBox
            // 
            this.tableGroupPriorityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupPriority", true));
            this.tableGroupPriorityTextBox.Location = new System.Drawing.Point(184, 167);
            this.tableGroupPriorityTextBox.Name = "tableGroupPriorityTextBox";
            this.tableGroupPriorityTextBox.Size = new System.Drawing.Size(101, 22);
            this.tableGroupPriorityTextBox.TabIndex = 16;
            // 
            // restaurantIDTextBox
            // 
            this.restaurantIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "Layout.RestaurantID", true));
            this.restaurantIDTextBox.Location = new System.Drawing.Point(186, 28);
            this.restaurantIDTextBox.Name = "restaurantIDTextBox";
            this.restaurantIDTextBox.ReadOnly = true;
            this.restaurantIDTextBox.Size = new System.Drawing.Size(100, 22);
            this.restaurantIDTextBox.TabIndex = 24;
            // 
            // tableGroupPosXTextBox
            // 
            this.tableGroupPosXTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupPosX", true));
            this.tableGroupPosXTextBox.Location = new System.Drawing.Point(187, 68);
            this.tableGroupPosXTextBox.Name = "tableGroupPosXTextBox";
            this.tableGroupPosXTextBox.Size = new System.Drawing.Size(104, 22);
            this.tableGroupPosXTextBox.TabIndex = 12;
            // 
            // tableGroupImageTextBox
            // 
            this.tableGroupImageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupImage", true));
            this.tableGroupImageTextBox.Location = new System.Drawing.Point(187, 34);
            this.tableGroupImageTextBox.Name = "tableGroupImageTextBox";
            this.tableGroupImageTextBox.Size = new System.Drawing.Size(104, 22);
            this.tableGroupImageTextBox.TabIndex = 8;
            // 
            // tableGroupPosYTextBox
            // 
            this.tableGroupPosYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupPosY", true));
            this.tableGroupPosYTextBox.Location = new System.Drawing.Point(187, 96);
            this.tableGroupPosYTextBox.Name = "tableGroupPosYTextBox";
            this.tableGroupPosYTextBox.Size = new System.Drawing.Size(104, 22);
            this.tableGroupPosYTextBox.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(tableGroupImageLabel);
            this.groupBox1.Controls.Add(this.tableGroupPosYTextBox);
            this.groupBox1.Controls.Add(this.tableGroupImageTextBox);
            this.groupBox1.Controls.Add(tableGroupPosYLabel);
            this.groupBox1.Controls.Add(tableGroupPosXLabel);
            this.groupBox1.Controls.Add(this.tableGroupPosXTextBox);
            this.groupBox1.Location = new System.Drawing.Point(41, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 145);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphic Design";
            // 
            // tableGroupNameTextBox
            // 
            this.tableGroupNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableGroupBindingSource, "TableGroupName", true));
            this.tableGroupNameTextBox.Location = new System.Drawing.Point(185, 142);
            this.tableGroupNameTextBox.Name = "tableGroupNameTextBox";
            this.tableGroupNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.tableGroupNameTextBox.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateTable);
            this.groupBox2.Controls.Add(this.btnDeleteTable);
            this.groupBox2.Controls.Add(this.btnAddTable);
            this.groupBox2.Controls.Add(this.tableInGroupDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(417, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 347);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tables";
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(253, 188);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(121, 42);
            this.btnUpdateTable.TabIndex = 3;
            this.btnUpdateTable.Text = "&Update Table";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(253, 142);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(121, 40);
            this.btnDeleteTable.TabIndex = 2;
            this.btnDeleteTable.Text = "&Delete table";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(253, 94);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(121, 42);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "Add &Table";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // tableInGroupDataGridView
            // 
            this.tableInGroupDataGridView.AutoGenerateColumns = false;
            this.tableInGroupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableInGroupDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.tableInGroupDataGridView.DataSource = this.tableInGroupBindingSource;
            this.tableInGroupDataGridView.Location = new System.Drawing.Point(30, 37);
            this.tableInGroupDataGridView.Name = "tableInGroupDataGridView";
            this.tableInGroupDataGridView.RowHeadersWidth = 51;
            this.tableInGroupDataGridView.RowTemplate.Height = 24;
            this.tableInGroupDataGridView.Size = new System.Drawing.Size(187, 281);
            this.tableInGroupDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TableID";
            this.dataGridViewTextBoxColumn1.HeaderText = "TableID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // tableInGroupBindingSource
            // 
            this.tableInGroupBindingSource.DataSource = typeof(TableReadyADO.TableInGroup);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(67, 371);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(80, 32);
            this.btnAccept.TabIndex = 28;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(TableReadyADO.Table);
            // 
            // frmTableGroupUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 428);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(tableGroupNameLabel);
            this.Controls.Add(this.tableGroupNameTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(restaurantIDLabel);
            this.Controls.Add(this.restaurantIDTextBox);
            this.Controls.Add(layoutIDLabel);
            this.Controls.Add(this.layoutIDTextBox);
            this.Controls.Add(tableGroupActiveLabel);
            this.Controls.Add(this.tableGroupActiveCheckBox);
            this.Controls.Add(tableGroupIDLabel);
            this.Controls.Add(this.tableGroupIDTextBox);
            this.Controls.Add(tableGroupPriorityLabel);
            this.Controls.Add(this.tableGroupPriorityTextBox);
            this.Name = "frmTableGroupUpdate";
            this.Text = "Table Group ";
            this.Load += new System.EventHandler(this.frmTableGroupUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGroupBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableInGroupDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tableGroupBindingSource;
        private System.Windows.Forms.TextBox layoutIDTextBox;
        private System.Windows.Forms.CheckBox tableGroupActiveCheckBox;
        private System.Windows.Forms.TextBox tableGroupIDTextBox;
        private System.Windows.Forms.TextBox tableGroupPriorityTextBox;
        private System.Windows.Forms.TextBox restaurantIDTextBox;
        private System.Windows.Forms.TextBox tableGroupPosXTextBox;
        private System.Windows.Forms.TextBox tableGroupImageTextBox;
        private System.Windows.Forms.TextBox tableGroupPosYTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tableGroupNameTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.DataGridView tableInGroupDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource tableInGroupBindingSource;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}