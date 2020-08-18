using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableReadyADO
{
    //Ehsans Part
    public partial class frmTableUpdate : Form
    {
        //Public Variables
        public bool IsAdd; // Distinguishes Add from Edit; main form sets it
        public Table table; // Table object
        public int restaurantId; // Restauraunt ID
        public int tableId;
        public string tableName; // Table Name
        public int tableMaxNumberSeats; // Max Number Seats
        public string tableImage = null; // Table Image
        public string tableImageAvailable = null; // Table Image Available
        public string tableImageUnavailable = null; // Table Image Unavialble
        public string tableImageCheckOut = null; // Table Image Checkout
        public string tableImageCleaning = null; // Table Image Cleaning
        public string tableType = null; // Table Type
        public string tableSize = null; // Table Size
        public DateTime creationDate; // Creation Date
        public bool tableActive; // Table Active
        public int? floor = null;
        TableReadyEntities2 db = new TableReadyEntities2();//object context


        public frmTableUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Upon upload populate the combobox and date, if update then populate the selected table info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTableUpdate_Load(object sender, EventArgs e)
        {
            DisplayRestaurantID();
            if (IsAdd)
            {
                creationDate = DateTime.Today;
                TU_creationDateTextBox.Text = creationDate.ToString();
            }
            else
            {
                var restaurant = db.Restaurants.SingleOrDefault(rest => rest.RestaurantId == restaurantId);

                TU_restaurantIdComboBox.Text = restaurantId.ToString();
                TU_restaurantNameTextBox.Text = restaurant.RestaurantName;
                TU_tableIDTextBox.Text = tableId.ToString();
                TU_tableNameTextBox.Text = tableName;
                TU_tableSizeTextBox.Text = tableSize;
                TU_tableTypeTextBox.Text = tableType;
                TU_tableActiveCheckBox.Checked = tableActive;
                TU_tableImageTextBox.Text = tableImage;
                TU_tableImageAvailableTextBox.Text = tableImageAvailable;
                TU_tableImageUnavailableTextBox.Text = tableImageUnavailable;
                TU_tableImageCheckoutTextBox.Text = tableImageCheckOut;
                TU_tableImageCleaningTextBox.Text = tableImageCleaning;
                TU_tableMaxNumberSeatsTextBox.Text = tableMaxNumberSeats.ToString();
                TU_creationDateTextBox.Text = creationDate.ToString();
               
            }

        }
        /// <summary>
        /// Display Rest ID
        /// </summary>
        private void DisplayRestaurantID()
        {

            var restID = db.Restaurants.Select(a => a.RestaurantId).ToList();//execute LINQ query

            TU_restaurantIdComboBox.DataSource = restID;
        }

        /// <summary>
        /// Rest ID Combo box change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TU_restaurantIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            restaurantId = (int)TU_restaurantIdComboBox.SelectedValue;

            var restaurant = db.Restaurants.SingleOrDefault(rest => rest.RestaurantId == restaurantId);

            TU_restaurantNameTextBox.Text = restaurant.RestaurantName;

        }

        /// <summary>
        /// Cancel Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // close this form
        }

        /// <summary>
        /// Validate all of the entered information, if approved, save new table to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {

            }
            if (TU_tableSizeTextBox.Text != "")
                tableSize = TU_tableNameTextBox.Text;
            if (TU_tableTypeTextBox.Text != "")
                tableType = TU_tableTypeTextBox.Text;

            if (TU_tableActiveCheckBox.Checked == true)
                tableActive = true;
            else
                tableActive = false;

            if (TU_tableImageTextBox.Text.Length < 100)
                tableImage = TU_tableImageTextBox.Text;
            if (TU_tableImageAvailableTextBox.Text.Length < 100)
                tableImageAvailable = TU_tableImageAvailableTextBox.Text;
            if (TU_tableImageCheckoutTextBox.Text.Length < 100)
                tableImageCheckOut = TU_tableImageCheckoutTextBox.Text;
            if (TU_tableImageCleaningTextBox.Text.Length < 100)
                tableImageCleaning = TU_tableImageCleaningTextBox.Text;
            if (TU_tableImageUnavailableTextBox.Text.Length < 100)
                tableImageUnavailable = TU_tableImageUnavailableTextBox.Text;


            if (TU_tableNameTextBox.Text != "")
            {
                if (TU_tableNameTextBox.Text.Length <= 10) tableName = TU_tableNameTextBox.Text;
                else MessageBox.Show("Table Name too long. Please Revise under 10 characters!", "Table Name");

                if (Validator.IsProvided(TU_tableMaxNumberSeatsTextBox, "Table Max Seats")
                && Validator.IsNonNegativeInt(TU_tableMaxNumberSeatsTextBox, "Table Max Seats"))
                {
                    tableMaxNumberSeats = Convert.ToInt32(TU_tableMaxNumberSeatsTextBox.Text);

                    if (IsAdd)
                    {
                        table = new Table
                        {
                            RestaurantID = restaurantId,
                            TableName = tableName,
                            CreationDate = creationDate,
                            TableSize = tableSize,
                            TableType = tableType,
                            TableActive = tableActive,
                            TableImage = tableImage,
                            TableImageAvailable = tableImageAvailable,
                            TableImageCheckout = tableImageCheckOut,
                            TableImageCleaning = tableImageCleaning,
                            TableImageUnavailable = tableImageUnavailable,
                            TableMaxNumberSeats = tableMaxNumberSeats
                        };

                        try
                        {
                            db.Tables.Add(table);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving to the DB!" + ex.GetType().ToString());
                        }
                        
                    }
                    else
                    {
                        var context = ((IObjectContextAdapter)db).ObjectContext;
                        var result = db.Tables.SingleOrDefault(a => a.TableID == tableId);

                        result.RestaurantID = restaurantId;
                        result.TableMaxNumberSeats = tableMaxNumberSeats;
                        result.TableImage = tableImage;
                        result.TableName = tableName;
                        result.TableImageAvailable = tableImageAvailable;
                        result.TableImageUnavailable = tableImageUnavailable;
                        result.TableImageCheckout = tableImageCheckOut;
                        result.TableImageCleaning = tableImageCleaning;
                        result.TableType = tableType;
                        result.TableSize = tableSize;
                        result.CreationDate = DateTime.Today;
                        result.TableActive = tableActive;


                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving to the DB!" + ex.GetType().ToString());
                        }
                    }
                    

                    this.DialogResult = DialogResult.OK;
                }
            }
            else MessageBox.Show("Table Name cannot be empty!", "Table Name");
        }
    }
}
