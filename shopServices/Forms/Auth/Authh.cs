// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shopServices.MySql;
using shopServices.Messages;
using shopServices.Model;
using shopServices.MainForms;
using shopServices.MainForms.Sys;

namespace shopServices.Forms.Auth
{
    public partial class Authh : Form
    {
        int countSecond = 10;
        public Authh()
        {
            InitializeComponent();
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = Requests.GetUser("login", textBoxLogin.Text);

            if (groupBox1.Visible)
            {
                if (!CheckCapcha())
                {
                    MessageError.Show("Неверная капча");
                    EnabledControl();
                    timer1.Start();
                    labelCapcha.Text = GetTextCapcha();
                    return;
                }
            }

            if (user.login != textBoxLogin.Text || user.password != textBoxPassword.Text)
            {
                MessageError.Show("Неверные данные");
                if (groupBox1.Visible)
                {
                    EnabledControl();
                    timer1.Start();
                }
                groupBox1.Visible = true;
                labelCapcha.Text = GetTextCapcha();
                return;
            }
            AuthUser.roleUser = user.role;
            AuthUser.idUser = user.id;
            AuthUser.fioUser = user.surname + " " + user.name + " " + user.lastname;
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
        private bool CheckCapcha()
        {
            return textBoxCapcha.Text == labelCapcha.Text;
        }
        private string GetTextCapcha()
        {
            string simbols = "qwertyuioplkjhgfdsazxcvbnm1234567890";
            string capcha = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                capcha += simbols[random.Next(simbols.Length - 1)];
            }
            return capcha;
        }

        private void EnabledControl()
        {
            foreach (Control control in this.Controls)
                control.Enabled = !control.Enabled;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (countSecond <= 1)
            {
                button1.Text = "Войти";
                EnabledControl();
                timer1.Stop();
            }
            button1.Text = countSecond-- + " сек...";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
