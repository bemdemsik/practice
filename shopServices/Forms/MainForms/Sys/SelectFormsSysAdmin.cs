using shopServices.Forms.Orders;
using shopServices.Forms.Service;
using shopServices.Forms.Service.AnimatedImages;
using shopServices.Forms.Users;
using shopServices.MainForms.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopServices.Forms.MainForms
{
    public partial class SelectFormsSysAdmin : Form
    {
        public SelectFormsSysAdmin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SysAdmin q = new SysAdmin();
            q.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowUsers q = new ShowUsers();
            q.ShowDialog();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOrders q = new ShowOrders();
            q.ShowDialog();
        }
    }
}
