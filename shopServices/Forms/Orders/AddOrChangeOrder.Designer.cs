
namespace shopServices.Forms.Orders
{
    partial class AddOrChangeOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxMaster = new System.Windows.Forms.ComboBox();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.comboBoxAnimatedImages = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCostOrder = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxTelephone = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxAddService = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelCostService = new System.Windows.Forms.Label();
            this.labelCostAnimated = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.labelCostMainService = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, -4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(790, 208);
            this.dataGridView1.TabIndex = 101;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBoxMaster
            // 
            this.comboBoxMaster.FormattingEnabled = true;
            this.comboBoxMaster.Location = new System.Drawing.Point(395, 210);
            this.comboBoxMaster.Name = "comboBoxMaster";
            this.comboBoxMaster.Size = new System.Drawing.Size(289, 32);
            this.comboBoxMaster.TabIndex = 102;
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Location = new System.Drawing.Point(512, 283);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(172, 32);
            this.comboBoxDuration.TabIndex = 104;
            this.comboBoxDuration.SelectedIndexChanged += new System.EventHandler(this.comboBoxDuration_SelectedIndexChanged);
            // 
            // comboBoxAnimatedImages
            // 
            this.comboBoxAnimatedImages.FormattingEnabled = true;
            this.comboBoxAnimatedImages.Location = new System.Drawing.Point(295, 321);
            this.comboBoxAnimatedImages.Name = "comboBoxAnimatedImages";
            this.comboBoxAnimatedImages.Size = new System.Drawing.Size(389, 32);
            this.comboBoxAnimatedImages.TabIndex = 105;
            this.comboBoxAnimatedImages.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnimatedImages_SelectedIndexChanged);
            // 
            // dateTimePickerDay
            // 
            this.dateTimePickerDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDay.Location = new System.Drawing.Point(161, 209);
            this.dateTimePickerDay.Name = "dateTimePickerDay";
            this.dateTimePickerDay.Size = new System.Drawing.Size(126, 29);
            this.dateTimePickerDay.TabIndex = 106;
            this.dateTimePickerDay.ValueChanged += new System.EventHandler(this.dateTimePickerDay_ValueChanged);
            // 
            // dateTimePickerIn
            // 
            this.dateTimePickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerIn.Location = new System.Drawing.Point(161, 244);
            this.dateTimePickerIn.Name = "dateTimePickerIn";
            this.dateTimePickerIn.ShowUpDown = true;
            this.dateTimePickerIn.Size = new System.Drawing.Size(126, 29);
            this.dateTimePickerIn.TabIndex = 107;
            this.dateTimePickerIn.ValueChanged += new System.EventHandler(this.dateTimePickerIn_ValueChanged);
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.Enabled = false;
            this.dateTimePickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOut.Location = new System.Drawing.Point(161, 279);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.ShowUpDown = true;
            this.dateTimePickerOut.Size = new System.Drawing.Size(126, 29);
            this.dateTimePickerOut.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 109;
            this.label1.Text = "Длительность(часы) *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 110;
            this.label2.Text = "Стоимость заказа: ";
            // 
            // labelCostOrder
            // 
            this.labelCostOrder.AutoSize = true;
            this.labelCostOrder.Location = new System.Drawing.Point(316, 448);
            this.labelCostOrder.Name = "labelCostOrder";
            this.labelCostOrder.Size = new System.Drawing.Size(0, 24);
            this.labelCostOrder.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 112;
            this.label3.Text = "Мастер *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 24);
            this.label5.TabIndex = 114;
            this.label5.Text = "Телефон клиента *";
            // 
            // maskedTextBoxTelephone
            // 
            this.maskedTextBoxTelephone.Location = new System.Drawing.Point(484, 248);
            this.maskedTextBoxTelephone.Mask = "+7(000)-000-00-00";
            this.maskedTextBoxTelephone.Name = "maskedTextBoxTelephone";
            this.maskedTextBoxTelephone.Size = new System.Drawing.Size(200, 29);
            this.maskedTextBoxTelephone.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 24);
            this.label4.TabIndex = 116;
            this.label4.Text = "Анимационный образ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 24);
            this.label6.TabIndex = 117;
            this.label6.Text = "Дата";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 24);
            this.label7.TabIndex = 118;
            this.label7.Text = "С";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 24);
            this.label8.TabIndex = 119;
            this.label8.Text = "До";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 31);
            this.button1.TabIndex = 120;
            this.button1.Text = "Сформировать заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 365);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(229, 24);
            this.label9.TabIndex = 121;
            this.label9.Text = "Дополнительные услуги";
            // 
            // comboBoxAddService
            // 
            this.comboBoxAddService.FormattingEnabled = true;
            this.comboBoxAddService.Location = new System.Drawing.Point(317, 362);
            this.comboBoxAddService.Name = "comboBoxAddService";
            this.comboBoxAddService.Size = new System.Drawing.Size(367, 32);
            this.comboBoxAddService.TabIndex = 122;
            this.comboBoxAddService.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddService_SelectedIndexChanged);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(194, 403);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(117, 24);
            this.labelCount.TabIndex = 123;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(317, 400);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(100, 29);
            this.textBoxCount.TabIndex = 124;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 31);
            this.button2.TabIndex = 125;
            this.button2.Text = "Добавить к заказу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelCostService
            // 
            this.labelCostService.AutoSize = true;
            this.labelCostService.Location = new System.Drawing.Point(690, 365);
            this.labelCostService.Name = "labelCostService";
            this.labelCostService.Size = new System.Drawing.Size(0, 24);
            this.labelCostService.TabIndex = 126;
            // 
            // labelCostAnimated
            // 
            this.labelCostAnimated.AutoSize = true;
            this.labelCostAnimated.Location = new System.Drawing.Point(690, 324);
            this.labelCostAnimated.Name = "labelCostAnimated";
            this.labelCostAnimated.Size = new System.Drawing.Size(0, 24);
            this.labelCostAnimated.TabIndex = 127;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 445);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 31);
            this.button3.TabIndex = 128;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelCostMainService
            // 
            this.labelCostMainService.AutoSize = true;
            this.labelCostMainService.Location = new System.Drawing.Point(690, 286);
            this.labelCostMainService.Name = "labelCostMainService";
            this.labelCostMainService.Size = new System.Drawing.Size(0, 24);
            this.labelCostMainService.TabIndex = 129;
            // 
            // AddOrChangeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(788, 487);
            this.ControlBox = false;
            this.Controls.Add(this.labelCostMainService);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelCostAnimated);
            this.Controls.Add(this.labelCostService);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxAddService);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBoxTelephone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCostOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerOut);
            this.Controls.Add(this.dateTimePickerIn);
            this.Controls.Add(this.dateTimePickerDay);
            this.Controls.Add(this.comboBoxAnimatedImages);
            this.Controls.Add(this.comboBoxDuration);
            this.Controls.Add(this.comboBoxMaster);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AddOrChangeOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление(изменение) заказа";
            this.Load += new System.EventHandler(this.AddOrChangeOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxMaster;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.ComboBox comboBoxAnimatedImages;
        private System.Windows.Forms.DateTimePicker dateTimePickerDay;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCostOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelephone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxAddService;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelCostService;
        private System.Windows.Forms.Label labelCostAnimated;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelCostMainService;
    }
}