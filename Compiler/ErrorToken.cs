using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class ErrorToken
    {
        public string errorType;
        public string errorStr;
        public int errorRow;
        public int errorCol;
        public int errorIndex;

        public ErrorToken(string errorType,string errorStr,int errorRow,int errorCol,int errorIndex)
        {
            this.errorType = errorType;
            this.errorStr = errorStr;
            this.errorRow = errorRow;
            this.errorCol = errorCol;
            this.errorIndex = errorIndex;
        }
    }
}
