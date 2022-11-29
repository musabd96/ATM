using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace atmSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            //when the program start the deposite and menubar will be this positions.
            pnlDeposit.Height = 0;
            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 99);
            btnHome.Visible = false;
        }


        //logout button in menubar
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //MenuBar closet and open deposite panel
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            menuBarClose();
            pnlDeposit.Height = pnlLogIn.Height;
        }

        //Home button in menubar 
        private void btnHome_Click(object sender, EventArgs e)
        {
            menuBarClose();

            pnlDeposit.Height = 0;

        }

        //Menu bar close
        private void menuBarClose()
        {
            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 99);
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

            if (pnlDeposit.Height == 351)
            {
                btnHome.Enabled = true;
            }
            else if (pnlDeposit.Height == 0)
            {
                btnHome.Enabled = false;
            }



        }

        //Menu bar button
        private void picMenuBar_Click(object sender, EventArgs e)
        {
            menuBarOpen();


        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }



        //Withdraw

        private void btn500_Click(object sender, EventArgs e)
        {

            //Close menu bar 

            menuBarClose();

            MessageBox.Show("Du har tagit ut 500kr");
            //substract blance in data base
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();

            MessageBox.Show("Du har tagit ut 100kr");
            //substract blance in data base
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();

            MessageBox.Show("Du har tagit ut 200kr");


            //substract blance in data base

        }

        private void btnService_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();

            MessageBox.Show("Hi! 'customer Name'. Thank you for you contact us!", "Customer Server");
        }

        private void plnAtm_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void pnlLogIn_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }

        private void pnlDeposit_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }
        private void txtcashWd_TextChanged(object sender, EventArgs e)
        {
            // TextBox - withdrawal home.cs[Design] window
            txtcashWd.BackColor = Color.White;
            lbinvWd.Hide();
            lbstarWd.Hide();
            lbMaxWd.Hide();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // invalid  * - "label" withdrawal home.cs[Design] window
        }

        private void lbMaxWd_Click(object sender, EventArgs e)
        {
            // Max 10 000 SEK - withdrawal home.cs[Design] window
        }

        private void lbinvWd_Click(object sender, EventArgs e)
        {
            // invalid - withdrawal home.cs[Design] window
        }

        private void lbstarWd_Click(object sender, EventArgs e)
        {
            // * -  withdrawal home.cs[Design] window
        }
        private void btnOkeyWith_Click_1(object sender, EventArgs e)
        {
            // show entered withdrawal - withdrawal home.cs[Design] window
            int a;
            a = int.Parse(txtcashWd.Text);
            if (a <= 10000)
            {
                MessageBox.Show("Du tog ut " + a);
            }
            else
            {
                lbMaxWd.Show();
                lbinvWd.Show();
                lbstarWd.Show();
                txtcashWd.BackColor = Color.Red;
            }
        }
        // Enterknappen utför OK-knapptryck
        private void txtcashWd_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkeyWith.PerformClick();
            }
        }
        // txtcashWd Only digits, return, delete can be entered
        private void txtcashWd_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46 && ch != 13)
            {
                e.Handled = true;
            }
        }
        // Home.cs[Design] accepterar EnterOK knapp / remove ding sound
        private void pnlLogIn_Paint_1(object sender, PaintEventArgs e)
        {
            this.AcceptButton = this.btnOkeyWith;
        }
    }
        
}
