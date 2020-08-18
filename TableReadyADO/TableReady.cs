//Author:Gustavo Lourenco Moises
//Date:7/18/2020
//Thread Project Team 4 - TableReady
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableReadyADO
{
    public partial class Form2 : Form
    {
        TableReadyEntities2 db = new TableReadyEntities2();//object context
        List<TableGroup> tableGroups;// list of table groups
        TableGroup tableGroup; // table group object
        List<TableInGroup> tableInGroupTables; // list of table in groups
        int layoutId; //layout ID
        int restaurantId; // Rest ID
        List<int> tableInGroupTableStatus; //List of table in group status
        Restaurant restaurant;// current restaurant
        //TableGroup tableGroup;//Current tablegroup
        List<int> availableTables; //list of int available tables
        List<Table> restTables; //rest tables
        BindingSource sourceTIG = new BindingSource();
        BindingSource sourceTG = new BindingSource();
        //************************* Ehsan's Variables ***************************
        List<Table> tables; //list of tables
        Table table; //table object
        Layout layout; //layout object
        //************************* END OF EHSAN'S VARIABLES
        //*************************Jessy's Variables ******************************
        int customerId; //cust id
        Customer customer; // current Customer
        List<Customer> lstCustomers; // list of customers
        /////////////////////////////////////////////////////////////////////////////


        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load, populate all of the main page variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            //bind-combo box
            var restaurantIDs = DisplayRestaurantID();

            // ************************** EHSANS CODE *********************************
            Table_restaurantIdComboBox.DataSource = restaurantIDs; //Display Restauraunt ID onto the Tables Screen ComboBox
            DisplayTableInfo((int)Table_restaurantIdComboBox.SelectedValue); //Method to Display Table information onto the Tables Screen
            DisplayTables((int)Table_restaurantIdComboBox.SelectedValue); // Method to Display All Tables into the Tables Grid View
            // ************************** END OF EHSANS CODE **************************
            // ************************* Jessy's Code *****************************
            var customerIDs = (from cust in db.Customers
                               orderby cust.CustomerID
                               select cust.CustomerID).ToList();//execute LINQ query
            //Is in the database any order?
            if (customerIDs.Count > 0)
            {
                //Set the customerID combo box to the query result
                customerIDComboBox.DataSource = customerIDs;
                //Display Order and its details for the first order in the list
                //DisplayCustomers(customerIDs[0]);
            }
            else
            {
                //If no order is found, send an error message
                MessageBox.Show("Database does not have any customers", "Customers not found");
            }
            //************************** End of Jessy's *****************************


            //Is in the database any order?
            if (restaurantIDs.Count > 0)
            {
                //Set the orderID combo box to the query result
                restaurantIdComboBox.DataSource = restaurantIDs;
                LayoutrestaurantIDComboBox1.DataSource = restaurantIDs;
                //restaurantIDComboBox2.DataSource = restaurantIDs;
                tg_restaurantIdComboBox.DataSource = restaurantIDs;
                //Display Order and its details for the first order in the list
                DisplayRestaurantLayoutAndTables(restaurantIDs[0]);
            }
            else
            {
                //If no order is found, send an error message
                MessageBox.Show("Database do not have restaurants", "Restaurants not found");
            }

        }

        /// <summary>
        /// Get restaurant ID from database and return list of int
        /// </summary>
        /// <returns></returns>
        private List<int> DisplayRestaurantID()
        {

            var restId = (from rest in db.Restaurants
                          orderby rest.RestaurantId
                          select rest.RestaurantId).ToList();//execute LINQ query

            return restId;
        }

        /// <summary>
        /// Upon rest ID combo box change, display new information on the Restaurant tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restaurantIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRestaurantLayoutAndTables((int)restaurantIdComboBox.SelectedValue);
        }

        /// <summary>
        /// Display all of the information tied to the restauraunt id combo box on the restaurant tab
        /// </summary>
        /// <param name="restaurantId"></param>
        private void DisplayRestaurantLayoutAndTables(int restaurantId)
        {
            //get data of the selected restaurant
            restaurant = (from rest in db.Restaurants
                          where rest.RestaurantId == restaurantId
                          select rest).Single();// execute the query
            DisplayRestaurant(restaurant);
            DisplayRestaurantTables(restaurantId, rest_tableDataGridView);
            DisplayRestaurantLayouts(restaurantId, rest_layoutDataGridView);
        }

        /// <summary>
        /// Display restauraunt infromation
        /// </summary>
        /// <param name="restaurant"></param>
        private void DisplayRestaurant(Restaurant restaurant)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            //Set values of each Order attibute
            rest_restaurantNameTextBox.Text = restaurant.RestaurantName;

            if (restaurant.LayoutActive == null) rest_layoutActiveTextBox.Text = "";
            else rest_layoutActiveTextBox.Text = restaurant.LayoutActive.ToString();

        }

        /// <summary>
        /// Restauraunt tables for the restauraunt tab
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <param name="dgv"></param>
        private void DisplayRestaurantTables(int restaurantId, DataGridView dgv)
        {
            dgv.Visible = false;
            var restaurantTables = (from tab in db.Tables
                                    where tab.RestaurantID == restaurantId
                                    orderby tab.TableID
                                    select tab).ToList();
            //Set the datasource of the datagridview to the query result

            if(restaurantTables.Count>0)
            {
                dgv.DataSource = restaurantTables;
                dgv.Visible = true;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int n = item.Index;
                    dgv.Rows[n].Cells[1].Value = TableInTableGroups(Int32.Parse(dgv.Rows[n].Cells[0].Value.ToString()));
                }
            }

        }

        /// <summary>
        /// Table in table groups
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        private int TableInTableGroups(int tableId)
        {

            var TGtable = (from table in db.Tables
                           join tabInGr in db.TableInGroups on table.TableID equals tabInGr.TableID
                           where tabInGr.TableID == tableId
                           select tabInGr.TableGroupID).ToList();// execute the query

            return TGtable.Count;
        }

        /// <summary>
        /// Display Restauraunt layouts 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <param name="dgv"></param>
        private void DisplayRestaurantLayouts(int restaurantId, DataGridView dgv )
        {
            dgv.Visible = false;
            var restaurantLayouts = (from lay in db.Layouts
                                     where lay.RestaurantID == restaurantId
                                     orderby lay.LayoutId
                                     select lay).ToList();

            if(restaurantLayouts.Count>0)
            {
                dgv.Visible = true;
                //Set the datasource of the datagridview to the query result
                dgv.DataSource = restaurantLayouts;


                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int n = item.Index;
                    dgv.Rows[n].Cells[4].Value = TableGroupsInLayout(Int32.Parse(dgv.Rows[n].Cells[0].Value.ToString()));
                    if (LayoutIsActive(Int32.Parse(dgv.Rows[n].Cells[0].Value.ToString()), restaurantId)) dgv.Rows[n].Cells[1].Value = 1;
                    else dgv.Rows[n].Cells[1].Value = 0;
                }
            }

        }

        /// <summary>
        /// Table groups in layout
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        private int TableGroupsInLayout(int layoutId)
        {


            var layoutTG = (from layout in db.Layouts
                            join tabGr in db.TableGroups on layout.LayoutId equals tabGr.LayoutID
                            where layout.LayoutId == layoutId
                            select tabGr.TableGroupID).ToList();// execute the query

            return layoutTG.Count;
        }


        //LAYOUT

        /// <summary>
        /// Layout is active
        /// </summary>
        /// <param name="layoutId"></param>
        /// <param name="restauranId"></param>
        /// <returns></returns>
        private bool LayoutIsActive(int layoutId, int restauranId)
        {
            bool success;

            var layoutAct = (from layout in db.Layouts
                             join rest in db.Restaurants on layout.LayoutId equals rest.LayoutActive
                             where rest.RestaurantId == restauranId & layout.LayoutId == layoutId
                             select rest.LayoutActive).ToList();// execute the query
            if (layoutAct.Count > 0)
                success = true;
            else success = false;

            return success;
        }

        /// <summary>
        /// Layout Rest ID combo box change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restaurantIDComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var restId = (int)LayoutrestaurantIDComboBox1.SelectedValue;
            lay_layoutDataGridView.Visible = false;
            //get data of the selected order
            restaurant = (from rest in db.Restaurants
                          where rest.RestaurantId == restId
                          select rest).Single();// execute the query
            lay_restaurantNameTextBox.Text = restaurant.RestaurantName;

            DisplayLayoutGridView(restId);
        }

        /// <summary>
        /// Display layout gridview layout tab
        /// </summary>
        /// <param name="restId"></param>
        private void DisplayLayoutGridView(int restId)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }

            //DisplayRestaurantLayouts((int)restaurantIDComboBox1.SelectedValue, lay_layoutDataGridView);
            var restaurantLayouts = (from lay in db.Layouts
                                     where lay.RestaurantID == restId
                                     orderby lay.LayoutId
                                     select lay).ToList();
            if (restaurantLayouts.Count > 0)
            {
                lay_layoutDataGridView.Visible = true;
                //Set the datasource of the datagridview to the query result
                lay_layoutDataGridView.DataSource = restaurantLayouts;
            }
        }

        /// <summary>
        /// Add layout button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLayout_Click(object sender, EventArgs e)
        {
            frmLayoutUpdate newfrmLayoutUpdate = new frmLayoutUpdate();
            newfrmLayoutUpdate.isAdd = true;
            newfrmLayoutUpdate.ShowDialog();

            DisplayLayoutGridView((int)LayoutrestaurantIDComboBox1.SelectedValue);
        }

        /// <summary>
        /// Gridview cell click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lay_layoutDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.lay_layoutDataGridView.Rows[e.RowIndex];
                var selectedLayoutId = (int)row.Cells[0].Value;
                 layout = new Layout
                 {
                     LayoutId = selectedLayoutId,
                     RestaurantID = (int)LayoutrestaurantIDComboBox1.SelectedValue,
                     LayoutName = row.Cells[1].Value.ToString(),
                     LayoutImage = row.Cells[2].Value.ToString()
                 };
            } 
        }

        /// <summary>
        /// Update button layout tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateLayout_Click(object sender, EventArgs e)
        {
            if (layout != null)
            {
                frmLayoutUpdate frmLayoutUpdate = new frmLayoutUpdate();
                frmLayoutUpdate.isAdd = false;
                frmLayoutUpdate.restId = layout.RestaurantID;
                frmLayoutUpdate.layoutId = layout.LayoutId;
                frmLayoutUpdate.layoutName = layout.LayoutName;
                frmLayoutUpdate.layoutImage = layout.LayoutImage;
                frmLayoutUpdate.ShowDialog();

                DisplayLayoutGridView((int)LayoutrestaurantIDComboBox1.SelectedValue);
            }
        }


        //GUSTAVO
        //TABLEIN GROUP
        private void restaurantIdComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the DataSource of DataGridViews and combo boxes
            tg_tableInGroupDataGridView.Visible = false;
            tg_tableGroupDataGridView.Visible = false;
            tg_layoutIdComboBox.Visible = false;
            groupBoxRestaurant.Enabled = false;
            groupBoxLayout.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            
            if (tg_restaurantIdComboBox.SelectedValue!=null)
            {
                //Restaurant of selected restaurant
                var restaurant = (from rest in db.Restaurants
                                  where rest.RestaurantId == (int)tg_restaurantIdComboBox.SelectedValue
                                  select rest).Single();// execute the query
                //Enable Restaurant Box
                groupBoxRestaurant.Enabled = true;
                //Show restaurant Name
                tg_restaurantNameTextBox.Text = restaurant.RestaurantName;
                //Show LayoutActive in the restaurant
                if (restaurant.LayoutActive == null) tg_layoutActiveTextBox.Text = "";
                else tg_layoutActiveTextBox.Text = restaurant.LayoutActive.ToString();
            }

            if (tg_restaurantIdComboBox.SelectedValue!=null)
            {
                //LayoutIds of selected restaurant
                var layoutIDs = (from lay in db.Layouts
                                 where lay.RestaurantID == (int)tg_restaurantIdComboBox.SelectedValue
                                 orderby lay.LayoutId
                                 select lay.LayoutId).ToList();//execute LINQ query
               //If layoutIds is not empty, refresh  datasource and make it visible
                if (layoutIDs.Count > 0)
                {
                    //Enable Layout Box
                    groupBoxLayout.Enabled = true;
                    tg_layoutIdComboBox.DataSource = layoutIDs;
                    tg_layoutIdComboBox.Visible = true;
                    btnAdd.Enabled = true;
                }
            }

        }

        private void tg_layoutIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the DataSource of DataGridViews and combo boxes
            tg_tableInGroupDataGridView.Visible = false;
            tg_tableGroupDataGridView.Visible = false;
            if (tg_layoutIdComboBox.SelectedValue!= null)
            {
                //tableGRoups of selected layout
                tableGroups = (from tg in db.TableGroups
                               where tg.LayoutID == (int)tg_layoutIdComboBox.SelectedValue
                               orderby tg.TableGroupID
                               select tg).ToList();// execute the query
                                                   //If tableGroups is not empty, refresh datasource and make it visible
                if (tableGroups.Count > 0)
                {
                    sourceTG.DataSource = tableGroups;
                    tg_tableGroupDataGridView.DataSource = sourceTG;
                    tg_tableGroupDataGridView.Visible = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = true;
                    tg_tableGroupDataGridView.Visible = false;
                }
            }
        }

        private void tg_tableGroupDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //Clear the DataSource of DataGridViews and combo boxes
            tg_tableInGroupDataGridView.Visible = false;
            if (sourceTG.Count>0)
            {
                if (tg_tableGroupDataGridView.Rows[tg_tableGroupDataGridView.CurrentCell.RowIndex].Cells[1].Value != null)
                {
                    //tableGroupId selected from the tg_tableGroupDataGridView
                    int tableGroupId = Int32.Parse(tg_tableGroupDataGridView.Rows[tg_tableGroupDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    //tableInGoupTables of selected tableGroup
                    tableInGroupTables = (from tig in db.TableInGroups
                                          where tig.TableGroupID == tableGroupId
                                          orderby tig.TableGroupID
                                          select tig).ToList();
                    //If tableInGroupTables is not empty, refresh datasource and make it visible
                    sourceTIG.DataSource = tableInGroupTables;
                    if (sourceTIG.Count > 0)
                    {
                       tg_tableInGroupDataGridView.DataSource = sourceTIG;
                       tg_tableInGroupDataGridView.Visible = true;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            frmTableGroupUpdate secondForm = new frmTableGroupUpdate();

            // Edit, not Add 
            secondForm.IsAdd = false;

            //Identify the restaurant Id and pass to the other form
            restaurantId = (int)tg_restaurantIdComboBox.SelectedValue;

            secondForm.restaurantId = restaurantId;
            //Identify the layout Id and pass to the other form

            layoutId = (int)tg_layoutIdComboBox.SelectedValue;
            secondForm.layoutId = layoutId;

            //Tables of the Restaurant
           
            restTables = (from tab in db.Tables
                              where tab.RestaurantID == (int)tg_restaurantIdComboBox.SelectedValue
                              orderby tab.TableID
                              select tab).ToList();
            secondForm.restTables = restTables;

            //TableIds of the Restaurant
            var restTableIds = (from tab in db.Tables
                                where tab.RestaurantID == (int)tg_restaurantIdComboBox.SelectedValue
                                orderby tab.TableID
                                select tab.TableID).ToList();
            secondForm.restTableIds = restTableIds;

            //tableGroupId
            int tableGroupId = Int32.Parse(tg_tableGroupDataGridView.Rows[tg_tableGroupDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString());

            //tableInGroupTableIds in tableGroup
            var tableInGroupTableIds = (from tig in db.TableInGroups
                                        where tig.TableGroupID == tableGroupId
                                        orderby tig.TableID
                                        select tig.TableID).ToList();
            //tableInGroupTableIds in tableGroup Original
            var tableInGroupTableIdsO = (from tig in db.TableInGroups
                                        where tig.TableGroupID == tableGroupId
                                        orderby tig.TableID
                                        select tig.TableID).ToList();
            secondForm.tableInGroupTableIds = tableInGroupTableIds;

            //tableInGroupTables original status
            List<int> tableInGroupTableStatusO = new List<int>();

            //tableInGroupTables and its status
            tableInGroupTableStatus = new List<int>();
            tableInGroupTables = new List<TableInGroup>();
            foreach (int i in tableInGroupTableIds)
            {
                var tableAux = (from tig in db.TableInGroups
                                where tig.TableID == i && tig.TableGroupID == tableGroupId
                                orderby tig.TableID
                                select tig).Single();
                tableInGroupTables.Add(tableAux);
                tableInGroupTableStatus.Add(0);
                tableInGroupTableStatusO.Add(0);
            }
            secondForm.tableInGroupTables = tableInGroupTables;
            secondForm.tableInGroupTableStatus = tableInGroupTableStatus;

            //Available tables 
            List<int> availableTablesx = new List<int>();
            int kaux = 0;
            foreach (int i in restTableIds)
            {
                if (restTables[kaux].TableActive)
                { 
                    bool aux = true;
                    foreach (int j in tableInGroupTableIds)
                    {
                        if (i == j) aux = false;
                    }
                    if (aux) availableTablesx.Add(i);
                }
                kaux++;
            }
            availableTables = availableTablesx;
            secondForm.availableTables = availableTables;
            //Choose the table group to be editted in the datagridview
            secondForm.tableGroup = tableGroups[tg_tableGroupDataGridView.CurrentCell.RowIndex]; // this is reference to the product to edit
                                                                                                             // assigned to second form property
            
            secondForm.tableInGroupInUse = GetTableGroupInUse(tableGroupId);
            DialogResult result = secondForm.ShowDialog(); // show second as dialog (modal)
            if (result == DialogResult.OK)
            {
                //Database exception 
                try
                {
                    db.SaveChanges();
                    //Update tableGroups list
                    tableGroups = (from tg in db.TableGroups
                                   where tg.LayoutID == (int)tg_layoutIdComboBox.SelectedValue
                                   select tg).ToList();

                    //Refresh the datagrid view data source
                    sourceTG.DataSource = tableGroups;

                    //Make the tableGroup datagridview VISIBLE
                    if (sourceTG.Count > 0)
                    {
                        tg_tableGroupDataGridView.DataSource = sourceTG;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnAdd.Enabled = true;
                        tg_tableGroupDataGridView.Visible = true;
                    }
                    int j = 0;
                    //Add if tableInGroupTableStatus equals to 1 and remove if tableInGroupTableStatus equals to -1
                    foreach (int i in secondForm.tableInGroupTableStatus)
                    {
                        int indexTIG=tableInGroupTableIdsO.FindIndex(k => k == secondForm.tableInGroupTableIds[j]);
                        if(indexTIG>=0)
                        {
                            if (i == -1) db.TableInGroups.Remove(secondForm.tableInGroupTables[j]);
                        }
                        else
                        {
                            if (i == 1) db.TableInGroups.Add(secondForm.tableInGroupTables[j]);
                        }
                        j++;
                    }

                    //Save change of the context into database
                    db.SaveChanges();

                    //Show message to the user
                    MessageBox.Show("Successful Update");
                    //Update tableInGroupTables list
                    tableInGroupTables = (from tig in db.TableInGroups
                                          where tig.TableGroupID == tableGroupId
                                          select tig).ToList();
                    sourceTIG.DataSource = tableInGroupTables;

                    //Make the tableGroup datagridview VISIBLE
                    if (sourceTIG.Count > 0)
                    {
                        tg_tableInGroupDataGridView.DataSource = sourceTIG;
                        tg_tableInGroupDataGridView.Visible = true;
                    }
                    else
                    {
                        tg_tableInGroupDataGridView.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    //Exception Message
                    MessageBox.Show("Error while saving after add: " + ex.Message, ex.GetType().ToString());
                }

            }
        }

        //Add Table Group
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //New form to Add a tableGroup
            frmTableGroupUpdate newProductForm = new frmTableGroupUpdate();

            //Add, not Edit
            newProductForm.IsAdd = true;

            //Identify the restaurant Id and pass to the other form
            restaurantId = (int)tg_restaurantIdComboBox.SelectedValue;
            newProductForm.restaurantId = restaurantId;

            //Identify the layout Id and pass to the other form
            layoutId = (int)tg_layoutIdComboBox.SelectedValue;
            newProductForm.layoutId = layoutId;

            //Tables of the Restaurant
            restTables = (from tab in db.Tables
                              where tab.RestaurantID == (int)tg_restaurantIdComboBox.SelectedValue
                              orderby tab.TableID
                              select tab).ToList();
            newProductForm.restTables = restTables;

            //Verify if tableiInGroup should be added to table Group: (1) include (-1) Do not include
            tableInGroupTableStatus = new List<int>();
            newProductForm.tableInGroupTableStatus = tableInGroupTableStatus;

            //TableIds of the Restaurant
            var restTableIds = (from tab in db.Tables
                                where tab.RestaurantID == (int)tg_restaurantIdComboBox.SelectedValue
                                orderby tab.TableID
                                select tab.TableID).ToList();

            //Available tables 
            List<int> availableTablesx = new List<int>();
            int kaux = 0;
            foreach (int i in restTableIds)
            {
                if (restTables[kaux].TableActive)
                { 
                 availableTablesx.Add(i);
                }
                kaux++;
            }
            availableTables = availableTablesx;
            newProductForm.availableTables = availableTables;
            
            // table group to be added
            tableGroup = newProductForm.GetNewTableGroup();
            //tableInGroupTables without tablegroupID to be added to the database;
            //Create auxtableInGroupTables to help to deal with tableInGroupTables without tableGroupID
            List<TableInGroup> auxtableInGroupTables = new List<TableInGroup>();
            if (newProductForm.tableInGroupTables != null)
            {
                foreach (TableInGroup tig in newProductForm.tableInGroupTables)
                    auxtableInGroupTables.Add(tig);
            }
            //If new table group to be added
            if (tableGroup != null)
            {
                //Database exception 
                try
                {
                    //Add new tablegroup to the database
                    db.TableGroups.Add(tableGroup);
                    //Add new tableGroup to the List tablegroups
                    tableGroups.Add(tableGroup);
                    //Save change of the context into database
                    db.SaveChanges();
                    //Show message to the user
                    MessageBox.Show(" New Table Group Added ");
                    //Update tableGroups list
                    tableGroups = (from tg in db.TableGroups
                                   where tg.LayoutID == (int)tg_layoutIdComboBox.SelectedValue
                                   select tg).ToList();
                    //Refresh the datagrid view data source
                    sourceTG.DataSource = tableGroups;

                    //Make the tableGroup datagridview VISIBLE
                    if (sourceTG.Count > 0)
                    {
                        tg_tableGroupDataGridView.DataSource = sourceTG;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnAdd.Enabled = true;
                        tg_tableGroupDataGridView.Visible = true;
                    }
                    //Add tableInGroupTables of the added tableGroup
                    if (auxtableInGroupTables!=null)
                    {
                        try
                        {
                            //Update the tablegroup Id of the tableInGroupTables
                            int j= 0;
                            foreach (TableInGroup tig in auxtableInGroupTables)
                            {
                                //Only Add if tableInGroupTableStatus equals to 1
                                if (newProductForm.tableInGroupTableStatus[j] == 1)
                                {
                                    tig.TableGroupID = tableGroup.TableGroupID;
                                     db.TableInGroups.Add(tig);
                                }
                                j++;
                            }
                            //Save change of the context into database
                            db.SaveChanges();
                            //Show message to the user
                            MessageBox.Show("New Tables Added to TableGroup");
                            //Update tableInGroupTables list
                            tableInGroupTables = (from tig in db.TableInGroups
                                                  where tig.TableGroupID == tableGroup.TableGroupID
                                                  select tig).ToList();
                            //Refresh the datagrid view data source
                            sourceTIG.DataSource = tableInGroupTables;
                            
                            //Make the tableGroup datagridview VISIBLE
                            if (sourceTIG.Count > 0)
                            {
                                tg_tableInGroupDataGridView.DataSource = sourceTIG;
                                tg_tableInGroupDataGridView.Visible = true;
                            }
                            else
                            {
                                tg_tableInGroupDataGridView.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            //Exception Message
                            MessageBox.Show("Error while saving after add: " + ex.Message, ex.GetType().ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Exception Message
                    MessageBox.Show("Error while saving after add: " + ex.Message, ex.GetType().ToString());
                }

            }
        }
        //Delete Table Group
        private void brnDelete_Click(object sender, EventArgs e)
        {
            //
            string message;

            
            //get the tablegroupId from the selected row in the data grid
            int tableGroupId = Int32.Parse(tg_tableGroupDataGridView.Rows[tg_tableGroupDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString());
           
            //Find index of table group
            int indexT = tableGroups.FindIndex(i => i.TableGroupID == tableGroupId);
            //Check if the tableGroupId selected is in the tableGroup List
            if (indexT < 0)
            { 
                //If it is not in the list
                MessageBox.Show("The table was already deleted", "Delete is not possible");
                //Update the dataset
                tableGroups = (from tg in db.TableGroups
                               where tg.LayoutID == (int)tg_layoutIdComboBox.SelectedValue
                               select tg).ToList();
                //Refresh the datagrid view
                sourceTG.DataSource = tableGroups;
                //If there is at least one table group, make the dataview visible
                if (sourceTG.Count > 0)
                {
                    tg_tableGroupDataGridView.DataSource = sourceTG;
                    tg_tableGroupDataGridView.Visible = true;
                }
                else tg_tableGroupDataGridView.Visible = false;
            }
            else 
            {
                //Chose the tablegroup to be deleted
                tableGroup = tableGroups[indexT];

                //Verify if the table Group is in use
                if (GetTableGroupInUse(tableGroupId))
                {
                    //If the table group is in use, send a message to the user
                    message = "Table Group ID " + Convert.ToString(tableGroup.TableGroupID) + " Name: " + tableGroup.TableGroupName + "cannot be deleted beacuse it is in use";
                    MessageBox.Show(message, "Delete is not possible");
                }
                else
                {
                    //Double check if the user want to delete the table group
                    message = "Are you sure you want to delete " + tableGroup.TableGroupName + "?";
                    DialogResult button =
                        MessageBox.Show(message, "Confirm Delete",
                        MessageBoxButtons.YesNo);
                    //if the user confirms the delete, DELETE
                    if (button == DialogResult.Yes)
                    {
                        try
                        {
                            //Remove the tablegroup from the database
                            db.TableGroups.Remove(tableGroup);
                            //save the changes in the context
                            db.SaveChanges();
                            //Update the dataset
                            tableGroups = (from tg in db.TableGroups
                                           where tg.LayoutID == (int)tg_layoutIdComboBox.SelectedValue
                                           select tg).ToList();
                            //Refresh the datagrid view
                            sourceTG.DataSource = tableGroups;
                            
                            //If there is at least one table group, make the datagrid view visible
                            if (sourceTG.Count == 0)
                            {
                                btnUpdate.Enabled = false;
                                btnDelete.Enabled = false;
                                btnAdd.Enabled = true;
                                tg_tableGroupDataGridView.DataSource = sourceTG;
                                tg_tableGroupDataGridView.Visible = false;
                                tg_tableInGroupDataGridView.Visible = false;
                            }
                            else
                            {
                                tg_tableGroupDataGridView.Visible = true;
                                btnUpdate.Enabled = true;
                                btnDelete.Enabled = true;
                                btnAdd.Enabled = true;
                            }
                                
                            //Inform the user that Delete action was successful
                            MessageBox.Show("Table Group Deleted");

                        }
                        //Catch any error during database procedure
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while saving after delete: " + ex.Message,
                                ex.GetType().ToString());
                        }
                    }
                }
            }
              
        }
        //Verify if the table Group is in use
        private bool GetTableGroupInUse(int tableGroupID)
        {
            //Look for a registry with tableGroupID
            var tableGroupInUse = (from ta in db.TableAvailabilityDates
                                   where ta.TableGroupID == tableGroupID
                                   select ta.C_Datetime).ToList();
            //If a registry is found in the TableAvailabilityDates table (Count>0), this table group is in use and cannot be deleted
            if (tableGroupInUse.Count > 0) return true;
            else return false;
        }

        //****************** EHSANS CODE ******************************

        /// <summary>
        /// Display RestaurantID in the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restaurantIdComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int restId = (int)Table_restaurantIdComboBox.SelectedValue;

            DisplayTableInfo(restId);
            DisplayTables(restId);

        }


        /// <summary>
        /// Display Table information on the Table screen
        /// </summary>
        /// <param name="restId"></param>
        private void DisplayTableInfo(int restId)
        {
            restaurant = (from rest in db.Restaurants
                          where rest.RestaurantId == restId
                          select rest).Single();// execute the query

            Table_restaurantNameTextBox.Text = restaurant.RestaurantName;
        }

        /// <summary>
        /// Display The information within the table grid view
        /// </summary>
        /// <param name="restID"></param>
        private void DisplayTables(int restId)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }

            Table_restaurantNameTextBox.Text = (string)restaurant.RestaurantName;

            tables = (from table in db.Tables
                              where table.RestaurantID == restId
                              orderby table.TableID
                              select table).ToList();
            tableDataGridView.DataSource = tables;
        }

        /// <summary>
        /// Add new Tables into the Tables Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_btnAdd_Click(object sender, EventArgs e)
        {
            frmTableUpdate newfrmTableUpdate = new frmTableUpdate();
            newfrmTableUpdate.IsAdd = true;
            newfrmTableUpdate.ShowDialog();

            DisplayTables((int)Table_restaurantIdComboBox.SelectedValue);
        }
        
        /// <summary>
        /// Table tab update button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestUpdate_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                frmTableUpdate frmTableUpdate = new frmTableUpdate();
                frmTableUpdate.IsAdd = false;
                frmTableUpdate.tableId = table.TableID;
                frmTableUpdate.restaurantId = (int)table.RestaurantID;
                frmTableUpdate.tableName = table.TableName;
                frmTableUpdate.tableMaxNumberSeats = table.TableMaxNumberSeats;
                frmTableUpdate.tableImage = table.TableImage;
                frmTableUpdate.tableImageAvailable = table.TableImageAvailable;
                frmTableUpdate.tableImageUnavailable = table.TableImageUnavailable;
                frmTableUpdate.tableImageCheckOut = table.TableImageCheckout;
                frmTableUpdate.tableImageCleaning = table.TableImageCleaning;
                frmTableUpdate.tableType = table.TableType;
                frmTableUpdate.tableSize = table.TableSize;
                frmTableUpdate.creationDate = table.CreationDate;
                frmTableUpdate.tableActive = table.TableActive;

                frmTableUpdate.ShowDialog();

                DisplayTables((int)Table_restaurantIdComboBox.SelectedValue);
            }
        }

        /// <summary>
        /// Grid view table tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tableDataGridView.Rows[e.RowIndex];
                var selectedTableId = (int)row.Cells[0].Value;
                table = new Table
                {
                    TableID = selectedTableId,
                    RestaurantID = (int)row.Cells[1].Value,
                    TableName = row.Cells[2].Value.ToString(),
                    TableMaxNumberSeats = (int)row.Cells[3].Value,
                    TableImage = row.Cells[4].Value.ToString(),
                    TableImageAvailable = row.Cells[5].Value.ToString(),
                    TableImageUnavailable = row.Cells[6].Value.ToString(),
                    TableImageCheckout = row.Cells[7].Value.ToString(),
                    TableImageCleaning = row.Cells[8].Value.ToString(),
                    TableType = row.Cells[9].Value.ToString(),
                    TableSize = row.Cells[10].Value.ToString(),
                    CreationDate = (DateTime)row.Cells[11].Value,
                    TableActive = db.Tables.SingleOrDefault(a => a.TableID == selectedTableId).TableActive
                };
            }
        }
        //  **************************** END OF EHSANS CODE *************************

        // **************************************Jessy Code*******************************

        //This code was commented out because our database was updated to include the authentication
        //of the second workshop and this functionality was not available anymore because customers require
        //a user ID which is created in the user entity which is tied to the registration page in our workshop #2.
        //We were not able to come back to edit this part so we decided to remove this functionality.

        ///// <summary>
        ///// Refresh all method
        ///// </summary>
        //public void RefreshAll()
        //{
        //    foreach (var entity in db.ChangeTracker.Entries())
        //    {
        //        entity.Reload();
        //    }
        //    DisplayCustomer();
        //}

        ///// <summary>
        ///// Display Customer Customer tab
        ///// </summary>
        //private void DisplayCustomer()
        //{
        //    //Set values of each Order attibute
        //    customerIDComboBox.SelectedItem = customer.CustomerID;
        //    customerFirstNameTextBox.Text = customer.CustomerFirstName;
        //    customerLastNameTextBox.Text = customer.CustomerLastName;
        //}

        ///// <summary>
        ///// Display Customers customers tab
        ///// </summary>
        ///// <param name="customerId"></param>
        //private void DisplayCustomers(int customerId)
        //{
        //    //get data of the selected restaurant
        //    customer = (from cust in db.Customers
        //                where cust.CustomerID == customerId
        //                select cust).Single();// execute the query
        //    DisplayCustomer();
        //}

        ///// <summary>
        ///// Refresh Button
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnCustRefresh_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Successfully Updated");
        //    var customerIDs = (from cust in db.Customers
        //                       orderby cust.CustomerID
        //                       select cust.CustomerID).ToList();//execute LINQ query
        //    DisplayCustomers(customerIDs[0]);
        //    RefreshAll();
        //}

        ///// <summary>
        ///// Customer add button
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnCustAdd_Click(object sender, EventArgs e)
        //{
        //    frmCustomerUpdate secondCustForm = new frmCustomerUpdate();
        //    secondCustForm.IsAdd = true;
        //    //Identify the customer Id and pass to the other form
        //    customerId = (int)customerIDComboBox.SelectedValue;
        //    secondCustForm.customerId = customerId;
        //    ////Add, not Edit
        //    secondCustForm.IsAdd = true;
        //    secondCustForm.ShowDialog();
        //}

        ///// <summary>
        ///// Customer update button
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnCustUpdate_Click(object sender, EventArgs e)
        //{
        //    frmCustomerUpdate secondCustForm = new frmCustomerUpdate();
        //    // Edit, not Add 
        //    secondCustForm.IsAdd = false;
        //    //Identify the restaurant Id and pass to the other form
        //    customerId = (int)customerIDComboBox.SelectedValue;
        //    secondCustForm.customerId = customerId;
        //    lstCustomers = (from cust in db.Customers
        //                    where cust.CustomerID == (int)customerIDComboBox.SelectedValue
        //                    orderby cust.CustomerID
        //                    select cust).ToList();
        //    secondCustForm.lstCustomers = lstCustomers;
        //    secondCustForm.custFirstName = customerFirstNameTextBox.Text;
        //    secondCustForm.custLastName = customerLastNameTextBox.Text;
        //    secondCustForm.ShowDialog();
        //}

        ///// <summary>
        ///// Customer id combo box change
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void customerIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Assigns the value of the int named ordID to the selected value of the orderID combo box.
        //    int customerId = (int)customerIDComboBox.SelectedValue;
        //    customer = (from cust in db.Customers
        //                where cust.CustomerID == customerId
        //                select cust).Single();// execute the query

        //    DisplayCustomer();
        //}

        ///// <summary>
        ///// Customer add leave 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnCustAdd_Leave(object sender, EventArgs e)
        //{
        //    var customerIDs = (from cust in db.Customers
        //                       orderby cust.CustomerID
        //                       select cust.CustomerID).ToList();//execute LINQ query
        //    customerIDComboBox.DataSource = customerIDs;
        //    DisplayCustomers(customerIDs[0]);
        //}


        //*************************Khurrams part*************************************

        /// <summary>
        /// Add button Restauraunt tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRest_Click(object sender, EventArgs e)
        {
            frmRestaurantUpdate newfrmRestaurantUpdate = new frmRestaurantUpdate();
            newfrmRestaurantUpdate.isAdd = true;
            newfrmRestaurantUpdate.ShowDialog();

            restaurantIdComboBox.DataSource = DisplayRestaurantID();
        }

        //Added by Ehsan

        /// <summary>
        /// Reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateRest_Click(object sender, EventArgs e)
        {
            frmRestaurantUpdate newfrmRestaurantUpdate = new frmRestaurantUpdate();
            newfrmRestaurantUpdate.isAdd = false;
            newfrmRestaurantUpdate.restaurantId = (int)restaurantIdComboBox.SelectedValue;
            newfrmRestaurantUpdate.restaurantName = rest_restaurantNameTextBox.Text;
            if (rest_layoutActiveTextBox.Text != "")
            {
                newfrmRestaurantUpdate.layoutActive = Convert.ToInt32(rest_layoutActiveTextBox.Text);
            }
            newfrmRestaurantUpdate.ShowDialog();

            DisplayRestaurantLayoutAndTables((int)restaurantIdComboBox.SelectedValue);


        }
    }









}


    
