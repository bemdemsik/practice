// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using shopServices.MainForms;
using shopServices.Messages;
using shopServices.MySql;
using shopServices.Model;
using shopServices.MainForms.Sys;

namespace shopServices.Forms.Users
{
    public partial class ShowUsers : Form
    {
        int numberPage = 1;
        int countPage = 0;
        int rowId = 0;
        int countRows = 0;
        string cells = string.Empty;
        string idUser = string.Empty;
        string orderBy = string.Empty;
        string filter = string.Empty;
        string serch = string.Empty;
        string limit = string.Empty;
        readonly string requestUsers = "select id, concat(name, ' ', surname, ' ', lastname) as 'ФИО', telephone as 'Телефон', happy as 'День рождение', (select role from roles where id=idrole) as 'Роль' from users ";
        public ShowUsers()
        {
            InitializeComponent();
        }

        private void ShowUsersTable()
        {
            try
            {
                limit = " limit " + ((numberPage - 1) * 10) + ",10 ";
                dataGridView1.DataSource = MyDataTable.GetData(requestUsers + filter + serch + orderBy + limit);
                countRows = MyDataTable.GetData(requestUsers + filter + serch + orderBy).Rows.Count;
                labelCountRows.Text = countRows.ToString();
                countPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countRows / 10.0)));
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["ФИО"].Width = 500;
                UI();
            }
            catch (Exception err)
            {
                MessageError.Show(err.Message);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateSerch();
            ShowUsersTable();        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateOrderBy();
            ShowUsersTable();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
            ShowUsersTable();
        }

        private void updateSerch()
        {
            serch = " order by case when lower(name) like '" + textBoxSerch.Text.ToLower().Trim() + "%' then 1 when lower(surname) like '" + textBoxSerch.Text.ToLower().Trim() + "%' then 2 when lower(lastname) like '" + textBoxSerch.Text.ToLower().Trim() + "%' then 3 else 4 end";
            if (textBoxSerch.Text.Trim().Length == 0)
                serch = string.Empty;
            updateOrderBy();
        }
        private void updateFilter()
        {
            filter = " where idrole=(select id from roles where role='" + comboBoxFilter.Text + "') ";
            if (comboBoxFilter.Text == "Нет")
                filter = string.Empty;
        }
        private void updateOrderBy()
        {
            orderBy = " surname ";
            if (string.IsNullOrEmpty(serch.Trim()))
                orderBy = " order by " + orderBy;
            else orderBy = ", " + orderBy;

            if (comboBoxOrderBy.Text == "Нет" || comboBoxOrderBy.Text == string.Empty)
                orderBy = string.Empty;
            else if (comboBoxOrderBy.Text == "По убыванию") orderBy += " desc";

        }

        private void labelNextPage_Click(object sender, EventArgs e)
        {
            numberPage++;
            ShowUsersTable();
        }

        private void labelBackPage_Click(object sender, EventArgs e)
        {
            numberPage--;
            ShowUsersTable();
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

        private void ShowUsers_Load(object sender, EventArgs e)
        {
            ShowUsersTable();
            AddUpdateAndDeleteColumn();
            AddConditionInControlBoxs();
        }
        private void AddConditionInControlBoxs()
        {
            comboBoxFilter.Items.Add("Нет");
            comboBoxFilter.Items.Add("Администратор");
            comboBoxFilter.Items.Add("Мастер");
            comboBoxFilter.Items.Add("Управляющий");
            comboBoxFilter.Items.Add("Системный администратор");
            comboBoxOrderBy.Items.Add("Нет");
            comboBoxOrderBy.Items.Add("По убыванию");
            comboBoxOrderBy.Items.Add("По возрастанию");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                rowId = e.RowIndex;
                cells = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                idUser = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Удалить")
            {
                if (MessageBox.Show("Вы уверены что хотите удалить данного пользователя?", "Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    if (Requests.UniversalRequest("delete from users where id=" + idUser))
                        MessageSuccess.Show("Операция выполнена успешна");
                    else MessageError.Show("Операция не выполнена");
                    ShowUsersTable();
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Изменить")
            {
                AddOrChangeUser q = new AddOrChangeUser(idUser);
                q.FormClosed += Q_FormClosed;
                q.ShowDialog();
            }
        }

        private void Q_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowUsersTable();
            dataGridView1.Rows[rowId].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrChangeUser q = new AddOrChangeUser();
            q.FormClosed += Q_FormClosed1; ;
            q.ShowDialog();
        }

        private void Q_FormClosed1(object sender, FormClosedEventArgs e)
        {
            ShowUsersTable();
        }
    }
}
