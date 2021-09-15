using FileCompare.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class UCFileCompare : UserControl
    {
        /*
         * 比对逻辑：
         * 用程序里现有的 遍历路径下文件
         * 获取所选模板对应详情
         * 逐行读取详情，如取第一条“ZAA_%\01_开发库\01_文档区\03_系统测试\%_ST_系统测试报告.doc%”（第一级ZAA要特殊处理，拼上勾选的文件夹名称，可能在模板里也不需要配）
         * 将详情第一条中的%替换为(?!%).*可能\要替换为\\（正则转义）
         * 将新生成的行当作正则表达式去校验遍历出来的文件路径
         * 匹配则跳过，无匹配则记录
         * 
         * 
         * 
         * 测试正则：
         * 正则表达式
         * ZAA_(?!%).*\\01_开发库\\01_文档区\\03_系统测试\\(?!%).*_ST_系统测试报告.doc(?!%).*
         * 待匹配文本
         * ZAA_%\01_开发库\01_文档区\03_系统测试\%_ST_系统测试报告.doc%;
         * ZAA_123\01_开发库\01_文档区\03_系统测试\123_ST_系统测试报告.doc
         * ZAA_111\01_开发库\01_文档区\03_系统测试\111_ST_系统测试报告.docx
         * ZAA_111\02_开发库\01_文档区\03_系统测试\111_ST_系统测试报告.docx
         * ZAA_*\01_开发库\01_文档区\03_系统测试\%_ST_系统测试报告.doc%
         * 共找到 2 处匹配：
         * ZAA_123\01_开发库\01_文档区\03_系统测试\123_ST_系统测试报告.doc
         * ZAA_111\01_开发库\01_文档区\03_系统测试\111_ST_系统测试报告.docx
         */

        #region 变量
        //所选比对模板对应模板详情
        private string templateDetails = "";
        //正则
        Regex rgTemplateDetails;
        #endregion

        public UCFileCompare()
        {
            InitializeComponent();
        }

        #region 窗体加载
        private void UCFileCompare_Load(object sender, EventArgs e)
        {
            //配置文件读取默认配置
            DefaultConfig.Init();
            DefaultConfigSettingsFill();

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

            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 加载默认配置
        private void DefaultConfigSettingsFill()
        {
            //比对文件路径读取配置文件
            TextBoxComparePath.Text = DefaultConfig.DefaultFloaderPath;
        }
        #endregion

        #region 确认路径按钮
        private void BtnConfirmPath_Click(object sender, EventArgs e)
        {
            TVCompareFolderRefresh();
            DefaultConfig.EditappSettings("DefaultFloaderPath", TextBoxComparePath.Text.Trim());
        }
        #endregion

        #region 使用正则去数组中进行比对
        /// <summary>
        /// 使用正则去数组中进行比对
        /// </summary>
        /// <param name="rg">正则表达式</param>
        /// <param name="eachLineFiles">需要比对的数组</param>
        /// <returns>含有匹配项返回true，否则false</returns>
        private bool MatchRegex(Regex rg, string[] eachLineFiles)
        {
            for (int i = 0; i < eachLineFiles.Length; i++)
            {
                if (rg.Match(eachLineFiles[i]).Success == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void GetFileCompareResult()
        {
            string result = "";
            
            RichTextBoxCompareResult.Text = "";

            //所选模板详情中去掉结尾分号，%替换为正则模糊搜索
            string str = templateDetails.Replace(";", "").Replace("%", "(?!%).*").Replace("\\", "\\\\");
            //对处理完的数据按换行分割成数组
            string[] sArray = str.Split(new char[2] { '\r', '\n' });
            //去除数组中多余的空值
            var strArr = sArray.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            List<string> tvchecked = new List<string>();

            //遍历子节点
            for (int i = 0; i < TVCompareFolder.Nodes[0].Nodes.Count; i++)
            {
                //子节点有勾选添加到list
                if (TVCompareFolder.Nodes[0].Nodes[i].Checked == true)
                {
                    tvchecked.Add(TVCompareFolder.Nodes[0].Nodes[i].Text);
                }
            }

            //文件夹
            foreach (var item in tvchecked)
            {
                string directory = FileSystemEntriesHelper.GetFileSystemEntries(TextBoxComparePath.Text.Trim(), item, -1, false)[0];
                //需要展示目录不注释下面一行，补齐
                //result += no++ + "行：" + directory + "\r\n";



                /*
                foreach (var item1 in FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false))
                {
                    eachLine = no++ + "行：" + item1 + "\r\n";
                    result += eachLine;
                    fileResult.Add(eachLine);
                }
                RichTextBoxCompareResult.Text += "\r\n\r\n" + result;
                */


                RichTextBoxCompareResult.Text += "\r\n" + item + " 比对结果：\r\n";
                //根据每条正则去比对遍历结果
                List<int> noMatchs = new List<int> { };
                for (int i = 0; i < strArr.Length; i++)
                {
                    rgTemplateDetails = new Regex(item + "\\\\" + strArr[i]);
                    //RichTextBoxCompareResult.Text += "\r\n\r\n" + rgTemplateDetails;
                    //RichTextBoxCompareResult.Text += "\r\n" + MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)).ToString();
                    if (!MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)))
                    {
                        noMatchs.Add(i);
                        //RichTextBoxCompareResult.Text += "\r\n" + strArr[i].Replace("(?!%).*", "%").Replace("\\\\", "\\");
                    }
                }
                if (noMatchs.Count == 0)
                {
                    RichTextBoxCompareResult.Text += "无文件缺失\r\n";
                }
                else
                {
                    foreach (var itemnomatch in noMatchs)
                    {
                        RichTextBoxCompareResult.Text += "缺少：" + strArr[itemnomatch].Replace("(?!%).*", "%").Replace("\\\\", "\\") + "\r\n";
                    }
                }

                RichTextBoxCompareResult.Focus();//获取焦点
                RichTextBoxCompareResult.Select(RichTextBoxCompareResult.TextLength, 0);//光标定位到文本最后
                RichTextBoxCompareResult.ScrollToCaret();//滚动到光标处
            }
            //return result;
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            RichTextBoxCompareResult.Text = "";

            //取所选模板
            //MessageBox.Show(templateDetails);
            //所选模板详情中去掉结尾分号，%替换为正则模糊搜索
            string str = templateDetails.Replace(";", "").Replace("%", "(?!%).*").Replace("\\", "\\\\");
            //对处理完的数据按换行分割成数组
            string[] sArray = str.Split(new char[2] { '\r', '\n' });
            //去除数组中多余的空值
            var strArr = sArray.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            //List<string> = templateDetails.Split('\r\n');
            //获取数组中第一条正则
            rgTemplateDetails = new Regex(strArr[0]);
            //rgTemplateDetails = new Regex("ZAA_(?!%).*\\01_开发库\\01_文档区\\03_系统测试\\(?!%).*_ST_系统测试用例.xls(?!%).*");
            //rgTemplateDetails = new Regex("ZAA_(?!%).*\\\\01_开发库\\\\01_文档区\\\\03_系统测试\\\\(?!%).*_ST_系统测试用例.xls(?!%).*");
            //MatchRegex(rgTemplateDetails,)



            #region 遍历tv勾选文件夹下文件
            string result = "";
            string eachLine;
            List<string> tvchecked = new List<string>();
            List<string> fileResult = new List<string>();
            int no;

            //遍历子节点
            for (int i = 0; i < TVCompareFolder.Nodes[0].Nodes.Count; i++)
            {
                //子节点有勾选添加到list
                if (TVCompareFolder.Nodes[0].Nodes[i].Checked == true)
                {
                    tvchecked.Add(TVCompareFolder.Nodes[0].Nodes[i].Text);
                }
            }
            //根节点选中
            if (TVCompareFolder.Nodes[0].Checked == true)
            {
                RichTextBoxCompareResult.Text = "";
                no = 1;
                fileResult.Clear();


                /*
                foreach (var item in FileSystemEntriesHelper.GetFiles(TextBoxComparePath.Text.Trim(), "^(?!\\.).*", -1, false))
                {
                    eachLine = no++ + "行：" + item + "\r\n";
                    result += eachLine;
                    fileResult.Add(eachLine);
                }
                RichTextBoxCompareResult.Text = result;
                */






                //文件夹
                foreach (var item in tvchecked)
                {
                    string directory = FileSystemEntriesHelper.GetFileSystemEntries(TextBoxComparePath.Text.Trim(), item, -1, false)[0];
                    //需要展示目录不注释下面一行，补齐
                    //result += no++ + "行：" + directory + "\r\n";



                    /*
                    foreach (var item1 in FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false))
                    {
                        eachLine = no++ + "行：" + item1 + "\r\n";
                        result += eachLine;
                        fileResult.Add(eachLine);
                    }
                    RichTextBoxCompareResult.Text += "\r\n\r\n" + result;
                    */


                    RichTextBoxCompareResult.Text += "\r\n" + item + " 比对结果：\r\n";
                    //根据每条正则去比对遍历结果
                    List<int> noMatchs = new List<int> { };
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        rgTemplateDetails = new Regex(item + "\\\\" + strArr[i]);
                        //RichTextBoxCompareResult.Text += "\r\n\r\n" + rgTemplateDetails;
                        //RichTextBoxCompareResult.Text += "\r\n" + MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)).ToString();
                        if (!MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)))
                        {
                            noMatchs.Add(i);
                            //RichTextBoxCompareResult.Text += "\r\n" + strArr[i].Replace("(?!%).*", "%").Replace("\\\\", "\\");
                        }
                    }
                    if (noMatchs.Count == 0)
                    {
                        RichTextBoxCompareResult.Text += "无文件缺失\r\n";
                    }
                    else
                    {
                        foreach (var itemnomatch in noMatchs)
                        {
                            RichTextBoxCompareResult.Text += "缺少：" + strArr[itemnomatch].Replace("(?!%).*", "%").Replace("\\\\", "\\") + "\r\n";
                        }
                    }








                }





            }
            //根节点未选中
            else
            {
                result = "";
                //有勾选子节点
                if (tvchecked.Count > 0)
                {
                    no = 1;
                    fileResult.Clear();




                    //文件夹
                    foreach (var item in tvchecked)
                    {
                        string directory = FileSystemEntriesHelper.GetFileSystemEntries(TextBoxComparePath.Text.Trim(), item, -1, false)[0];
                        //需要展示目录不注释下面一行，补齐
                        //result += no++ + "行：" + directory + "\r\n";



                        /*
                        foreach (var item1 in FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false))
                        {
                            eachLine = no++ + "行：" + item1 + "\r\n";
                            result += eachLine;
                            fileResult.Add(eachLine);
                        }
                        RichTextBoxCompareResult.Text += "\r\n\r\n" + result;
                        */


                        RichTextBoxCompareResult.Text += "\r\n" + item + " 比对结果：\r\n";
                        //根据每条正则去比对遍历结果
                        List<int> noMatchs = new List<int> { };
                        for (int i = 0; i < strArr.Length; i++)
                        {
                            rgTemplateDetails = new Regex(item + "\\\\" + strArr[i]);
                            //RichTextBoxCompareResult.Text += "\r\n\r\n" + rgTemplateDetails;
                            //RichTextBoxCompareResult.Text += "\r\n" + MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)).ToString();
                            if (!MatchRegex(rgTemplateDetails, FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false)))
                            {
                                noMatchs.Add(i);
                                //RichTextBoxCompareResult.Text += "\r\n" + strArr[i].Replace("(?!%).*", "%").Replace("\\\\", "\\");
                            }
                        }
                        if (noMatchs.Count == 0)
                        {
                            RichTextBoxCompareResult.Text += "无文件缺失\r\n";
                        }
                        else
                        {
                            foreach (var itemnomatch in noMatchs)
                            {
                                RichTextBoxCompareResult.Text += "缺少：" + strArr[itemnomatch].Replace("(?!%).*", "%").Replace("\\\\", "\\") + "\r\n";
                            }
                        }








                    }
                }
                //未勾选子节点
                else
                {
                    RichTextBoxCompareResult.Text = "请在左侧勾选要比对的目录";
                }
            }
            /*
            RichTextBoxCompareResult.Text += "\r\n\r\n\r\n提取文件名：\r\n";
            foreach (var item in fileResult)
            {
                //richTextBox1.Text += item;
                string[] temp = item.Split('\\');
                RichTextBoxCompareResult.Text += temp[temp.Length - 1];
            }
            */
            #endregion

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

        private void button1_Click(object sender, EventArgs e)
        {
            Thread threadmatchreg = new Thread(new ThreadStart(GetFileCompareResult));
            threadmatchreg.Start();
            //等待线程执行完毕
            threadmatchreg.Join();
        }
    }
}