﻿using FileCompare.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //配置文件读取默认配置
            DefaultConfigHelper.Init();
            DefaultConfigSettingsFill();

            //RichTextBox增加右键菜单
            RichTextBoxMenu richTextBoxMenu_richTextBox1 = new RichTextBoxMenu(richTextBox1);

            string rootPath = System.Environment.CurrentDirectory;
            //MessageBox.Show(rootPath);
            FileStream templatesfile = File.Create(rootPath + "\\Templates");
            templatesfile.Close();

            TemplatesConfig.Init();
            //MessageBox.Show(TemplatesConfig.Templates);

            treeView1.CheckBoxes = true;
            treeView1.ShowLines = false;
            treeView1Refresh();

            panel1.Controls.Clear();
            UCTest uctest = new UCTest();
            panel1.Controls.Add(uctest);
        }

        private void treeView1Refresh()
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
            treeView1Refresh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCTest uc = new UCTest();
            //UCFileCompare uc = new UCFileCompare();
            panel1.Controls.Add(uc);
        }

        private void 比对模板管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}