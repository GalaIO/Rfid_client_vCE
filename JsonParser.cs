
/*
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    A very simple json parser!
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class JsonParser
{
    static public string find(string json, string name)
    {
        try
        {
            int index = json.IndexOf(name);
            if (index <= 0) throw new Exception();
            //"name":
            index += name.Length + 1 + 1;
            int j = 0;
            bool isYh2 = false;
            if (json[index] == '{' || json[index] == '\"' || json[index] == '[')
            {
                if (json[index] == '\"') isYh2 = true;
                ++j;
                ++index;
            }
            int i = index;
            for (; json[i] != '\0'; i++)
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
            if (json[i - 1] == '}' || json[i - 1] == '\"' || json[i - 1] == '}')
            {
                --i;
            }
            return json.Substring(index, i-index+1);
        }
        catch (Exception e)
        {
            return ""  +e.Message;
        }
    }
}
