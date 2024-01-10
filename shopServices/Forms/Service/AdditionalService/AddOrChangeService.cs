using shopServices.Messages;
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

namespace shopServices.Forms.Service.AdditionalService
{
    public partial class AddOrChangeService : Form
    {
        int checkCount = 0;
        string idService = string.Empty;
        string request = string.Empty;
        public AddOrChangeService(string idServices)
        {
            idService = idServices;
            InitializeComponent();
            buttonAddOrChangeService.Text = "Изменить";
        }

        public AddOrChangeService()
        {
            InitializeComponent();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkCount = 1;
            else checkCount = 0;
        }
        private bool CheckOnNullData()
        {
            foreach (TextBox control in this.Controls.OfType<TextBox>())
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

        private void buttonAddOrChangeUser_Click(object sender, EventArgs e)
        {
            if (!CheckOnNullData())
            {
                MessageWarning.Show("Заполните все поля");
                return;
            }
            if (buttonAddOrChangeService.Text == "Добавить")
                request = "insert into service(nameservice,price,count) values("
                    + "'" + textBoxNameService.Text + "',"
                    + "'" + textBoxPrice.Text + "',"
                    + "'" + checkCount + "')";
            else request = "update service set nameservice='" + textBoxNameService.Text + "'"
                    + ",price='" + textBoxPrice.Text + "'"
                     + ",count='" + checkCount + "'"
                    + " where id=" + idService;

            if (Requests.UniversalRequest(request))
            {
                MessageSuccess.Show("Операция выполнена успешна");
                this.Close();
            }
            else MessageError.Show("Операция не выполнена");
        }
        private void FillServiceData()
        {
            try
            {
                string[] service = Requests.GetOneService("id", idService);
                textBoxNameService.Text = service[0];
                textBoxPrice.Text = service[1];
                checkBox1.Checked = service[2] == "True";
            }
            catch
            {
                MessageError.Show("Не в курсе");
                return;
            }
        }
        private void AddOrChangeService_Load(object sender, EventArgs e)
        {
            if (buttonAddOrChangeService.Text == "Изменить")
                FillServiceData();
        }
    }
}
