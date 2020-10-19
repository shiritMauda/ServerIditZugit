using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DALsweets : IDisposable
    {
        private MySqlConnection connection;
        //private string server;
        //private string database;
        //private string uid;
        //private string password;

        //Constructor
        public DALsweets()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //server = "localhost";
            //database = "sweets";
            //uid = "SweetWeb";
            //password = "21062911aA!";
            //string connectionString;
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //connection = new MySqlConnection(connectionString);
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["iditZugit"].ConnectionString);
            try
            {
                //open connection to database
                connection.Open();

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Debug.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Debug.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
        }


        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public MySqlDataReader ExecuteReader(String query, List<MySqlParameter> sqlparams)
        {

            MySqlCommand Command = new MySqlCommand(query, connection);

            if (!sqlparams.Any())
            {
                foreach (var parameter in sqlparams)
                {
                    Command.Parameters.Add(parameter);
                }
            }
            try
            {
                return Command.ExecuteReader();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                throw ex;
            }
        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //    //Insert statement
        //    public void Insert()
        //    {
        //        string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

        //        //open connection
        //        if (this.OpenConnection() == true)
        //        {
        //            //create command and assign the query and connection from the constructor
        //            MySqlCommand cmd = new MySqlCommand(query, connection);

        //            //Execute command
        //            cmd.ExecuteNonQuery();

        //            //close connection
        //            this.CloseConnection();
        //        }
        //    }

        //    //Update statement
        //    public void Update()
        //    {
        //        string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

        //        //Open connection
        //        if (this.OpenConnection() == true)
        //        {
        //            //create mysql command
        //            MySqlCommand cmd = new MySqlCommand();
        //            //Assign the query using CommandText
        //            cmd.CommandText = query;
        //            //Assign the connection using Connection
        //            cmd.Connection = connection;

        //            //Execute query
        //            cmd.ExecuteNonQuery();

        //            //close connection
        //            this.CloseConnection();
        //        }
        //    }

        //    //Delete statement
        //    public void Delete()
        //    {
        //        string query = "DELETE FROM tableinfo WHERE name='John Smith'";

        //        if (this.OpenConnection() == true)
        //        {
        //            MySqlCommand cmd = new MySqlCommand(query, connection);
        //            cmd.ExecuteNonQuery();
        //            this.CloseConnection();
        //        }
        //    }

        //    //Select statement
        //    public List<string>[] Select()
        //    {
        //        string query = "SELECT * FROM food";

        //        //Create a list to store the result
        //        List<string>[] list = new List<string>[3];
        //        list[0] = new List<string>();
        //        list[1] = new List<string>();
        //        list[2] = new List<string>();
        //        try
        //        {


        //            //Open connection
        //            if (this.OpenConnection() == true)
        //            {
        //                //Create Command
        //                MySqlCommand cmd = new MySqlCommand(query, connection);
        //                //Create a data reader and Execute the command
        //                MySqlDataReader dataReader = cmd.ExecuteReader();

        //                //Read the data and store them in the list
        //                while (dataReader.Read())
        //                {
        //                    list[0].Add(dataReader["id"] + "");
        //                    list[1].Add(dataReader["name"] + "");
        //                    list[2].Add(dataReader["age"] + "");
        //                }

        //                //close Data Reader
        //                dataReader.Close();

        //                //close Connection
        //                this.CloseConnection();

        //                //return list to be displayed
        //                return list;
        //            }
        //            else
        //            {
        //                return list;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Exception source: {0}", e.Source);
        //            return null;
        //        }
        //    }

        //    //Count statement
        //    public int Count()
        //    {
        //        string query = "SELECT Count(*) FROM tableinfo";
        //        int Count = -1;

        //        //Open Connection
        //        if (this.OpenConnection() == true)
        //        {
        //            //Create Mysql Command
        //            MySqlCommand cmd = new MySqlCommand(query, connection);

        //            //ExecuteScalar will return one value
        //            Count = int.Parse(cmd.ExecuteScalar() + "");

        //            //close Connection
        //            this.CloseConnection();

        //            return Count;
        //        }
        //        else
        //        {
        //            return Count;
        //        }
        //    }
        //}
    }
}
