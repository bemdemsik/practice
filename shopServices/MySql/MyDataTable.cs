// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using shopServices.Messages;
using System.IO;
using System.Windows.Forms;
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
                MySqlCommand cmd = new MySqlCommand(request, con);
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
        public static void Backup()
        {
            string path = Directory.GetCurrentDirectory() + "\\shop " + DateTime.Now.ToString().Replace(":", "-") + ".sql";
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup back = new MySqlBackup(cmd);
                cmd.Connection = con;
                back.ExportToFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить резервное копирование\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public static void Restore(string File)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + File;
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup back = new MySqlBackup(cmd);
                cmd.Connection = con;
                back.ImportFromFile(path);
                MessageBox.Show("База данных была успешно восстановлена", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить восстановление БД\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
