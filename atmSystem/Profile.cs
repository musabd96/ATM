using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using atmMachine;

namespace atmSystem
{

    public partial class Profile : Form
    {

        public static string newPin { get; set; }
        public Profile()
        {
            InitializeComponent();



            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 100);
            btnHome.Visible = false;

            // showing name, email & accNr currently logged in
            dataBase dataBase = new dataBase();
            dataBase.getData();
            lbFullName.Text = dataBase.fullNameDb;
            lbEmail.Text = dataBase.emailDb;
            lbAcc.Text = dataBase.accountNrDb.ToString();
        }


       
        //Menu bar close
        private void menuBarClose()
        {
            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 100);
            btnHome.Visible = false;

        }

        //Menu bar open
        private void menuBarOpen()
        {
            picMenuBar.Dock = DockStyle.Left;
            lbMenuBar.Text = "Menu";
            pnlMenuBar.Size = new Size(130, 225);
            btnHome.Visible = true;

            //If the deposite panel open the home btn in menu bar will disable or enable if not

            btnProfile.Enabled = false;


        }

        private void picMenuBar_Click(object sender, EventArgs e)
        {
            menuBarOpen();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

       

        private void btnService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi! 'customer Name'. Thank you for you contact us!", "Customer Server");
        }

       

       

        private void plnAtmProf_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();

        }

        private void pnlProfWh_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataBase dataBase = new dataBase();
            dataBase.getData();
            MessageBox.Show($"{dataBase.pinDb}");
            try
            {
                if (txtOldPin.Text == dataBase.pinDb)
                {
                    try
                    {
                        int newpin, ConfPin;
                        newpin = Convert.ToInt32(txtNewPin.Text);
                        ConfPin = Convert.ToInt32(txtConfPin.Text);

                        if (newpin == ConfPin)
                        {
                            newPin = Convert.ToString(newpin);
                            MessageBox.Show($"{newPin}");
                            dataBase.newPin();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Du skrev in fel lösenord");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
            txtOldPin
            txtNewPin
            txtConfPin
            */
        }
    }

       
}
