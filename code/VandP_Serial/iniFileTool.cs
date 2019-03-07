using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VandP_Serial
{
    public static class iniFileTool
    {
        //配置文件路径
        public static string iniPath="" ;

        #region API函数声明

        [System.Runtime.InteropServices.DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [System.Runtime.InteropServices.DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key,string defaultStr)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, defaultStr, temp, 1024, iniFileTool.iniPath);
            return temp.ToString();
        }


        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(Section, Key, "", temp, 500, iniFileTool.iniPath);
            return temp.ToString();
        } 
        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value)
        {
            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFileTool.iniPath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}
