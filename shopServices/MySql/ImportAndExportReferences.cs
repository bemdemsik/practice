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
    internal class ImportAndExportReferences
    {
        public static bool ExportData(string nameTable)
        {
            bool result = true;

            DataTable dt = new DataTable();
            StreamWriter writer = null;

            try
            {
                dt = MyDataTable.GetData("select * from " + nameTable);

                string fileName = "exp_" + nameTable + ".csv";
                FileStream fs = null;
                fs = new FileStream(fileName, FileMode.OpenOrCreate);

                writer = new StreamWriter(fs, Encoding.UTF8);

                for (int i = 1, len = dt.Columns.Count - 1; i <= len; ++i)
                {
                    if (i != len)
                        writer.Write(dt.Columns[i].ColumnName + ";");
                    else writer.Write(dt.Columns[i].ColumnName);
                }

                writer.Write("\n");

                foreach (DataRow dataRow in dt.Rows)
                {
                    string r = String.Join(";", dataRow.ItemArray);
                    writer.WriteLine(r);
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
            return result;
        }
        public static bool ImportData(string nameTable)
        {
            bool result = true;
            StreamReader FILE = null;

            try
            {
                int row = 0;
                string[] array;
                string rowText = "";
                string values = "";
                string insertinto = "insert into " + nameTable;
                if (nameTable == "orders") insertinto += "(idmaster, telephoneClient, idmainservice, idanimatedimages,day,timeIn,timeOut,price) values";
                else if (nameTable == "users") insertinto += "(name,surname,lastname,login,happy,telephone,password,idrole) values";
                else if (nameTable == "animatedimages") insertinto += "(nameimages,price) values";
                else if (nameTable == "service") insertinto += "(nameservice,price,count) values";
                FILE = new StreamReader("exp_" + nameTable + ".csv");

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        values += ',';
                    }

                    array = rowText.Split(';');
                    values += "(";
                    for(int i = 1; i < array.Length; i++)
                    {
                        if(i > 1)
                            values += ",";
                        values = values + "'" + array[i] + "'";
                    }
                    values += ")";
                    row++;
                }

                bool isHave = Requests.UniversalRequest(insertinto + values);

                if (!isHave) { result = false; }
            }
            catch (Exception ex)
            { result = false; }
            finally
            {
                FILE.Close();
            }
            return result;
        }
    }
}
