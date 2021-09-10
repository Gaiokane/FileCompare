
namespace FileCompare
{
    partial class UCTempletesSetting
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.RichTextBoxTempleteDetails = new System.Windows.Forms.RichTextBox();
            this.LabNotic = new System.Windows.Forms.Label();
            this.LabTempleteName = new System.Windows.Forms.Label();
            this.GroupNewEdit = new System.Windows.Forms.GroupBox();
            this.BtnNewEditCancel = new System.Windows.Forms.Button();
            this.BtnNewEditSave = new System.Windows.Forms.Button();
            this.TextBoxTempleteName = new System.Windows.Forms.TextBox();
            this.GroupNewEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabTempletes
            // 
            this.LabTempletes.AutoSize = true;
            this.LabTempletes.Location = new System.Drawing.Point(15, 15);
            this.LabTempletes.Name = "LabTempletes";
            this.LabTempletes.Size = new System.Drawing.Size(65, 12);
            this.LabTempletes.TabIndex = 0;
            this.LabTempletes.Text = "比对模板：";
            // 
            // ComBoxTempletes
            // 
            this.ComBoxTempletes.FormattingEnabled = true;
            this.ComBoxTempletes.Location = new System.Drawing.Point(86, 12);
            this.ComBoxTempletes.Name = "ComBoxTempletes";
            this.ComBoxTempletes.Size = new System.Drawing.Size(121, 20);
            this.ComBoxTempletes.TabIndex = 1;
            this.ComBoxTempletes.SelectedIndexChanged += new System.EventHandler(this.ComBoxTempletes_SelectedIndexChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(213, 10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(294, 10);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 3;
            this.BtnNew.Text = "新增";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(375, 10);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 4;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(456, 10);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 5;
            this.BtnDel.Text = "删除";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // RichTextBoxTempleteDetails
            // 
            this.RichTextBoxTempleteDetails.Location = new System.Drawing.Point(3, 87);
            this.RichTextBoxTempleteDetails.Name = "RichTextBoxTempleteDetails";
            this.RichTextBoxTempleteDetails.Size = new System.Drawing.Size(794, 332);
            this.RichTextBoxTempleteDetails.TabIndex = 6;
            this.RichTextBoxTempleteDetails.Text = "";
            // 
            // LabNotic
            // 
            this.LabNotic.AutoSize = true;
            this.LabNotic.Location = new System.Drawing.Point(15, 36);
            this.LabNotic.Name = "LabNotic";
            this.LabNotic.Size = new System.Drawing.Size(413, 48);
            this.LabNotic.TabIndex = 7;
            this.LabNotic.Text = "路径中文件夹或文件中以\\分隔，最后一项需为文件名\r\n文件夹名或文件名左/右“%”代表模糊搜索（仅能在文件夹名和文件名左右）\r\n每行结尾需以;结尾\r\n如“编号_%\\" +
    "01_aa库\\01_bb区\\03_cc\\%_dd.xls%;”";
            // 
            // LabTempleteName
            // 
            this.LabTempleteName.AutoSize = true;
            this.LabTempleteName.Location = new System.Drawing.Point(6, 23);
            this.LabTempleteName.Name = "LabTempleteName";
            this.LabTempleteName.Size = new System.Drawing.Size(65, 12);
            this.LabTempleteName.TabIndex = 9;
            this.LabTempleteName.Text = "模板名称：";
            // 
            // GroupNewEdit
            // 
            this.GroupNewEdit.Controls.Add(this.BtnNewEditCancel);
            this.GroupNewEdit.Controls.Add(this.BtnNewEditSave);
            this.GroupNewEdit.Controls.Add(this.TextBoxTempleteName);
            this.GroupNewEdit.Controls.Add(this.LabTempleteName);
            this.GroupNewEdit.Location = new System.Drawing.Point(9, 36);
            this.GroupNewEdit.Name = "GroupNewEdit";
            this.GroupNewEdit.Size = new System.Drawing.Size(522, 48);
            this.GroupNewEdit.TabIndex = 10;
            this.GroupNewEdit.TabStop = false;
            this.GroupNewEdit.Text = "新增/编辑模板";
            // 
            // BtnNewEditCancel
            // 
            this.BtnNewEditCancel.Location = new System.Drawing.Point(285, 18);
            this.BtnNewEditCancel.Name = "BtnNewEditCancel";
            this.BtnNewEditCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnNewEditCancel.TabIndex = 12;
            this.BtnNewEditCancel.Text = "取消";
            this.BtnNewEditCancel.UseVisualStyleBackColor = true;
            this.BtnNewEditCancel.Click += new System.EventHandler(this.BtnNewEditCancel_Click);
            // 
            // BtnNewEditSave
            // 
            this.BtnNewEditSave.Location = new System.Drawing.Point(204, 18);
            this.BtnNewEditSave.Name = "BtnNewEditSave";
            this.BtnNewEditSave.Size = new System.Drawing.Size(75, 23);
            this.BtnNewEditSave.TabIndex = 12;
            this.BtnNewEditSave.Text = "保存";
            this.BtnNewEditSave.UseVisualStyleBackColor = true;
            this.BtnNewEditSave.Click += new System.EventHandler(this.BtnNewEditSave_Click);
            // 
            // TextBoxTempleteName
            // 
            this.TextBoxTempleteName.Location = new System.Drawing.Point(77, 20);
            this.TextBoxTempleteName.Name = "TextBoxTempleteName";
            this.TextBoxTempleteName.Size = new System.Drawing.Size(121, 21);
            this.TextBoxTempleteName.TabIndex = 11;
            // 
            // UCTempletesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupNewEdit);
            this.Controls.Add(this.LabNotic);
            this.Controls.Add(this.RichTextBoxTempleteDetails);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.ComBoxTempletes);
            this.Controls.Add(this.LabTempletes);
            this.Name = "UCTempletesSetting";
            this.Size = new System.Drawing.Size(800, 422);
            this.Load += new System.EventHandler(this.UCTempletesSetting_Load);
            this.GroupNewEdit.ResumeLayout(false);
            this.GroupNewEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabTempletes;
        private System.Windows.Forms.ComboBox ComBoxTempletes;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.RichTextBox RichTextBoxTempleteDetails;
        private System.Windows.Forms.Label LabNotic;
        private System.Windows.Forms.Label LabTempleteName;
        private System.Windows.Forms.GroupBox GroupNewEdit;
        private System.Windows.Forms.TextBox TextBoxTempleteName;
        private System.Windows.Forms.Button BtnNewEditCancel;
        private System.Windows.Forms.Button BtnNewEditSave;
    }
}
