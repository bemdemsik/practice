
namespace shopServices.Forms.Service.AnimatedImages
{
    partial class AddOrChangeAnimatedImages
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxNameImages = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAddOrChangeImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Анимационный образ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Цена";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(16, 95);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(200, 29);
            this.textBoxPrice.TabIndex = 23;
            // 
            // textBoxNameImages
            // 
            this.textBoxNameImages.Location = new System.Drawing.Point(16, 36);
            this.textBoxNameImages.Name = "textBoxNameImages";
            this.textBoxNameImages.Size = new System.Drawing.Size(597, 29);
            this.textBoxNameImages.TabIndex = 22;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(16, 130);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(176, 36);
            this.buttonBack.TabIndex = 21;
            this.buttonBack.Text = "К услугам";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonAddOrChangeImages
            // 
            this.buttonAddOrChangeImages.Location = new System.Drawing.Point(446, 130);
            this.buttonAddOrChangeImages.Name = "buttonAddOrChangeImages";
            this.buttonAddOrChangeImages.Size = new System.Drawing.Size(167, 36);
            this.buttonAddOrChangeImages.TabIndex = 20;
            this.buttonAddOrChangeImages.Text = "Добавить";
            this.buttonAddOrChangeImages.UseVisualStyleBackColor = true;
            this.buttonAddOrChangeImages.Click += new System.EventHandler(this.buttonAddOrChangeImages_Click);
            // 
            // AddOrChangeAnimatedImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 176);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxNameImages);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddOrChangeImages);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AddOrChangeAnimatedImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавления(изменение) анимационных образов";
            this.Load += new System.EventHandler(this.AddOrChangeAnimatedImages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxNameImages;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAddOrChangeImages;
    }
}