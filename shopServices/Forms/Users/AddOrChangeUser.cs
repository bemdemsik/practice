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
    public partial class AddOrChangeUser : Form
    {
        string idUser = string.Empty;
        string request = string.Empty;
        public AddOrChangeUser(string id)
        {
            idUser = id;
            InitializeComponent();
            buttonAddOrChangeUser.Text = "Изменить";
        }
        public AddOrChangeUser()
        {
            InitializeComponent();
            buttonAddOrChangeUser.Text = "Добавить";
        }

        private void AddAngChangeUser_Load(object sender, EventArgs e)
        {
            dateTimePickerHappy.CustomFormat = "yyyy-MM-dd";
            AddConditionInControlBoxs();
            if (buttonAddOrChangeUser.Text == "Изменить")
                FillUserData();
        }
        private void FillUserData()
        {
            User user = Requests.GetUser("id", idUser);
            textBoxSurname.Text = user.surname;
            textBoxName.Text = user.name;
            textBoxLastName.Text = user.lastname;
            dateTimePickerHappy.Text = user.happy;
            maskedTextBoxTelephone.Text = user.telephone;
            comboBoxRole.Text = user.role;
            textBoxLogin.Text = user.login;
            textBoxPassword.Text = textBoxPassword1.Text = user.password;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!CheckOnNullData())
            {
                MessageWarning.Show("Заполните все поля");
                return;
            }
            if(textBoxPassword.Text != textBoxPassword1.Text)
            {
                MessageWarning.Show("Пароли не совпадают");
                return;
            }
            if (buttonAddOrChangeUser.Text == "Добавить")
                request = "insert into users(name,surname,lastname,login,happy,telephone,password,idrole) values("
                    + "'" + textBoxName.Text + "',"
                    + "'" + textBoxSurname.Text + "',"
                    + "'" + textBoxLastName.Text + "',"
                    + "'" + textBoxLogin.Text + "',"
                    + "'" + dateTimePickerHappy.Text + "',"
                    + "'" + maskedTextBoxTelephone.Text + "',"
                    + "'" + textBoxPassword.Text + "',"
                    + "(select id from roles where role='" + comboBoxRole.Text + "'))";
            else request = "update users set name='" + textBoxName.Text + "'"
                    + ",surname='" + textBoxSurname.Text + "'"
                    + ",lastname='" + textBoxLastName.Text + "'"
                    + ",login='" + textBoxLogin.Text + "'"
                    + ",happy='" + dateTimePickerHappy.Text + "'"
                    + ",telephone='" + maskedTextBoxTelephone.Text + "'"
                    + ",password='" + textBoxPassword.Text + "'"
                    + ",idrole=(select id from roles where role='" + comboBoxRole.Text + "')"
                    + " where id=" + idUser;

            if (Requests.UniversalRequest(request))
            {
                MessageSuccess.Show("Операция выполнена успешна");
                this.Close();
            }
            else MessageError.Show("Операция не выполнена");
        }

        private bool CheckOnNullData()
        {
            if (!maskedTextBoxTelephone.MaskFull)
            {
                return false;
            }
            foreach(TextBox control in this.Controls.OfType<TextBox>())
            {
                try
                {
                    if (control.Text.Trim() == string.Empty)
                        return false;
                }
                catch (NullReferenceException err)
                {
                    continue;
                }
            }
            return true;
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

        private void buttonGeneratorLogin_Click(object sender, EventArgs e)
        {
            string simbols = "qwertyuioplkjhgfdsazxcvbnm1234567890";
            textBoxLogin.Text = "login";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                textBoxLogin.Text += simbols[random.Next(simbols.Length - 1)];
            }
        }

        private void buttonGeneratorPassword_Click(object sender, EventArgs e)
        {
            string simbols = "qwertyuioplkjhgfdsazxcvbnm1234567890";
            textBoxPassword1.Text = textBoxPassword.Text = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                textBoxPassword.Text = textBoxPassword1.Text += simbols[random.Next(simbols.Length - 1)];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = textBoxPassword1.UseSystemPasswordChar = !textBoxPassword1.UseSystemPasswordChar;
            if(button1.Text == "Показать")
                button1.Text = "Скрыть";
            else button1.Text = "Показать";
        }
    }
}
