using shopServices.Forms.Service.AdditionalService;
using shopServices.Forms.Users;
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

namespace shopServices.Forms.Service
{
    public partial class ShowService : Form
    {
        int numberPage = 1;
        int countPage = 0;
        int countRows = 0;
        int rowId = 0;
        string cells = string.Empty;
        string idService = string.Empty;
        string orderBy = string.Empty;
        string serch = string.Empty;
        string limit = string.Empty;
        readonly string requestService = "select id, nameservice as 'Название услуги',price as 'Цена',count from service";

        public ShowService()
        {
            InitializeComponent();
        }

        private void ShowService_Load(object sender, EventArgs e)
        {
            ShowServiceTable();
            AddUpdateAndDeleteColumn();
            AddConditionInControlBoxs();
            dataGridView1.Columns["Название услуги"].Width = 500;
        }
        private void AddUpdateAndDeleteColumn()
        {
            DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            updateColumn.UseColumnTextForButtonValue = true;
            updateColumn.Name = "Изменить";
            updateColumn.Text = "Изменить";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Name = "Удалить";
            deleteColumn.Text = "Удалить";
            dataGridView1.Columns.Add(updateColumn);
            dataGridView1.Columns.Add(deleteColumn);
        }

        private void ShowServiceTable()
        {
            try
            {
                limit = " limit " + ((numberPage - 1) * 10) + ",10 ";
                dataGridView1.DataSource = MyDataTable.GetData(requestService + serch + orderBy + limit);
                countRows = MyDataTable.GetData(requestService + serch + orderBy).Rows.Count;
                labelCountRows.Text = countRows.ToString();
                countPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countRows / 10.0)));
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["count"].Visible = false;
                dataGridView1.Columns["Название услуги"].Width = 500;
                UI();
            }
            catch (Exception err)
            {
                MessageError.Show(err.Message);
            }
        }

        private void textBoxSerch_TextChanged(object sender, EventArgs e)
        {
            updateSerch();
            ShowServiceTable();
        }

        private void comboBoxOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateOrderBy();
            ShowServiceTable();
        }
        private void updateSerch()
        {
            serch = " order by case when lower(nameservice) like '" + textBoxSerch.Text.ToLower().Trim() + "%' then 1 when lower(nameservice) like '%" + textBoxSerch.Text.ToLower().Trim() + "%' then 2 else 3 end";
            if (textBoxSerch.Text.Trim().Length == 0)
                serch = string.Empty;
            updateOrderBy();
        }
        private void updateOrderBy()
        {
            orderBy = " price ";
            if (string.IsNullOrEmpty(serch.Trim()))
                orderBy = " order by " + orderBy;
            else orderBy = ", " + orderBy;

            if (comboBoxOrderBy.Text == "Нет" || comboBoxOrderBy.Text == string.Empty)
                orderBy = string.Empty;
            else if (comboBoxOrderBy.Text == "По убыванию") orderBy += " desc";

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

        private void AddConditionInControlBoxs()
        {
            comboBoxOrderBy.Items.Add("Нет");
            comboBoxOrderBy.Items.Add("По убыванию");
            comboBoxOrderBy.Items.Add("По возрастанию");
        }

        private void labelNextPage_Click(object sender, EventArgs e)
        {
            numberPage++;
            ShowServiceTable();
        }

        private void labelBackPage_Click(object sender, EventArgs e)
        {
            numberPage--;
            ShowServiceTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (AuthUser.roleUser)
            {
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                rowId = e.RowIndex;
                cells = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                idService = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Удалить")
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данную услугу?", "Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    if (Requests.UniversalRequest("delete from service where id=" + idService))
                        MessageSuccess.Show("Операция выполнена успешна");
                    else MessageError.Show("Операция не выполнена");
                    ShowServiceTable();
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Изменить")
            {
                AddOrChangeService q = new AddOrChangeService(idService);
                q.FormClosed += Q_FormClosed2;
                q.ShowDialog();
            }
        }

        private void Q_FormClosed2(object sender, FormClosedEventArgs e)
        {
            ShowServiceTable();
            dataGridView1.Rows[rowId].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrChangeService q = new AddOrChangeService();
            q.FormClosed += Q_FormClosed;
            q.ShowDialog();
        }

        private void Q_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowServiceTable();
        }
    }
}
