using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        string filePath = "";
        List<Token> ScanResult = new List<Token>();
        List<Token> ScanValue = new List<Token>();
        List<SemanticUnit> Actions = new List<SemanticUnit>();//记录语义动作
        Scanning scanning = new Scanning();//词法分析    
        bool scanSuccess = true;
        string str;
        LLParserAnalyze llp = new LLParserAnalyze();//语法分析
        public Form1()
        {
            InitializeComponent();
            
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            if (rtbSource.Text == "")
            {
                MessageBox.Show("请输入代码或者选择已有文件！");
                return;
            }
            clear();
            rtbToken.Text += "\n";
            str = rtbSource.Text + "\n";
            ScanResult = scanning.ScanProcess(str);
            for (int k = 0; k < ScanResult.Count; k++)
            {
                rtbToken.Text += ScanResult[k].toString() + "\n";
                ScanValue.Add(ScanResult[k]);
                if (ScanResult[k].tokenType == "ERROR")
                {
                    scanSuccess = false;
                    rtbSource.SelectionStart = ScanResult[k].index;
                    rtbSource.SelectionLength = ScanResult[k].attributeValue.Length;
                    rtbSource.SelectionColor = Color.Red;
                    scanSuccess = false;
                }
            }
            str = "";
            scanning.Tokens.Clear();
            ScanResult.Clear();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            if (rtbSource.Text == "")
            {
                MessageBox.Show("请输入代码或者选择已有文件！");
                return;
            }
            if (scanning.tokenNum == 0)
            {
                MessageBox.Show("请先做词法分析！");
                return;
            }
            Semantic semantic = new Semantic();
            tVSyntax.Nodes.Clear();
            if (scanSuccess)
            {
                llp.Analyze(rtbLLParser, rtbSource, ScanValue, Actions);
                tVSyntax.Nodes.Add(llp.root);
                tVSyntax.ExpandAll();
                if (llp.success)
                {
                    semantic.getSemantic(Actions, scanning.SymbolTableHash, rtbSource);
                    rtbThreeCode.Text = semantic._3add;
                    rtbThreeCode.Text += "\n";
                    foreach (DictionaryEntry i in scanning.SymbolTableHash)
                    {
                        rtbThreeCode.Text += "\n" + i.Key;
                        SymbolTable sti = (SymbolTable)i.Value;
                        rtbThreeCode.Text += ": Type:" + sti.type;
                    }
                }
                else
                    MessageBox.Show("WARNING:存在语法错误，无法进行语义分析！");
            }
            else
            {
                MessageBox.Show("WARNING:存在词法错误，无法进行语法分析！");
            }
        }

        private void rtbSource_TextChanged(object sender, EventArgs e)
        {
            rtbSource.Select(0, rtbSource.Text.Length);
            rtbSource.SelectionColor = Color.Black;
            this.Display_Blue(rtbSource);
            rtbSource.Focus();
            rtbSource.Select(rtbSource.TextLength, 0);
        }
        private void Display_Blue(RichTextBox rtb)
        {
            string[] strInput = new string[] {"int","real","if","then","else","while"};
            for (int count = 0; count < strInput.Length; count++)
            {
                Regex reg = new Regex("\\b(?<!@)" + strInput[count] + "\\b");
                Match ma = reg.Match(rtb.Text);
                while (ma.Success)
                {
                    rtb.Select(ma.Index, strInput[count].Length);
                    rtb.SelectionColor = Color.Blue;
                    ma = reg.Match(rtb.Text, ma.Index + ma.Length);
                }
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            clear();
            rtbSource.Clear();
        }
        private void clear()
        {
            filePath = "";
            ScanResult = new List<Token>();
            ScanValue = new List<Token>();
            Actions = new List<SemanticUnit>();
            scanning = new Scanning();
            scanSuccess = true;
            llp = new LLParserAnalyze();
            rtbToken.Clear();
            rtbThreeCode.Clear();
            rtbLLParser.Clear();
            ScanResult.Clear();
            ScanValue.Clear();
            Actions.Clear(); ;
            tVSyntax.Nodes.Clear();
            scanSuccess = true;
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            openFileDialog1.Title = "打开文件";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                filePath = openFileDialog1.FileName;
            if (filePath == "")
            {
            }
            else
                rtbSource.LoadFile(filePath, RichTextBoxStreamType.PlainText);
            clear();
        }

        private void savescan_Click(object sender, EventArgs e)
        {
            SaveFileDialog objSave = new SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "Token" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter FileWriter = new StreamWriter(objSave.FileName, true); //写文件

                FileWriter.Write(rtbToken.Text);//将字符串写入
                FileWriter.Close(); //关闭StreamWriter对象
            }
        }

        private void saveparser_Click(object sender, EventArgs e)
        {
            SaveFileDialog objSave = new SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "Induction Result" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter FileWriter = new StreamWriter(objSave.FileName, true); //写文件

                FileWriter.Write(rtbLLParser.Text);//将字符串写入
                FileWriter.Close(); //关闭StreamWriter对象
            }
        }

        private void save3address_Click(object sender, EventArgs e)
        {
            SaveFileDialog objSave = new SaveFileDialog();
            objSave.Filter = "(*.txt)|*.txt|" + "(*.*)|*.*";
            objSave.FileName = "Three Address Codes" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter FileWriter = new StreamWriter(objSave.FileName, true); //写文件

                FileWriter.Write(rtbThreeCode.Text);//将字符串写入
                FileWriter.Close(); //关闭StreamWriter对象
            }
        }
    }
}
