using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Common
{
    public class Util
    {
        public static int ConvertInt(string str, int def = 0)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return def;
            }
        }
    }
}
