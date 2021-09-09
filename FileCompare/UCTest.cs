using FileCompare.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class UCTest : UserControl
    {
        public UCTest()
        {
            InitializeComponent();
        }

        private void UCTest_Load(object sender, EventArgs e)
        {
            //配置文件读取默认配置
            DefaultConfigHelper.Init();
            DefaultConfigSettingsFill();

            //RichTextBox增加右键菜单
            _ = new RichTextBoxMenu(richTextBox1);

            string rootPath = Environment.CurrentDirectory;
            //MessageBox.Show(rootPath);
            FileStream templatesfile = File.Create(rootPath + "\\Templates");
            templatesfile.Close();

            TemplatesConfig.Init();
            //MessageBox.Show(TemplatesConfig.Templates);

            treeView1.CheckBoxes = true;
            treeView1.ShowLines = false;
            TV1Refresh();
        }

        private void TV1Refresh()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("全选");
            foreach (var item in FileSystemEntriesHelper.GetDirectories(textBox1.Text.Trim(), "^(?!\\.).*", 0, false))
            {
                List<string> list = item.Split('\\').ToList();
                treeView1.Nodes[0].Nodes.Add(list[list.Count - 1]);
            }
            treeView1.ExpandAll();
        }

        private void DefaultConfigSettingsFill()
        {
            this.Text = DefaultConfigHelper.DefaultFormText;
            textBox1.Text = DefaultConfigHelper.DefaultFloaderPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            int no = 1;
            foreach (var item in FileSystemEntriesHelper.GetFileSystemEntries(textBox1.Text.Trim(), "^(?!\\.).*", -1, false))
            {
                result += no++ + "行：" + item + "\r\n";
            }
            richTextBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = "";
            int no = 1;
            foreach (var item in FileSystemEntriesHelper.GetDirectories(textBox1.Text.Trim(), "^(?!\\.).*", -1, false))
            {
                result += no++ + "行：" + item + "\r\n";
            }
            richTextBox1.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = "";
            int no = 1;
            foreach (var item in FileSystemEntriesHelper.GetFiles(textBox1.Text.Trim(), "^(?!\\.).*", -1, false))
            {
                result += no++ + "行：" + item + "\r\n";
            }
            richTextBox1.Text = result;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewCheck.CheckControl(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TV1Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string result = "";
            string eachLine = "";
            List<string> tvchecked = new List<string>();
            List<string> fileResult = new List<string>();
            int no;
            //根节点选中
            if (treeView1.Nodes[0].Checked == true)
            {
                richTextBox1.Text = "";
                no = 1;
                fileResult.Clear();
                foreach (var item in FileSystemEntriesHelper.GetFiles(textBox1.Text.Trim(), "^(?!\\.).*", -1, false))
                {
                    eachLine = no++ + "行：" + item + "\r\n";
                    result += eachLine;
                    fileResult.Add(eachLine);
                }
                richTextBox1.Text = result;

                /*
                foreach (var item in treeView1.Nodes[0].Nodes)
                {
                    tvchecked.Add(item.ToString());
                }
                */
            }
            //根节点未选中
            else
            {
                result = "";
                //遍历子节点
                for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++)
                {
                    //子节点有勾选添加到list
                    if (treeView1.Nodes[0].Nodes[i].Checked == true)
                    {
                        tvchecked.Add(treeView1.Nodes[0].Nodes[i].Text);
                    }
                }
                if (tvchecked.Count > 0)
                {
                    no = 1;
                    fileResult.Clear();
                    foreach (var item in tvchecked)
                    {
                        string directory = FileSystemEntriesHelper.GetFileSystemEntries(textBox1.Text.Trim(), item, -1, false)[0];
                        //需要展示目录不注释下面一行，补齐
                        //result += no++ + "行：" + directory + "\r\n";
                        foreach (var item1 in FileSystemEntriesHelper.GetFiles(directory, "^(?!\\.).*", -1, false))
                        {
                            eachLine = no++ + "行：" + item1 + "\r\n";
                            result += eachLine;
                            fileResult.Add(eachLine);
                        }
                        richTextBox1.Text = result;
                        //richTextBox1.Text += item + "\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text = "未勾选";
                }
            }
            /*
            string directory = FileSystemEntriesHelper.GetFileSystemEntries(textBox1.Text.Trim(), "ZAA_CP19005", -1, false)[0];
            //string result = "";
            //int no = 1;
            foreach (var item in FileSystemEntriesHelper.GetFileSystemEntries(directory, "^(?!\\.).*", -1, false))
            {
                result += no++ + "行：" + item + "\r\n";
            }
            richTextBox1.Text = result;
            */

            /*
            richTextBox1.Text = "";
            foreach (var item in tvchecked)
            {
                richTextBox1.Text += item+"\r\n";
            }
            */
            richTextBox1.Text += "\r\n\r\n\r\n提取文件名：\r\n";
            foreach (var item in fileResult)
            {
                //richTextBox1.Text += item;
                string[] temp = item.Split('\\');
                richTextBox1.Text += temp[temp.Length - 1];
            }
        }
    }
}