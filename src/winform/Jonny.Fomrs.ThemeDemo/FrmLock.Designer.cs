
namespace Jonny.Fomrs.ThemeDemo
{
    partial class FrmLock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioWhite = new System.Windows.Forms.RadioButton();
            this.radioDark = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(894, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 983);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统操作";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 174);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主题";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioWhite);
            this.panel2.Controls.Add(this.radioDark);
            this.panel2.Location = new System.Drawing.Point(6, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 59);
            this.panel2.TabIndex = 2;
            // 
            // radioWhite
            // 
            this.radioWhite.AutoSize = true;
            this.radioWhite.Location = new System.Drawing.Point(158, 14);
            this.radioWhite.Name = "radioWhite";
            this.radioWhite.Size = new System.Drawing.Size(100, 39);
            this.radioWhite.TabIndex = 1;
            this.radioWhite.TabStop = true;
            this.radioWhite.Text = "浅色";
            this.radioWhite.UseVisualStyleBackColor = true;
            this.radioWhite.Click += new System.EventHandler(this.RadioGroup_Click);
            // 
            // radioDark
            // 
            this.radioDark.AutoSize = true;
            this.radioDark.Location = new System.Drawing.Point(30, 14);
            this.radioDark.Name = "radioDark";
            this.radioDark.Size = new System.Drawing.Size(100, 39);
            this.radioDark.TabIndex = 0;
            this.radioDark.TabStop = true;
            this.radioDark.Text = "深色";
            this.radioDark.UseVisualStyleBackColor = true;
            this.radioDark.Click += new System.EventHandler(this.RadioGroup_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(75, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 35);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "姓名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(164, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 42);
            this.txtName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOther);
            this.panel1.Controls.Add(this.txtOther);
            this.panel1.Location = new System.Drawing.Point(75, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 275);
            this.panel1.TabIndex = 3;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(9, 36);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(69, 35);
            this.lblOther.TabIndex = 1;
            this.lblOther.Text = "其他";
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(89, 33);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(313, 42);
            this.txtOther.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(773, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 1007);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLock";
            this.Text = "FrmLock";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmLock_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioWhite;
        private System.Windows.Forms.RadioButton radioDark;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}

