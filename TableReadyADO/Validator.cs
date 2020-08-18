//Author: Gustavo Lourenco Moises
//CPRG 200 Lab Assigment 3
//Date:July 11, 2020

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableReadyADO
{
    /// <summary>
    /// A repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// tests if text box has content
        /// </summary>
        /// <param name="inputBox">text box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsProvided(TextBox inputBox, string name)
        {
            bool isValid = true; // 
            if(inputBox.Text=="")  
            {
                isValid = false;
                MessageBox.Show( name + " must be provided");
                inputBox.SelectAll();
                inputBox.Focus();
            }

            return isValid;
        }
        /// <summary>
        /// tests if text box contains value that is non-negative integer
        /// </summary>
        /// <param name="inputBox">text box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>true if non-negative integer, and false if not</returns>
        public static bool IsNonNegativeInt(TextBox inputBox, string name)
        {
            bool isValid = true;
            int value;     //parsed
            if (!Int32.TryParse(inputBox.Text, out value))
            {
                isValid = false;
                MessageBox.Show(name + " must be an integer number");
                inputBox.SelectAll(); //Selesct all conntent for replacement
                inputBox.Focus();
            }
            else
            {
                if (value < 0) 
                {
                    isValid = false;
                    MessageBox.Show(name + " must be a non-negative integer number");
                    inputBox.SelectAll(); //Selesct all conntent for replacement
                    inputBox.Focus();
                }
            }
            return isValid;
        }
        /// <summary>
        /// tests if text box contains value that is non-negative double
        /// </summary>
        /// <param name="inputBox">text box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>true if non-negative double, and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox inputBox, string name)
        {
            bool isValid = true;
            double value;     //parsed
            if (!Double.TryParse(inputBox.Text, out value))
            {
                isValid = false;
                MessageBox.Show(name + " must be a number");
                inputBox.SelectAll(); //Selesct all conntent for replacement
                inputBox.Focus();
            }
            else
            {
                if (value < 0)
                {
                    isValid = false;
                    MessageBox.Show(name + " must be a non-negative number");
                    inputBox.SelectAll(); //Selesct all conntent for replacement
                    inputBox.Focus();
                }
            }
            return isValid;
        }
        /// <summary>
        /// tests if text box contains value that is non-negative decimal
        /// </summary>
        /// <param name="inputBox">text box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>true if non-negative decimal, and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox inputBox, string name)
        {
            bool isValid = true;
            decimal value;     //parsed
            if (!Decimal.TryParse(inputBox.Text, out value))
            {
                isValid = false;
                MessageBox.Show(name + " must be a number");
                inputBox.SelectAll();
                inputBox.Focus();
            }
            else
            {
                if (value < 0)
                {
                    isValid = false;
                    MessageBox.Show(name + " must be a non-negative number");
                    inputBox.SelectAll(); //Selesct all conntent for replacement
                    inputBox.Focus();
                }
            }
            return isValid;
        }
        /// <summary>
        /// tests if Combo box has content
        /// </summary>
        /// <param name="inputComboBox">Combo box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsComboBoxProvided(ComboBox inputComboBox, string name)
        {
            bool isValid = true; // 
            if (inputComboBox.SelectedIndex <0)
            {
                isValid = false;
                MessageBox.Show(name + " must be provided");
                inputComboBox.SelectAll();
                inputComboBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        ///tests if text box contains value that is true/True/TRUE/1 or false/False/FALSE/0
        /// </summary>
        /// <param name="inputBox">Combo box under text</param>
        /// <param name="name">name for error message</param>
        /// <returns>if TRUE or FALSE, and false if not</returns>
        public static bool IsTrueOrFalse(TextBox inputBox, string name)
        {
            bool isValid = true;
            
            if (inputBox.Text!="False" && inputBox.Text != "True")
            {
                if (inputBox.Text == "FALSE" || inputBox.Text == "false" || inputBox.Text=="0")
                {
                    inputBox.Text = "False";
                }
                else
                {
                    if (inputBox.Text == "TRUE" || inputBox.Text == "true" || inputBox.Text == "1")
                    {
                        inputBox.Text = "True";
                    }
                    else
                    {
                        isValid = false;
                        MessageBox.Show(name + " must be TRUE or FALSE");
                        inputBox.SelectAll(); //Selesct all conntent for replacement
                        inputBox.Focus();
                    }
                }
            }
            return isValid;
        }
    }
}
