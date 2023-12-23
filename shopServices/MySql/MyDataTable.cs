// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using shopServices.Messages;
namespace shopServices.MySql
{
    class MyDataTable
    {
        static public DataTable GetData(string request)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(request);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
            }
            catch(Exception err)
            {
                MessageError.Show(err.Message);
            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }
    }
}
