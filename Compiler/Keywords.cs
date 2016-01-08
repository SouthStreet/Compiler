using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Keywords
    {
        enum keywords { INT,REAL,IF,THEN,ELSE,WHILE}
        public bool IsKeyword(string keyword)
        {
            foreach (string i in Enum.GetNames(typeof(keywords)))
            {
                if (keyword == i.ToString().ToLower())
                    return true;
            }
            return false;
        }
    }
}
