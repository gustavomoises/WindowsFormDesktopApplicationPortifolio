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
    public partial class frmLayoutUpdate : Form
    {
        public bool isAdd; //is add
        public int layoutId; //layout id
        public int restId; //rest id
        public string layoutName; //layout name
        public string restName; //rest name
        public string layoutImage; //layout image
        TableReadyEntities2 db = new TableReadyEntities2();
        Layout layout; //layout object

        public frmLayoutUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Upon load populate combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLayoutUpdate_Load(object sender, EventArgs e)
        {
            LU_restaurantIDComboBox.DataSource = db.Restaurants.Select(a => a.RestaurantId).ToList();

            if (!isAdd)
            {
                LU_IdTextBox.Text = layoutId.ToString();
                LU_restaurantIDComboBox.Text = restId.ToString();
                restName = db.Restaurants.SingleOrDefault(a => a.RestaurantId == restId).RestaurantName.ToString();
                LU_restaurantNameTextBox.Text = restName;
                LU_layoutNameTextBox.Text = layoutName;
                LU_layoutImageTextBox.Text = layoutImage;
            }
        }

        /// <summary>
        /// Add button code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLayoutUpdate_Click(object sender, EventArgs e)
        {
            if (Validator.IsProvided(LU_layoutNameTextBox, "Layout Name"))
            {
                if (LU_layoutNameTextBox.Text.Length < 20)
                {
                    layoutName = LU_layoutNameTextBox.Text;

                    if (LU_layoutImageTextBox.Text.Length < 200)
                    {
                        layoutImage = LU_layoutImageTextBox.Text;

                        if (isAdd)
                        {
                            layout = new Layout
                            {
                                RestaurantID = restId,
                                LayoutName = layoutName,
                                LayoutImage = layoutImage
                            };

                            try
                            {
                                db.Layouts.Add(layout);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Saving to the DB!" + ex.GetType().ToString());
                            }
                            
                        }
                        else
                        {
                            var context = ((IObjectContextAdapter)db).ObjectContext;
                            var result = db.Layouts.SingleOrDefault(a => a.LayoutId == layoutId);

                            result.RestaurantID = restId;
                            result.LayoutName = layoutName;
                            result.LayoutImage = layoutImage;

                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Saving to the DB!" + ex.GetType().ToString());
                            }
                            
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Layout image cannot be over 200 characters, please revise!");
                    }
                }
                else
                {
                    MessageBox.Show("Layout name cannot be higher than 20 characters. Please revise!");
                }
            }
        }

        /// <summary>
        /// Rest ID Combo box change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LU_restaurantIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            restId = Convert.ToInt32(LU_restaurantIDComboBox.SelectedValue);
            LU_restaurantNameTextBox.Text = db.Restaurants.SingleOrDefault(a => a.RestaurantId == restId).RestaurantName;
        }
        

        private void btnCancelLayoutUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // close this form
        }
    }
}
