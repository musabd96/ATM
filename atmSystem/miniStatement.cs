using atmMachine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmSystem
{
    public partial class miniStatement : Form
    {
        public miniStatement()
        {
            InitializeComponent();
            menuBarClose();
        }

        internal void miniStat()
        {
            MySqlConnection conn = new MySqlConnection($"SERVER={dataBase.server};DATABASE={dataBase.database};UID={dataBase.user};PASSWORD={dataBase.pass};");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM cusdata.ministat  WHERE accNr= '" + dataBase.accountNr + "'", conn);
            conn.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ministat");
            dataGridView1.DataSource = ds.Tables["ministat"];
            conn.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }


        // profile button
        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }


        //Serivce button
        private void btnService_Click(object sender, EventArgs e)
        {
            menuBarClose();

            MessageBox.Show($"Hello! {dataBase.fullNameDb}, " +
                            $"thank you for contacting us,\n " +
                            $"we'll be in touch very soon", "Customer service");
        }
        //logut button

        private void btnLogout_Click(object sender, EventArgs e)
        {
            menuBarClose();

            if (MessageBox.Show("Are you sure to logout?", "LOGOUT",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        //Menu bar close
        private void menuBarClose()
        {
            //Close menu bar
            picMenuBar.Dock = DockStyle.Right;
            lbMenuBar.Text = "";
            pnlMenuBar.Size = new Size(130, 99);
            btnHome.Visible = false;
        }


        //Menu bar open


        private void picMenuBar_Click(object sender, EventArgs e)
        {
            picMenuBar.Dock = DockStyle.Left;
            lbMenuBar.Text = "Menu";
            btnHome.Visible = true;
            pnlMenuBar.Size = new Size(130, 225);
        }
    }
}
