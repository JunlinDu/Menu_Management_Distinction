using System;
using System.IO;

namespace MenuProject
{
    public static class ExtensionForLoading
    {
        //<summary>
        // Some extension for loading to make sure everthing works as excepted.
        // </summary>
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }

        public static double ReadSingle(this StreamReader reader)
        {
            return Convert.ToDouble(reader.ReadLine());
        }
    }
}