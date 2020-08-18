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
    public partial class frmRestaurantUpdate : Form
    {
        //Khurrams Part - had to be completed by Ehsan (I have marked my contributions)
        TableReadyEntities2 db = new TableReadyEntities2(); //Context
        public bool isAdd; //is add boolean
        public Restaurant Restaurant; //Restauraunt Object
        public int restaurantId; //Rest ID
        public string restaurantName; //Rest Name
        public int layoutActive; //Active Layout

        public frmRestaurantUpdate()
        {
            InitializeComponent();
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // close this form
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Accept button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Needed to be revised by Ehsan for method to be functioning as required
            if (isAdd) // added
            {
                Restaurant = new Restaurant
                {
                    RestaurantName = RU_restaurantNameTextBox.Text,
                };

                try //added
                {
                    db.Restaurants.Add(Restaurant);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving to the DB!" + ex.GetType().ToString());
                }
            }
            else //Update section added by Ehsan
            {
                var context = ((IObjectContextAdapter)db).ObjectContext;
                var result = db.Restaurants.SingleOrDefault(a => a.RestaurantId == restaurantId);

                result.RestaurantName = restaurantName;
                if (RU_layoutActiveComboBox.Enabled==true)
                {
                    result.LayoutActive = (int)RU_layoutActiveComboBox.SelectedValue;
                }
                

                try 
                {
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving to the DB!" + ex.GetType().ToString());
                }
            }

        }

        /// <summary>
        /// Display layout ID
        /// </summary>
        private void DisplayLayoutID(int restId)
        {
            var layID = db.Layouts.Where(a => a.RestaurantID==restId).ToList();//execute query


            
            if (layID.Count()==0)
            {
                RU_layoutActiveComboBox.Enabled = false;
                RU_layoutActiveComboBox.Text = "";
             }
            else
            {
                RU_layoutActiveComboBox.Enabled = true;
                List<int> layouts = new List<int>();
                foreach (Layout lay in layID)
                    layouts.Add(lay.LayoutId);
                RU_layoutActiveComboBox.DataSource = layouts;
                RU_layoutActiveComboBox.Text = layoutActive.ToString();

            }
            
        }


        // Added by Ehsan

        /// <summary>
        /// Update button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRestaurantUpdate_Load(object sender, EventArgs e)
        {
            if (!isAdd) 
            {
                DisplayLayoutID(restaurantId);

                
                RU_restaurantIdTextBox.Text = restaurantId.ToString();
                RU_restaurantNameTextBox.Text = restaurantName;
                RU_restaurantNameTextBox.Focus();
                
                
            }
            else
            {
                RU_restaurantNameTextBox.Focus();
                RU_layoutActiveComboBox.Enabled = false;
                //DisplayLayoutID();
            }
        }


    }
}
