using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using shopServices.Messages;
namespace shopServices.MySql
{
    class TransactionOrder
    {
        static public bool ToFormOrder(List<string> requests)
        {
            bool b = true;
            MySqlConnection con = new MySqlConnection(StringConnection.GetStringConnection);
            con.Open();
            MySqlTransaction mySqlTransaction = con.BeginTransaction();
            try
            {
                MySqlCommand cmd;
                for(int i =0; i < requests.Count; i++)
                {
                    if (requests[i] == string.Empty)
                        continue;
                    cmd = new MySqlCommand(requests[i], con, mySqlTransaction);
                    cmd.ExecuteNonQuery();
                }
                mySqlTransaction.Commit();
            }
            catch (Exception err)
            {
                mySqlTransaction.Rollback();
                MessageError.Show(err.Message);
                b = !b;
            }
            finally
            {
                con.Close();
            }
            return b;
        }
    }
}
