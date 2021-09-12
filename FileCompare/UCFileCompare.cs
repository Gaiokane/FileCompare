using FileCompare.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class UCFileCompare : UserControl
    {
        /*
         * 获取所选模板对应详情
         * 
         */

        #region 变量
        //所选比对模板对应模板详情
        private string templateDetails = "";
        #endregion

        public UCFileCompare()
        {
            InitializeComponent();
        }

        #region 窗体加载
        private void UCFileCompare_Load(object sender, EventArgs e)
        {
            //RichTextBox增加右键菜单
            _ = new RichTextBoxMenu(RichTextBoxCompareResult);

            //比对模板下拉框修改样式
            ComBoxTempletes.DropDownStyle = ComboBoxStyle.DropDownList;
            //重新绑定比对模板下拉框数据
            RefreshComBoxTempletes();

            //tv显示节点显示复选框
            TVCompareFolder.CheckBoxes = true;
            //tv节点间不显示连线
            TVCompareFolder.ShowLines = false;
            //重新绑定比对目录数据
            TVCompareFolderRefresh();
        }
        #endregion

        #region 确认路径按钮
        private void BtnConfirmPath_Click(object sender, EventArgs e)
        {
            TVCompareFolderRefresh();
        }
        #endregion

        private void BtnCompare_Click(object sender, EventArgs e)
        {

        }

        #region 重新绑定 比对目录 数据
        private void TVCompareFolderRefresh()
        {
            TVCompareFolder.Nodes.Clear();
            TVCompareFolder.Nodes.Add("全选");
            foreach (var item in FileSystemEntriesHelper.GetDirectories(TextBoxComparePath.Text.Trim(), "^(?!\\.).*", 0, false))
            {
                List<string> list = item.Split('\\').ToList();
                TVCompareFolder.Nodes[0].Nodes.Add(list[list.Count - 1]);
            }
            TVCompareFolder.ExpandAll();
        }
        #endregion

        #region 复制到剪切板按钮
        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RichTextBoxCompareResult.Text.Trim());
            MessageBox.Show("复制成功");
        }
        #endregion

        #region 保存到文件按钮
        private void BtnSaveToFile_Click(object sender, EventArgs e)
        {
            string rootPath = Environment.CurrentDirectory;
            string compareResultPath = rootPath + "\\CompareResult";
            FileHelper.CreateNewDirectory(compareResultPath);
            string compareResultFilePath = compareResultPath + "\\CompareResult" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            FileHelper.CreateNewFile(compareResultFilePath, RichTextBoxCompareResult.Text.Trim());
            MessageBox.Show("保存成功\r\n" + compareResultFilePath);
        }
        #endregion

        #region 重新绑定 比对模板 下拉框数据
        /// <summary>
        /// 重新绑定 比对模板 下拉框数据
        /// </summary>
        private void RefreshComBoxTempletes()
        {
            ComBoxTempletes.Items.Clear();
            List<string> templates;
            templates = TemplatesConfig.GetappSettingsSplitBySemicolon("Templates", ';');
            //将list中元素倒叙
            templates.Reverse();
            foreach (var item in templates)
            {
                ComBoxTempletes.Items.Add(item);
            }
            if (ComBoxTempletes.Items.Count > 0)
            {
                ComBoxTempletes.SelectedIndex = 0;
                GetTempleteDetailsByTempletes(ComBoxTempletes.SelectedItem.ToString());
            }
        }
        #endregion

        #region 根据所选模板获取模板详情
        /// <summary>
        /// 根据所选模板获取模板详情
        /// </summary>
        /// <param name="templete">模板名称</param>
        private void GetTempleteDetailsByTempletes(string templete)
        {
            List<string> templateDetails;
            string temp = "";
            templateDetails = TemplatesConfig.GetappSettingsSplitBySemicolon(templete, ';');
            for (int i = 0; i < templateDetails.Count; i++)
            {
                if (i == templateDetails.Count - 1)
                {
                    temp += templateDetails[i] + ";";
                }
                else
                {
                    temp += templateDetails[i] + ";\r\n";
                }
            }
            this.templateDetails = temp;
        }
        #endregion

        #region 比对模板下拉框切换刷新模板详情
        private void ComBoxTempletes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTempleteDetailsByTempletes(ComBoxTempletes.SelectedItem.ToString());
        }
        #endregion

        #region 重写tv勾选节点复选框checked属性
        private void TVCompareFolder_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewCheck.CheckControl(e);
        }
        #endregion
    }
}