namespace Jonny.AllDemo.SQLiteFirst
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitBusiness = new System.Windows.Forms.Button();
            this.gbx取票 = new System.Windows.Forms.GroupBox();
            this.btn健康体检 = new System.Windows.Forms.Button();
            this.btn团检 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl票号 = new System.Windows.Forms.Label();
            this.lbl业务 = new System.Windows.Forms.Label();
            this.lbl受理窗口 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl等候人数 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbx取票.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitBusiness
            // 
            this.btnInitBusiness.Location = new System.Drawing.Point(25, 30);
            this.btnInitBusiness.Name = "btnInitBusiness";
            this.btnInitBusiness.Size = new System.Drawing.Size(203, 94);
            this.btnInitBusiness.TabIndex = 0;
            this.btnInitBusiness.Text = "初始化业务数据";
            this.btnInitBusiness.UseVisualStyleBackColor = true;
            // 
            // gbx取票
            // 
            this.gbx取票.Controls.Add(this.btn团检);
            this.gbx取票.Controls.Add(this.btn健康体检);
            this.gbx取票.Location = new System.Drawing.Point(687, 30);
            this.gbx取票.Name = "gbx取票";
            this.gbx取票.Size = new System.Drawing.Size(514, 558);
            this.gbx取票.TabIndex = 1;
            this.gbx取票.TabStop = false;
            this.gbx取票.Text = "办理业务取票";
            // 
            // btn健康体检
            // 
            this.btn健康体检.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn健康体检.Location = new System.Drawing.Point(67, 122);
            this.btn健康体检.Name = "btn健康体检";
            this.btn健康体检.Size = new System.Drawing.Size(404, 146);
            this.btn健康体检.TabIndex = 0;
            this.btn健康体检.Text = "健康体检";
            this.btn健康体检.UseVisualStyleBackColor = true;
            this.btn健康体检.Click += new System.EventHandler(this.btn健康体检_Click);
            // 
            // btn团检
            // 
            this.btn团检.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn团检.Location = new System.Drawing.Point(67, 353);
            this.btn团检.Name = "btn团检";
            this.btn团检.Size = new System.Drawing.Size(404, 146);
            this.btn团检.TabIndex = 0;
            this.btn团检.Text = "职工体检";
            this.btn团检.UseVisualStyleBackColor = true;
            this.btn团检.Click += new System.EventHandler(this.btn团检_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl受理窗口);
            this.groupBox1.Controls.Add(this.lbl业务);
            this.groupBox1.Controls.Add(this.lbl等候人数);
            this.groupBox1.Controls.Add(this.lbl票号);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 458);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "票据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "重庆市第九人民医院体检中心";
            // 
            // lbl票号
            // 
            this.lbl票号.AutoSize = true;
            this.lbl票号.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl票号.Location = new System.Drawing.Point(258, 163);
            this.lbl票号.Name = "lbl票号";
            this.lbl票号.Size = new System.Drawing.Size(33, 36);
            this.lbl票号.TabIndex = 1;
            this.lbl票号.Text = "0";
            // 
            // lbl业务
            // 
            this.lbl业务.AutoSize = true;
            this.lbl业务.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl业务.Location = new System.Drawing.Point(249, 227);
            this.lbl业务.Name = "lbl业务";
            this.lbl业务.Size = new System.Drawing.Size(51, 36);
            this.lbl业务.TabIndex = 1;
            this.lbl业务.Text = "无";
            // 
            // lbl受理窗口
            // 
            this.lbl受理窗口.AutoSize = true;
            this.lbl受理窗口.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl受理窗口.Location = new System.Drawing.Point(249, 297);
            this.lbl受理窗口.Name = "lbl受理窗口";
            this.lbl受理窗口.Size = new System.Drawing.Size(51, 36);
            this.lbl受理窗口.TabIndex = 1;
            this.lbl受理窗口.Text = "无";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(498, 27);
            this.label5.TabIndex = 1;
            this.label5.Text = "温馨提示：请保管好自己的随身贵重物品";
            // 
            // lbl等候人数
            // 
            this.lbl等候人数.AutoSize = true;
            this.lbl等候人数.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl等候人数.Location = new System.Drawing.Point(533, 164);
            this.lbl等候人数.Name = "lbl等候人数";
            this.lbl等候人数.Size = new System.Drawing.Size(33, 36);
            this.lbl等候人数.TabIndex = 1;
            this.lbl等候人数.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "等候人数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "业务名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "受理窗口：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 627);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbx取票);
            this.Controls.Add(this.btnInitBusiness);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbx取票.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitBusiness;
        private System.Windows.Forms.GroupBox gbx取票;
        private System.Windows.Forms.Button btn团检;
        private System.Windows.Forms.Button btn健康体检;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl受理窗口;
        private System.Windows.Forms.Label lbl业务;
        private System.Windows.Forms.Label lbl票号;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl等候人数;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

