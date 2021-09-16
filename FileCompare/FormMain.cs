using FileCompare.Helper;
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
            DefaultConfig.Init();
            DefaultConfigSettingsFill();

            //模板配置文件相关初始化
            string rootPath = Environment.CurrentDirectory;
            FileStream templatesfile = File.Create(rootPath + "\\Templates");
            templatesfile.Close();
            TemplatesConfig.Init();

            panel1.Controls.Clear();
            //UCTest uc = new UCTest();
            UCFileCompare uc = new UCFileCompare();
            panel1.Controls.Add(uc);

            _ = DefaultConfig.ShowTest == "1" ? 测试ToolStripMenuItem.Visible = true : 测试ToolStripMenuItem.Visible = false;
            //测试ToolStripMenuItem.Visible = false;

            this.Icon = Properties.Resources.ah2t5_ehkkx_001;
        }

        private void DefaultConfigSettingsFill()
        {
            this.Text = DefaultConfig.DefaultFormText;
        }

        private void 文件比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCFileCompare uc = new UCFileCompare();
            panel1.Controls.Add(uc);
        }

        private void 比对模板管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCTempletesSetting uc = new UCTempletesSetting();
            panel1.Controls.Add(uc);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCTest uc = new UCTest();
            panel1.Controls.Add(uc);
        }
    }
}