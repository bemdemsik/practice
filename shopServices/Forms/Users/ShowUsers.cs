using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shopServices.MainForms;
using shopServices.Messages;
using shopServices.MySql;

namespace shopServices.Forms.Users
{
    public partial class ShowUsers : Form
    {
        int numberPage = 1;
        int countPage = 0;
        string orderBy = string.Empty;
        string filter = string.Empty;
        string serch = string.Empty;
        string limit = string.Empty;
        readonly string requestUsers = "select id, concat(name, ' ', surname, ' ', lastname) as 'ФИО', telephone as 'Телефон', happy as 'День рождение', (select role from roles where id=idrole) as 'Роль' from users";
        public ShowUsers()
        {
            InitializeComponent();
        }

        private void ShowUsersTable()
        {
            limit = " limit 10," + (numberPage * 10);
            dataGridView1.DataSource = MyDataTable.GetData(requestUsers + serch + filter + limit + orderBy);
            countPage = dataGridView1.Rows.Count / 10;
            dataGridView1.Columns["id"].Visible = false;
            HidePersonalData();
            UI();
        }
        private void AddUpdateAndDeleteColumn()
        {
            DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            updateColumn.Name = "Измененить";
            deleteColumn.Name = "Удалить";
            dataGridView1.Columns.AddRange(updateColumn, deleteColumn);
        }
        private void HidePersonalData()
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateSerch();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateOrderBy();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void updateSerch()
        {
            serch = " where name like '%" + textBoxSerch.Text + "'";
            if (textBoxSerch.Text.Length == 0)
                serch = string.Empty;
            updateFilter();
        }
        private void updateFilter()
        {
            filter = " idrole=(select id from roles where role='" + comboBoxFilter.Text + "') ";
            if (comboBoxFilter.Text == "Нет")
                filter = string.Empty;
            if (string.IsNullOrEmpty(serch))
                filter = " where " + filter;
            else filter = " AND " + filter;
        }
        private void updateOrderBy()
        {
            orderBy = " order by surname";
            if (comboBoxOrderBy.Text == "Нет")
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
            this.Hide();
            Manager q = new Manager();
            q.ShowDialog();
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
            string idUser = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Удалить")
            {
                if(MessageBox.Show("Вы уверены что хотите удалить данного пользователя?", "Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    if (Requests.UniversalRequest("delete from users where id=" + idUser))
                        MessageSuccess.Show("Операция выполнена успешна");
                    else MessageError.Show("Операция не выполнена");
                    ShowUsersTable();
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Изменить")
            {
                AddAngChangeUser q = new AddAngChangeUser(idUser);
                q.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAngChangeUser q = new AddAngChangeUser();
            q.ShowDialog();
        }
    }
}
