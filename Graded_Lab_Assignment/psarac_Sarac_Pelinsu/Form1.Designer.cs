namespace psarac_Sarac_Pelinsu
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
            textBox_ip = new TextBox();
            textBox_port = new TextBox();
            textBox_email = new TextBox();
            textBox_name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            log = new RichTextBox();
            button_connect = new Button();
            SuspendLayout();
            // 
            // textBox_ip
            // 
            textBox_ip.Location = new Point(157, 87);
            textBox_ip.Name = "textBox_ip";
            textBox_ip.Size = new Size(217, 27);
            textBox_ip.TabIndex = 0;
            // 
            // textBox_port
            // 
            textBox_port.Location = new Point(157, 139);
            textBox_port.Name = "textBox_port";
            textBox_port.Size = new Size(217, 27);
            textBox_port.TabIndex = 1;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(157, 192);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(217, 27);
            textBox_email.TabIndex = 2;
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(157, 243);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(217, 27);
            textBox_name.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 90);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 4;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 146);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 5;
            label2.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 195);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 250);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 7;
            label4.Text = "Name:";
            // 
            // log
            // 
            log.Location = new Point(417, 88);
            log.Name = "log";
            log.Size = new Size(326, 345);
            log.TabIndex = 8;
            log.Text = "";
            // 
            // button_connect
            // 
            button_connect.Location = new Point(191, 297);
            button_connect.Name = "button_connect";
            button_connect.Size = new Size(139, 39);
            button_connect.TabIndex = 9;
            button_connect.Text = "Connect";
            button_connect.UseVisualStyleBackColor = true;
            button_connect.Click += button_connect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 503);
            Controls.Add(button_connect);
            Controls.Add(log);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_name);
            Controls.Add(textBox_email);
            Controls.Add(textBox_port);
            Controls.Add(textBox_ip);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ip;
        private TextBox textBox_port;
        private TextBox textBox_email;
        private TextBox textBox_name;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox log;
        private Button button_connect;
    }
}