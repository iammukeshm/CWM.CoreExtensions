using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.CoreExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
