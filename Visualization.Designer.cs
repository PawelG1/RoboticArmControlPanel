namespace espControl1
{
    partial class Visualization
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
            this.SuspendLayout();
            // 
            // close_bt
            // 
            this.close_bt.BackColor = System.Drawing.Color.Red;
            this.close_bt.Font = new System.Drawing.Font("Microsoft YaHei", 10.69307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.close_bt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.close_bt.Location = new System.Drawing.Point(691, 12);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(97, 36);
            this.close_bt.TabIndex = 0;
            this.close_bt.Text = "Close";
            this.close_bt.UseVisualStyleBackColor = false;
            // 
            // Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.close_bt);
            this.Name = "Visualization";
            this.Text = "visualization";
            this.Load += new System.EventHandler(this.Visualization_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button close_bt;
    }
}