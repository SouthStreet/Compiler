using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    class SemanticUnit
    {
        public int productionNum;
        public string nodeObj;
        public string objType;
        public int index;
        public double value;
        public SemanticUnit(int prodictionNum, string nodeObj, string objType, int index)
        {
            this.productionNum = prodictionNum;
            this.nodeObj = nodeObj;
            this.objType = objType;
            this.index = index;
        }
        public SemanticUnit(int a, string b, string c, int index,int value)
        {
            this.productionNum = a;
            this.nodeObj = b;
            this.objType = c;
            this.index = index;
            this.value = value;
        }
    }

    class Semantic
    {
        string gen(string op, string result, string para1, string para2)
        {
            return "\n    " + op + " " + result + "," + para1 + "," + para2;
        }
        string newlabel()
        {
            return "L" + labelcount++;
        }
        string newtemp()
        {
            return "t" + regCount++;
        }
        int count = 0;
        int regCount = 0;
        int labelcount = 0;
        SemanticUnit x;

        string e_place = "";
        string id_place = "";
        string op = "";
        public string _3add;
        string a, m, s, mp, ap, getid, reg1, reg2;
        string a_type, m_type, s_type, mp_type, ap_type, gettype;
        bool _control = true;
        Hashtable decl = new Hashtable();
        public void getSemantic(List<SemanticUnit> test, Hashtable i, RichTextBox rtb)
        {
            if (_control)
                if (count < test.Count)
                {

                    x = test[count];
                    if (count == test.Count - 1)
                    {
                        if (x.objType == "identifier" || x.objType == "int"||x.objType=="real")
                            id_place = x.nodeObj; 

                    }
                    else
                    {
                        switch (x.productionNum)
                        {
                            case 0:
                                if (x.objType == "identifier" || x.objType == "INTNUM" || x.objType == "REALNUM")
                                {
                                    id_place = x.nodeObj;
                                    if (x.objType == "REALNUM")
                                        gettype = "real";
                                    else if (x.objType == "INTNUM")
                                        gettype = "int";
                                }
                                break;
                            case 1://program->decls compoundstmt
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 2://decls->decl ; decls
                                count++;getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 3://decls-> ε
                                break;
                            case 4://decl->int ID = INTNUM
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                getid = id_place;
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("mov", getid, "", test[count].nodeObj);
                                SymbolTable hashItem = (SymbolTable)i[getid];
                                string val = hashItem.val;
                                int index = hashItem.index;
                                i.Remove(getid);
                                i.Add(getid, new SymbolTable(val,hashItem.type,index));
                                decl.Add(getid, new SymbolTable(a_type, val, index));
                                break;
                            case 5://decl->real ID = REALNUM
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                getid = id_place;
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("mov", getid, "", test[count].nodeObj);
                                SymbolTable hashItem1 = (SymbolTable)i[getid];
                                string val1 = hashItem1.val;
                                int index1 = hashItem1.index;
                                i.Remove(getid);
                                i.Add(getid, new SymbolTable(val1,hashItem1.type, index1));
                                decl.Add(getid, new SymbolTable(a_type, val1, index1));
                                break;
                            case 6://stmt->ifstmt
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 7://stmt->whilestmt
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 8://stmt->assgstmt
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 9://stmt->compoundstmt
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 10: //compoundstmt->{ stmts }
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 11://stmts->stmt stmts 
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 12://stmts->ε
                                   //DONE
                                break;
                            case 13://ifstmt->if ( boolexpr ) then stmt else stmt
                                count++; getSemantic(test, i, rtb);
                                string s_else = newlabel();
                                string s_after = newlabel();
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("jmpf", e_place, "", s_else);
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("jmp", "", "", s_after);
                                count++; getSemantic(test, i, rtb);
                                _3add += "\n" + s_else + ":";
                                count++; getSemantic(test, i, rtb);
                                _3add += "\n" + s_after + ":";
                                break;
                            case 14://whilestmt->while ( boolexpr ) stmt
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                string s_begin = newlabel();
                                string s_end = newlabel();
                                _3add += "\n" + s_begin + ":"; count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("jmpf", e_place, "", s_end); count++; getSemantic(test, i, rtb);
                                _3add += gen("jmp", "", "", s_begin);
                                _3add += "\n" + s_end + ":";
                                break;
                            case 15://assgstmt->ID = arithexpr ;
                                    //ID赋值
                                regCount = 0;
                                count++; getSemantic(test, i, rtb);//get s 
                                if (!decl.Contains(x.nodeObj))
                                {
                                    MessageBox.Show(x.nodeObj + " 未声明");
                                }
                                getid = id_place;
                                string aimID = getid;
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("mov", getid, "", a);
                                SymbolTable hashItem2 = (SymbolTable)i[getid];
                                string val2 = hashItem2.val;
                                int index2 = hashItem2.index;
                                //  int length = hashItem.Length;
                                i.Remove(getid);
                                i.Add(getid, new SymbolTable(val2, hashItem2.type,index2));
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 16://boolexpr->arithexpr boolop arithexpr
                                count++; getSemantic(test, i, rtb);
                                reg1 = a;
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                reg2 = a;
                                e_place = reg1;
                                _3add += gen(op, e_place, reg1, reg2);
                                break;
                            case 17://<
                                op = "lt"; count++; getSemantic(test, i, rtb);
                                break;
                            case 18://>
                                op = "gt"; count++; getSemantic(test, i, rtb);
                                break;
                            case 19://<=
                                op = "le"; count++; getSemantic(test, i, rtb);
                                break;
                            case 20://>=
                                op = "ge"; count++; getSemantic(test, i, rtb);
                                break;
                            case 21://=
                                op = "eq"; count++; getSemantic(test, i, rtb);
                                break;
                            case 22://arithexpr->multexpr arithexprprime
                                count++; getSemantic(test, i, rtb);
                                ap = m;
                                ap_type = m_type;
                                count++; getSemantic(test, i, rtb);
                                a = ap;
                                a_type = ap_type;
                                break;
                            case 23://arithexprprime->  + multexpr arithexprprime 
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("add", ap, ap, m);
                                if (ap_type == "int" && m_type == "int")
                                    ap_type = "int";
                                else
                                    ap_type = "real";
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 24://arithexprprime->- multexpr arithexprprime
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("sub", ap, ap, m);
                                if (ap_type == "int" && m_type == "int")
                                    ap_type = "int";
                                else
                                    ap_type = "real";
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 25://arithexprprime->ε
                                    //DONE
                                break;
                            case 26://multexpr->simpleexpr  multexprprime
                                count++; getSemantic(test, i, rtb);
                                mp = e_place;
                                mp_type = s_type;
                                count++; getSemantic(test, i, rtb);
                                m = mp;
                                m_type = mp_type;
                                break;
                            case 27://multexprprime -> * simpleexpr multexprprime
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("mul", mp, mp, e_place);
                                if (mp_type == "int" && s_type == "int")
                                    mp_type = "int";
                                else
                                    mp_type = "real";
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 28://multexprprime -> / simpleexpr multexprprime
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                _3add += gen("div", mp, mp, e_place);
                                if (mp_type == "int" && s_type == "int")
                                    mp_type = "int";
                                else
                                    mp_type = "real";
                                count++; getSemantic(test, i, rtb);
                                break;
                            case 29://multexprprime->ε
                                    //DONE
                                break;
                            case 30://simpleexpr->ID
                                count++; getSemantic(test, i, rtb);
                                e_place = newtemp();
                                s = id_place;
                                _3add += gen("mov", e_place, "", s);

                                hashItem = (SymbolTable)i[x.nodeObj];
                                if(!decl.Contains(x.nodeObj))
                                {
                                    MessageBox.Show(x.nodeObj + " 未声明");
                                }
                                else
                                    gettype = hashItem.type;

                                break;
                            case 31://simpleexpr->INTNUM
                                count++; getSemantic(test, i, rtb);
                                e_place = newtemp();
                                s = id_place;
                                _3add += gen("mov", e_place, "", s);
                                s_type = gettype;
                                break;
                            case 32:
                                count++; getSemantic(test, i, rtb);
                                e_place = newtemp();
                                s = id_place;
                                _3add += gen("mov", e_place, "", s);
                                s_type = gettype;
                                break;
                            case 33://simpleexpr->( arithexpr )
                                count++; getSemantic(test, i, rtb);
                                count++; getSemantic(test, i, rtb);
                                e_place = a;
                                mp = ap = "t0";
                                count++; getSemantic(test, i, rtb);
                                s_type = a_type;
                                break;
                            default:
                                break;
                        }
                    }
                }
        }
    }
}
