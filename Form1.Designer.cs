namespace espControl1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sendMessage_tb = new System.Windows.Forms.TextBox();
            this.received_rtb = new System.Windows.Forms.RichTextBox();
            this.send_bt = new System.Windows.Forms.Button();
            this.connect_bt = new System.Windows.Forms.Button();
            this.disconnect_bt = new System.Windows.Forms.Button();
            this.ports_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refresh_bt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teach_bt = new System.Windows.Forms.Button();
            this.Cartesian_bt = new System.Windows.Forms.Button();
            this.joint_bt = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendMessage_tb
            // 
            this.sendMessage_tb.Location = new System.Drawing.Point(422, 387);
            this.sendMessage_tb.Multiline = true;
            this.sendMessage_tb.Name = "sendMessage_tb";
            this.sendMessage_tb.Size = new System.Drawing.Size(281, 23);
            this.sendMessage_tb.TabIndex = 0;
            // 
            // received_rtb
            // 
            this.received_rtb.Location = new System.Drawing.Point(728, 387);
            this.received_rtb.Name = "received_rtb";
            this.received_rtb.ReadOnly = true;
            this.received_rtb.Size = new System.Drawing.Size(314, 183);
            this.received_rtb.TabIndex = 1;
            this.received_rtb.Text = "";
            // 
            // send_bt
            // 
            this.send_bt.BackColor = System.Drawing.Color.Blue;
            this.send_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.send_bt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.send_bt.Location = new System.Drawing.Point(422, 467);
            this.send_bt.Name = "send_bt";
            this.send_bt.Size = new System.Drawing.Size(281, 42);
            this.send_bt.TabIndex = 2;
            this.send_bt.Text = "SEND";
            this.send_bt.UseVisualStyleBackColor = false;
            this.send_bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // connect_bt
            // 
            this.connect_bt.Location = new System.Drawing.Point(18, 95);
            this.connect_bt.Name = "connect_bt";
            this.connect_bt.Size = new System.Drawing.Size(172, 46);
            this.connect_bt.TabIndex = 3;
            this.connect_bt.Text = "CONNECT";
            this.connect_bt.UseVisualStyleBackColor = true;
            this.connect_bt.Click += new System.EventHandler(this.connect_bt_Click);
            // 
            // disconnect_bt
            // 
            this.disconnect_bt.Location = new System.Drawing.Point(196, 95);
            this.disconnect_bt.Name = "disconnect_bt";
            this.disconnect_bt.Size = new System.Drawing.Size(172, 46);
            this.disconnect_bt.TabIndex = 4;
            this.disconnect_bt.Text = "DISCONNECT";
            this.disconnect_bt.UseVisualStyleBackColor = true;
            this.disconnect_bt.Click += new System.EventHandler(this.disconnect_bt_Click);
            // 
            // ports_combo
            // 
            this.ports_combo.FormattingEnabled = true;
            this.ports_combo.Location = new System.Drawing.Point(90, 49);
            this.ports_combo.Name = "ports_combo";
            this.ports_combo.Size = new System.Drawing.Size(278, 21);
            this.ports_combo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select available serial port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Command to be send";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(725, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Received messages";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(409, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(633, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refresh_bt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.connect_bt);
            this.groupBox1.Controls.Add(this.disconnect_bt);
            this.groupBox1.Controls.Add(this.ports_combo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 166);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Establish Connection";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // refresh_bt
            // 
            this.refresh_bt.Location = new System.Drawing.Point(18, 48);
            this.refresh_bt.Name = "refresh_bt";
            this.refresh_bt.Size = new System.Drawing.Size(66, 22);
            this.refresh_bt.TabIndex = 7;
            this.refresh_bt.Text = "Refresh";
            this.refresh_bt.UseVisualStyleBackColor = true;
            this.refresh_bt.Click += new System.EventHandler(this.refresh_bt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select available serial port";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(18, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "CONNECT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.connect_bt_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(196, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "DISCONNECT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.disconnect_bt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.teach_bt);
            this.groupBox2.Controls.Add(this.Cartesian_bt);
            this.groupBox2.Controls.Add(this.joint_bt);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 376);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available functions:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // teach_bt
            // 
            this.teach_bt.Location = new System.Drawing.Point(18, 139);
            this.teach_bt.Name = "teach_bt";
            this.teach_bt.Size = new System.Drawing.Size(350, 49);
            this.teach_bt.TabIndex = 2;
            this.teach_bt.Text = "Teach Mode";
            this.teach_bt.UseVisualStyleBackColor = true;
            this.teach_bt.Click += new System.EventHandler(this.teach_bt_Click);
            // 
            // Cartesian_bt
            // 
            this.Cartesian_bt.Location = new System.Drawing.Point(18, 84);
            this.Cartesian_bt.Name = "Cartesian_bt";
            this.Cartesian_bt.Size = new System.Drawing.Size(350, 49);
            this.Cartesian_bt.TabIndex = 1;
            this.Cartesian_bt.Text = "Cartesian Space Control";
            this.Cartesian_bt.UseVisualStyleBackColor = true;
            this.Cartesian_bt.Click += new System.EventHandler(this.button5_Click);
            // 
            // joint_bt
            // 
            this.joint_bt.Location = new System.Drawing.Point(18, 29);
            this.joint_bt.Name = "joint_bt";
            this.joint_bt.Size = new System.Drawing.Size(350, 49);
            this.joint_bt.TabIndex = 0;
            this.joint_bt.Text = "Joint Space Control";
            this.joint_bt.UseVisualStyleBackColor = true;
            this.joint_bt.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.841584F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(901, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 45);
            this.button4.TabIndex = 12;
            this.button4.Text = "CLOSE APP";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(419, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 39);
            this.label5.TabIndex = 13;
            this.label5.Text = "e.g. \'P23 H\' - sets pin GPIO23 to High state\r\n      \'P21 180deg\' - drives servo a" +
    "ttached to GPIO21 to\r\n      180 deg position\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 582);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.send_bt);
            this.Controls.Add(this.received_rtb);
            this.Controls.Add(this.sendMessage_tb);
            this.Name = "Form1";
            this.Text = "RobotArm Control Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendMessage_tb;
        private System.Windows.Forms.RichTextBox received_rtb;
        private System.Windows.Forms.Button send_bt;
        private System.Windows.Forms.Button connect_bt;
        private System.Windows.Forms.Button disconnect_bt;
        private System.Windows.Forms.ComboBox ports_combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button joint_bt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button teach_bt;
        private System.Windows.Forms.Button Cartesian_bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button refresh_bt;
    }
}

