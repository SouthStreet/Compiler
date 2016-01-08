using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    class LLParserAnalyze
    {
        private string[] subProduction = new string[10]; //将产生式按照非终结符，终结符拆分
        public bool success = true;
        public TreeNode root = new TreeNode("program");

        SyntaxTable syntax_Table = new SyntaxTable();//语法分析表
        Stack<TreeNode> parserStack = new Stack<TreeNode>();
        List<TreeNode> tNode = new List<TreeNode>();
        List<ErrorToken> errortoken = new List<ErrorToken>();

        int nodeIndex = 0;
        int tIndex;//终结符的索引下标
        int ntIndex;//非终结符的索引下标

        public void Initialize()//初始化:table和stack
        {
            syntax_Table.initialize();//初始化语法分析表
            initializeStack();
            Console.WriteLine("Table and Stack Initialized Successfully");
        }
        private void initializeStack()//初始化栈
        {
            parserStack.Clear();
            parserStack.Push(new TreeNode("$"));
            parserStack.Push(root);
        }
        private void handleError(string str)//错误处理
        {
            MessageBox.Show("Error!    " + "匹配" + str + "时出错");
        }
        void setRightSubProduction(TreeNode f_node, int index)
        {
            for (int i = 0; i < 10; i++)
                subProduction[i] = " ";
            switch (index)
            {
                case 1:
                    subProduction[0] = "decls";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "compoundstmt";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 2:
                    subProduction[0] = "decl";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = ";";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "decls";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 29:
                case 25:
                case 12:
                case 3:
                    subProduction[0] = "ε";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 4:
                    subProduction[0] = "int";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "ID";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "=";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[3] = "INTNUM";
                    tNode.Add(new TreeNode(subProduction[3]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 5:
                    subProduction[0] = "real";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "ID";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "=";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[3] = "REALNUM";
                    tNode.Add(new TreeNode(subProduction[3]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 6:
                    subProduction[0] = "ifstmt";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 7:
                    subProduction[0] = "whilestmt";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 8:
                    subProduction[0] = "assgstmt";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 9:
                    subProduction[0] = "compoundstmt";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 10:
                    subProduction[0] = "{";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "stmts";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "}";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 11:
                    subProduction[0] = "stmt";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "stmts";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 13:
                    subProduction[0] = "if";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "(";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "boolexpr";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[3] = ")";
                    tNode.Add(new TreeNode(subProduction[3]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[4] = "then";
                    tNode.Add(new TreeNode(subProduction[4]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[5] = "stmt";
                    tNode.Add(new TreeNode(subProduction[5]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[6] = "else";
                    tNode.Add(new TreeNode(subProduction[6]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[7] = "stmt";
                    tNode.Add(new TreeNode(subProduction[7]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 14:
                    subProduction[0] = "while";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "(";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "boolexpr";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[3] = ")";
                    tNode.Add(new TreeNode(subProduction[3]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[4] = "stmt";
                    tNode.Add(new TreeNode(subProduction[4]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 15:
                    subProduction[0] = "ID";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "=";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "arithexpr";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[3] = ";";
                    tNode.Add(new TreeNode(subProduction[3]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 16:
                    subProduction[0] = "arithexpr";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "boolop";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "arithexpr";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 17:
                    subProduction[0] = "<";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 18:
                    subProduction[0] = ">";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 19:
                    subProduction[0] = "<=";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 20:
                    subProduction[0] = ">=";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 21:
                    subProduction[0] = "==";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 22:
                    subProduction[0] = "multexpr";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "arithexprprime";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 23:
                    subProduction[0] = "+";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "multexpr";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "arithexprprime";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 24:
                    subProduction[0] = "-";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "multexpr";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "arithexprprime";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 26:
                    subProduction[0] = "simpleexpr";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "multexprprime";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 27:
                    subProduction[0] = "*";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "simpleexpr";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "multexprprime";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 28:
                    subProduction[0] = "/";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "simpleexpr";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = "multexprprime";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 30:
                    subProduction[0] = "ID";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 31:
                    subProduction[0] = "INTNUM";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 32:
                    subProduction[0] = "REALNUM";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                case 33:
                    subProduction[0] = "(";
                    tNode.Add(new TreeNode(subProduction[0]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[1] = "arithexpr";
                    tNode.Add(new TreeNode(subProduction[1]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    subProduction[2] = ")";
                    tNode.Add(new TreeNode(subProduction[2]));
                    f_node.Nodes.Add(tNode[nodeIndex++]);
                    break;
                default:
                    break;
            }
        }
        public void Analyze(RichTextBox rtb, RichTextBox codeBox, List<Token> test, List<SemanticUnit> pdt)//LL(1)语法分析器的主函数
        {
            pdt.Clear();
            Initialize();//初始化table和stack
            rtb.AppendText("匹配的token:" + "                      " + "相应的产生式" + "\n");
            int start = 0;
            //-------核心算法------
            int count = 0;
            test.Add(new Token("", "$", 0, 0,0));
            while (parserStack.Peek().Text != "$" && test[count].attributeValue != "$")
            {
                rtb.AppendText("\n");
                TreeNode X = parserStack.Peek();//得到栈顶元素，初始值为program
                string currentInput;
                if (test[count].tokenType == "identifier")
                    currentInput = "ID";
                else if (test[count].tokenType == "REALNUM")
                    currentInput = "REALNUM";
                else if (test[count].tokenType == "INTNUM")
                    currentInput = "INTNUM";
                else
                    currentInput = test[count].attributeValue;

                //rtb.AppendText(" ");
                if (syntax_Table.getIndexOfTerminal(X.Text)!=-1 || X.Text == "$")//X is a Terminal
                {
                    if (X.Text == currentInput)
                    {
                        parserStack.Pop();
                        //X.Text = test[count].AttributeValue;
                        rtb.AppendText(currentInput + "\n");
                        pdt.Add(new SemanticUnit(0, test[count].attributeValue, test[count].tokenType,test[count].index));
                        start = ++count;
                    }
                    else
                    {
                        handleError(X.Text);
                        if (test[count].attributeValue == ";" || test[count].attributeValue == "}")
                        {
                            while (parserStack.Peek().Text != ";")
                            {
                                parserStack.Pop();
                            }
                            parserStack.Pop();
                            codeBox.SelectionStart = test[start].index - 1;
                            codeBox.SelectionLength = test[count].index - codeBox.SelectionStart + 1;
                            codeBox.SelectionBackColor = Color.White;
                            Font font = new Font(rtb.SelectionFont, FontStyle.Underline);
                            codeBox.SelectionFont = font;
                            count++;
                        }
                        else
                        {
                            codeBox.SelectionStart = test[count].index;
                            codeBox.SelectionLength = test[count].attributeValue.Length;
                            codeBox.SelectionBackColor = Color.Gray;
                            count++;
                        }
                        success = false;
                        //break;
                    }
                }
                else //X is not a Terminal
                {
                    ntIndex =syntax_Table.getIndexOfNonTerminal(X.Text);
                    tIndex = syntax_Table.getIndexOfTerminal(currentInput);

                    if (syntax_Table.Table[ntIndex, tIndex] == 0)
                    {
                        handleError(X.Text);
                        codeBox.SelectionStart = test[count].index;
                        codeBox.SelectionLength = test[count].attributeValue.Length;
                        codeBox.SelectionBackColor = Color.Gray;
                        count++;
                        success = false;
                        //break;

                    }
                    else
                    {
                        parserStack.Pop();
                        string outPutToken;
                        if (test[count].tokenType == "identifier")
                            outPutToken = "ID";
                        else if (test[count].tokenType == "number")
                            if (test[count].attributeValue.Contains("."))
                                outPutToken = "REALNUM";
                            else
                                outPutToken = "INTNUM";
                        else
                            outPutToken = test[count].attributeValue;
                        //rtb.AppendText(outPutToken + "      " + Production[syntax_Table.Table[ntIndex, tIndex]] + "\n");
                        rtb.AppendText(outPutToken + "                             " + syntax_Table.getProduction()[syntax_Table.Table[ntIndex, tIndex]] + "\n");
                        setRightSubProduction(X, syntax_Table.Table[ntIndex, tIndex]);
                        pdt.Add(new SemanticUnit(syntax_Table.Table[ntIndex, tIndex], X.Text, "", 0));
                        for (int k = 0; k < 10; k++)
                        {
                            if (subProduction[k] != " " && subProduction[k] != "ε")
                            {
                                parserStack.Push(tNode[nodeIndex - k - 1]);//逆向压栈
                            }
                        }
                    }
                }
            }
            if (test[count].attributeValue == "$")
            {
                if (parserStack.Peek().Text == "$")
                {
                    if (success)
                        rtb.AppendText("Parsing Done");
                    else
                    {
                        rtb.AppendText("Parsing Failed");
                    }
                }
                else
                {
                    MessageBox.Show("\nMISSING }");
                    success = false;
                    rtb.AppendText("Parsing Failed");
                }
            }
            else
            {
                codeBox.SelectionStart = test[count].index;
                codeBox.SelectionLength = 999;
                codeBox.SelectionBackColor = Color.Gray;
                success = false;
                rtb.AppendText("Parsing Failed");
            }
        }
    }
}
