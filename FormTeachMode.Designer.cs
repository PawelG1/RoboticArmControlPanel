namespace espControl1
{
    partial class FormTeachMode
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
            this.close_bt = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grp_tb = new System.Windows.Forms.TextBox();
            this.grip_trb = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.j2Rot_tb = new System.Windows.Forms.TextBox();
            this.j2Rot_trb = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.j1Rot_tb = new System.Windows.Forms.TextBox();
            this.j1Rot_trb = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baseRot_tb = new System.Windows.Forms.TextBox();
            this.baseRot_trb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.addPos_bt = new System.Windows.Forms.Button();
            this.autoMode_bt = new System.Windows.Forms.Button();
            this.points_lv = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grip_trb)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.j2Rot_trb)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.j1Rot_trb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseRot_trb)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // close_bt
            // 
            this.close_bt.BackColor = System.Drawing.Color.Red;
            this.close_bt.Location = new System.Drawing.Point(12, 409);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(130, 29);
            this.close_bt.TabIndex = 11;
            this.close_bt.Text = "Return";
            this.close_bt.UseMnemonic = false;
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grp_tb);
            this.groupBox4.Controls.Add(this.grip_trb);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 68);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gripper";
            // 
            // grp_tb
            // 
            this.grp_tb.Location = new System.Drawing.Point(339, 32);
            this.grp_tb.Name = "grp_tb";
            this.grp_tb.Size = new System.Drawing.Size(80, 20);
            this.grp_tb.TabIndex = 3;
            // 
            // grip_trb
            // 
            this.grip_trb.LargeChange = 15;
            this.grip_trb.Location = new System.Drawing.Point(7, 14);
            this.grip_trb.Maximum = 180;
            this.grip_trb.Name = "grip_trb";
            this.grip_trb.Size = new System.Drawing.Size(326, 48);
            this.grip_trb.SmallChange = 5;
            this.grip_trb.TabIndex = 0;
            this.grip_trb.TickFrequency = 5;
            this.grip_trb.Value = 90;
            this.grip_trb.Scroll += new System.EventHandler(this.grip_trb_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Servo Position: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.j2Rot_tb);
            this.groupBox3.Controls.Add(this.j2Rot_trb);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(433, 68);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2 Joint Rotation";
            // 
            // j2Rot_tb
            // 
            this.j2Rot_tb.Location = new System.Drawing.Point(339, 32);
            this.j2Rot_tb.Name = "j2Rot_tb";
            this.j2Rot_tb.Size = new System.Drawing.Size(80, 20);
            this.j2Rot_tb.TabIndex = 3;
            // 
            // j2Rot_trb
            // 
            this.j2Rot_trb.LargeChange = 15;
            this.j2Rot_trb.Location = new System.Drawing.Point(7, 14);
            this.j2Rot_trb.Maximum = 180;
            this.j2Rot_trb.Name = "j2Rot_trb";
            this.j2Rot_trb.Size = new System.Drawing.Size(326, 48);
            this.j2Rot_trb.SmallChange = 5;
            this.j2Rot_trb.TabIndex = 0;
            this.j2Rot_trb.TickFrequency = 5;
            this.j2Rot_trb.Value = 90;
            this.j2Rot_trb.Scroll += new System.EventHandler(this.j2Rot_trb_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Servo Position: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.j1Rot_tb);
            this.groupBox2.Controls.Add(this.j1Rot_trb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 68);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1 Joint Rotation";
            // 
            // j1Rot_tb
            // 
            this.j1Rot_tb.Location = new System.Drawing.Point(339, 32);
            this.j1Rot_tb.Name = "j1Rot_tb";
            this.j1Rot_tb.Size = new System.Drawing.Size(80, 20);
            this.j1Rot_tb.TabIndex = 3;
            // 
            // j1Rot_trb
            // 
            this.j1Rot_trb.LargeChange = 15;
            this.j1Rot_trb.Location = new System.Drawing.Point(7, 14);
            this.j1Rot_trb.Maximum = 180;
            this.j1Rot_trb.Name = "j1Rot_trb";
            this.j1Rot_trb.Size = new System.Drawing.Size(326, 48);
            this.j1Rot_trb.SmallChange = 5;
            this.j1Rot_trb.TabIndex = 0;
            this.j1Rot_trb.TickFrequency = 5;
            this.j1Rot_trb.Value = 90;
            this.j1Rot_trb.Scroll += new System.EventHandler(this.j1Rot_trb_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servo Position: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baseRot_tb);
            this.groupBox1.Controls.Add(this.baseRot_trb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Rotation";
            // 
            // baseRot_tb
            // 
            this.baseRot_tb.Location = new System.Drawing.Point(339, 32);
            this.baseRot_tb.Name = "baseRot_tb";
            this.baseRot_tb.Size = new System.Drawing.Size(80, 20);
            this.baseRot_tb.TabIndex = 2;
            this.baseRot_tb.TextChanged += new System.EventHandler(this.baseRot_tb_TextChanged);
            // 
            // baseRot_trb
            // 
            this.baseRot_trb.LargeChange = 15;
            this.baseRot_trb.Location = new System.Drawing.Point(7, 14);
            this.baseRot_trb.Maximum = 180;
            this.baseRot_trb.Name = "baseRot_trb";
            this.baseRot_trb.Size = new System.Drawing.Size(326, 48);
            this.baseRot_trb.SmallChange = 5;
            this.baseRot_trb.TabIndex = 0;
            this.baseRot_trb.TickFrequency = 5;
            this.baseRot_trb.Value = 90;
            this.baseRot_trb.Scroll += new System.EventHandler(this.baseRot_trb_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servo Position: ";
            // 
            // addPos_bt
            // 
            this.addPos_bt.BackColor = System.Drawing.Color.DodgerBlue;
            this.addPos_bt.Location = new System.Drawing.Point(12, 323);
            this.addPos_bt.Name = "addPos_bt";
            this.addPos_bt.Size = new System.Drawing.Size(207, 45);
            this.addPos_bt.TabIndex = 12;
            this.addPos_bt.Text = "Add point";
            this.addPos_bt.UseVisualStyleBackColor = false;
            this.addPos_bt.Click += new System.EventHandler(this.addPos_bt_Click);
            // 
            // autoMode_bt
            // 
            this.autoMode_bt.BackColor = System.Drawing.Color.DodgerBlue;
            this.autoMode_bt.Location = new System.Drawing.Point(242, 323);
            this.autoMode_bt.Name = "autoMode_bt";
            this.autoMode_bt.Size = new System.Drawing.Size(203, 45);
            this.autoMode_bt.TabIndex = 13;
            this.autoMode_bt.Text = "Automatic Mode";
            this.autoMode_bt.UseVisualStyleBackColor = false;
            this.autoMode_bt.Click += new System.EventHandler(this.autoMode_bt_Click);
            // 
            // points_lv
            // 
            this.points_lv.GridLines = true;
            this.points_lv.HideSelection = false;
            this.points_lv.Location = new System.Drawing.Point(6, 19);
            this.points_lv.Name = "points_lv";
            this.points_lv.Size = new System.Drawing.Size(309, 398);
            this.points_lv.TabIndex = 14;
            this.points_lv.UseCompatibleStateImageBehavior = false;
            this.points_lv.View = System.Windows.Forms.View.List;
            this.points_lv.SelectedIndexChanged += new System.EventHandler(this.points_lv_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.points_lv);
            this.groupBox5.Location = new System.Drawing.Point(467, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(321, 423);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Points:";
            // 
            // FormTeachMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.autoMode_bt);
            this.Controls.Add(this.addPos_bt);
            this.Controls.Add(this.close_bt);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTeachMode";
            this.Text = "FormTeachMode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTeachMode_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grip_trb)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.j2Rot_trb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.j1Rot_trb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseRot_trb)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button close_bt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox grp_tb;
        private System.Windows.Forms.TrackBar grip_trb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox j2Rot_tb;
        private System.Windows.Forms.TrackBar j2Rot_trb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox j1Rot_tb;
        private System.Windows.Forms.TrackBar j1Rot_trb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox baseRot_tb;
        private System.Windows.Forms.TrackBar baseRot_trb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPos_bt;
        private System.Windows.Forms.Button autoMode_bt;
        private System.Windows.Forms.ListView points_lv;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}