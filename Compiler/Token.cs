using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Token
    {
        public string tokenType { get; private set; }
        public string attributeValue { get; private set; }
        public int row { get; private set; }
        public int col { get; private set; }
        public int index { get; private set; }
        public Token(string str1, string str2, int str3, int str4,int str5)
        {
            this.tokenType = str1;
            this.attributeValue = str2;
            this.row = str3;
            this.col = str4;
            this.index = str5;
        }
        public string toString()
        {
            return "("
                        + tokenType + ","
                        + attributeValue + ","
                        + row + ","
                        + col + ","
                        + index
                        + ")";
        }
    }
}
