
/*
 * Author:  GalaIO
 * Data:    2016-2-27
 * Describe:    A json generator!
 * */
using System;
namespace Json
{
    public class JsonGen
    {
        public static int stepSize = 3000;

        private char[] jsonTmp;
        private int length;
        private int[] bias;
        private int len;
        public JsonGen()
        {
            this.jsonTmp = new char[stepSize];
            this.length = stepSize;
            resetJson();
        }
        private void JsonIncreaseBuf()
        {
            this.length += stepSize;
            this.jsonTmp = (char [])IncreaseArray.Redim(this.jsonTmp, this.length);
        }
        #region json_handle
        public bool startJson()
        {
            while (this.len + 4 > this.length)
            {
                JsonIncreaseBuf();
            }
            if (this.len + 4 < this.length)
            {
                jsonTmp[0] = '{';
                jsonTmp[1] = ',';
                jsonTmp[2] = '}';
                jsonTmp[3] = '\0';
                len += 4;
                bias[bias[0]] += 1;

                return true;
            }
            return false;
        }
        public bool endJson()
        {
            for (int i = bias[bias[0]]; jsonTmp[i] != '\0'; i++)
            {
                jsonTmp[i] = jsonTmp[i + 1];
            }
            bias[0] -= 1;
            len -= 1;
            return true;
        }
        #endregion
        #region obj_handle
        public bool startObj(string name)
        {
            while (len + name.Length + 4 + 3 > length)
            {
                JsonIncreaseBuf();
            }
            if (len + name.Length + 4 + 3 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = name.Length + 4 + 2 + 1;
                }
                else
                {
                    room = name.Length + 4 + 2;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < name.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = name[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                jsonTmp[i++ + bias[bias[0]]] = ':';
                jsonTmp[i++ + bias[bias[0]]] = '{';
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                jsonTmp[i++ + bias[bias[0]]] = '}';
                bias[++bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }
        public bool endObj()
        {
            for (int i = bias[bias[0]]; jsonTmp[i] != '\0'; i++)
            {
                jsonTmp[i] = jsonTmp[i + 1];
            }
            for (int i = bias[0] - 1; i > 0; i--)
            {
                bias[i]--;
            }
            bias[0] -= 1;
            len -= 1;
            return true;
        }
        #endregion
        #region array_handle
        public bool startArray(string name)
        {
            while (len + name.Length + 4 + 3 > length)
            {
                JsonIncreaseBuf();
            }
            if (len + name.Length + 4 + 3 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = name.Length + 4 + 2 + 1;
                }
                else
                {
                    room = name.Length + 4 + 2;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < name.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = name[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                jsonTmp[i++ + bias[bias[0]]] = ':';
                jsonTmp[i++ + bias[bias[0]]] = '[';
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                jsonTmp[i++ + bias[bias[0]]] = ']';
                bias[++bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }
        public bool endArray()
        {
            for (int i = bias[bias[0]]; jsonTmp[i] != '\0'; i++)
            {
                jsonTmp[i] = jsonTmp[i + 1];
            }
            for (int i = bias[0] - 1; i > 0; i--)
            {
                bias[i]--;
            }
            bias[0] -= 1;
            len -= 1;
            return true;
        }
        #endregion
        #region item_String_handle
        public bool addString(string name, string value)
        {

            while (len + name.Length + value.Length + 2 + 2 + 1 > length)
            {
                JsonIncreaseBuf();
            }
            if (len + name.Length + value.Length + 2 + 2 + 1 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = name.Length + value.Length + 2 + 2 + 1 + 1;
                }
                else
                {
                    room = name.Length + value.Length + 2 + 2 + 1;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < name.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = name[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                jsonTmp[i++ + bias[bias[0]]] = ':';
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < value.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = value[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                bias[bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }
        public bool addStringToArray(string value)
        {

            while (len + value.Length + 2 + 1 > length)
            {
                JsonIncreaseBuf();
            }
            if (len + value.Length + 2 + 1 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = value.Length + 2 + 1;
                }
                else
                {
                    room = value.Length + 2;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < value.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = value[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                bias[bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }
        #endregion

        #region item_num_handle
        public bool addNum(string name, int num)
        {
            string value = num.ToString();

            while (len + name.Length + value.Length + 2 + 1 > length)
            {
                JsonIncreaseBuf();
            }
            //"name":num
            if (len + name.Length + value.Length + 2 + 1 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = name.Length + value.Length + 2 + 1 + 1;
                }
                else
                {
                    room = name.Length + value.Length + 2 + 1;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < name.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = name[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                jsonTmp[i++ + bias[bias[0]]] = ':';
                for (int j = 0; j < value.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = value[j];
                }
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                bias[bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }
        #endregion
        #region item_bool_handle
        public bool addBool(string name, bool isTrue)
        {
            string value = null;
            if (isTrue)
            {
                value = "True";
            }
            else
            {
                value = "False";
            }
            while (len + name.Length + value.Length + 2 + 1 > length)
            {
                JsonIncreaseBuf();
            }
            //"name":bool
            if (len + name.Length + value.Length + 2 + 1 < length)
            {
                int room = 1;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    room = name.Length + value.Length + 2 + 1 + 1;
                }
                else
                {
                    room = name.Length + value.Length + 2 + 1;
                }
                //先腾出空间
                for (int j = 0; j < len - bias[bias[0]]; j++)
                {
                    jsonTmp[j + bias[bias[0]] + room] = jsonTmp[j + bias[bias[0]]];
                }
                int i = 0;
                if (jsonTmp[bias[bias[0]] - 1] != '{' && jsonTmp[bias[bias[0]] - 1] != '[')
                {
                    jsonTmp[i++ + bias[bias[0]]] = ',';
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                for (int j = 0; j < name.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = name[j];
                }
                jsonTmp[i++ + bias[bias[0]]] = '\"';
                jsonTmp[i++ + bias[bias[0]]] = ':';
                for (int j = 0; j < value.Length; i++, j++)
                {
                    jsonTmp[i + bias[bias[0]]] = value[j];
                }
                int tmp = i + bias[bias[0]];
                jsonTmp[i++ + bias[bias[0]]] = ',';
                bias[bias[0]] = tmp;
                for (int j = bias[0] - 1; j > 0; j--)
                {
                    bias[j] += room;
                }
                len += room;
                return true;
            }
            return false;
        }

        #endregion

        #region util_handle
        public string toJson()
        {
            return new string(jsonTmp, 0, len);
        }
        public bool resetJson()
        {
            //最多嵌套10层
            this.bias = new int[10];
            this.bias[0] = 1;
            this.bias[this.bias[0]] = 0;
            this.len = 0;
            return true;
        }
        #endregion
    }
}
