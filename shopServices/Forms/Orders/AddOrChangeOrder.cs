using shopServices.Messages;
using shopServices.Model;
using shopServices.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopServices.Forms.Orders
{
    public partial class AddOrChangeOrder : Form
    {
        bool checkLoad = false;
        string requestAddOrChangeOrder = string.Empty;
        string requestAddOrChangeStructureOrder = string.Empty;
        string idOrder = string.Empty;
        Order order = new Order();
        public AddOrChangeOrder(string iOrder)
        {
            idOrder = iOrder;
            InitializeComponent();
        }
        public AddOrChangeOrder()
        {
            InitializeComponent();
        }

        private void AddOrChangeOrder_Load(object sender, EventArgs e)
        {
            dateTimePickerDay.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDay.MinDate = DateTime.Now;
            dateTimePickerIn.CustomFormat = "HH:mm";
            dateTimePickerIn.MinDate = DateTime.Now;
            dateTimePickerOut.CustomFormat = "HH:mm";
            AddColumnsInDataGridView();
            AddConditionInControlBoxs();
            labelCount.Visible = false;
            textBoxCount.Visible = false;
            button2.Visible = false;
            try
            {
                if (idOrder != string.Empty)
                {
                    button1.Text = "Сохранить";
                    List<Services> listService = Requests.GetStructureOrderById(idOrder);
                    foreach (Services service in listService)
                    {
                        comboBoxAddService.Text = service.nameservice;
                        AddService();
                    }
                    order = Requests.GetOrderById(idOrder);
                    comboBoxMaster.Text = order.fioMaster;
                    comboBoxDuration.Text = order.duration;
                    comboBoxAnimatedImages.Text = order.animatedImage;
                    maskedTextBoxTelephone.Text = order.telephoneClient;
                    comboBoxAddService.SelectedIndex = -1;
                    labelCostService.Text = string.Empty;
                    button2.Visible = false;
                    textBoxCount.Visible = false;
                    labelCount.Visible = false;
                    Requests.UniversalRequest("delete from structureorders where idorder=" + idOrder);
                }
            }
            catch
            {
                MessageError.Show("Не в курсе");
            }
            checkLoad = true;
        }
        private void AddConditionInControlBoxs()
        {
            comboBoxAnimatedImages.Items.Add(string.Empty);
            comboBoxAnimatedImages.DataSource = Requests.GetAllImages();
            comboBoxAnimatedImages.ValueMember = "nameimages";
            comboBoxAnimatedImages.SelectedIndex = -1;

            comboBoxAddService.Items.Add(string.Empty);
            comboBoxAddService.DataSource = Requests.GetAllService();
            comboBoxAddService.ValueMember = "nameservice";
            comboBoxAddService.SelectedIndex = -1;

            comboBoxDuration.DataSource = Requests.GetAllMainServices();
            comboBoxDuration.ValueMember = "duration";
            comboBoxDuration.SelectedIndex = -1;
            AddConditionMaster();
            labelCostAnimated.Text = labelCostMainService.Text = labelCostService.Text = string.Empty;
            labelCostOrder.Text = "0р.";
        }
        private void AddConditionMaster()
        {
            string whereOrder = string.IsNullOrEmpty(idOrder) ? string.Empty : " id=" + idOrder + " or " ;
            comboBoxMaster.DataSource = Requests.GetAllMaster(" and id not in (select idmaster from orders where " + whereOrder + " day='" + dateTimePickerDay.Text + "' and timeIn<'" + dateTimePickerIn.Value.ToString() + "' and timeOut>'" + dateTimePickerIn.Value.ToString() + "' and timeIn<'" + dateTimePickerOut.Value.ToString() + "' and timeOut>'" + dateTimePickerOut.Value.ToString() + "')");
            comboBoxMaster.ValueMember = "fio";
            comboBoxMaster.SelectedIndex = -1;
        }
        private void AddColumnsInDataGridView()
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxNameService = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dataGridViewTextBoxPrice = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.UseColumnTextForButtonValue = true;
            delete.Name = "Удалить";
            delete.Text = "Удалить";
            dataGridViewTextBoxNameService.Name = "Дополнительная услуга";
            dataGridViewTextBoxPrice.Name = "Цена";
            dataGridView1.Columns.AddRange(dataGridViewTextBoxNameService, dataGridViewTextBoxPrice, delete);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddService();
        }
        private void AddService()
        {
            try
            {
                if (textBoxCount.Visible)
                {
                    if (textBoxCount.Text.Length == 0 && checkLoad)
                    {
                        MessageWarning.Show("Укажите количество");
                        return;
                    }
                    string count = checkLoad ? textBoxCount.Text : Requests.GetOneValue("select (select price from structureorders where idorder='"+idOrder+"' and idservice=(select id from service where nameservice='"+comboBoxAddService.Text+ "'))/(select price from service where nameservice='"+comboBoxAddService.Text+"')");
                    labelCostService.Text = (Convert.ToDouble(labelCostService.Text.Replace("р.", "")) * Convert.ToInt32(count)).ToString() + "р.";
                }
                labelCount.Visible = false;
                textBoxCount.Visible = false;
                button2.Visible = false;
                labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) + Convert.ToDouble(labelCostService.Text.Replace("р.", ""))).ToString();
                dataGridView1.Rows.Add(comboBoxAddService.Text, labelCostService.Text);
                labelCostService.Text = string.Empty;
                comboBoxAddService.SelectedIndex = -1;
            }
            catch
            {
                MessageError.Show("Неверный формат данных");
            }
        }

        private void comboBoxAddService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button2.Visible = true;
                string[] dataService = Requests.GetOneService("nameservice", comboBoxAddService.Text);
                if (dataService[2] == "True")
                {
                    labelCount.Visible = true;
                    textBoxCount.Visible = true;
                }
                else
                {
                    labelCount.Visible = false;
                    textBoxCount.Visible = false;
                }
                labelCostService.Text = dataService[1] + "р.";
            }
            catch
            {
                return;
            }
        }

        private void comboBoxAnimatedImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (labelCostAnimated.Text != string.Empty)
                {
                    labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) - Convert.ToDouble(labelCostAnimated.Text.Replace("р.", ""))).ToString();
                }
                string[] dataService = Requests.GetOneImage("nameimages", comboBoxAnimatedImages.Text);
                labelCostAnimated.Text = dataService[1] + "р.";
                labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) + Convert.ToDouble(labelCostAnimated.Text.Replace("р.", ""))).ToString() + "р.";
            }
            catch
            {
                return;
            }
        }

        private void dateTimePickerIn_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerOut.Value = dateTimePickerIn.Value;
            if (comboBoxDuration.SelectedIndex == -1)
                return;
            dateTimePickerOut.Value.AddHours(Convert.ToInt32(comboBoxDuration.Text));
            AddConditionMaster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> requests = new List<string>();
            if (dataGridView1.Rows.Count == 0)
                requestAddOrChangeStructureOrder = string.Empty;
            else
            {
                requestAddOrChangeStructureOrder = "insert into structureorders(idorder, idservice, price) values";
                string id = string.IsNullOrEmpty(idOrder) ? "last_insert_id()" : idOrder;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    requestAddOrChangeStructureOrder += "(" + id + ",(select id from service where nameservice='" + row.Cells[0].Value.ToString() + "'), '" + row.Cells[1].Value.ToString().Replace("р.", "") + "')";
                    if (dataGridView1.Rows.Count != row.Index + 1)
                        requestAddOrChangeStructureOrder += ",";
                }
            }
            if (button1.Text == "Сформировать заказ")
            {
                requestAddOrChangeOrder = "insert into orders(idmaster, telephoneClient, idmainservice, idanimatedimages,day,timeIn,timeOut,price) values("
                    + "(select min(id) from users where concat(name, ' ', surname, ' ', lastname)='" + comboBoxMaster.Text + "'),"
                    + "'" + maskedTextBoxTelephone.Text + "',"
                    + "(select min(id) from mainservice where duration='" + comboBoxDuration.Text + "'),"
                    + "(select min(id) from animatedimages where nameimages='" + comboBoxAnimatedImages.Text + "'),"
                    + "'" + dateTimePickerDay.Text + "',"
                    + "'" + dateTimePickerIn.Text + "',"
                    + "'" + dateTimePickerOut.Text + "',"
                    + "'" + labelCostOrder.Text + "')";
            }
            else
            {
                requestAddOrChangeOrder = "update orders set idmaster = (select min(id) from users where concat(name, ' ', surname, ' ', lastname)='" + comboBoxMaster.Text + "'),"
                    + "telephoneClient='" + maskedTextBoxTelephone.Text + "',"
                    + "idmainservice=(select min(id) from mainservice where duration='" + comboBoxDuration.Text + "'),"
                    + "idanimatedimages=(select min(id) from animatedimages where nameimages='" + comboBoxAnimatedImages.Text + "'),"
                    + "day='" + dateTimePickerDay.Text + "',"
                    + "timeIn='" + dateTimePickerIn.Text + "',"
                    + "timeOut='" + dateTimePickerOut.Text + "',"
                    + "price='" + labelCostOrder.Text + "'";
            }
            requests.Add(requestAddOrChangeOrder);
            requests.Add(requestAddOrChangeStructureOrder);
            if (TransactionOrder.ToFormOrder(requests))
            {
                if (button1.Text == "Сформировать заказ")
                    MessageSuccess.Show("Заказ оформлен успешно");
                else
                {
                    MessageSuccess.Show("Изменения сохранены успешно");
                    this.Close();
                }
                ClearControl();
            }
            else MessageError.Show("При формировании заказа возникли ошибки, попробуйте позже");
        }
        private void ClearControl()
        {
            maskedTextBoxTelephone.Text = string.Empty;
            foreach (TextBox control in this.Controls.OfType<TextBox>())
                control.Text = string.Empty;
            foreach (ComboBox control in this.Controls.OfType<ComboBox>())
                control.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerOut.Value = dateTimePickerIn.Value.AddHours(Convert.ToInt32(comboBoxDuration.Text));
                if (labelCostMainService.Text != string.Empty)
                    labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) - Convert.ToDouble(labelCostMainService.Text.Replace("р.", ""))).ToString() + "р.";
                labelCostMainService.Text = Requests.GetOneMainService("duration", comboBoxDuration.Text)[0] + "р.";
                labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) + Convert.ToDouble(labelCostMainService.Text.Replace("р.", ""))).ToString() + "р.";
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Удалить")
            {
                labelCostOrder.Text = (Convert.ToDouble(labelCostOrder.Text.Replace("р.", "")) - Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Цена"].Value.ToString().Replace("р.", ""))).ToString() + "р.";
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void dateTimePickerDay_ValueChanged(object sender, EventArgs e)
        {
            AddConditionMaster();
        }
    }
}
