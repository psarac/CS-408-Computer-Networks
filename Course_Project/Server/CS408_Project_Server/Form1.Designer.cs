namespace CS408_Project_Server
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
            label1 = new Label();
            portTextBox = new TextBox();
            ListenButton = new Button();
            monitor = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            currentlyConnectedListView = new ListView();
            IF100ListView = new ListView();
            SPS101ListView = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 44);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            label1.Click += label1_Click;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(205, 41);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(134, 27);
            portTextBox.TabIndex = 1;
            // 
            // ListenButton
            // 
            ListenButton.Location = new Point(359, 41);
            ListenButton.Name = "ListenButton";
            ListenButton.Size = new Size(104, 27);
            ListenButton.TabIndex = 2;
            ListenButton.Text = "Listen";
            ListenButton.UseVisualStyleBackColor = true;
            ListenButton.Click += ListenButton_Click;
            // 
            // monitor
            // 
            monitor.Location = new Point(547, 70);
            monitor.Name = "monitor";
            monitor.Size = new Size(381, 508);
            monitor.TabIndex = 3;
            monitor.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(547, 41);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 4;
            label2.Text = "Monitor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 129);
            label3.Name = "label3";
            label3.Size = new Size(146, 20);
            label3.TabIndex = 8;
            label3.Text = "Currently Connected:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 264);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 9;
            label4.Text = "IF100:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 405);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 10;
            label5.Text = "SPS101:";
            // 
            // currentlyConnectedListView
            // 
            currentlyConnectedListView.Location = new Point(196, 129);
            currentlyConnectedListView.Name = "currentlyConnectedListView";
            currentlyConnectedListView.Size = new Size(267, 100);
            currentlyConnectedListView.TabIndex = 11;
            currentlyConnectedListView.UseCompatibleStateImageBehavior = false;
            // 
            // IF100ListView
            // 
            IF100ListView.Location = new Point(196, 264);
            IF100ListView.Name = "IF100ListView";
            IF100ListView.Size = new Size(267, 100);
            IF100ListView.TabIndex = 12;
            IF100ListView.UseCompatibleStateImageBehavior = false;
            // 
            // SPS101ListView
            // 
            SPS101ListView.Location = new Point(196, 405);
            SPS101ListView.Name = "SPS101ListView";
            SPS101ListView.Size = new Size(267, 100);
            SPS101ListView.TabIndex = 13;
            SPS101ListView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 630);
            Controls.Add(SPS101ListView);
            Controls.Add(IF100ListView);
            Controls.Add(currentlyConnectedListView);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(monitor);
            Controls.Add(ListenButton);
            Controls.Add(portTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox portTextBox;
        private Button ListenButton;
        private RichTextBox monitor;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListView currentlyConnectedListView;
        private ListView IF100ListView;
        private ListView SPS101ListView;
    }
}