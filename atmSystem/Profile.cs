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

namespace atmSystem
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();



            //change pin panel unvisible
            pnlCchanPin.Visible = false;



            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 101);
            btnHome.Visible = false;
        }


       
        //Menu bar close
        private void menuBarClose()
        {
            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 101);
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

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            pnlCchanPin.Visible = false;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi! 'customer Name'. Thank you for you contact us!", "Customer Server");
        }

        private void plnAtmProf_Paint(object sender, PaintEventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void pnlProfWh_Paint(object sender, PaintEventArgs e)
        {
            //Close menu bar 

            menuBarClose();
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

        private void btnTrans_Click(object sender, EventArgs e)
        {


            pnlCchanPin.Visible = true;

        }
    }

       
}
