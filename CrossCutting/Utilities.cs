﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class Utilities
    {
        public static string removeSpecialCharacters(string text)
        {
            return Regex.Replace(text, "\'", "");
        }
    }
}
