using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    using System.Collections.Generic;
    using System.Collections;
    using System.Windows.Forms;
    class Scanning
    {
        //------------------------成员变量--------------------------
        public int state;
        public int row = 1, column, position;
        public int n = 0;
        public string token = "";
        public List<Token> Tokens = new List<Token>();
        public Keywords keywords = new Keywords();
        public Hashtable SymbolTableHash = new Hashtable();
        public List<ErrorToken> errortoken = new List<ErrorToken>();
        public int tokenNum = 0;
        public int index = 0;

        public List<Token> ScanProcess(string str)
        {
            state = 0;
            row = 1;
            column = 0;
            position = 0;
            position += 1;
            n = 0;
            while (n <= str.Length - 1)
            {
                switch (state)
                {
                    case 0:
                        if (str[n] == '+' | str[n] == '-' | str[n] == '*')
                        { column = position; token += str[n]; state = 1; }
                        else if (str[n] == '<')
                        { column = position; token += str[n]; state = 2; }
                        else if (str[n] == '=')
                        { column = position; token += str[n]; state = 5; }
                        else if (str[n] == '>')
                        { column = position; token += str[n]; state = 8; }
                        else if (str[n] == '!')
                        { column = position; token += str[n]; state = 11; }
                        else if (char.IsLetter(str[n]))
                        { column = position; token += str[n]; state = 13; }
                        else if (char.IsDigit(str[n]))
                        { column = position; token += str[n]; state = 15; }
                        else if (str[n] == '(' || str[n] == ')' || str[n] == '{' || str[n] == '}' || str[n] == ';')
                        { column = position; token += str[n]; state = 22; }
                        else if (str[n] == '\n')
                        {
                            position = 0; row++; state = 0;
                            n++; index++; position += 1;
                        }
                        else if (str[n] == ' ')
                        {
                            state = 0;
                            n++; index++; position += 1;
                        }
                        else if (str[n] == '/')
                        {
                            column = position; token += str[n]; state = 23;
                        }
                        else
                        {
                            token += str[n];
                            ErrorToken e = new ErrorToken("非法字符输入！", token, row, column, index);
                            errortoken.Add(e);
                            errorGet(token, str);
                        }

                        break;
                    case 1:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        n++; index++;
                        position += 1;
                        token = "";
                        state = 0; break;
                    case 2:
                        n++; index++;
                        position += 1;
                        if (str[n] == '=')
                        { token += str[n]; state = 3; }
                        else
                            state = 4;
                        break;
                    case 3:
                        ;
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        n++; index++;
                        position += 1;
                        token = "";
                        state = 0; break;
                    case 4:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        token = "";
                        state = 0; break;
                    case 5:
                        n++; index++;
                        position += 1;
                        if (str[n] == '=')
                        { token += str[n]; state = 6; }
                        else
                            state = 7;
                        break;
                    case 6:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        n++; index++;
                        position += 1;
                        token = "";
                        state = 0; break;
                    case 7:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        token = "";
                        state = 0; break;
                    case 8:
                        n++; index++;
                        position += 1;
                        if (str[n] == '=')
                        { token += str[n]; state = 9; }
                        else
                            state = 10;
                        break;
                    case 9:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        n++; index++;
                        position += 1;
                        token = "";
                        state = 0; break;
                    case 10:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        token = "";
                        state = 0; break;
                    case 11:
                        n++; index++;
                        position += 1;
                        if (str[n] == '=')
                        { token += str[n]; state = 12; }
                        else
                        {
                            token += str[n];
                            errorGet(token, str);
                            ErrorToken e = new ErrorToken("'!='错误！", token, row, column, index);
                            errortoken.Add(e);
                        }
                        break;
                    case 12:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        token = "";
                        n++; index++;
                        position += 1;
                        state = 0; break;
                    case 13:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]) || char.IsLetter(str[n]))
                        { token += str[n]; }
                        else
                            state = 14;
                        break;
                    case 14:
                        if (keywords.IsKeyword(token))
                        {
                            Tokens.Add(new Token("keyword", token, row, column,index));
                            tokenNum++;
                        }
                        else
                        {
                            Tokens.Add(new Token("identifier", token, row, column,index));
                            if (!SymbolTableHash.ContainsKey(token))
                                if(tokenNum <=0 )
                                {
                                    token += str[n];
                                    ErrorToken e = new ErrorToken("标识符未声明！", token, row, column, index);
                                    errortoken.Add(e);
                                }
                                else
                                {
                                    if (Tokens[tokenNum - 1].attributeValue != "real" && Tokens[tokenNum - 1].attributeValue != "int")
                                    {
                                        token += str[n];
                                        ErrorToken e = new ErrorToken("标识符未声明！", token, row, column, index);
                                        errortoken.Add(e);
                                    }
                                    else
                                        SymbolTableHash.Add(token, new SymbolTable(token, Tokens[tokenNum-1].attributeValue,index - position + column));
                                }
                            tokenNum++;
                        }
                        token = "";
                        state = 0;
                        break;
                    case 15:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]))
                        { token += str[n]; state = 15; }
                        else if (str[n] == '.')
                        { token += str[n]; state = 16; }
                        else if (str[n] == 'E' || str[n] == 'e')
                        { token += str[n]; state = 18; }
                        else
                            state = 21;
                        break;
                    case 16:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]))
                        { token += str[n]; state = 17; }
                        else
                        {
                            token += str[n];
                            ErrorToken e = new ErrorToken("非法数字输入！", token, row, column, index);
                            errortoken.Add(e);
                            errorGet(token, str);
                        }
                        break;
                    case 17:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]))
                        { token += str[n]; state = 17; }
                        else if (str[n] == 'E' || str[n] == 'e')
                        { token += str[n]; state = 18; }
                        else
                            state = 21;
                        break;
                    case 18:
                        n++; index++;
                        position += 1;
                        if (str[n] == '+' || str[n] == '-')
                        { token += str[n]; state = 19; }
                        else
                        {
                            token += str[n];
                            ErrorToken e = new ErrorToken("非法数字输入！", token, row, column, index);
                            errortoken.Add(e);
                            errorGet(token, str);
                        }
                        break;
                    case 19:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]))
                        { token += str[n]; state = 20; }
                        else
                        {
                            token += str[n];
                            ErrorToken e = new ErrorToken("非法数字输入！", token, row, column, index);
                            errortoken.Add(e);
                            errorGet(token, str);
                        }
                        break;
                    case 20:
                        n++; index++;
                        position += 1;
                        if (char.IsDigit(str[n]))
                        { token += str[n]; state = 20; }
                        else
                            state = 21;
                        break;
                    case 21:
                        if (token.Contains("."))
                            Tokens.Add(new Token("REALNUM", token, row, column,index));
                        else
                            Tokens.Add(new Token("INTNUM", token, row, column, index));
                        tokenNum++;
                        token = "";
                        state = 0; break;
                    case 22:
                        if (str[n] == '(' || str[n] == ')' || str[n] == '{' || str[n] == '}' || str[n] == ';')
                        {
                            Tokens.Add(new Token("delim", token, row, column,index));
                            tokenNum++;
                            n++; index++;
                            position += 1;
                            token = "";
                            state = 0;
                        }
                        break;
                    case 23:
                        n++; index++;
                        position += 1;
                        if (str[n] == '/')
                        { token += str[n]; state = 24; }
                        else
                            state = 25;
                        break;
                    case 24:
                        do
                        { n++; index++; }
                        while (str[n] != '\n');
                        n++; index++;
                        token = "";
                        state = 0; break;
                    case 25:
                        Tokens.Add(new Token("operator", token, row, column,index));
                        tokenNum++;
                        token = "";
                        state = 0; break;

                }
            }
            return Tokens;
        }
        void errorGet(string token, string str)
        {
            tokenNum++;
            Tokens.Add(new Token("ERROR", token, row, column,index));
            n++; index++;
            token = "";
            state = 0;
        }
    }
}
