namespace парикмахерская
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Snow;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(234, 315);
            label1.Name = "label1";
            label1.Size = new Size(88, 38);
            label1.TabIndex = 0;
            label1.Text = "Вход";
            // 
            // button1
            // 
            button1.BackColor = Color.Snow;
            button1.Font = new Font("Times New Roman", 16.2F, FontStyle.Underline, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(176, 368);
            button1.Name = "button1";
            button1.Size = new Size(214, 51);
            button1.TabIndex = 2;
            button1.Text = "Регистрация";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Snow;
            button2.Font = new Font("Times New Roman", 16.2F, FontStyle.Underline, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.IndianRed;
            button2.Location = new Point(176, 502);
            button2.Name = "button2";
            button2.Size = new Size(214, 51);
            button2.TabIndex = 3;
            button2.Text = "Администратор";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RosyBrown;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(122, 169);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(329, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Snow;
            label2.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(187, 452);
            label2.Name = "label2";
            label2.Size = new Size(190, 38);
            label2.TabIndex = 6;
            label2.Text = "Войти как:";
            label2.Click += label2_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Snow;
            button5.Font = new Font("Times New Roman", 16.2F, FontStyle.Underline, GraphicsUnit.Point, 204);
            button5.ForeColor = Color.IndianRed;
            button5.Location = new Point(176, 559);
            button5.Name = "button5";
            button5.Size = new Size(214, 51);
            button5.TabIndex = 7;
            button5.Text = "Клиент";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(570, 707);
            Controls.Add(button5);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Label label2;
        private Button button5;
    }
}
