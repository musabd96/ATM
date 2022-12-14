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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            MessageBox.Show($"Hello! {dataBase.fullNameDb}, " +
                            $"thank you for contacting us,\n " +
                            $"we'll be in touch very soon", "Customer service");
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
            // check if old pin is ok, new pin and confirm pin - Method runs 
            dataBase dataBase = new dataBase();
            dataBase.getData();
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
                            dataBase.newPin();
                            txtNewPin.Clear();
                            txtConfPin.Clear();
                            txtOldPin.Clear();
                            lberror.Text = "";
                            lbstarNew.Text = "";
                            lbstarConP.Text = "";
                            MessageBox.Show($"{dataBase.accountNrDb} pin is now changed", "CHANGED PIN");
                        }
                        else
                        {

                            txtNewPin.ForeColor = Color.Red;
                            txtConfPin.ForeColor = Color.Red;
                            pnlNewPin.BackColor = Color.Red;
                            pnlConfPin.BackColor = Color.Red;
                            lberror.Text = "Pin do not match!";
                            lbstarNew.Text = "*";
                            lbstarConP.Text = "*";
                            txtNewPin.Focus();
                            txtNewPin.SelectAll();
                            txtConfPin.SelectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    pnlOldPin.BackColor = Color.Red;
                    txtOldPin.ForeColor = Color.Red;
                    lberror.Text = "Wrong pin!";
                    lbstarOld.Text = "*";
                    txtOldPin.SelectAll();
                    txtOldPin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void txtOldPin_TextChanged(object sender, EventArgs e)
        {
            pnlOldPin.BackColor = Color.DodgerBlue;
            txtOldPin.ForeColor = Color.Black;

        }

        private void txtNewPin_TextChanged(object sender, EventArgs e)
        {
            pnlNewPin.BackColor = Color.DodgerBlue;
            txtNewPin.ForeColor = Color.Black;
        }

        private void txtConfPin_TextChanged(object sender, EventArgs e)
        {
            pnlConfPin.BackColor = Color.DodgerBlue;
            txtConfPin.ForeColor = Color.Black;
            pnlNewPin.BackColor = Color.DodgerBlue;
            txtNewPin.ForeColor = Color.Black;
        }

        private void txtConfPin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }
    }

       
}
