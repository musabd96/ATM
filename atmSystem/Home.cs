using atmMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace atmSystem
{
    public partial class Home : Form
    {
        public string userAccNr { get; set; }
        public string userFullName { get; set; }
        //public string oldBalance { get; set; }
        public static int newBalance { get; set; }
        public static int cashDp { get; set; }
        public static int cashWd { get; set; }
        public static int fastWd { get; set; }

        
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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // showing name & accNr currently logged in
           
            dataBase dataBase = new dataBase();
            dataBase.getData();
            lbAcc.Text = dataBase.accountNrDb.ToString();
            lbname.Text = dataBase.fullNameDb;

            if(dataBase.accountNrDb == 1234)
            {
                btnminstat.Enabled = false;
            }
            else
            {
                btnminstat.Enabled = true;
            }
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
            btnHome.Enabled = true;
            pnlDeposit.Height = pnlWithdraw.Height;
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
        #region BTN100-500
        private void btn100_Click(object sender, EventArgs e)
        {
            //Close menu bar 
            fastWd = 100;
            withdraw();
            
            menuBarClose();
            //substract blance in data base
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            fastWd = 200;
            withdraw();
            //Close menu bar 
            
            menuBarClose();
            //substract blance in data base
        }
        private void btn500_Click(object sender, EventArgs e)
        {

            fastWd = 500;
            withdraw();
            //Close menu bar
            
            menuBarClose();
            //substract blance in data base
        }
        #endregion

        private void btnService_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();

            MessageBox.Show($"Hi! {dataBase.fullName}. Thank you for you contact us!", "Customer Server");
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

            miniStatement miniStatement = new miniStatement();
            miniStatement.miniStat();
            miniStatement.Show();
            this.Close();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            dataBase dataBase = new dataBase();
            dataBase.getData();
            MessageBox.Show($"Ditt Saldo är: {dataBase.balanceDb}");//Close menu bar 

            menuBarClose();
        }

        private void pnlDeposit_Click(object sender, EventArgs e)
        {
            //Close menu bar 

            menuBarClose();
        }
       
        
        private void withdraw()
        {
            dataBase dataBase = new dataBase();
            dataBase.getData();
            try
            {
                
                if ( txtcashWd.Text == "")
                {
                    cashWd = fastWd;
                }
                else if( txtcashWd.Text != "")
                {
                    cashWd = Convert.ToInt32(txtcashWd.Text);
                }

                
                if (cashWd >= 10000)
                {
                    lbstarWd.Text = "*";
                    
                    lbMaxWd.ForeColor = Color.Red;
                }
                else
                {
                    if (Convert.ToInt32(dataBase.balanceDb) < cashWd)
                    {
                        MessageBox.Show("Du har inte tillräckligt med pengar.");
                        txtcashWd.SelectAll();

                    }
                    else
                    {
                        newBalance = Convert.ToInt32(dataBase.balanceDb) - cashWd;
                        dataBase.newBalance();
                        dataBase.getData();
                        dataBase.miniStatement();
                        MessageBox.Show($"Du har tagit ut: {cashWd} SEK" +
                                        $"\nfrån ditt Konto nummer: {dataBase.accountNrDb}");
                    }

                }
                
                
                    
            }
            catch
            {
                lbinvWd.Text = "Invalid inmatning.";

            }

        }

        private void btnOkeyWith_Click(object sender, EventArgs e)
        {
            withdraw();

        }

        private void txtcashWd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                withdraw();

            }
            lbstarWd.Text = "";
            lbinvWd.Text = "";
            lbMaxWd.ForeColor = Color.DodgerBlue;
        }
    }
        
}
