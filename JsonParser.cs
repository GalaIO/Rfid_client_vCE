
/*
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    A very simple json parser!
 * 
 * 
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    修改若干bug，适应更多json格式，包括出现空格等；修改错误，如果只有name没有对应value，直接返回空字符串。
 * 
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    添加对json数值类型的支持。
 * 
 * Author:  GalaIO
 * Data:    2016-3-11
 * Describe:   修改了find函数，找value更轻松
 *            增加了findnextArray用于寻找 列表
 *            增加了findnextObj  用于寻找 对象
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class JsonParser
{
    static public string findNextArray(string jsonTmp, string name, int offset)
    {
        try
        {
            string json = jsonTmp.Substring(offset, jsonTmp.Length - offset);
            int index = 0;
            if (name != null)
            {
                index = json.IndexOf(name);
                if (index <= 0) throw new Exception();
                //"name":
                index += name.Length + 1 + 1;
                while (json[index] == ' ' || json[index] == '\n')
                {
                    index++;
                }
            }
            int j = 0;
            bool isYh2 = false;
            while (json[index] != '[') index++;
            if (json[index] == '{' || json[index] == '\"' || json[index] == '[')
            {
                if (json[index] == '\"') isYh2 = true;
                ++j;
                ++index;
            }
            int i = index;
            for (; i < json.Length && j > 0; i++)
            {
                if (j == 0)
                {
                    --i;
                    break;
                }
                if (json[i] == '{' || json[i] == '[')
                {
                    ++j;
                    continue;
                }
                if (json[i] == '}' || json[i] == ']')
                {
                    --j;
                    continue;
                }
                if (json[i] == '\"')
                {
                    if (!isYh2)
                    {
                        isYh2 = true;
                        ++j;
                        continue;
                    }
                    else
                    {
                        isYh2 = false;
                        --j;
                        continue;
                    }
                }
            }
            /*if (i == json.Length) i--;
            --i;*/
            i -= 2;
            return json.Substring(index, i - index + 1);
        }
        catch (Exception e)
        {
            return null;
        }
    }
    static public string findNextObj(string jsonTmp, string name, int offset)
    {
        try
        {
            string json = jsonTmp.Substring(offset, jsonTmp.Length - offset);
            int index = 0;
            if (name != null)
            {
                index = json.IndexOf(name);
                if (index <= 0) throw new Exception();
                //"name":
                index += name.Length + 1 + 1;
                while (json[index] == ' ' || json[index] == '\n')
                {
                    index++;
                }
            }
            int j = 0;
            bool isYh2 = false;
            while (json[index] != '{') index++;
            if (json[index] == '{' || json[index] == '\"' || json[index] == '[')
            {
                if (json[index] == '\"') isYh2 = true;
                ++j;
                ++index;
            }
            int i = index;
            for (; i < json.Length && j > 0; i++)
            {
                if (j == 0)
                {
                    --i;
                    break;
                }
                if (json[i] == '{' || json[i] == '[')
                {
                    ++j;
                    continue;
                }
                if (json[i] == '}' || json[i] == ']')
                {
                    --j;
                    continue;
                }
                if (json[i] == '\"')
                {
                    if (!isYh2)
                    {
                        isYh2 = true;
                        ++j;
                        continue;
                    }
                    else
                    {
                        isYh2 = false;
                        --j;
                        continue;
                    }
                }
            }
            /*if (i == json.Length) i--;
            --i;*/
            i -= 2;
            return json.Substring(index, i - index + 1);
        }
        catch (Exception e)
        {
            return null;
        }
    }
    static public string find(string jsonTmp, string name, int offset)
    {
        try
        {
            string json = jsonTmp.Substring(offset, jsonTmp.Length - offset);
            int index = json.IndexOf(name);
            if (index <= 0) throw new Exception();
            //"name":
            index += name.Length + 1 + 1;
            while (json[index] == ' ' || json[index] == '\n')
            {
                index++;
            }
            int j = 0;
            bool isYh2 = false;
            if (json[index] == '{' || json[index] == '\"' || json[index] == '[')
            {
                if (json[index] == '\"') isYh2 = true;
                ++j;
                ++index;
            }
            else
            {
                if (json[index] >= '0' && json[index] <= '9')
                {

                    int l = index;
                    for (; json[l] != '\0'; l++)
                    {
                        if (json[l] < '0' || json[l] > '9')
                        {
                            --l;
                            break;
                        }
                    }
                    return json.Substring(index, l - index + 1);
                }
                //如果：随后没有任何字段，返回空字符串
                return "";
            }
            int i = index;
            for (; i < json.Length && j > 0; i++)
            {
                if (j == 0)
                {
                    --i;
                    break;
                }
                if (json[i] == '{' || json[i] == '[')
                {
                    ++j;
                    continue;
                }
                if (json[i] == '}' || json[i] == ']')
                {
                    --j;
                    continue;
                }
                if (json[i] == '\"')
                {
                    if (!isYh2)
                    {
                        isYh2 = true;
                        ++j;
                        continue;
                    }
                    else
                    {
                        isYh2 = false;
                        --j;
                        continue;
                    }
                }
            }
            /*if (i == json.Length) i--;
            --i;*/
            i -= 2;
            return json.Substring(index, i - index + 1);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}