// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using shopServices.Forms.Auth;
using shopServices.Forms.Orders;
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
    public partial class AdminAndMaster : Form
    {
        public AdminAndMaster()
        {
            InitializeComponent();
            label2.Text = AuthUser.roleUser + ": " + AuthUser.fioUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOrders q = new ShowOrders();
            q.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyDataTable.Backup();
            this.Hide();
            Authh q = new Authh();
            q.ShowDialog();
        }
    }
}
