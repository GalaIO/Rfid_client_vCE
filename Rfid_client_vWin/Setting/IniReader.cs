using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace Setting
{
    class IniReader
    {
        /************************************************************************/
        /*写操作
         * strSection   节
         * strKey       键
         * strValue     需要写入的值
         * strFilePath  配置文件的全路径（wince中只能使用绝对全路径）
         */
        /************************************************************************/

        public static void PutINI(string strSection, string strKey, string strValue, string strFilePath)
        {
            INICommon(false, strSection, strKey, strValue, strFilePath);
        }
        /************************************************************************/
        /* 读操作
         * strSection   节
         * strKey       键
         * strDefault   如果未找到相应键对应的值则填入此值
         * strFilePath  配置文件的全路径（wince中只能使用绝对全路径）
         * 返回：       指定键的相应值
         * 说明：       如果在文件中未找到相应节则添加，未找到相应键亦添加，如果键对应的值为空串则使用默认值填充ini文件并返回
        /************************************************************************/
        public static string GetINI(string strSection, string strKey, string strDefault, string strFilePath)
        {
            return INICommon(true, strSection, strKey, strDefault, strFilePath);
        }
        private static string[] Split(string input, string pattern)
        {
            string[] arr = System.Text.RegularExpressions.Regex.Split(input, pattern);
            return arr;
        }
        private static void AppendToFile(string strPath, string strContent)
        {
            FileStream fs = new FileStream(strPath, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fs, System.Text.Encoding.Default);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            streamWriter.WriteLine(strContent);
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
        private static void WriteArray(string strPath, string[] strContent)
        {
            FileStream fs = new FileStream(strPath, FileMode.Truncate);
            StreamWriter streamWriter = new StreamWriter(fs, System.Text.Encoding.Default);
            streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < strContent.Length; i++)
            {
                if (strContent[i].Trim() == "/r/n")
                    continue;
                streamWriter.WriteLine(strContent[i].Trim());
            }
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
        //INI解析
        private static string INICommon(bool isRead, string ApplicationName, string KeyName, string Default, string FileName)
        {
            string strSection = "[" + ApplicationName + "]";
            string strBuf;
            try
            {
                //a.文件不存在则创建
                if (!File.Exists(FileName))
                {
                    FileStream sr = File.Create(FileName);
                    sr.Close();
                }
                //读取INI文件
                System.IO.StreamReader stream = new System.IO.StreamReader(FileName, System.Text.Encoding.Default);
                //strBuf = stream.ReadToEnd();
                strBuf = stream.ReadLine();
                while (strBuf != null)
                {
                    if (strSection == strBuf)
                        break;
                    strBuf = stream.ReadLine();
                }
                if (strBuf == null)
                {
                    stream.Close();
                    return Default;
                }
                strBuf = stream.ReadLine();
                while (strBuf != null)
                {
                    string[] tmp = Split(strBuf, "=");

                    if (tmp.Length < 2)
                    {
                        stream.Close();
                        return Default;
                    }
                    if (tmp[0] == KeyName)
                    {
                        stream.Close();
                        return tmp[1];
                    }
                    strBuf = stream.ReadLine();
                }
                return Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "INI文件读取异常");
                return Default;
            }

        }
    }
}
