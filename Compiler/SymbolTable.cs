using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class SymbolTable
    {
        public string val;
        public string type;
        public int index;

        public SymbolTable(string val, string type, int index)
        {
            this.val = val;
            this.type = type;
            this.index = index;
        }
    }
}
