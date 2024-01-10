using shopServices.MainForms;
using shopServices.MainForms.Sys;
using shopServices.Messages;
using shopServices.Model;
using shopServices.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopServices.Forms.Orders
{
    public partial class ShowOrders : Form
    {
        int numberPage = 1;
        int countPage = 0;
        int rowId = 0;
        int countRows = 0;
        string whereMaster = string.Empty;
        string cells = string.Empty;
        string idOrder = string.Empty;
        string limit = string.Empty;
        readonly string requestOrders = "select id,(select concat(name, ' ', surname, ' ', lastname) from users where id=idmaster) as 'Мастер'," +
            "telephoneClient as 'Тел. клиента', " +
            "(select duration from mainservice where id=idmainservice) as 'Длительность'," +
            "(select nameimages from animatedimages where id=idanimatedimages) as 'Анимационный образ'," +
            "day as 'День'," +
            "timeIn as 'Начало'," +
            "timeOut 'Конец'," +
            "price as 'Цена'" +
            " from orders ";

        private void ShowOrdersTable()
        {
            try
            {
                limit = " limit " + ((numberPage - 1) * 10) + ",10 ";
                dataGridView1.DataSource = MyDataTable.GetData(requestOrders + whereMaster + limit);
                countRows = MyDataTable.GetData(requestOrders).Rows.Count;
                labelCountRows.Text = countRows.ToString();
                countPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countRows / 10.0)));
                dataGridView1.Columns["id"].Visible = false;
                UI();
            }
            catch (Exception err)
            {
                MessageError.Show(err.Message);
            }
        }

        public ShowOrders()
        {
            InitializeComponent();
        }

        private void ShowOrders_Load(object sender, EventArgs e)
        {
            if (AuthUser.roleUser == "Мастер")
                whereMaster = " where idmaster="+AuthUser.idUser;
            ShowOrdersTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (AuthUser.roleUser)
            {
                case "Администратор":
                    {
                        this.Hide();
                        AdminAndMaster q = new AdminAndMaster();
                        q.ShowDialog();
                        break;
                    }
                case "Мастер":
                    {
                        this.Hide();
                        AdminAndMaster q = new AdminAndMaster();
                        q.ShowDialog();
                        break;
                    }
                case "Управляющий":
                    {
                        this.Hide();
                        Manager q = new Manager();
                        q.ShowDialog();
                        break;
                    }
                case "Системный администратор":
                    {
                        this.Hide();
                        SysAdmin q = new SysAdmin();
                        q.ShowDialog();
                        break;
                    }
                default: return;
            }
        }

        private void labelNextPage_Click(object sender, EventArgs e)
        {
            numberPage++;
            ShowOrdersTable();
        }

        private void labelBackPage_Click(object sender, EventArgs e)
        {
            numberPage--;
            ShowOrdersTable();
        }
        private void UI()
        {
            labelNextPage.Enabled = true;
            labelBackPage.Enabled = true;
            if (numberPage == countPage)
                labelNextPage.Enabled = false;
            if (numberPage == 1)
                labelBackPage.Enabled = false;
            labelPage.Text = numberPage + "/" + countPage;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                rowId = e.RowIndex;
                cells = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                idOrder = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
            catch
            {
                return;
            }
                AddOrChangeOrder q = new AddOrChangeOrder(idOrder);
                q.FormClosed += Q_FormClosed;
                q.ShowDialog();
        }

        private void Q_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowOrdersTable();
            dataGridView1.Rows[rowId].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrChangeOrder q = new AddOrChangeOrder();
            q.FormClosed += Q_FormClosed1;
            q.ShowDialog();
        }

        private void Q_FormClosed1(object sender, FormClosedEventArgs e)
        {
            ShowOrdersTable();
        }
    }
}
