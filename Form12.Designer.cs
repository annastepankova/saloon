namespace парикмахерская
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            button1 = new Button();
            textBoxFio = new TextBox();
            textBoxDate = new TextBox();
            textBoxTime = new TextBox();
            comboBoxServices = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            label6 = new Label();
            ComboBoxMaster = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Snow;
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(49, 526);
            button1.Name = "button1";
            button1.Size = new Size(158, 44);
            button1.TabIndex = 0;
            button1.Text = "Записаться";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxFio
            // 
            textBoxFio.BackColor = Color.Snow;
            textBoxFio.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFio.ForeColor = Color.IndianRed;
            textBoxFio.Location = new Point(49, 149);
            textBoxFio.Multiline = true;
            textBoxFio.Name = "textBoxFio";
            textBoxFio.Size = new Size(313, 42);
            textBoxFio.TabIndex = 1;
            // 
            // textBoxDate
            // 
            textBoxDate.BackColor = Color.Snow;
            textBoxDate.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDate.ForeColor = Color.IndianRed;
            textBoxDate.Location = new Point(49, 232);
            textBoxDate.Multiline = true;
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(313, 42);
            textBoxDate.TabIndex = 2;
            // 
            // textBoxTime
            // 
            textBoxTime.BackColor = Color.Snow;
            textBoxTime.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxTime.ForeColor = Color.IndianRed;
            textBoxTime.Location = new Point(49, 317);
            textBoxTime.Multiline = true;
            textBoxTime.Name = "textBoxTime";
            textBoxTime.Size = new Size(313, 42);
            textBoxTime.TabIndex = 3;
            // 
            // comboBoxServices
            // 
            comboBoxServices.BackColor = Color.Snow;
            comboBoxServices.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxServices.ForeColor = Color.IndianRed;
            comboBoxServices.FormattingEnabled = true;
            comboBoxServices.Location = new Point(49, 403);
            comboBoxServices.Name = "comboBoxServices";
            comboBoxServices.Size = new Size(313, 34);
            comboBoxServices.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Snow;
            label1.Font = new Font("Times New Roman", 22.2F, FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(145, 86);
            label1.Name = "label1";
            label1.Size = new Size(126, 42);
            label1.TabIndex = 6;
            label1.Text = "Запись";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Snow;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(49, 120);
            label2.Name = "label2";
            label2.Size = new Size(62, 26);
            label2.TabIndex = 7;
            label2.Text = "ФИО";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Snow;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(49, 203);
            label3.Name = "label3";
            label3.Size = new Size(57, 26);
            label3.TabIndex = 8;
            label3.Text = "Дата";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Snow;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(49, 288);
            label4.Name = "label4";
            label4.Size = new Size(74, 26);
            label4.TabIndex = 9;
            label4.Text = "Время";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Snow;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(49, 374);
            label5.Name = "label5";
            label5.Size = new Size(257, 26);
            label5.TabIndex = 10;
            label5.Text = "Предоставляемые услуги";
            // 
            // button2
            // 
            button2.BackColor = Color.Snow;
            button2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.IndianRed;
            button2.Location = new Point(273, 534);
            button2.Name = "button2";
            button2.Size = new Size(100, 36);
            button2.TabIndex = 11;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Snow;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.IndianRed;
            label6.Location = new Point(54, 452);
            label6.Name = "label6";
            label6.Size = new Size(93, 26);
            label6.TabIndex = 12;
            label6.Text = "Мастера";
            // 
            // ComboBoxMaster
            // 
            ComboBoxMaster.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxMaster.FormattingEnabled = true;
            ComboBoxMaster.Location = new Point(49, 481);
            ComboBoxMaster.Name = "ComboBoxMaster";
            ComboBoxMaster.Size = new Size(313, 34);
            ComboBoxMaster.TabIndex = 13;
            // 
            // Form12
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(437, 602);
            Controls.Add(ComboBoxMaster);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxServices);
            Controls.Add(textBoxTime);
            Controls.Add(textBoxDate);
            Controls.Add(textBoxFio);
            Controls.Add(button1);
            ForeColor = Color.IndianRed;
            Name = "Form12";
            Text = "Запись на услуги";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxFio;
        private TextBox textBoxDate;
        private TextBox textBoxTime;
        private ComboBox comboBoxServices;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
        private Label label6;
        private ComboBox ComboBoxMaster;
    }
}