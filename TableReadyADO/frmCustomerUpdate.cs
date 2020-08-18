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
    // Code completed by Jessy
    public partial class frmCustomerUpdate : Form
    {

        //This code was commented out because our database was updated to include the authentication
        //of the second workshop and this functionality was not available anymore because customers require
        //a user ID which is created in the user entity which is tied to the registration page in our workshop #2.
        //We were not able to come back to edit this part so we decided to remove this functionality.





        //public bool IsAdd;// distinguishes Add from Edit; main form sets it
        //public Customer cust;
        //public int customerId;
        //public string custFirstName;
        //public string custLastName;
        //public List<Customer> lstCustomers = null;
        //TableReadyEntities2 db = new TableReadyEntities2();




        public frmCustomerUpdate()
        {
            InitializeComponent();
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close(); // close this form
        //}

        //    private void btnAccept_Click(object sender, EventArgs e)
        //{
            

            //if (IsAdd == true)
            //{
            //    if (Validator.IsProvided(customerFirstNameTextBox, "Customer First Name") &&
            //    Validator.IsProvided(customerLastNameTextBox, "Customer Last Name"))
            //    {
            //        db = new TableReadyEntities1();
            //        var customer = new Customer()
            //        {
            //            CustomerFirstName = customerFirstNameTextBox.Text,
            //            CustomerLastName = customerLastNameTextBox.Text
            //        };
            //        db.Customers.Add(customer);
            //        db.SaveChanges();
            //        this.DialogResult = DialogResult.OK;
            //        RefreshAll();
            //        Close();
            //    }
            //}

//            if (IsAdd == false)
//            {
//                using (var db = new TableReadyEntities2())
//                {
//                    int cID = Convert.ToInt32(customerIDTextBox.Text);
//                    var result = db.Customers.SingleOrDefault
//                        (row => row.CustomerID == (int)cID);
//                    if (Validator.IsProvided(customerFirstNameTextBox, "Customer First Name") &&
//                        Validator.IsProvided(customerLastNameTextBox, "Customer Last Name"))
//                    {
//                        var context = ((IObjectContextAdapter)db).ObjectContext;
//                        result.CustomerFirstName = customerFirstNameTextBox.Text;
//                        result.CustomerLastName = customerLastNameTextBox.Text;
//                        db.SaveChanges();
//                        Close();
//                    }
//                }
//            }

//        }

//        private void frmCustomerUpdate_Load(object sender, EventArgs e)
//        {
//            if (IsAdd == false)
//            {
//                btnAccept.Text = "Save";
//                customerIDTextBox.Text = Convert.ToString(customerId);
//                customerFirstNameTextBox.Text = custFirstName;
//                customerLastNameTextBox.Text = custLastName;
//            }
//            else
//            {
//                btnAccept.Text = "Add";
//            }
//        }

//        public void RefreshAll()
//        {
//            foreach (var entity in db.ChangeTracker.Entries())
//            {
//                entity.Reload();
//            }
//        }
    }
}
