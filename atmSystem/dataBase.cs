using atmSystem;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmMachine
{
    public class dataBase
    {
        //You must change to your database 

        public static string server = "localhost";
        public static string database = "cusdata";
        public static string user = "root";
        public static string pass = "Xy7ce2e2";   // <------ write your database password here


        //From data base
        public static int accountNrDb { get; set; }
        public static int newAccNrDb { get; set; }
        public static string pinDb { get; set; }
        public static string newPinDb { get; set; }

        public static string fullNameDb { get; set; }
        public static string emailDb { get; set; }
        public static string balanceDb { get; set; }

        //to data base 
        public static int accountNr { get; set; }
        public static string pin { get; set; }
        public static string fullName { get; set; }
        public static string email { get; set; }
        public static string balance { get; set; }
        public static string type { get; set; }
        public static int amount { get; set; }

        //Connect database 

        MySqlConnection conn = new MySqlConnection($"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};");

        //Get data from database 
        internal void getData()
        {
            Login login = new Login();



            string Query = "SELECT * FROM  cusdata.useracc WHERE accNr= '" + accountNr + "' ";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                accountNrDb = (int)reader["accNr"];

                pinDb = (string)reader["pin"];
                fullNameDb = (string)reader["fullName"];
                emailDb = (string)reader["email"];
                balanceDb = (string)reader["balance"];


            }
            conn.Close();
        }

        //insert data from database 
        internal void insertData()
        {

            MessageBox.Show($"{pin} {fullName} {email} {newAccNrDb} {balance} ");
            string query = "UPDATE cusdata.useracc SET pin= '" + pin + "' , fullName= '" + fullName + "' , email= '" + email + "'  , balance= '" + balance + "' WHERE accNr = " + newAccNrDb + "";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQueryAsync();

            conn.Close();

        }
        
        //New balace to balace column
        internal void newBalance()
        {

            string query = "UPDATE cusdata.useracc SET balance= '" + Home.newBalance + "' WHERE accNr = " + accountNr + "";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQueryAsync();


            conn.Close();

        }
        
        //Change current pin in pin column
        internal void newPin()
        {

            string query = "UPDATE useracc SET pin= '" + Profile.newPin + "' WHERE accNr = '" + accountNr + "'";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQueryAsync();

            conn.Close();
        }
        
        
        internal void miniStatement()
        {
            Random rand = new Random();
            Home home = new Home();


            if (Home.cashDp == 0)
            {
                amount = Home.cashWd;
                type = "Withdraw";
            }
            else if (Home.cashWd == 0)
            {
                amount = Home.cashDp;
                type = "Deposite";
            }



            string insertQuery = "insert into  cusdata.ministat (accNr, type, amount, dateTime) " +
                                 "values ( '" + accountNr + "','" + type + "','" + amount + "','" + DateTime.Now + "')";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            var ds = new DataSet();



            cmd.ExecuteReader();
            conn.Close();
        }



        internal void createAcc()
        {
            lastAccNr();
            //MessageBox.Show($"{newPinDb} create");


            if (newPinDb != "0")
            {
                string query = "insert into  cusdata.useracc (pin, fullName, email, balance) values (0, 0, 0, 0 )";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var ds = new DataSet();



                cmd.ExecuteReader();



                conn.Close();
            }
            else
            {

            }

        }

        internal void lastAccNr()
        {


            string query = "SELECT  * FROM cusdata.useracc order by accNr desc limit 1";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                newAccNrDb = (int)reader["accNr"];
                newPinDb = (string)reader["pin"];
                MessageBox.Show($"new acc {newAccNrDb} pin {newPinDb}");
            }
            conn.Close();
        }
    }
}
