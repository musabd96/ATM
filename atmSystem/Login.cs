﻿using atmMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmSystem
{
    public partial class Login : Form
    {
        public static string accNr { get; set; }
        public static string Pin { get; set; }

        public Login()
        {           
             InitializeComponent();

            //when the program start the registration,login and ATM logo labels will be this positions.
            pnlRegister.Height = 0;
            pnlLogIn.Location = new Point(314, 5);
            plnAtm.Location = new Point(5, 5);



        }

        
        #region Login
        //Login 
        public void login()
        {
            accNr = txtAccNr.Text;
            Pin =  txtPin.Text;

            try
            {
                dataBase dataBase = new dataBase();
                Home home = new Home();


                string accountNr = txtAccNr.Text;
                string pin = txtPin.Text;

                if (accountNr == "admin" && pin == "admin")
                {

                    accountNr = home.userAccNr;
                    home.userAccNr = txtAccNr.Text;
                    home.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        dataBase.accountNr = int.Parse(accountNr);

                        dataBase.getData();



                        if (dataBase.accountNrDb == Convert.ToInt32(accountNr) && dataBase.pinDb == pin)
                        {
                            this.Hide();
                            

                            home.Show();
                        }

                        else
                        {
                            lberror.Text = "Wrong account and pin!";
                            lberror.ForeColor = Color.Red;
                            txtAccNr.ForeColor = Color.Red;
                            pnlAccNr.BackColor = Color.Red;
                            pnlPin.BackColor = Color.Red;
                            txtPin.ForeColor = Color.Red;
                            txtAccNr.SelectAll();
                            txtPin.SelectAll();
                            txtAccNr.Focus();



                        }

                    }
                    catch
                    {
                        

                        txtAccNr.ForeColor = Color.Red;
                        pnlAccNr.BackColor = Color.Red;
                        pnlPin.BackColor = Color.Red;
                        txtPin.ForeColor = Color.Red;
                        txtAccNr.SelectAll();
                        txtPin.SelectAll();
                        txtAccNr.Focus();

                    }

                }

            }
            catch
            {

            }
        }
        //Login button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
              

        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeApp();
        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
            
        }


        #endregion

        #region registration
        private void LnkRegister_Click(object sender, EventArgs e)
        {
            //Creating account nr 
            dataBase dataBase = new dataBase();
            dataBase.lastAccNr();
            if (dataBase.newPinDb != "0")
            {
                dataBase.createAcc();
                dataBase.lastAccNr();
                txtAccNrReg.Text = Convert.ToString(dataBase.newAccNrDb);

            }
            else
            {
                txtAccNrReg.Text = Convert.ToString(dataBase.newAccNrDb);

            }

            //Clear all fields
            txtFullName.Clear();
            txtEmail.Clear();
            txtPinReg.Clear();
            txtPinConf.Clear();
            btnRegister.Enabled = false;

            txtAccNrReg.Enabled = false;
            pnlRegister.Height = pnlLogIn.Height;
            pnlLogIn.Location = new Point(5, 5);
            plnAtm.Location = new Point(380, 5);

        }

        public void registration()
        {
            dataBase dataBase = new dataBase();

            // pin and conform pin  are not same error message will popup 
            if (txtPinReg.Text != txtPinConf.Text)
            {
                lberrorReg.Text = "Pin do not match!";
                txtPinReg.ForeColor = Color.Red;
                txtPinConf.ForeColor = Color.Red;
                pnlpinreg.BackColor = Color.Red;
                pnlConPin.BackColor = Color.Red;

            }
            //If the field empty
            else if (txtFullName.Text == "" || txtEmail.Text == "" || txtPinReg.Text == "" || txtPinConf.Text == "")
            {
                lbInv.Text = "Please fill out empty fields.";
                
            }
            else
            {
                dataBase.fullName = txtFullName.Text;
                dataBase.email = txtEmail.Text;
                dataBase.pin = txtPinReg.Text;
                dataBase.balance = "0";
                dataBase.insertData();
                MessageBox.Show("Your registration has been succesfull", "Congratulation!");

                // go back to login 
                pnlRegister.Height = 0;
                pnlLogIn.Location = new Point(314, 5);
                plnAtm.Location = new Point(5, 5);

            }
        }
        private void btnRegister_KeyDown(object sender, KeyEventArgs e)
        {
            registration();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            registration();
            
        }

        private void txtAccNr_Click(object sender, EventArgs e)
        {
            lberror.Text = "";

        }
        
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            pnlRegister.Height = 0;
            pnlLogIn.Location = new Point(314, 5);
            plnAtm.Location = new Point(5, 5);
        }

        private void txtPinConf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                registration();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                btnRegister.Enabled = false;
            }
            else
            {
                btnRegister.Enabled=true;
            }
        }

            #endregion

        //Close Application

        internal void closeApp()
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }   
}
