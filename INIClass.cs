using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
namespace JN_WELD_Service
{
    class INIClass
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        String _filepath = "JN_CONFIG.ini";
        public INIClass()
        {
            _filepath=AppDomain.CurrentDomain.BaseDirectory+"\\"+_filepath;
        }
        /// <summary>
        /// 读取键值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        protected string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this._filepath);
            return temp.ToString();
        }
        /// <summary>
        /// 获取松下服务器的IP地址
        /// </summary>
        /// <returns></returns>
        public String getPQMDIP()
        {
            String sxIP = "";
            sxIP = IniReadValue("PQMD", "serviceip");
            return sxIP;
        }
        /// <summary>
        /// 获取数据库连接串
        /// </summary>
        /// <returns></returns>
        public String getDBConntionstr()
        {
            String sip = "";
            String dbname = "";
            String dbpwd = "";
            String dbuser = "";
            String cnnstr = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
            sip = IniReadValue("DB", "serviceip");
            dbname = IniReadValue("DB", "dbname");
            dbpwd = IniReadValue("DB", "dbpwd");
            dbuser = IniReadValue("DB", "dbuser");
            cnnstr = String.Format(cnnstr, sip, dbname, dbuser, dbpwd);
            return cnnstr;

        }

    }
}
