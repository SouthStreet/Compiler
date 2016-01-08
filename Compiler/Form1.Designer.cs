namespace Compiler
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
            this.bt1 = new System.Windows.Forms.Button();
            this.rtbSource = new System.Windows.Forms.RichTextBox();
            this.rtbToken = new System.Windows.Forms.RichTextBox();
            this.rtbThreeCode = new System.Windows.Forms.RichTextBox();
            this.rtbLLParser = new System.Windows.Forms.RichTextBox();
            this.bt2 = new System.Windows.Forms.Button();
            this.tVSyntax = new System.Windows.Forms.TreeView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openfile = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savescan = new System.Windows.Forms.ToolStripMenuItem();
            this.saveparser = new System.Windows.Forms.ToolStripMenuItem();
            this.save3address = new System.Windows.Forms.ToolStripMenuItem();
            this.btclear = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(339, 2);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(75, 23);
            this.bt1.TabIndex = 0;
            this.bt1.Text = "词法分析";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // rtbSource
            // 
            this.rtbSource.BackColor = System.Drawing.SystemColors.Window;
            this.rtbSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSource.Location = new System.Drawing.Point(0, 28);
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.Size = new System.Drawing.Size(330, 494);
            this.rtbSource.TabIndex = 1;
            this.rtbSource.Text = "";
            this.rtbSource.TextChanged += new System.EventHandler(this.rtbSource_TextChanged);
            // 
            // rtbToken
            // 
            this.rtbToken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbToken.Location = new System.Drawing.Point(336, 28);
            this.rtbToken.Name = "rtbToken";
            this.rtbToken.Size = new System.Drawing.Size(265, 280);
            this.rtbToken.TabIndex = 2;
            this.rtbToken.Text = "";
            // 
            // rtbThreeCode
            // 
            this.rtbThreeCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbThreeCode.Location = new System.Drawing.Point(913, 29);
            this.rtbThreeCode.Name = "rtbThreeCode";
            this.rtbThreeCode.Size = new System.Drawing.Size(239, 494);
            this.rtbThreeCode.TabIndex = 3;
            this.rtbThreeCode.Text = "";
            // 
            // rtbLLParser
            // 
            this.rtbLLParser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLLParser.Location = new System.Drawing.Point(339, 315);
            this.rtbLLParser.Name = "rtbLLParser";
            this.rtbLLParser.Size = new System.Drawing.Size(568, 200);
            this.rtbLLParser.TabIndex = 4;
            this.rtbLLParser.Text = "";
            // 
            // bt2
            // 
            this.bt2.Location = new System.Drawing.Point(646, 0);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(75, 23);
            this.bt2.TabIndex = 5;
            this.bt2.Text = "语法分析";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // tVSyntax
            // 
            this.tVSyntax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tVSyntax.Location = new System.Drawing.Point(607, 29);
            this.tVSyntax.Name = "tVSyntax";
            this.tVSyntax.Size = new System.Drawing.Size(300, 279);
            this.tVSyntax.TabIndex = 6;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1164, 25);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfile,
            this.保存文件ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // openfile
            // 
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(152, 22);
            this.openfile.Text = "打开文件";
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savescan,
            this.saveparser,
            this.save3address});
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存文件ToolStripMenuItem.Text = "保存文件";
            // 
            // savescan
            // 
            this.savescan.Name = "savescan";
            this.savescan.Size = new System.Drawing.Size(152, 22);
            this.savescan.Text = "词法分析";
            this.savescan.Click += new System.EventHandler(this.savescan_Click);
            // 
            // saveparser
            // 
            this.saveparser.Name = "saveparser";
            this.saveparser.Size = new System.Drawing.Size(152, 22);
            this.saveparser.Text = "语法分析";
            this.saveparser.Click += new System.EventHandler(this.saveparser_Click);
            // 
            // save3address
            // 
            this.save3address.Name = "save3address";
            this.save3address.Size = new System.Drawing.Size(152, 22);
            this.save3address.Text = "三地址代码";
            this.save3address.Click += new System.EventHandler(this.save3address_Click);
            // 
            // btclear
            // 
            this.btclear.Location = new System.Drawing.Point(881, 2);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(75, 23);
            this.btclear.TabIndex = 8;
            this.btclear.Text = "清除";
            this.btclear.UseVisualStyleBackColor = true;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1164, 527);
            this.Controls.Add(this.btclear);
            this.Controls.Add(this.tVSyntax);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.rtbLLParser);
            this.Controls.Add(this.rtbThreeCode);
            this.Controls.Add(this.rtbToken);
            this.Controls.Add(this.rtbSource);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.RichTextBox rtbSource;
        private System.Windows.Forms.RichTextBox rtbToken;
        private System.Windows.Forms.RichTextBox rtbThreeCode;
        private System.Windows.Forms.RichTextBox rtbLLParser;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.TreeView tVSyntax;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openfile;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savescan;
        private System.Windows.Forms.ToolStripMenuItem saveparser;
        private System.Windows.Forms.ToolStripMenuItem save3address;
        private System.Windows.Forms.Button btclear;
    }
}

