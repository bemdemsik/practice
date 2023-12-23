// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopServices.Model;
using MySql.Data.MySqlClient;
using shopServices.Messages;
namespace shopServices.MySql
{
    class Requests
    {
        static public User GetUser(string column, string value)
        {
            User user = new User();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select *, (select role from roles where id=idrole) as rol from users where "+column+"="+ value);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.id = reader.GetInt32("id");
                    user.name = reader.GetString("name");
                    user.surname = reader.GetString("surname");
                    user.lastname = reader.GetString("lastname");
                    user.role = reader.GetString("rol");
                    user.telephone = reader.GetString("telephone");
                    user.happy = reader.GetString("happy");
                    user.password = reader.GetString("password");
                    user.login = reader.GetString("login");
                }
                reader.Close();
            }
            catch (Exception err)
            {
                MessageError.Show(err.Message);
            }
            finally
            {
                con.Close();
            }
            return user;
        }
        static public bool UniversalRequest(string request)
        {
            bool checkDelete = true;
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(request);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageError.Show(err.Message);
                checkDelete = false;
            }
            finally
            {
                con.Close();
            }
            return checkDelete;
        }
    }
}
