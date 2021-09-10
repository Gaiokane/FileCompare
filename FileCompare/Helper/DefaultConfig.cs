using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare.Helper
{
    class DefaultConfig
    {
        //窗体默认名称
        public static string DefaultFormText;
        //默认文件夹路径
        public static string DefaultFloaderPath;

        //配置文件路径
        public static string CONFIGPATH = "./FileCompare.exe";

        #region 配置文件初始化，检查默认键是否有缺失，有则新增
        /// <summary>
        /// 配置文件初始化，检查默认键是否有缺失，有则新增
        /// </summary>
        public static void Init()
        {
            GetAllDefaultappSettings();
            SetDefaultSettingsIfIsNullOrEmpty();
            GetAllDefaultappSettings();
        }
        #endregion

        #region 获取配置文件中所有默认键值
        /// <summary>
        /// 获取配置文件中所有默认键值
        /// </summary>
        public static void GetAllDefaultappSettings()
        {
            DefaultFormText = ConfigHelper.GetappSettings("DefaultFormText", CONFIGPATH);
            DefaultFloaderPath = ConfigHelper.GetappSettings("DefaultFloaderPath", CONFIGPATH);
        }
        #endregion

        #region 如果配置文件中有缺失默认键，则新增
        /// <summary>
        /// 如果配置文件中有缺失默认键，则新增
        /// </summary>
        public static void SetDefaultSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(DefaultFormText))
            {
                ConfigHelper.AddappSettings("DefaultFormText", @"未配置窗体名称，可在配置文件中自定义", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(DefaultFloaderPath))
            {
                //AddappSettings("DefaultFloaderPath", @"E:\testfloader");
                ConfigHelper.AddappSettings("DefaultFloaderPath", Environment.CurrentDirectory, CONFIGPATH);
            }
        }
        #endregion

        #region 调用ConfigHelper
        /// <summary>
        /// 配置文件中是否存在指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回true,false</returns>
        public static bool IsappSettingsExists(string key)
        {
            return ConfigHelper.IsappSettingsExists(key, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中新增键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回true,false</returns>
        public static bool AddappSettings(string key, string value)
        {
            return ConfigHelper.AddappSettings(key, value, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中删除指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回true,false</returns>
        public static bool DelappSettings(string key)
        {
            return ConfigHelper.DelappSettings(key, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中删除指定key中的指定value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="delValue"></param>
        /// <param name="split"></param>
        /// <returns>返回true,false</returns>
        public static bool DelappSettingsByValue(string key, string delValue, char split)
        {
            return ConfigHelper.DelappSettingsByValue(key, delValue, split, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中修改键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回true,false</returns>
        public static bool EditappSettings(string key, string value)
        {
            return ConfigHelper.EditappSettings(key, value, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中读取指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回key对应value</returns>
        public static string GetappSettings(string key)
        {
            return ConfigHelper.GetappSettings(key, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中读取指定key，并按指定字符分隔
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回分隔后的数组</returns>
        public static List<string> GetappSettingsSplitBySemicolon(string key, char split)
        {
            return ConfigHelper.GetappSettingsSplitBySemicolon(key, split, CONFIGPATH);
        }
        #endregion
    }
}