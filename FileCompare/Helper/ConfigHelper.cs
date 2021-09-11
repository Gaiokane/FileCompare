using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare.Helper
{
    class ConfigHelper
    {
        #region 是否存在配置文件中的key
        /// <summary>
        /// 是否存在配置文件中的key
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>true, false</returns>
        public static bool IsappSettingsExists(string key, string configpath)
        {
            if (!string.IsNullOrEmpty(GetappSettings(key, configpath)))
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
        /// <param name="key">appSettings键</param>
        /// <param name="value">appSettings值</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>true, false</returns>
        public static bool AddappSettings(string key, string value, string configpath)
        {
            try
            {
                RWConfig.SetappSettingsValue(key, value, configpath);
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
        /// <param name="key">appSettings键</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>true, false</returns>
        public static bool DelappSettings(string key, string configpath)
        {
            try
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
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 删除appSettings配置，删除指定key中的指定value
        /// <summary>
        /// 删除appSettings配置，删除指定key中的指定value
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <param name="delValue">指定key中要删除的指定value</param>
        /// <param name="split">value中分隔符</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>true, false</returns>
        public static bool DelappSettingsByValue(string key, string delValue, char split, string configpath)
        {
            try
            {
                if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, configpath)))
                {
                    List<string> temp = GetappSettingsSplitBySemicolon(key, split, configpath);
                    temp.Remove(delValue);
                    if (EditappSettings(key, string.Join(";", temp.ToArray()), configpath))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
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
        /// <param name="key">appSettings键</param>
        /// <param name="value">appSettings值</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>true, false</returns>
        public static bool EditappSettings(string key, string value, string configpath)
        {
            try
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
        /// <param name="key">appSettings键</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>appSettings值</returns>
        public static string GetappSettings(string key, string configpath)
        {
            string result;
            result = RWConfig.GetappSettingsValue(key, configpath);
            return result;
        }
        #endregion

        #region 查询appSettings配置，并对键值以指定字符分隔
        /// <summary>
        /// 查询appSettings配置，并对键值以指定字符分隔
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <param name="configpath">配置文件</param>
        /// <returns>appSettings值，以指定字符分隔，返回数组</returns>
        public static List<string> GetappSettingsSplitBySemicolon(string key, char split, string configpath)
        {
            List<string> result = new List<string>();
            string values;
            values = RWConfig.GetappSettingsValue(key, configpath);
            if (string.IsNullOrEmpty(values))
            {
                return result;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (!string.IsNullOrEmpty(values))
                    {
                        result = values.Split(split).ToList();
                        break;
                    }
                }
                if (string.IsNullOrEmpty(result[result.Count - 1]))
                {
                    result.Remove(result[result.Count - 1]);
                }
                return result;
            }
        }
        #endregion
    }
}