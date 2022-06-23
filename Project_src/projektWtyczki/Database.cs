using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace projektWtyczki
{
    class Database
    {
       

        public Database()
        {

        }


        static public void FillDataGrid(DataGrid dataGrid, string table,string query)

        {
            string connectionString = @"Data Source=DESKTOP-031P31K;Initial Catalog=Plugins;User ID=sa;Password=zaq1";
            string cmdString = query;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable(table);

                sda.Fill(dt);
                //MessageBox.Show("Connection Open  !");
                dataGrid.DataContext = dt.DefaultView;
                sda.Dispose();

            }

        }

        static public void UpdateRow(string table, string query)
        {
            string connectionString = @"Data Source=DESKTOP-031P31K;Initial Catalog=Plugins;User ID=sa;Password=zaq1";
            string cmdString = query;
            SqlCommand command;
            SqlDataAdapter adapt = new SqlDataAdapter();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
           
                command = new SqlCommand(query, con);

                adapt.UpdateCommand =new SqlCommand(query,con);
                adapt.UpdateCommand.ExecuteNonQuery();
                    command.Dispose();
            con.Close();
        }

        static public string validateMorT(string maker)
        {
            string temp = "0";
            if(maker.All(Char.IsDigit))
            {
                return maker;
            }
            else
            {
                return temp;
            }
        }
        static public string validateInstOrEff(string type)
        {
            string temp = "Other";
            if (type=="Instrument" || type =="Effect" || type=="Other")
            {
                return type;
            }
            else
            {
                return temp;
            }
        }

        static public void AddRow(DataGrid dataGrid, string table, string query)
        {
            string connectionString = @"Data Source=DESKTOP-031P31K;Initial Catalog=Plugins;User ID=sa;Password=zaq1";
       
            SqlCommand command;
            SqlDataAdapter adapt = new SqlDataAdapter();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            command = new SqlCommand(query, con);

            adapt.InsertCommand = new SqlCommand(query, con);
            adapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            con.Close();
        }
        static public int countRows(string table)
        {
            string connectionString = @"Data Source=DESKTOP-031P31K;Initial Catalog=Plugins;User ID=sa;Password=zaq1";
            string query = "SELECT COUNT(*) FROM "+table+";";
            SqlCommand command;
            SqlDataAdapter adapt = new SqlDataAdapter();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            command = new SqlCommand(query, con);

            adapt.InsertCommand = new SqlCommand(query, con);
            adapt.InsertCommand.ExecuteNonQuery();

            return (int)command.ExecuteScalar();
            command.Dispose();
            con.Close();
        }
        }
    }

