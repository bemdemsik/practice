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

namespace shopServices.Forms.Service.AnimatedImages
{
    public partial class AddOrChangeAnimatedImages : Form
    {
        string idImage = string.Empty;
        string request = string.Empty;
        public AddOrChangeAnimatedImages(string idImages)
        {
            idImage = idImages;
            InitializeComponent();
            buttonAddOrChangeImages.Text = "Изменить";
        }
        public AddOrChangeAnimatedImages()
        {
            InitializeComponent();
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

        private void buttonAddOrChangeImages_Click(object sender, EventArgs e)
        {
            if (!CheckOnNullData())
            {
                MessageWarning.Show("Заполните все поля");
                return;
            }
            if (buttonAddOrChangeImages.Text == "Добавить")
                request = "insert into animatedimages(nameimages,price) values("
                    + "'" + textBoxNameImages.Text + "',"
                    + "'" + textBoxPrice.Text + "')";
            else request = "update animatedimages set nameimages='" + textBoxNameImages.Text + "'"
                    + ",price='" + textBoxPrice.Text + "'"
                    + " where id=" + idImage;

            if (Requests.UniversalRequest(request))
            {
                MessageSuccess.Show("Операция выполнена успешна");
                this.Close();
            }
            else MessageError.Show("Операция не выполнена");
        }
        private void FillImageData()
        {
            try
            {
                string[] images = Requests.GetOneImage("id", idImage);
                textBoxNameImages.Text = images[0];
                textBoxPrice.Text = images[1];
            }
            catch
            {
                MessageError.Show("Не в курсе");
                return;
            }
        }
        private void AddOrChangeAnimatedImages_Load(object sender, EventArgs e)
        {
            if (buttonAddOrChangeImages.Text == "Изменить")
                FillImageData();
        }
    }
}
