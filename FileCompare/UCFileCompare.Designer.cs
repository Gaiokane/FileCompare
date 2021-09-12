
namespace FileCompare
{
    partial class UCFileCompare
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabTempletes = new System.Windows.Forms.Label();
            this.ComBoxTempletes = new System.Windows.Forms.ComboBox();
            this.LabComparePath = new System.Windows.Forms.Label();
            this.TextBoxComparePath = new System.Windows.Forms.TextBox();
            this.BtnConfirmPath = new System.Windows.Forms.Button();
            this.BtnCompare = new System.Windows.Forms.Button();
            this.LabCompareFolder = new System.Windows.Forms.Label();
            this.TVCompareFolder = new System.Windows.Forms.TreeView();
            this.LabCompareResult = new System.Windows.Forms.Label();
            this.BtnCopyToClipboard = new System.Windows.Forms.Button();
            this.BtnSaveToFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LabTempletes
            // 
            this.LabTempletes.AutoSize = true;
            this.LabTempletes.Location = new System.Drawing.Point(3, 10);
            this.LabTempletes.Name = "LabTempletes";
            this.LabTempletes.Size = new System.Drawing.Size(65, 12);
            this.LabTempletes.TabIndex = 0;
            this.LabTempletes.Text = "比对模板：";
            // 
            // ComBoxTempletes
            // 
            this.ComBoxTempletes.FormattingEnabled = true;
            this.ComBoxTempletes.Location = new System.Drawing.Point(74, 7);
            this.ComBoxTempletes.Name = "ComBoxTempletes";
            this.ComBoxTempletes.Size = new System.Drawing.Size(121, 20);
            this.ComBoxTempletes.TabIndex = 2;
            // 
            // LabComparePath
            // 
            this.LabComparePath.AutoSize = true;
            this.LabComparePath.Location = new System.Drawing.Point(201, 10);
            this.LabComparePath.Name = "LabComparePath";
            this.LabComparePath.Size = new System.Drawing.Size(89, 12);
            this.LabComparePath.TabIndex = 3;
            this.LabComparePath.Text = "比对文件路径：";
            // 
            // TextBoxComparePath
            // 
            this.TextBoxComparePath.Location = new System.Drawing.Point(296, 7);
            this.TextBoxComparePath.Name = "TextBoxComparePath";
            this.TextBoxComparePath.Size = new System.Drawing.Size(326, 21);
            this.TextBoxComparePath.TabIndex = 14;
            // 
            // BtnConfirmPath
            // 
            this.BtnConfirmPath.Location = new System.Drawing.Point(628, 5);
            this.BtnConfirmPath.Name = "BtnConfirmPath";
            this.BtnConfirmPath.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirmPath.TabIndex = 15;
            this.BtnConfirmPath.Text = "确认路径";
            this.BtnConfirmPath.UseVisualStyleBackColor = true;
            // 
            // BtnCompare
            // 
            this.BtnCompare.Location = new System.Drawing.Point(709, 5);
            this.BtnCompare.Name = "BtnCompare";
            this.BtnCompare.Size = new System.Drawing.Size(75, 23);
            this.BtnCompare.TabIndex = 16;
            this.BtnCompare.Text = "开始比对";
            this.BtnCompare.UseVisualStyleBackColor = true;
            // 
            // LabCompareFolder
            // 
            this.LabCompareFolder.AutoSize = true;
            this.LabCompareFolder.Location = new System.Drawing.Point(3, 39);
            this.LabCompareFolder.Name = "LabCompareFolder";
            this.LabCompareFolder.Size = new System.Drawing.Size(65, 12);
            this.LabCompareFolder.TabIndex = 17;
            this.LabCompareFolder.Text = "比对目录：";
            // 
            // TVCompareFolder
            // 
            this.TVCompareFolder.Location = new System.Drawing.Point(3, 63);
            this.TVCompareFolder.Name = "TVCompareFolder";
            this.TVCompareFolder.Size = new System.Drawing.Size(190, 356);
            this.TVCompareFolder.TabIndex = 18;
            // 
            // LabCompareResult
            // 
            this.LabCompareResult.AutoSize = true;
            this.LabCompareResult.Location = new System.Drawing.Point(201, 39);
            this.LabCompareResult.Name = "LabCompareResult";
            this.LabCompareResult.Size = new System.Drawing.Size(65, 12);
            this.LabCompareResult.TabIndex = 19;
            this.LabCompareResult.Text = "比对结果：";
            // 
            // BtnCopyToClipboard
            // 
            this.BtnCopyToClipboard.Location = new System.Drawing.Point(272, 34);
            this.BtnCopyToClipboard.Name = "BtnCopyToClipboard";
            this.BtnCopyToClipboard.Size = new System.Drawing.Size(85, 23);
            this.BtnCopyToClipboard.TabIndex = 20;
            this.BtnCopyToClipboard.Text = "复制到剪切板";
            this.BtnCopyToClipboard.UseVisualStyleBackColor = true;
            // 
            // BtnSaveToFile
            // 
            this.BtnSaveToFile.Location = new System.Drawing.Point(363, 34);
            this.BtnSaveToFile.Name = "BtnSaveToFile";
            this.BtnSaveToFile.Size = new System.Drawing.Size(85, 23);
            this.BtnSaveToFile.TabIndex = 21;
            this.BtnSaveToFile.Text = "保存到文件";
            this.BtnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(199, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(598, 356);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            // 
            // UCFileCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnSaveToFile);
            this.Controls.Add(this.BtnCopyToClipboard);
            this.Controls.Add(this.LabCompareResult);
            this.Controls.Add(this.TVCompareFolder);
            this.Controls.Add(this.LabCompareFolder);
            this.Controls.Add(this.BtnCompare);
            this.Controls.Add(this.BtnConfirmPath);
            this.Controls.Add(this.TextBoxComparePath);
            this.Controls.Add(this.LabComparePath);
            this.Controls.Add(this.ComBoxTempletes);
            this.Controls.Add(this.LabTempletes);
            this.Name = "UCFileCompare";
            this.Size = new System.Drawing.Size(800, 422);
            this.Load += new System.EventHandler(this.UCFileCompare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabTempletes;
        private System.Windows.Forms.ComboBox ComBoxTempletes;
        private System.Windows.Forms.Label LabComparePath;
        private System.Windows.Forms.TextBox TextBoxComparePath;
        private System.Windows.Forms.Button BtnConfirmPath;
        private System.Windows.Forms.Button BtnCompare;
        private System.Windows.Forms.Label LabCompareFolder;
        private System.Windows.Forms.TreeView TVCompareFolder;
        private System.Windows.Forms.Label LabCompareResult;
        private System.Windows.Forms.Button BtnCopyToClipboard;
        private System.Windows.Forms.Button BtnSaveToFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
