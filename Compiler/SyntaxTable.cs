using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class SyntaxTable
    {
        public static string[] Terminals = new string[25] { "{", "}", "if", "(", ")", "int","real","then", "else", "while", "ID", "=", ";", "<", ">", "<=", ">=", "==", "+", "-", "*", "/", "INTNUM","REALNUM", "$" };
        public static string[] Non_Terminals = new string[16] { "program", "decls","decl","stmt", "compoundstmt", "stmts", "ifstmt", "whilestmt", "assgstmt", "boolexpr", "boolop", "arithexpr", "arithexprprime", "multexpr", "multexprprime", "simpleexpr" };
        public static string[] Production = new string[34] { "","program->decls compoundstmt", "decls->decl ; decls", "decls-> ε", "decl->int ID = INTNUM", "decl->real ID = REALNUM", "stmt->ifstmt", "stmt->whilestmt",
            "stmt->assgstmt", "stmt->compoundstmt", "compoundstmt->{stmts}", "stmts->stmt stmts", "stmts->ε", "ifstmt->if (boolexpr) then stmt else stmt", "whilestmt->while (boolexpr) stmt", "assgstmt->ID = arithexpr ;",
            "boolexpr->arithexpr boolop arithexpr", "boolop-><", "boolop->>", "boolop-><=", "boolop->>=", "boolop->==", "arithexpr->multexpr arithexprprime", "arithexprprime->+ multexpr arithexprprime",
            "arithexprprime->- multexpr arithexprprime", "arithexprprime->ε", "multexpr->simpleexpr  multexprprime", "multexprprime->* simpleexpr multexprprime", "multexprprime->/ simpleexpr multexprprime", "multexprprime->ε",
            "simpleexpr->ID", "simpleexpr->INTNUM","simpleexpr-> REALNUM", "simpleexpr->(arithexpr)" };
        public static int ROW_NUM = 16;//14行 行存放非终结符
        public static int COLUMN_NUM = 25;//22列 列存放终结符
        
        public int[,] Table = new int[ROW_NUM, COLUMN_NUM];//二维数组存放语法预测分析表

        public void initialize()
        {
            for (int i = 0; i < ROW_NUM; i++)
            {
                for (int j = 0; j < COLUMN_NUM; j++)
                    Table[i, j] = 0;
            }
            Table[0, 0] = 0+1;
            Table[0, 5] = 0+1;
            Table[0, 6] = 0+1;

            Table[1, 0] = 2+1;
            Table[1, 5] = 1+1;
            Table[1, 6] = 1+1;

            Table[2, 5] = 3+1;
            Table[2, 6] = 4+1;

            Table[3, 0] = 8+1;
            Table[3, 2] = 5+1;
            Table[3, 9] = 6+1;
            Table[3, 10] = 7+1;

            Table[4, 0] = 9+1;

            Table[5, 0] = 10+1;
            Table[5, 1] = 11+1;
            Table[5, 2] = 10+1;
            Table[5, 9] = 10+1;
            Table[5, 10] = 10+1;

            Table[6, 2] = 12+1;

            Table[7, 9] = 13+1;

            Table[8, 10] = 14+1;

            Table[9, 3] = 15+1;
            Table[9, 10] = 15+1;
            Table[9, 22] = 15+1;
            Table[9, 23] = 15+1;

            Table[10, 13] = 16+1;
            Table[10, 14] = 17+1;
            Table[10, 15] = 18+1;
            Table[10, 16] = 19+1;
            Table[10, 17] = 20+1;

            Table[11, 3] = 21+1;
            Table[11, 10] = 21+1;
            Table[11, 22] = 21+1;
            Table[11, 23] = 21+1;

            Table[12, 4] = 24+1;
            Table[12, 12] = 24+1;
            Table[12, 13] = 24+1;
            Table[12, 14] = 24+1;
            Table[12, 15] = 24+1;
            Table[12, 16] = 24+1;
            Table[12, 17] = 24+1;
            Table[12, 18] = 22+1;
            Table[12, 19] = 23+1;

            Table[13, 3] = 25+1;
            Table[13, 10] = 25+1;
            Table[13, 22] = 25+1;
            Table[13, 23] = 25+1;

            Table[14, 4] = 28+1;
            Table[14, 12] = 28+1;
            Table[14, 13] = 28+1;
            Table[14, 14] = 28+1;
            Table[14, 15] = 28+1;
            Table[14, 16] = 28+1;
            Table[14, 17] = 28+1;
            Table[14, 18] = 28+1;
            Table[14, 19] = 28+1;
            Table[14, 20] = 26+1;
            Table[14, 21] = 27+1;

            Table[15, 3] = 32+1;
            Table[15, 10] = 29+1;
            Table[15, 22] = 30+1;
            Table[15, 23] = 31+1;
        }
        public string [] getProduction()
        {
            return Production;
        }
        public int getIndexOfTerminal(string str)//查找Terminal表，返回下标
        {
            for (int i = 0; i < COLUMN_NUM; i++)
            {
                if (Terminals[i] == str)
                    return i;
            }
            return -1;
        }
        public int getIndexOfNonTerminal(string str)
        {
            for (int i = 0; i < ROW_NUM; i++)
            {
                if (Non_Terminals[i] == str)
                    return i;
            }
            return -1;
        }
    }
}
