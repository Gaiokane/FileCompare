using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare.Helper
{
    class FileHelper
    {
        /// <summary>
        /// 新建文件并写入内容，如果已存在，则覆盖
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="content">文件内容</param>
        public static bool CreateNewFile(string fileName, string content)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 复制文件，如果目标路径已存在同名文件，则覆盖，否则新建
        /// </summary>
        /// <param name="source">源文件路径</param>
        /// <param name="dest">目标文件路径</param>
        public static bool CopyFileTo(string source, string dest)
        {
            try
            {
                if (System.IO.File.Exists(source))//必须判断要复制的文件是否存在
                {
                    if (IsFileInUsed(source) == false)
                    {
                        System.IO.File.Copy(source, dest, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("所选文件被占用，无法复制");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 移动文件/目录
        /// </summary>
        /// <param name="source">源路径</param>
        /// <param name="dest">目标路径</param>
        public static bool MoveFileTo(string source, string dest)
        {
            try
            {
                if (System.IO.File.Exists(source))
                {
                    if (IsFileInUsed(source) == false)
                    {
                        System.IO.File.Move(source, dest);
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("所选文件被占用，无法移动");
                        return false;
                    }
                }
                else if (Directory.Exists(source))
                {
                    try
                    {
                        Directory.Move(source, dest);
                        return true;
                    }
                    catch
                    {
                        //MessageBox.Show("所选文件夹被占用，无法移动");
                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("所选文件/文件夹不存在");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断指定文件是否在使用
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public static bool IsFileInUsed(string fileName)
        {
            try
            {
                bool inUse = true;
                if (System.IO.File.Exists(fileName))
                {
                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                        inUse = false;
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message.ToString());
                        return false;
                    }
                    finally
                    {
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }
                    return inUse;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断指定文件是否存在
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public static bool IsFileExists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }

        /// <summary>
        /// 判断指定目录是否存在
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>true, false</returns>
        public static bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 新建目录，如果已存在，则不进行操作
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>true, false</returns>
        public static bool CreateNewDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 在桌面创建快捷方式
        /// </summary>
        /// <param name="ShortcutName">快捷方式名称</param>
        /// <param name="TargetPath">快捷方式目标路径</param>
        /// <returns>true：创建成功, false：创建失败，已存在</returns>
        /*public static bool CreateShortcutOnDesktop(string ShortcutName, string TargetPath)
        {
            //添加引用 (com->Windows Script Host Object Model)，using IWshRuntimeLibrary;
            String shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), ShortcutName + ".lnk");
            //有相同快捷方式，不创建
            if (System.IO.File.Exists(shortcutPath))
            {
                return false;
            }
            //没有相同快捷方式，创建
            else
            {
                IWshShell shell = new WshShell();
                WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(shortcutPath);
                //目标
                shortcut.TargetPath = TargetPath;
                //目标后面跟的参数，会有个空格隔开
                //shortcut.Arguments = ""; 
                //备注
                //shortcut.Description = "";
                //起始位置
                //shortcut.WorkingDirectory = Environment.CurrentDirectory;//程序所在文件夹，在快捷方式图标点击右键可以看到此属性
                //shortcut.WorkingDirectory = "";
                //图标，该图标是应用程序的资源文件
                //shortcut.IconLocation = exePath;
                //快捷键
                //shortcut.Hotkey = "CTRL+SHIFT+W";//热键，发现没作用，大概需要注册一下
                shortcut.WindowStyle = 1;
                shortcut.Save();
                return true;
            }
        }*/
    }
}