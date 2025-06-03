namespace WinFormsApp6
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
            button1 = new Button();
            label_info = new Label();
            textBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(328, 275);
            button1.Name = "button1";
            button1.Size = new Size(132, 58);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1;
            // 
            // label_info
            // 
            label_info.AutoSize = true;
            label_info.Location = new Point(328, 102);
            label_info.Name = "label_info";
            label_info.Size = new Size(38, 15);
            label_info.TabIndex = 1;
            label_info.Text = "label1";
            // 
            // textBox
            // 
            textBox.Location = new Point(328, 184);
            textBox.Name = "textBox";
            textBox.Size = new Size(100, 23);
            textBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox);
            Controls.Add(label_info);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label_info;
        private TextBox textBox;
    }
}
