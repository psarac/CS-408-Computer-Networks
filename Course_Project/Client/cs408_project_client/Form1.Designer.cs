namespace cs408_project_client
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
            Label1 = new Label();
            label2 = new Label();
            UsernametextBox = new TextBox();
            IPtextBox = new TextBox();
            label3 = new Label();
            PorttextBox = new TextBox();
            BTNConnect = new Button();
            StatusTextBox = new RichTextBox();
            label4 = new Label();
            IF100Chat = new RichTextBox();
            SPS101Chat = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            BTNIF100sub = new Button();
            BTNSPS101unsub = new Button();
            BTNIF100unsub = new Button();
            BTNSPS101sub = new Button();
            SPS101_text_box = new TextBox();
            IF100_text_box = new TextBox();
            BTN_IF100_send = new Button();
            BTN_SPS101_send = new Button();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(91, 42);
            Label1.Name = "Label1";
            Label1.Size = new Size(75, 20);
            Label1.TabIndex = 0;
            Label1.Text = "Username";
            Label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 95);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "IP Adress";
            // 
            // UsernametextBox
            // 
            UsernametextBox.Location = new Point(207, 42);
            UsernametextBox.Name = "UsernametextBox";
            UsernametextBox.Size = new Size(123, 27);
            UsernametextBox.TabIndex = 2;
            // 
            // IPtextBox
            // 
            IPtextBox.Location = new Point(207, 92);
            IPtextBox.Name = "IPtextBox";
            IPtextBox.Size = new Size(123, 27);
            IPtextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 146);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 4;
            label3.Text = "Port Number";
            // 
            // PorttextBox
            // 
            PorttextBox.Location = new Point(207, 146);
            PorttextBox.Name = "PorttextBox";
            PorttextBox.Size = new Size(123, 27);
            PorttextBox.TabIndex = 5;
            // 
            // BTNConnect
            // 
            BTNConnect.Location = new Point(220, 194);
            BTNConnect.Name = "BTNConnect";
            BTNConnect.Size = new Size(94, 29);
            BTNConnect.TabIndex = 6;
            BTNConnect.Text = "Connect";
            BTNConnect.UseVisualStyleBackColor = true;
            BTNConnect.Click += BTNConnect_Click;
            // 
            // StatusTextBox
            // 
            StatusTextBox.Location = new Point(538, 67);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.Size = new Size(342, 69);
            StatusTextBox.TabIndex = 7;
            StatusTextBox.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(637, 29);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 8;
            label4.Text = "Connection Status";
            label4.Click += label4_Click;
            // 
            // IF100Chat
            // 
            IF100Chat.Location = new Point(397, 211);
            IF100Chat.Name = "IF100Chat";
            IF100Chat.Size = new Size(298, 301);
            IF100Chat.TabIndex = 9;
            IF100Chat.Text = "";
            // 
            // SPS101Chat
            // 
            SPS101Chat.Location = new Point(768, 211);
            SPS101Chat.Name = "SPS101Chat";
            SPS101Chat.Size = new Size(302, 301);
            SPS101Chat.TabIndex = 10;
            SPS101Chat.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(397, 173);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 11;
            label5.Text = "IF100";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(768, 173);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 12;
            label6.Text = "SPS101";
            // 
            // BTNIF100sub
            // 
            BTNIF100sub.Enabled = false;
            BTNIF100sub.Location = new Point(397, 529);
            BTNIF100sub.Name = "BTNIF100sub";
            BTNIF100sub.Size = new Size(94, 29);
            BTNIF100sub.TabIndex = 13;
            BTNIF100sub.Text = "Subscribe";
            BTNIF100sub.UseVisualStyleBackColor = true;
            BTNIF100sub.Click += BTNIF100sub_Click;
            // 
            // BTNSPS101unsub
            // 
            BTNSPS101unsub.Enabled = false;
            BTNSPS101unsub.Location = new Point(877, 529);
            BTNSPS101unsub.Name = "BTNSPS101unsub";
            BTNSPS101unsub.Size = new Size(112, 29);
            BTNSPS101unsub.TabIndex = 14;
            BTNSPS101unsub.Text = "Unsubscribe";
            BTNSPS101unsub.UseVisualStyleBackColor = true;
            BTNSPS101unsub.Click += BTNSPS101unsub_Click;
            // 
            // BTNIF100unsub
            // 
            BTNIF100unsub.Enabled = false;
            BTNIF100unsub.Location = new Point(513, 529);
            BTNIF100unsub.Name = "BTNIF100unsub";
            BTNIF100unsub.Size = new Size(107, 29);
            BTNIF100unsub.TabIndex = 15;
            BTNIF100unsub.Text = "Unsubscribe";
            BTNIF100unsub.UseVisualStyleBackColor = true;
            BTNIF100unsub.Click += BTNIF100unsub_Click;
            // 
            // BTNSPS101sub
            // 
            BTNSPS101sub.Enabled = false;
            BTNSPS101sub.Location = new Point(768, 529);
            BTNSPS101sub.Name = "BTNSPS101sub";
            BTNSPS101sub.Size = new Size(94, 29);
            BTNSPS101sub.TabIndex = 16;
            BTNSPS101sub.Text = "Subscribe";
            BTNSPS101sub.UseVisualStyleBackColor = true;
            BTNSPS101sub.Click += BTNSPS101sub_Click;
            // 
            // SPS101_text_box
            // 
            SPS101_text_box.Enabled = false;
            SPS101_text_box.Location = new Point(768, 590);
            SPS101_text_box.Name = "SPS101_text_box";
            SPS101_text_box.Size = new Size(302, 27);
            SPS101_text_box.TabIndex = 17;
            SPS101_text_box.TextChanged += textBox1_TextChanged;
            // 
            // IF100_text_box
            // 
            IF100_text_box.Enabled = false;
            IF100_text_box.Location = new Point(397, 590);
            IF100_text_box.Name = "IF100_text_box";
            IF100_text_box.Size = new Size(298, 27);
            IF100_text_box.TabIndex = 18;
            // 
            // BTN_IF100_send
            // 
            BTN_IF100_send.Enabled = false;
            BTN_IF100_send.Location = new Point(397, 644);
            BTN_IF100_send.Name = "BTN_IF100_send";
            BTN_IF100_send.Size = new Size(94, 29);
            BTN_IF100_send.TabIndex = 19;
            BTN_IF100_send.Text = "Send";
            BTN_IF100_send.UseVisualStyleBackColor = true;
            BTN_IF100_send.Click += BTN_IF100_send_Click;
            // 
            // BTN_SPS101_send
            // 
            BTN_SPS101_send.Enabled = false;
            BTN_SPS101_send.Location = new Point(768, 644);
            BTN_SPS101_send.Name = "BTN_SPS101_send";
            BTN_SPS101_send.Size = new Size(94, 29);
            BTN_SPS101_send.TabIndex = 20;
            BTN_SPS101_send.Text = "Send";
            BTN_SPS101_send.UseVisualStyleBackColor = true;
            BTN_SPS101_send.Click += BTN_SPS101_send_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 739);
            Controls.Add(BTN_SPS101_send);
            Controls.Add(BTN_IF100_send);
            Controls.Add(IF100_text_box);
            Controls.Add(SPS101_text_box);
            Controls.Add(BTNSPS101sub);
            Controls.Add(BTNIF100unsub);
            Controls.Add(BTNSPS101unsub);
            Controls.Add(BTNIF100sub);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(SPS101Chat);
            Controls.Add(IF100Chat);
            Controls.Add(label4);
            Controls.Add(StatusTextBox);
            Controls.Add(BTNConnect);
            Controls.Add(PorttextBox);
            Controls.Add(label3);
            Controls.Add(IPtextBox);
            Controls.Add(UsernametextBox);
            Controls.Add(label2);
            Controls.Add(Label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label1;
        private Label label2;
        private TextBox UsernametextBox;
        private TextBox IPtextBox;
        private Label label3;
        private TextBox PorttextBox;
        private Button BTNConnect;
        private RichTextBox StatusTextBox;
        private Label label4;
        private RichTextBox IF100Chat;
        private RichTextBox SPS101Chat;
        private Label label5;
        private Label label6;
        private Button BTNIF100sub;
        private Button BTNSPS101unsub;
        private Button BTNIF100unsub;
        private Button BTNSPS101sub;
        private TextBox SPS101_text_box;
        private TextBox IF100_text_box;
        private Button BTN_IF100_send;
        private Button BTN_SPS101_send;
    }
}