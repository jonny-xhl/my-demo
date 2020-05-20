namespace Jonny.AllDemo.MISPOS
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
            this.btnSign = new System.Windows.Forms.Button();
            this.btn消费 = new System.Windows.Forms.Button();
            this.btn开启监听 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(466, 41);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(238, 107);
            this.btnSign.TabIndex = 0;
            this.btnSign.Text = "签到";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btn消费
            // 
            this.btn消费.Location = new System.Drawing.Point(772, 41);
            this.btn消费.Name = "btn消费";
            this.btn消费.Size = new System.Drawing.Size(238, 107);
            this.btn消费.TabIndex = 0;
            this.btn消费.Text = "消费";
            this.btn消费.UseVisualStyleBackColor = true;
            this.btn消费.Click += new System.EventHandler(this.btn消费_Click);
            // 
            // btn开启监听
            // 
            this.btn开启监听.Location = new System.Drawing.Point(45, 41);
            this.btn开启监听.Name = "btn开启监听";
            this.btn开启监听.Size = new System.Drawing.Size(238, 107);
            this.btn开启监听.TabIndex = 0;
            this.btn开启监听.Text = "开启监听";
            this.btn开启监听.UseVisualStyleBackColor = true;
            this.btn开启监听.Click += new System.EventHandler(this.btn开启监听_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 702);
            this.Controls.Add(this.btn消费);
            this.Controls.Add(this.btn开启监听);
            this.Controls.Add(this.btnSign);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btn消费;
        private System.Windows.Forms.Button btn开启监听;
    }
}

