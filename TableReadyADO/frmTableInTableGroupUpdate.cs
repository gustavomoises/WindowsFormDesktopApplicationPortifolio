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
    public partial class frmTableInTableGroupUpdate : Form
    {

        public bool IsAdd;// distinguishes Add from Edit; main form sets it
        public List<int> tableInGroupTableIds = null;
        public TableInGroup tableInGroupTable = null;
        public List<Table> restTables = null;
        public List<int> restTableIds = null;
        public List<int>  availableTables = null;
        public int layoutId;
        public int restaurantId;
        public int tableGroupId;
        public frmTableInTableGroupUpdate()
        {
            InitializeComponent();
        }
        //Get New tableInGroupTable
        public TableInGroup GetNewTableInGroup()
        {
            this.ShowDialog();// second form displays itself
            return tableInGroupTable;
        }
        //Cancel button - close form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // close this form
        }
        //Upload data when form is loaded
        private void frmTableInTableGroupUpdate_Load(object sender, EventArgs e)
        {
            //Show restauranId
            restaurantIDTextBox.Text = Convert.ToString(restaurantId);
            //Show LayoutID
            layoutIDTextBox.Text = Convert.ToString(layoutId);
            //Show tableGroupID
            if (tableGroupId == -1) tableGroupIDTextBox.Text = "";
            else tableGroupIDTextBox.Text = Convert.ToString(tableGroupId);
            //ADD selected
            if (IsAdd)// adding new product
            {
                //Update User interface
                tableIDComboBox.Visible = true;
                tableIDComboBox.DataSource = availableTables;
                tableIDComboBox.Visible = true;

                if (availableTables.Count > 0)
                {
                    
                    tableIDComboBox.SelectedIndex = 0;
                    tableIDTextBox.Text = availableTables[tableIDComboBox.SelectedIndex].ToString();
                    //Show atributes of the table available selected
                    Table auxTable = new Table();
                    auxTable = restTables.Find(i => i.TableID == availableTables[tableIDComboBox.SelectedIndex]);

                    if (auxTable.TableImage == null) tableImageTextBox.Text = "";
                    else tableImageTextBox.Text = auxTable.TableImage;

                    if (auxTable.TableImageAvailable == null) tableImageAvailableTextBox.Text = "";
                    else tableImageAvailableTextBox.Text = auxTable.TableImageAvailable;

                    if (auxTable.TableImageUnavailable == null) tableImageUnavailableTextBox.Text = "";
                    else tableImageUnavailableTextBox.Text = auxTable.TableImageUnavailable;

                    if (auxTable.TableImageCheckout == null) tableImageCheckoutTextBox.Text = "";
                    else tableImageCheckoutTextBox.Text = auxTable.TableImageCheckout;

                    if (auxTable.TableImageCleaning == null) tableImageCleaningTextBox.Text = "";
                    else tableImageCleaningTextBox.Text = auxTable.TableImageCleaning;

                    tableNameTextBox.Text = auxTable.TableName;
                    tableMaxNumberSeatsTextBox.Text = Convert.ToString(auxTable.TableMaxNumberSeats);

                    if (auxTable.TableSize == null) tableSizeTextBox.Text = "";
                    else tableSizeTextBox.Text = auxTable.TableSize;

                    if (auxTable.TableType == null) tableTypeTextBox.Text = "";
                    else tableTypeTextBox.Text = auxTable.TableType;

                    creationDateTextBox.Text = auxTable.CreationDate.ToString("MM/dd/yy");
                }
                else
                {
                    //If there are no tables available
                    tableIDTextBox.Text = "";
                    tableImageTextBox.Text = "";
                    tableImageAvailableTextBox.Text = "";
                    tableImageUnavailableTextBox.Text = "";
                    tableImageCheckoutTextBox.Text = "";
                    tableImageCleaningTextBox.Text = "";
                    tableNameTextBox.Text = "";
                    tableMaxNumberSeatsTextBox.Text = "";
                    tableSizeTextBox.Text = "";
                    tableTypeTextBox.Text = "";
                    creationDateTextBox.Text = "";
                }

                this.Text = "Add New Product";
            }
            else // edit
            {
                //Update user interface
                tableIDComboBox.Visible = false;
                this.Text = "Edit Product";

                //// display data of the current tableinGroupTable
                tableGroupIDTextBox.Text = Convert.ToString(tableInGroupTable.TableGroupID);

                tableIDTextBox.Text = Convert.ToString(tableInGroupTable.TableID);
                tableIDComboBox.Visible = false;
                maxTableSeatNumberTextBox.Text = Convert.ToString(tableInGroupTable.MaxTableSeatNumber);

                if (tableInGroupTable.RestaurantArea == null) restaurantAreaTextBox.Text = "";
                else restaurantAreaTextBox.Text = tableInGroupTable.RestaurantArea;

                if (tableInGroupTable.RestaurantZone == null) restaurantZoneTextBox.Text = "";
                else restaurantZoneTextBox.Text = tableInGroupTable.RestaurantZone;

                if (tableInGroupTable.RestaurantFloor == null) restaurantFloorTextBox.Text = "";
                else restaurantFloorTextBox.Text = Convert.ToString(tableInGroupTable.RestaurantFloor);

                if (tableInGroupTable.TablePosX  == null) tablePosXTextBox.Text = "";
                else tablePosXTextBox.Text = Convert.ToString(tableInGroupTable.TablePosX);

                if (tableInGroupTable.TablePosY == null) tablePosYTextBox.Text = "";
                else tablePosYTextBox.Text = Convert.ToString(tableInGroupTable.TablePosY);


                //Table associated to tableInGroupTable.TableID
                Table auxTable = new Table();
                auxTable = restTables.Find(i => i.TableID == tableInGroupTable.TableID);

                //Show atributes of the table
                if (auxTable.TableImage == null) tableImageTextBox.Text = "";
                else tableImageTextBox.Text = auxTable.TableImage;

                if (auxTable.TableImageAvailable == null) tableImageAvailableTextBox.Text = "";
                else tableImageAvailableTextBox.Text = auxTable.TableImageAvailable;

                if (auxTable.TableImageUnavailable == null) tableImageUnavailableTextBox.Text = "";
                else tableImageUnavailableTextBox.Text = auxTable.TableImageUnavailable;

                if (auxTable.TableImageCheckout == null) tableImageCheckoutTextBox.Text = "";
                else tableImageCheckoutTextBox.Text = auxTable.TableImageCheckout;

                if (auxTable.TableImageCleaning == null) tableImageCleaningTextBox.Text = "";
                else tableImageCleaningTextBox.Text = auxTable.TableImageCleaning;

                tableNameTextBox.Text = auxTable.TableName;
                tableMaxNumberSeatsTextBox.Text = Convert.ToString(auxTable.TableMaxNumberSeats);

                if (auxTable.TableSize == null) tableSizeTextBox.Text = "";
                else tableSizeTextBox.Text = auxTable.TableSize;

                if (auxTable.TableType == null) tableTypeTextBox.Text = "";
                else tableTypeTextBox.Text = auxTable.TableType;

                creationDateTextBox.Text = auxTable.CreationDate.ToString("MM/dd/yy");

            }
        }

        private void tableIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableIDTextBox.Text = availableTables[tableIDComboBox.SelectedIndex].ToString();
            tableIDComboBox.Visible = true;

            Table auxTable = new Table();

            auxTable = restTables.Find(i => i.TableID == availableTables[tableIDComboBox.SelectedIndex]);
            
            //Show atributes of the table available selected

            if (auxTable.TableImage == null) tableImageTextBox.Text = "";
            else tableImageTextBox.Text = auxTable.TableImage;

            if (auxTable.TableImageAvailable == null) tableImageAvailableTextBox.Text = "";
            else tableImageAvailableTextBox.Text = auxTable.TableImageAvailable;

            if (auxTable.TableImageUnavailable == null) tableImageUnavailableTextBox.Text = "";
            else tableImageUnavailableTextBox.Text = auxTable.TableImageUnavailable;

            if (auxTable.TableImageCheckout == null) tableImageCheckoutTextBox.Text = "";
            else tableImageCheckoutTextBox.Text = auxTable.TableImageCheckout;

            if (auxTable.TableImageCleaning == null) tableImageCleaningTextBox.Text = "";
            else tableImageCleaningTextBox.Text = auxTable.TableImageCleaning;

            tableNameTextBox.Text = auxTable.TableName;
            tableMaxNumberSeatsTextBox.Text = Convert.ToString(auxTable.TableMaxNumberSeats);

            if (auxTable.TableSize == null) tableSizeTextBox.Text = "";
            else tableSizeTextBox.Text = auxTable.TableSize;

            if (auxTable.TableType == null) tableTypeTextBox.Text = "";
            else tableTypeTextBox.Text = auxTable.TableType;

            creationDateTextBox.Text = auxTable.CreationDate.ToString("MM/dd/yy");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Validate the Date
            if (IsValidData()) // validation for both Add  and Edit
            {
                //ADD
                if (IsAdd)
                {
                    //set the attributes of the new tableInGroupTable
                    tableInGroupTable= new TableInGroup ();
                    tableInGroupTable.TableGroupID = tableGroupId;

                    tableInGroupTable.TableID = Convert.ToInt32(tableIDTextBox.Text);
                    tableInGroupTable.MaxTableSeatNumber = Convert.ToInt32(maxTableSeatNumberTextBox.Text);

                    if (tablePosXTextBox.Text == "") tableInGroupTable.TablePosX = null;
                    else tableInGroupTable.TablePosX = Convert.ToDecimal(tablePosXTextBox.Text);
                    if (tablePosYTextBox.Text == "") tableInGroupTable.TablePosY = null;
                    else tableInGroupTable.TablePosY = Convert.ToDecimal(tablePosYTextBox.Text);

                    if (restaurantAreaTextBox.Text == "") tableInGroupTable.RestaurantArea = null;
                    else tableInGroupTable.RestaurantArea = restaurantAreaTextBox.Text;

                    if (restaurantZoneTextBox.Text == "") tableInGroupTable.RestaurantZone = null;
                    else tableInGroupTable.RestaurantZone = restaurantZoneTextBox.Text;

                    if (restaurantFloorTextBox.Text == "") tableInGroupTable.RestaurantFloor = null;
                    else tableInGroupTable.RestaurantFloor = Convert.ToInt32(restaurantFloorTextBox.Text);

                    //Confirmation Dialog
                    
                    this.DialogResult = DialogResult.OK;
                        this.Close();
                    
                }
                else // edit
                {
                    //update the attributes of the new tableInGroupTable
                    tableInGroupTable.MaxTableSeatNumber = Convert.ToInt32(maxTableSeatNumberTextBox.Text);
                    if (tablePosXTextBox.Text == "") tableInGroupTable.TablePosX = null;
                    else tableInGroupTable.TablePosX = Convert.ToDecimal(tablePosXTextBox.Text);
                    if (tablePosYTextBox.Text == "") tableInGroupTable.TablePosY = null;
                    else tableInGroupTable.TablePosY = Convert.ToDecimal(tablePosYTextBox.Text);
                    if (restaurantAreaTextBox.Text == "") tableInGroupTable.RestaurantArea = null;
                    else tableInGroupTable.RestaurantArea = restaurantAreaTextBox.Text;

                    if (restaurantZoneTextBox.Text == "") tableInGroupTable.RestaurantZone = null;
                    else tableInGroupTable.RestaurantZone = restaurantZoneTextBox.Text;

                    if (restaurantFloorTextBox.Text == "") tableInGroupTable.RestaurantFloor = null;
                    else tableInGroupTable.RestaurantFloor = Convert.ToInt32(restaurantFloorTextBox.Text);

                    //Confirmation Dialog
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        //Validates the data entrance
        private bool IsValidData()
        {
            bool floor;
            bool posx;
            bool posy;
            bool maxseat;
            if(Validator.IsNonNegativeInt(maxTableSeatNumberTextBox, "Max Table Seat Number"))
            { 
                if (Convert.ToInt32(maxTableSeatNumberTextBox.Text) > Convert.ToInt32(tableMaxNumberSeatsTextBox.Text))
                {
                    MessageBox.Show("Table Seat # in Group  must be less or equal to the table Max # of Seats");
                    maxTableSeatNumberTextBox.SelectAll();
                    maxTableSeatNumberTextBox.Focus();
                    maxseat = false;
                }
                else maxseat = true;
            }
            else maxseat = false;


            if (restaurantFloorTextBox.Text == "") floor = true;
            else if (Validator.IsNonNegativeInt(restaurantFloorTextBox, "Restaurant Floor")) floor = true;
            else floor = false;

            if (tablePosXTextBox.Text == "") posx = true;
            else if (Validator.IsNonNegativeDecimal(tablePosXTextBox, "Table Position X")) posx = true;
            else posx = false;

            if (tablePosYTextBox.Text == "") posy = true;
            else if (Validator.IsNonNegativeDecimal(tablePosYTextBox, "Table Position Y")) posy = true;
            else posy = false;

            return  maxseat && floor && posx && posy;
        }
    }
}
