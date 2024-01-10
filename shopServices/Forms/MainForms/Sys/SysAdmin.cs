// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using MySqlX.XDevAPI.Relational;
using shopServices.Forms.Auth;
using shopServices.Forms.MainForms;
using shopServices.Forms.MainForms.Sys;
using shopServices.Messages;
using shopServices.Model;
using shopServices.MySql;
using System;
using System.IO;
using System.Windows.Forms;

namespace shopServices.MainForms.Sys
{
    public partial class SysAdmin : Form
    {
        public SysAdmin()
        {
            InitializeComponent();
            label2.Text = AuthUser.roleUser + ": " + AuthUser.fioUser;
        }

        private void SysAdmin_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyDataTable.Backup();
            this.Hide();
            Authh q = new Authh();
            q.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportAndExportData q = new ImportAndExportData();
            q.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectFormsSysAdmin q = new SelectFormsSysAdmin();
            q.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] qwe = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.sql");
            for (int i = 0; i < qwe.Length; i++)
                comboBox1.Items.Add(Path.GetFileName(qwe[i]));
            if (comboBox1.Items.Count == 0)
            {
                MessageWarning.Show("Не найдено ни одного скрипта для восстановления");
                return;
            }
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                MessageWarning.Show("Вы не выбрали файл");
                return;
            }
            MyDataTable.Restore(comboBox1.Text);
        }
    }
}
