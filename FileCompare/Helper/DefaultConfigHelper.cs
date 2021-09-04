using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare.Helper
{
    class DefaultConfigHelper
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
            DefaultFormText = GetappSettings("DefaultFormText");
            DefaultFloaderPath = GetappSettings("DefaultFloaderPath");
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
                AddappSettings("DefaultFormText", @"未配置窗体名称，可在配置文件中自定义");
            }
            if (string.IsNullOrEmpty(DefaultFloaderPath))
            {
                AddappSettings("DefaultFloaderPath", @"E:\testfloader");
            }
        }
        #endregion

        #region 是否存在配置文件中的key
        /// <summary>
        /// 是否存在配置文件中的key
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <returns>true, false</returns>
        public static bool IsappSettingsExists(string key)
        {
            if (!string.IsNullOrEmpty(GetappSettings(key)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 新增appSettings配置
        /// <summary>
        /// 新增appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <param name="Value">appSettings值</param>
        /// <returns>true, false</returns>
        public static bool AddappSettings(string key, string value, string configpath = null)
        {
            try
            {
                if (configpath == null)
                {
                    RWConfig.SetappSettingsValue(key, value, CONFIGPATH);
                }
                else
                {
                    RWConfig.SetappSettingsValue(key, value, configpath);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 删除appSettings配置
        /// <summary>
        /// 删除appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>true, false</returns>
        public static bool DelappSettings(string key, string configpath = null)
        {
            try
            {
                if (configpath == null)
                {
                    if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, CONFIGPATH)))
                    {
                        RWConfig.DelappSettingsValue(key, CONFIGPATH);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, configpath)))
                    {
                        RWConfig.DelappSettingsValue(key, configpath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 修改appSettings配置
        /// <summary>
        /// 修改appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <param name="Value">appSettings值</param>
        /// <returns>true, false</returns>
        public static bool EditappSettings(string key, string value, string configpath = null)
        {
            try
            {
                if (configpath == null)
                {
                    if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, CONFIGPATH)))
                    {
                        RWConfig.SetappSettingsValue(key, value, CONFIGPATH);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, configpath)))
                    {
                        RWConfig.SetappSettingsValue(key, value, configpath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 查询appSettings配置
        /// <summary>
        /// 查询appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>appSettings值</returns>
        public static string GetappSettings(string key, string configpath = null)
        {
            string result = "";
            if (configpath == null)
            {
                result = RWConfig.GetappSettingsValue(key, CONFIGPATH);
            }
            else
            {
                result = RWConfig.GetappSettingsValue(key, configpath);
            }
            return result;
        }
        #endregion

        #region 查询appSettings配置，并对键值以分号分割
        /// <summary>
        /// 查询appSettings配置，并对键值以分号分割
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>appSettings值，以分号分割，返回数组</returns>
        public static string[] GetappSettingsSplitBySemicolon(string key, string configpath = null)
        {
            string[] result = { };
            string values = "";
            if (configpath == null)
            {
                values = RWConfig.GetappSettingsValue(key, CONFIGPATH);
            }
            else
            {
                values = RWConfig.GetappSettingsValue(key, configpath);
            }
            for (int i = 0; i < 2; i++)
            {
                if (string.IsNullOrEmpty(values))
                {
                    Init();
                }
                else
                {
                    result = values.Split(';');
                    break;
                }
            }
            return result;
        }
        #endregion
    }
}