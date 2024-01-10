
namespace shopServices.Forms.Users
{
    partial class AddOrChangeUser
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
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword1 = new System.Windows.Forms.TextBox();
            this.buttonGeneratorLogin = new System.Windows.Forms.Button();
            this.buttonGeneratorPassword = new System.Windows.Forms.Button();
            this.buttonAddOrChangeUser = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBoxTelephone = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerHappy = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(23, 30);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(200, 29);
            this.textBoxSurname.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(23, 89);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 29);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(23, 148);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 29);
            this.textBoxLastName.TabIndex = 2;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(247, 30);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(200, 29);
            this.textBoxLogin.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(247, 89);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 29);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPassword1
            // 
            this.textBoxPassword1.Location = new System.Drawing.Point(247, 148);
            this.textBoxPassword1.Name = "textBoxPassword1";
            this.textBoxPassword1.Size = new System.Drawing.Size(200, 29);
            this.textBoxPassword1.TabIndex = 8;
            this.textBoxPassword1.UseSystemPasswordChar = true;
            // 
            // buttonGeneratorLogin
            // 
            this.buttonGeneratorLogin.Location = new System.Drawing.Point(468, 29);
            this.buttonGeneratorLogin.Name = "buttonGeneratorLogin";
            this.buttonGeneratorLogin.Size = new System.Drawing.Size(167, 33);
            this.buttonGeneratorLogin.TabIndex = 9;
            this.buttonGeneratorLogin.Text = "Сгенерировать";
            this.buttonGeneratorLogin.UseVisualStyleBackColor = true;
            this.buttonGeneratorLogin.Click += new System.EventHandler(this.buttonGeneratorLogin_Click);
            // 
            // buttonGeneratorPassword
            // 
            this.buttonGeneratorPassword.Location = new System.Drawing.Point(468, 88);
            this.buttonGeneratorPassword.Name = "buttonGeneratorPassword";
            this.buttonGeneratorPassword.Size = new System.Drawing.Size(167, 33);
            this.buttonGeneratorPassword.TabIndex = 10;
            this.buttonGeneratorPassword.Text = "Сгенерировать";
            this.buttonGeneratorPassword.UseVisualStyleBackColor = true;
            this.buttonGeneratorPassword.Click += new System.EventHandler(this.buttonGeneratorPassword_Click);
            // 
            // buttonAddOrChangeUser
            // 
            this.buttonAddOrChangeUser.Location = new System.Drawing.Point(459, 379);
            this.buttonAddOrChangeUser.Name = "buttonAddOrChangeUser";
            this.buttonAddOrChangeUser.Size = new System.Drawing.Size(167, 36);
            this.buttonAddOrChangeUser.TabIndex = 11;
            this.buttonAddOrChangeUser.Text = "Добавить";
            this.buttonAddOrChangeUser.UseVisualStyleBackColor = true;
            this.buttonAddOrChangeUser.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(29, 379);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(176, 36);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "К пользователям";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Имя *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Фамилия *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Телефон";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "День рождения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "Логин *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "Пароль *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "Повторите пароль *";
            // 
            // maskedTextBoxTelephone
            // 
            this.maskedTextBoxTelephone.Location = new System.Drawing.Point(23, 207);
            this.maskedTextBoxTelephone.Mask = "+7(000)-000-00-00";
            this.maskedTextBoxTelephone.Name = "maskedTextBoxTelephone";
            this.maskedTextBoxTelephone.Size = new System.Drawing.Size(200, 29);
            this.maskedTextBoxTelephone.TabIndex = 3;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(23, 325);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(200, 32);
            this.comboBoxRole.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "Роль";
            // 
            // dateTimePickerHappy
            // 
            this.dateTimePickerHappy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHappy.Location = new System.Drawing.Point(23, 266);
            this.dateTimePickerHappy.Name = "dateTimePickerHappy";
            this.dateTimePickerHappy.Size = new System.Drawing.Size(200, 29);
            this.dateTimePickerHappy.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 33);
            this.button1.TabIndex = 23;
            this.button1.Text = "Показать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddOrChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 425);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerHappy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.maskedTextBoxTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddOrChangeUser);
            this.Controls.Add(this.buttonGeneratorPassword);
            this.Controls.Add(this.buttonGeneratorLogin);
            this.Controls.Add(this.textBoxPassword1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSurname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AddOrChangeUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание(изменение) пользователя";
            this.Load += new System.EventHandler(this.AddAngChangeUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPassword1;
        private System.Windows.Forms.Button buttonGeneratorLogin;
        private System.Windows.Forms.Button buttonGeneratorPassword;
        private System.Windows.Forms.Button buttonAddOrChangeUser;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelephone;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerHappy;
        private System.Windows.Forms.Button button1;
    }
}