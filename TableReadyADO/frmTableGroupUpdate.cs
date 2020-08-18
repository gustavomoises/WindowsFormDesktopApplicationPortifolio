//Author:Gustavo Lourenco Moises
//Date:7/18/2020
//Thread Project Team 4 - TableReady
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Gustavo's Part
namespace TableReadyADO
{
    public partial class frmTableGroupUpdate : Form
    {
        public frmTableGroupUpdate()
        {
            InitializeComponent();
        }
        public bool IsAdd;// distinguishes Add from Edit; main form sets it
        public TableGroup tableGroup = null; // when Edit, main for will set the current tableGroup
        //public List<Table> tables = null;
        public List<TableInGroup> tableInGroupTables = null;
        public List<int> tableInGroupTableIds = null;
        public List<int> tableInGroupTableStatus = null;

        public List<int> availableTables = null;
        public TableInGroup tableInGroupTable = null;
        public List<Table> restTables = null;
        public List<int> restTableIds=null;
        public bool tableInGroupInUse;
        public int layoutId;
        public int restaurantId;
        public int tableGroupId;
        List<int> local_tableInGroupTableIds;
        List<TableInGroup> local_tableInGroupTables;
        BindingSource source = new BindingSource();


        //Cancel Button - go back to previous form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //Data from form Load
        private void frmTableGroupUpdate_Load(object sender, EventArgs e)
        {
            //Show Restaurant and Layout IDs
            restaurantIDTextBox.Text = Convert.ToString(restaurantId);
            layoutIDTextBox.Text = Convert.ToString(layoutId);

            //Define tableInGroupTables locally based on the imported tableInGroupTables
            local_tableInGroupTables = new List<TableInGroup>();
            local_tableInGroupTableIds = new List<int>();
            if (tableInGroupTableIds!=null)
            {
                foreach (int i in tableInGroupTableIds)
                {
                    local_tableInGroupTableIds.Add(i);
                }
                foreach (TableInGroup i in tableInGroupTables)
                {
                    local_tableInGroupTables.Add(i);
                }
            }
            
            //ADD
            if (IsAdd)
            {
                this.Text = "Add New Table Group";
                //Disable Delete and Update buttons
                btnDeleteTable.Enabled = false;
                btnUpdateTable.Enabled = false;
                //New table, cannot be in use
                tableInGroupInUse = false;

            }
            //EDIT
            else            {
                this.Text = "Edit Table Group";
                // display data of the current product
                tableGroupIDTextBox.Text = Convert.ToString(tableGroup.TableGroupID);
                tableGroupNameTextBox.Text = tableGroup.TableGroupName;
                tableGroupActiveCheckBox.Checked = tableGroup.TableGroupActive;
                if (tableGroup.TableGroupPriority == null) tableGroupPriorityTextBox.Text = "";
                else tableGroupPriorityTextBox.Text = Convert.ToString(tableGroup.TableGroupPriority);
                if (tableGroup.TableGroupImage == null) tableGroupImageTextBox.Text = "";
                else tableGroupImageTextBox.Text = tableGroup.TableGroupImage;
                if (tableGroup.TableGroupPosX == null) tableGroupPosXTextBox.Text = "";
                else tableGroupPosXTextBox.Text = Convert.ToString(tableGroup.TableGroupPosX);
                if (tableGroup.TableGroupPosY == null) tableGroupPosYTextBox.Text = "";
                else tableGroupPosYTextBox.Text = Convert.ToString(tableGroup.TableGroupPosY);

                //Are there any tables in the tableGroup?
                if(tableInGroupTableIds.Count>0)
                {
                    source.DataSource = tableInGroupTables;
                    tableInGroupDataGridView.DataSource = source;
                    tableInGroupDataGridView.Visible = true;
                    btnDeleteTable.Enabled = true;
                    btnUpdateTable.Enabled = true;
                }
                else
                {
                    tableInGroupDataGridView.Visible = false;
                    btnDeleteTable.Enabled = false;
                    btnUpdateTable.Enabled = false;
                }

                //Disable the Delete and Add button, if the tablegroup is in use
                if (tableInGroupInUse==true)
                {
                    btnDeleteTable.Enabled = false;
                    btnAddTable.Enabled = false;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData()) // validation for both Add  and Edit
            {
                if (IsAdd)
                {
                    // Create a new tablegroup
                    tableGroup = new TableGroup();// txtCode.Text,txtDescription.Text, Convert.ToDecimal(txtPrice.Text));
                    //Update the tablegroup attributes
                    tableGroup.LayoutID = layoutId;
                    tableGroup.TableGroupName = tableGroupNameTextBox.Text;
                    tableGroup.TableGroupActive = tableGroupActiveCheckBox.Checked;
                    if (tableGroupPriorityTextBox.Text == "") tableGroup.TableGroupPriority = null;
                    else tableGroup.TableGroupPriority = Convert.ToInt32(tableGroupPriorityTextBox.Text);
                    if (tableGroupImageTextBox.Text == "") tableGroup.TableGroupImage = null;
                    else tableGroup.TableGroupImage = tableGroupImageTextBox.Text;
                    if (tableGroupPosXTextBox.Text == "") tableGroup.TableGroupPosX = null;
                    else tableGroup.TableGroupPosX = Convert.ToDecimal(tableGroupPosXTextBox.Text);
                    if (tableGroupPosYTextBox.Text == "") tableGroup.TableGroupPosY = null;
                    else tableGroup.TableGroupPosY = Convert.ToDecimal(tableGroupPosYTextBox.Text);
                    //Confirm entry
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                else // edit
                {
                    //Update the tablegroup attributes
                    tableGroup.TableGroupName = tableGroupNameTextBox.Text;
                    tableGroup.TableGroupActive = tableGroupActiveCheckBox.Checked;
                    if (tableGroupPriorityTextBox.Text == "") tableGroup.TableGroupPriority = null;
                    else tableGroup.TableGroupPriority = Convert.ToInt32(tableGroupPriorityTextBox.Text);
                    if (tableGroupPosXTextBox.Text == "") tableGroup.TableGroupPosX = null;
                    else tableGroup.TableGroupPosX = Convert.ToDecimal(tableGroupPosXTextBox.Text);
                    if (tableGroupPosYTextBox.Text == "") tableGroup.TableGroupPosY = null;
                    else tableGroup.TableGroupPosY = Convert.ToDecimal(tableGroupPosYTextBox.Text);
                    //Confirm entry
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        //Validation Method
        private bool IsValidData()
        {
            bool priority;
            bool posx;
            bool posy;
            bool active;

            if (tableGroupActiveCheckBox.Checked == true || tableGroupActiveCheckBox.Checked == false) active = true;
            else
            {
                active = false;
                MessageBox.Show(" The Table Group Active must be provided");
                tableGroupActiveCheckBox.Focus();
            }

            if (tableGroupPriorityTextBox.Text == "") priority = true;
            else if (Validator.IsNonNegativeInt(tableGroupPriorityTextBox,"Table Group Priority")) priority = true;
            else priority = false;

            if (tableGroupPosXTextBox.Text == "") posx = true;
            else if (Validator.IsNonNegativeDecimal(tableGroupPosXTextBox, "Table Group Position X")) posx = true;
            else posx = false;

            if (tableGroupPosYTextBox.Text == "") posy = true;
            else if (Validator.IsNonNegativeDecimal(tableGroupPosYTextBox, "Table Group Position Y")) posy = true;
            else posy = false;

            return Validator.IsProvided(tableGroupNameTextBox, "Table Group Name") && priority&& posx && posy & active;
        }

        // Get new table Group 
        public TableGroup GetNewTableGroup()
        {
            this.ShowDialog();// second form displays itself
            return tableGroup;
        }
        //Update the tableInGroupTable
        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            //New form to Add a tableInGroupTable
            frmTableInTableGroupUpdate thirdForm = new frmTableInTableGroupUpdate();

            // Edit, not Add
            thirdForm.IsAdd = false; 
                                    
            //Choode the tableInGroupTable to be Updated
            thirdForm.tableInGroupTable = (TableInGroup)tableInGroupTables[tableInGroupDataGridView.CurrentCell.RowIndex]; // this is reference to the product to edit
             
            //Identify the restaurant Id and pass to the other form
            thirdForm.restaurantId = restaurantId;
           
            //Identify the layout Id and pass to the other form
            thirdForm.layoutId = layoutId;
            
            //Restaurant Tables
            thirdForm.restTables = restTables;
            
            //Restaurant tableIds
            thirdForm.restTableIds = restTableIds;                                          
            
            //Available tables
            thirdForm.availableTables = availableTables;
            
            //tableInGroupTableIds
            thirdForm.tableInGroupTableIds = tableInGroupTableIds;

            DialogResult result = thirdForm.ShowDialog(); // show third as dialog (modal)

  
           if (result == DialogResult.OK)
            {
               MessageBox.Show("Successful Update ");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            //Set  tableGroupId = -1, when new tableGroup
            if (tableGroup == null) tableGroupId = -1;
            else tableGroupId = tableGroup.TableGroupID;
                
           frmTableInTableGroupUpdate newTableForm = new frmTableInTableGroupUpdate();
            //ADD, not Edit
            newTableForm.IsAdd = true;

            //Identify the restaurant Id and pass to the other form
            newTableForm.restaurantId = restaurantId;

            //Identify the layout Id and pass to the other form
            newTableForm.layoutId = layoutId;

            //Restaurant Tables
            newTableForm.restTables = restTables;

            //Restaurant tableIds
            newTableForm.restTableIds = restTableIds;

            //Available tables
            newTableForm.availableTables = availableTables;

            //tableGroupId
            newTableForm.tableGroupId = tableGroupId;

            //tableInGroupTableIds
            newTableForm.tableInGroupTableIds = tableInGroupTableIds;
            
            //New tableInGroupTable
            TableInGroup tableInGroupTable = newTableForm.GetNewTableInGroup();

            if (tableInGroupTable != null)
            {
                if(tableGroup!=null)
                {
                    tableInGroupTable.TableGroupID = tableGroup.TableGroupID;

                    //Find index 
                    int indexTIG = tableInGroupTableIds.FindIndex(j => j == tableInGroupTable.TableID);
                    if(indexTIG>=0)
                    {
                        //Update the tableStatus if the table is in tableInGroupTableIds
                        tableInGroupTableStatus[indexTIG] = 1;
                    }
                    else
                    {
                        //Add tableInTableGroupTable to  tableInTableGroupTable and set status, if not
                        tableInGroupTables.Add(tableInGroupTable);
                        tableInGroupTableIds.Add(tableInGroupTable.TableID);
                        tableInGroupTableStatus.Add(1);

                    }
                    //Update local lists
                    local_tableInGroupTables.Add(tableInGroupTable);
                    local_tableInGroupTableIds.Add(tableInGroupTable.TableID);
                   
             
                    //Update availableTables
                    availableTables.Remove(tableInGroupTable.TableID);

                    //Update user interface
                    if (local_tableInGroupTables.Count == 1)
                    {
                        source.DataSource = local_tableInGroupTables;
                        tableInGroupDataGridView.DataSource = source;
                        tableInGroupDataGridView.Visible = true;
                        btnDeleteTable.Enabled = true;
                        btnUpdateTable.Enabled = true;
                    }
                    
                    MessageBox.Show("New Table Added");
                    source.ResetBindings(false);
                    tableInGroupDataGridView.Visible = true;
                    //btnDeleteTable.Enabled = true;
                    btnAddTable.Enabled = true;
                   }
                else
                {
                    //Inititialize tables
                    if (tableInGroupTables == null)
                    {
                        tableInGroupTables = new List<TableInGroup>();
                        local_tableInGroupTables = new List<TableInGroup>();
                    }
                    if (tableInGroupTableIds == null)
                    {
                        tableInGroupTableIds = new List<int>();
                        tableInGroupTableStatus = new List<int>();
                    }
                    //Find index
                    int indexTIG = tableInGroupTableIds.FindIndex(j => j == tableInGroupTable.TableID);
                    if (indexTIG >= 0)
                    {
                        //Update the tableStatus if the table is in tableInGroupTableIds
                        tableInGroupTableStatus[indexTIG] = 1;
                    }
                    else
                    {
                        //Add tableInTableGroupTable to  tableInTableGroupTable and set status, if not
                        tableInGroupTables.Add(tableInGroupTable);
                        tableInGroupTableIds.Add(tableInGroupTable.TableID);
                        tableInGroupTableStatus.Add(1);

                    }
                    //Update local lists
                    local_tableInGroupTables.Add(tableInGroupTable);
                    local_tableInGroupTableIds.Add(tableInGroupTable.TableID);
                    //Update availableTables
                    availableTables.Remove(tableInGroupTable.TableID);
                    //Update user interface
                    if (local_tableInGroupTables.Count == 1)
                    {
                        source.DataSource = local_tableInGroupTables;
                        tableInGroupDataGridView.DataSource = source;
                        tableInGroupDataGridView.Visible = true;
                        btnUpdateTable.Enabled = true;
                        if (tableInGroupInUse == false)
                        {
                            btnDeleteTable.Enabled = true;
                            btnAddTable.Enabled = true;
                        }
                    }
                    else
                    {
                        source.ResetBindings(false);
                    }
                }
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            //Error Message
            string message;
            //Select tableInGroupTable to be deleted
            TableInGroup tableInGroupTableDel = (TableInGroup)tableInGroupTables[tableInGroupDataGridView.CurrentCell.RowIndex];
            //Verify if table is in use
            if (tableInGroupInUse)
            {
                //if tableGroup is in use, it cannot be deleted 
                message = "Table Group ID " + Convert.ToString(tableGroup.TableGroupID) + " Name: " + tableGroup.TableGroupName + "cannot be deleted beacuse it is in use";
                MessageBox.Show(message, "Delete is not possible");
            }
            else
            {
                //Confirm Delete
                message = "Are you sure you want to delete Table ID"
                + tableInGroupTableDel.TableID + " from table Group?";
                DialogResult button =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    //Update local lists
                    local_tableInGroupTables.Remove(tableInGroupTableDel);
                    local_tableInGroupTableIds.Remove(tableInGroupTableDel.TableID);
                    //Find index
                    int indexTIG = tableInGroupTableIds.FindIndex(j => j == tableInGroupTableDel.TableID);
                    if (indexTIG >= 0)
                    {
                        //Update the tableStatus if the table is in tableInGroupTableIds
                        tableInGroupTableStatus[indexTIG] = -1;
                    }

                    //if TableId is active
                    int indexTIG1 = restTables.FindIndex(j => j.TableID == tableInGroupTableDel.TableID);
                    if(restTables[indexTIG1].TableActive==true)
                    {
                        //Update availableTables
                        availableTables.Add(tableInGroupTableDel.TableID);
                    }

                    //Update users interface
                    source.DataSource = local_tableInGroupTables;
                    source.ResetBindings(false);
                    if (local_tableInGroupTables.Count > 0)
                    {
                        
                        tableInGroupDataGridView.Visible = true;
                        btnUpdateTable.Enabled = true;
                        if (tableInGroupInUse == false)
                        {
                            btnDeleteTable.Enabled = true;
                            btnAddTable.Enabled = true;
                        }

                    }
                    else
                    {
                        btnDeleteTable.Enabled = false;
                        btnUpdateTable.Enabled = false;
                        btnAddTable.Enabled = true;
                        tableInGroupDataGridView.Visible = false;

                    }
                    MessageBox.Show("Table Group Deleted ");
                }
            }
        }
    }
}
