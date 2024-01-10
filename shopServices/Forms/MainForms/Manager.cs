// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using shopServices.Forms.Auth;
using shopServices.Forms.Orders;
using shopServices.Forms.Service;
using shopServices.Forms.Service.AnimatedImages;
using shopServices.Forms.Users;
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

namespace shopServices.MainForms
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            label2.Text = AuthUser.roleUser + ": " + AuthUser.fioUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowUsers q = new ShowUsers();
            q.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowService q = new ShowService();
            q.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowAnimatedImages q = new ShowAnimatedImages();
            q.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOrders q = new ShowOrders();
            q.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyDataTable.Backup();
            this.Hide();
            Authh q = new Authh();
            q.ShowDialog();
        }
    }
}
