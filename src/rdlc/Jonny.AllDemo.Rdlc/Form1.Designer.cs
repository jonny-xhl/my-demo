namespace Jonny.AllDemo.Rdlc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewControl = new System.Windows.Forms.PrintPreviewControl();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrintSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewControl
            // 
            this.printPreviewControl.Location = new System.Drawing.Point(12, 425);
            this.printPreviewControl.Name = "printPreviewControl";
            this.printPreviewControl.Size = new System.Drawing.Size(2234, 951);
            this.printPreviewControl.TabIndex = 0;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(30, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(159, 83);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(223, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(159, 83);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrintSetting
            // 
            this.btnPrintSetting.Location = new System.Drawing.Point(420, 12);
            this.btnPrintSetting.Name = "btnPrintSetting";
            this.btnPrintSetting.Size = new System.Drawing.Size(159, 83);
            this.btnPrintSetting.TabIndex = 1;
            this.btnPrintSetting.Text = "打印设置";
            this.btnPrintSetting.UseVisualStyleBackColor = true;
            this.btnPrintSetting.Click += new System.EventHandler(this.btnPrintSetting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2885, 1745);
            this.Controls.Add(this.btnPrintSetting);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.printPreviewControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrintSetting;
    }
}

