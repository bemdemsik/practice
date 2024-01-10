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
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
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
                MySqlCommand cmd = new MySqlCommand("select *, (select role from roles where id=idrole) as rol from users where " + column + "='" + value + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.id = reader.GetInt32("id");
                    user.name = reader.GetString("name");
                    user.surname = reader.GetString("surname");
                    user.lastname = reader.GetString("lastname");
                    user.role = reader.GetString("rol");
                    user.telephone = reader.GetValue(6).ToString();
                    user.happy = reader.GetValue(5).ToString();
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

        static public List<Master> GetAllMaster(string where)
        {
            List<Master> listUser = new List<Master>();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select concat(name, ' ', surname, ' ', lastname) as 'fio' from users where idrole=(select id from roles where role='Мастер') " + where, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Master master = new Master
                    {
                        fio = reader.GetValue(0).ToString(),
                    };
                    listUser.Add(master);
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
            return listUser;
        }
        static public Order GetOrderById(string id)
        {
            Order order = new Order();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select (select concat(name, ' ', surname, ' ', lastname) from users where id=idmaster) as 'Мастер', telephoneClient as 'Тел. клиента',(select duration from mainservice where id=idmainservice) as 'Длительность',(select nameimages from animatedimages where id=idanimatedimages) as 'Анимационный образ',day as 'День',timeIn as 'Начало',timeOut 'Конец',price as 'Цена' from orders where id=" + id, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    order = new Order
                    {
                        fioMaster = reader.GetValue(0).ToString(),
                        telephoneClient = reader.GetValue(1).ToString(),
                        duration = reader.GetValue(2).ToString(),
                        animatedImage = reader.GetValue(3).ToString(),
                        day = reader.GetValue(4).ToString(),
                        timeIn = reader.GetValue(5).ToString(),
                        timeout = reader.GetValue(6).ToString(),
                        price = reader.GetDouble(7),
                    };
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
            return order;
        }
        static public List<Services> GetStructureOrderById(string id)
        {
            List<Services> listService = new List<Services>();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select (select nameservice from service where id=idservice), price from structureorders where idorder=" + id, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Services service = new Services
                    {
                        nameservice = reader.GetValue(0).ToString(),
                        price = reader.GetDouble(1),
                    };
                    listService.Add(service);
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
            return listService;
        }

        static public List<Services> GetAllService()
        {
            List<Services> listServices = new List<Services>();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from service", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Services service = new Services
                    {
                        nameservice = reader.GetValue(1).ToString(),
                        price = reader.GetDouble(2),
                        count = reader.GetInt32(3),
                    };
                    listServices.Add(service);
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
            return listServices;
        }
        static public List<Images> GetAllImages()
        {
            List<Images> listServices = new List<Images>();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from animatedimages", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Images service = new Images
                    {
                        nameimages = reader.GetValue(1).ToString(),
                        price = reader.GetDouble(2),
                    };
                    listServices.Add(service);
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
            return listServices;
        }

        static public List<MainService> GetAllMainServices()
        {
            List<MainService> listServices = new List<MainService>();
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from mainservice", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MainService service = new MainService
                    {
                        duration = reader.GetDouble(2),
                        price = reader.GetDouble(1),
                    };
                    listServices.Add(service);
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
            return listServices;
        }

        static public string[] GetOneService(string column, string value)
        {
            string[] services = new string[0];
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from service where "+column+"='"+value+"'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; ; i++)
                    {
                        Array.Resize(ref services, services.Length + 1);
                        services[i] = reader.GetValue(i + 1).ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception err) {}
            finally
            {
                con.Close();
            }
            return services;
        }
        static public string[] GetOneMainService(string column, string value)
        {
            string[] services = new string[0];
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from mainservice where " + column + "='" + value + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; ; i++)
                    {
                        Array.Resize(ref services, services.Length + 1);
                        services[i] = reader.GetValue(i + 1).ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
            return services;
        }
        static public string[] GetOneImage(string column, string value)
        {
            string[] images = new string[0];
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from animatedimages where "+column+"='"+value+"'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(int i = 0; ; i++)
                    {
                        Array.Resize(ref images, images.Length + 1);
                        images[i] = reader.GetValue(i + 1).ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception err) {}
            finally
            {
                con.Close();
            }
            return images;
        }
        static public bool UniversalRequest(string request)
        {
            bool checkDelete = true;
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(request, con);
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
        static public string GetOneValue(string request)
        {
            string value = string.Empty;
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(request, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                value = reader.GetValue(0).ToString();
                reader.Close();
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
            return value;
        }
    }
}
