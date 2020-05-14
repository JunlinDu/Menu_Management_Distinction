using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MenuProject
{
    public static class ExtensionForLoading
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
    }
}
