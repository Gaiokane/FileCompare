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
    public partial class UCTempletesSetting : UserControl
    {
        #region 变量
        //新增/编辑，1=新增，2=编辑
        int NewOrEdit = 0;
        #endregion

        public UCTempletesSetting()
        {
            InitializeComponent();
        }

        #region 窗体加载
        private void UCTempletesSetting_Load(object sender, EventArgs e)
        {
            ComBoxTempletes.DropDownStyle = ComboBoxStyle.DropDownList;
            GroupNewEdit.Visible = false;
            RefreshComBoxTempletes();
        }
        #endregion

        #region 比对模板详情保存按钮
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TemplatesConfig.AddappSettings(ComBoxTempletes.SelectedItem.ToString(), RichTextBoxTempleteDetails.Text.Trim().Replace("\n", "")))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
        #endregion

        #region 新增按钮
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //新增
            NewOrEdit = 1;
            SetControlState(1);
        }
        #endregion

        #region 编辑按钮
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //编辑
            NewOrEdit = 2;
            SetControlState(1);
            TextBoxTempleteName.Text = ComBoxTempletes.SelectedItem.ToString();
            TextBoxTempleteName.SelectionStart = TextBoxTempleteName.Text.Length;
        }
        #endregion

        #region 删除按钮
        private void BtnDel_Click(object sender, EventArgs e)
        {
            //下拉无数据
            if (ComBoxTempletes.Items.Count <= 0)
            {
                MessageBox.Show("暂无比对模板，无法进行删除操作");
            }
            //下拉有数据但只有一条
            else if (ComBoxTempletes.Items.Count == 1)
            {
                MessageBox.Show("无法删除全部比对模板，请至少保留一个模板");
            }
            //下拉有数据且大于1条
            else
            {
                if (DialogResult.OK == MessageBox.Show("确认删除模板：" + ComBoxTempletes.SelectedItem.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                {
                    TemplatesConfig.DelappSettingsByValue("Templates", ComBoxTempletes.SelectedItem.ToString(), ';');
                    RefreshComBoxTempletes();
                    MessageBox.Show("删除成功");
                }
            }
        }
        #endregion

        #region 新增/编辑模板保存按钮
        private void BtnNewEditSave_Click(object sender, EventArgs e)
        {
            List<string> templates = TemplatesConfig.GetappSettingsSplitBySemicolon("Templates", ';');

            //新增
            if (NewOrEdit == 1)
            {
                /*
                 * 先查询所有模板名称
                 * 比对是否有重复值
                 * 无重复值则在原有值后累加新值
                */

                //输入项在现有比对模板中已存在
                if (templates.Contains(TextBoxTempleteName.Text.Trim()))
                {
                    MessageBox.Show("已存在重名比对模板，请重新输入");
                }
                //不存在，能够新增
                else
                {
                    templates.Add(TextBoxTempleteName.Text.Trim());
                    if (TemplatesConfig.EditappSettings("Templates", string.Join(";", templates.ToArray())) && TemplatesConfig.AddappSettings(TextBoxTempleteName.Text.Trim(), ""))
                    {
                        MessageBox.Show("新增成功");
                    }
                    else
                    {
                        MessageBox.Show("新增失败");
                    }
                    RefreshComBoxTempletes();
                }
            }
            //编辑
            else if (NewOrEdit == 2)
            {
                /*
                 * 先查询所有模板名称
                 * 比对下拉框所选是否存在
                 * 存在则删除原值，新增新值
                 * 获取原值模板详情
                 * 删除原值模板详情
                 * 新增新值模板详情
                */

                //下拉框所选要编辑项在配置文件中不存在
                if (!templates.Contains(ComBoxTempletes.SelectedItem.ToString()))
                {
                    MessageBox.Show("所选要编辑的比对模板在配置文件中不存在，请确认");
                }
                //配置文件中存在要编辑的值，能够编辑
                else
                {
                    //修改比对模板配置
                    templates.Remove(ComBoxTempletes.SelectedItem.ToString());
                    templates.Add(TextBoxTempleteName.Text.Trim());
                    if (TemplatesConfig.EditappSettings("Templates", string.Join(";", templates.ToArray())) && TemplatesConfig.AddappSettings(TextBoxTempleteName.Text.Trim(), ""))
                    {
                        //修改比对模板详情配置
                        string temp = TemplatesConfig.GetappSettings(ComBoxTempletes.SelectedItem.ToString());
                        if (TemplatesConfig.DelappSettings(ComBoxTempletes.SelectedItem.ToString()) && TemplatesConfig.AddappSettings(TextBoxTempleteName.Text.Trim(), temp))
                        {
                            MessageBox.Show("修改成功");
                        }
                        else
                        {
                            MessageBox.Show("修改失败");
                        }
                        RefreshComBoxTempletes();
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
            SetControlState(2);
            ResetNewEditControlValue();
        }
        #endregion

        #region 取消按钮
        private void BtnNewEditCancel_Click(object sender, EventArgs e)
        {
            SetControlState(2);
            ResetNewEditControlValue();
        }
        #endregion

        #region 比对模板下拉框切换刷新模板详情
        private void ComBoxTempletes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTempleteDetailsByTempletes(ComBoxTempletes.SelectedItem.ToString());
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
            RichTextBoxTempleteDetails.Text = temp;
            RichTextBoxTempleteDetails.SelectionStart = RichTextBoxTempleteDetails.Text.Length;
        }
        #endregion

        #region 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="NewOrEdit">新增编辑/保存取消，1=新增编辑，2=保存取消</param>
        private void SetControlState(int NewOrEdit = 0)
        {
            //新增编辑
            if (NewOrEdit == 1)
            {
                LabNotic.Visible = false;
                GroupNewEdit.Visible = true;
                ComBoxTempletes.Enabled = false;
                BtnSave.Enabled = false;
                BtnNew.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                RichTextBoxTempleteDetails.Enabled = false;
            }
            //保存取消
            else if (NewOrEdit == 2)
            {
                LabNotic.Visible = true;
                GroupNewEdit.Visible = false;
                ComBoxTempletes.Enabled = true;
                BtnSave.Enabled = true;
                BtnNew.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
                RichTextBoxTempleteDetails.Enabled = true;
            }
            //其他 出错
            else
            {
                MessageBox.Show("SetControlState Error");
            }
        }
        #endregion

        #region 新增编辑group中 名称 置空
        /// <summary>
        /// 新增编辑group中 名称 置空
        /// </summary>
        private void ResetNewEditControlValue()
        {
            TextBoxTempleteName.Text = "";
        }
        #endregion
    }
}