using shopServices.MainForms.Sys;
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

namespace shopServices.Forms.MainForms.Sys
{
    public partial class ImportAndExportData : Form
    {
        public ImportAndExportData()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SysAdmin q = new SysAdmin();
            q.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBoxTable.Text == string.Empty)
            {
                MessageWarning.Show("Виберите таблицу");
                return;
            }
            if (ImportAndExportReferences.ExportData(comboBoxTable.Text))
                MessageSuccess.Show("Эспорт данных произведен успешно");
            else MessageError.Show("При экспорте данных возникли ошибки, попробуйте позже");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxTable.Text == string.Empty)
            {
                MessageWarning.Show("Виберите таблицу");
                return;
            }
            if(ImportAndExportReferences.ImportData(comboBoxTable.Text))
                MessageSuccess.Show("Импорт данных произведен успешно");
            else MessageError.Show("При импорте данных возникли ошибки, попробуйте позже");
        }

        private void ImportAndExportData_Load(object sender, EventArgs e)
        {
            comboBoxTable.Items.Add("orders"); 
            comboBoxTable.Items.Add("service");
            comboBoxTable.Items.Add("animatedimages");
            comboBoxTable.Items.Add("users");
        }
    }
}
