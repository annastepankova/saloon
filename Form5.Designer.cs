namespace парикмахерская
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            textBoxQuery = new TextBox();
            deleteButton = new Button();
            updateButton = new Button();
            insertButton = new Button();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(12, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1019, 471);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LavenderBlush;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1011, 438);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "appointments";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1011, 438);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "freetime";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1011, 438);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "services";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1011, 438);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "users";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1011, 438);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "master";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBoxQuery
            // 
            textBoxQuery.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxQuery.Location = new Point(543, 545);
            textBoxQuery.Multiline = true;
            textBoxQuery.Name = "textBoxQuery";
            textBoxQuery.Size = new Size(50, 38);
            textBoxQuery.TabIndex = 4;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(84, 546);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "button1";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(249, 543);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 6;
            updateButton.Text = "button2";
            updateButton.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(419, 541);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(94, 29);
            insertButton.TabIndex = 7;
            insertButton.Text = "button3";
            insertButton.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1098, 540);
            Controls.Add(insertButton);
            Controls.Add(updateButton);
            Controls.Add(deleteButton);
            Controls.Add(textBoxQuery);
            Controls.Add(tabControl1);
            Name = "Form5";
            Text = "Для администратора";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox textBoxQuery;
        private Button deleteButton;
        private Button updateButton;
        private Button insertButton;
        private TabPage tabPage5;
    }
}