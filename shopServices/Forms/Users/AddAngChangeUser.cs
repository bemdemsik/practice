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

namespace shopServices.Forms.Users
{
    public partial class AddAngChangeUser : Form
    {
        string idUser = string.Empty;
        string request = string.Empty;
        public AddAngChangeUser(string id)
        {
            idUser = id;
            InitializeComponent();
            buttonAddOrChangeUser.Text = "Изменить";
        }
        public AddAngChangeUser()
        {
            InitializeComponent();
            buttonAddOrChangeUser.Text = "Добавить";
        }

        private void AddAngChangeUser_Load(object sender, EventArgs e)
        {
            dateTimePickerHappy.CustomFormat = "yyyy-MM-dd";
            AddConditionInControlBoxs();
            if (!string.IsNullOrEmpty(idUser))
                FillUserData();
        }
        private void FillUserData()
        {
            User user = Requests.GetUser("id", idUser);
            textBoxSurname.Text = user.surname;
            textBoxName.Text = user.name;
            textBoxLastName.Text = user.lastname;
            dateTimePickerHappy.Text = user.happy;
            comboBoxRole.Text = user.role;
            textBoxLogin.Text = user.login;
            textBoxPassword.Text = textBoxPassword1.Text = user.password;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonAddOrChangeUser.Text == "Добавить")
                request = "insert into users(name,surname,lastname,login,happy,telephone,password,idrole) values("
                    +textBoxLastName.Text
                    +textBoxSurname.Text
                    +textBoxLastName.Text
                    +textBoxLogin.Text
                    +dateTimePickerHappy.Text
                    +maskedTextBoxTelephone.Text
                    +textBoxPassword.Text
                    +comboBoxRole.Text + ")";
            else request = "update users set name='"+textBoxName.Text
                    + ",surname='"+textBoxSurname.Text+"'"
                    + ",lastname='" + textBoxLastName.Text + "'"
                    + ",login='" + textBoxLogin.Text + "'"
                    + ",happy='" + dateTimePickerHappy.Text + "'"
                    + ",telephone='" + maskedTextBoxTelephone.Text + "'"
                    + ",password='" + textBoxPassword.Text + "'"
                    + ",idrole=(select id from roles where role='" + textBoxPassword.Text + "')"
                    + "' where id="+idUser;

            if (Requests.UniversalRequest(request))
                MessageSuccess.Show("Операция выполнена успешна");
            else MessageError.Show("Операция не выполнена");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void AddConditionInControlBoxs()
        {
            comboBoxRole.Items.Add("Администратор");
            comboBoxRole.Items.Add("Мастер");
            comboBoxRole.Items.Add("Управляющий");
            comboBoxRole.Items.Add("Системный администратор");
        }
    }
}
