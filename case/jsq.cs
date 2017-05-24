using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        /*
         * 只作为一个完整的,能运行的程序,给初学者一些建议和帮助
         * 我的想法其实就是,按数字按钮,就显示在显示框上,当按下运算符时,保存这个符号,保存这个显示框上面的数据为num1
         * 然后再按数字键时,先清空屏幕,再输入数据,之后按等于的话则直接显示结果,结束这次操作
         * tempp是MS,MR等4个按键时需要的变量,当MS保存了数据后,temp为1,temp为0是没保存数据
         */ 
         
        double numOne = 0, numTwo = 0, ans, temp;     
        char opr = ' ';                            //记录操作运算符        
        int step = 0, op = 0, tempp = 0;
        int radix = 10;
        Button[] btns;
        
        public Form1()
        {
            InitializeComponent();

            //将按钮都放入集合,用于对于不同进制显示不同的数字按钮
            btns = new Button[]{
                button0,button1,
                button2,button3,button4,button5,button6,button7,
                button8,button9,
                buttonA,buttonB,buttonC,buttonD,buttonE,buttonF
            };
        }

        private void SetInputFocus()
        {
            tbInput.Focus();
            tbInput.SelectionStart = tbInput.TextLength;
            tbInput.SelectionLength = 0;
        }

        //设置新的进制,将显示框内的数据置空或置为相应的进制数据
        private void SetInputRadix(int newRadix)
        {
            if (tbInput.TextLength == 0)
            {
                radix = newRadix;
                return;
            }
            try
            {
                Num n = new Num(tbInput.Text, radix);
                radix = newRadix;
                tbInput.Text = n.ToString(radix);
            }
            catch
            {
                radix = newRadix;
                tbInput.Text = string.Empty;
            }
        }

        //根据进制的不同,设置小于它的为Enabled,只有在10进制的时候,小数点的Enabled才为true
        private void SetButtonEnabled(int radix)
        {
            for (int i = 0; i < radix; i++)
                btns[i].Enabled = true;
            for (int i = radix; i < btns.Length; i++)
                btns[i].Enabled = false;
            if (radix == 10)
                buttonDot.Enabled = true;
            else
                buttonDot.Enabled = false;
        }

        //在显示框内增加字符
        private void AppendChar(char c)
        {
            tbInput.Text += new string(c, 1);
        }

        //在显示框数据的前面加一个字符
        private void InsertChar(char c)
        {
            tbInput.Text = new string(c, 1) + tbInput.Text;
        }

        //删除最后输入的一个数据,即显示框中的最后一个字符
        private void RemoveLastChar()
        {
            if (tbInput.TextLength > 0)
                tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
        }

        //选择进制2.8.10.16
        private void rRadix2_Click(object sender, EventArgs e)
        {
            SetInputRadix(2);
            SetButtonEnabled(2);
            SetInputFocus();
        }
        private void rRadix8_Click(object sender, EventArgs e)
        {
            SetInputRadix(8);
            SetButtonEnabled(8);
            SetInputFocus();
        }
        private void rRadix10_Click(object sender, EventArgs e)
        {
            SetInputRadix(10);
            SetButtonEnabled(10);
            SetInputFocus();
        }
        private void rRadix16_Click(object sender, EventArgs e)
        {
            SetInputRadix(16);
            SetButtonEnabled(16);
            SetInputFocus();
        }

        //默认选项,默认10进制
        private void Form1_Load(object sender, EventArgs e)
        {
            radix = 10;
            rRadix10.Checked = true;
            SetButtonEnabled(radix);
            SetInputFocus();
        }

        //这个也不是我写的...- -# 老师写的,老师给我的时候,Num.cs,以及有一些函数是他写的,我完成的只是根据他提供的代码,以及界面,完成这个计算器
        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' ||
                radix == 2 && e.KeyChar >= '0' && e.KeyChar <= '1' ||
                radix == 8 && e.KeyChar >= '0' && e.KeyChar <= '7' ||
                radix == 10 && (e.KeyChar == '.' && tbInput.Text.IndexOf('.') < 0 ||
                    e.KeyChar >= '0' && e.KeyChar <= '9') ||
                radix == 16 && (//已设置CharacterCasing to Upper
                    e.KeyChar >= '0' && e.KeyChar <= '9' ||
                    e.KeyChar >= 'a' && e.KeyChar <= 'f' ||
                    e.KeyChar >= 'A' && e.KeyChar <= 'F'))
                e.Handled = false;
            else
                e.Handled = true;

        }

        //这个是什么忘记了....可能没用吧
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                e.Handled = true;
        }

        //小数点操作
        private void buttonDot_Click(object sender, EventArgs e)
        {
            //在10进制，且当前没有小数点的时候，则添加一个小数点
            if (radix == 10 && !tbInput.Text.Contains('.'))
                AppendChar('.');
            SetInputFocus();
        }

        //+/-  功能，为整数则变为负数，为负数则变为正数
        private void buttonSign_Click(object sender, EventArgs e)
        {
            //如果显示框数据的第一位为‘-’号，则将其删除，否则在第一位加一个‘-’号
            if (tbInput.Text.StartsWith("-"))
                tbInput.Text = tbInput.Text.Substring(1);
            else
                InsertChar('-');
            SetInputFocus();
        }


        private void tbInput_Click(object sender, EventArgs e)
        {
            SetInputFocus();
        }

        /* 清屏操作,如果之前刚刚输入了操作运算符,再按数字键的时候,会清除显示框内的数据,并且将op置0
         * 这样,当按了运算符,则op为1,然后再按数字,则会清屏,然后op置0,之后再按数字,不会清屏了
         */ 
        public void clear()
        {
            //tbInput.Text=="0"  ,是在显示框内为"0"时,再按0,则清除之前的0,再写入一个0
            if (op != 0 || tbInput.Text=="0")
            {   
                tbInput.Text = String.Empty;
                if (op != 0)
                    op--;
            }
        }

        /*
         * 0-15.16个数字按钮,每次按下都是先用clear(),检查,操作,然后将相应的数字显示在显示框的数据的后面
         */ 
 //0按钮与其他几个不同,因为不能输入两个0,即如果已经输入了一个0,再按0,不能显示"00",它还是为"0",此按钮在这种情况下无效
        private void button0_Click(object sender, EventArgs e)
        {
            clear();
            if (tbInput.Text != "0")
            {
                AppendChar('0');
                SetInputFocus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('1');
            SetInputFocus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('2');
            SetInputFocus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('3');
            SetInputFocus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('4');
            SetInputFocus();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('5');
            SetInputFocus();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('6');
            SetInputFocus();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('7');
            SetInputFocus();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('8');
            SetInputFocus();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('9');
            SetInputFocus();
        }
        private void buttonA_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('A');
            SetInputFocus();
        }
        private void buttonB_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('B');
            SetInputFocus();
        }
        private void buttonC_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('C');
            SetInputFocus();
        }
        private void buttonD_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('D');
            SetInputFocus();
        }
        private void buttonE_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('E');
            SetInputFocus();
        }
        private void buttonF_Click(object sender, EventArgs e)
        {
            clear();
            AppendChar('F');
            SetInputFocus();
        }

        //backspace,即回删功能
        private void buttonBs_Click(object sender, EventArgs e)
        {
            RemoveLastChar();
            SetInputFocus();
        }

        //C按钮,全部清空,此时计算器相当于重新加载打开了
        private void buttonClear_Click(object sender, EventArgs e)
        {
            tbInput.Text = String.Empty;
            numOne = 0;
            numTwo = 0;
            op = 0;
            opr = ' ';
            ans = 0;
            tempp = 0;
            label1.Text = String.Empty;
        }

        //获得数
        private void getNum()
        {
            op++;           //运算计数器加1
            Num n = new Num(tbInput.Text, radix);
            
            //step为0,将显示框里的数据保存为num1,然后step加1
            if (step==0)
            {
                numOne = Convert.ToDouble(n.ToString(radix));
                step++;
            }
            
            /*step不为0了,将显示框中的数保存为num2,并进行操作,将结果显示在显示框中
             * 这里是用来进行连续操作的
             * 输入1,按下+,再按2,此时若不是按等于号,而是+-*之类的
             * 则会计算1+2=3,将3显示出来,同时将3保存为新的num1,将按下的运算符作为新的运算符ope
             */ 
            else
            {
                numTwo = Convert.ToDouble(n.ToString(radix));
                switch (opr)
                {
                        //是用num1来保存的,与等于号功能中的定义ans不同哦~~
                    case '+': numOne = numOne + numTwo; break;
                    case '-': numOne = numOne - numTwo; break;
                    case '*': numOne = numOne * numTwo; break;
                    case '/': numOne = numOne / numTwo; break;
                    case '%': numOne = numOne % numTwo; break;
                    case 'e': ans = numOne * Math.Pow(10, numTwo); break;
                }
                tbInput.Text = numOne.ToString();
            }
        }

        /*
         *基础的四则运算按钮，获得数字，并赋值运算符
         *但这里写了判断的条件，这样，输入数据，按了一下这些符号就保存数据到了num1中
         *而再按这些运算符时，只是改变运算符，不再做getNum操作，这样可以更改运算符
         *但是其他操作没有这样写，理应也是要这样写的（我偷懒了...因为大都是只用四则运算的...）
         * 
         */

        //加
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = '+';

        }

        //减
        private void buttonSub_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = '-';
        }

        //乘
        private void buttonMul_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = '*';
        }

        //除
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = '/';
        }

        //取模操作,即求余数
        private void buttonMod_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = '%';
        }

        //等于号,计算功能
        private void buttonEq_Click(object sender, EventArgs e)
        {
            //step为0的时候,opr还未赋值,即还不知道要对什么数进行什么操作
            if (step != 0)
            {
                //按下等于号时,或将显示框中的数据保存在num2中(之前已经保存了num1和opr运算符)
                Num n = new Num(tbInput.Text, radix);
                numTwo = Convert.ToDouble(n.ToString(radix));
                
                //根据不同的opr,进行不同的操作
                switch (opr)
                {
                    case '+': ans = numOne + numTwo; break;
                    case '-': ans = numOne - numTwo; break;
                    case '*': ans = numOne * numTwo; break;
                    case '/': ans = numOne / numTwo; break;
                    case '%': ans = numOne % numTwo; break;
                  
                    //下面这几个功能实现起来其实很简单,如果知道这些符号的话.....                   
                    case 'e': ans = numOne * Math.Pow(10, numTwo); break;   //Exp功能,num2为几,就在num1后面加几个0
                    case 'a': ans = (int)numOne & (int)numTwo; break;        //与运算
                    case 'o': ans = (int)numOne | (int)numTwo; break;           //或运算
                    case 'x': ans = (int)numOne ^ (int)numTwo; break;         //异或运算
                }

                //根据当前的进制,将结果显示在显示框
                int q = radix;
                String s = Convert.ToString((int)ans, q);
                tbInput.Text = s;
              
                //后续操作,清空
                op++;              
                opr = ' ';
                step = 0;
                numOne = 0;
                numTwo = 0;
            }
        }
        

        //copy功能,按下此键,就相当于复制了显示框中的内容
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbInput.Text.Trim());
        }

        //快捷输入π的数值,用了Math.PI而已
        private void buttonPI_Click(object sender, EventArgs e)
        {
            tbInput.Text = Math.PI.ToString();
            op++;
        }

        //清空显示框中的内容,用于输入数据错误,要重新输入时使用
        private void buttonCE_Click(object sender, EventArgs e)
        {
            tbInput.Text = string.Empty;
            SetInputFocus();
        }

        //取整功能,获得数字,然后取整数部分并显示
        private void buttonInt_Click(object sender, EventArgs e)
        {
            Num n = new Num(tbInput.Text, radix);
            tbInput.Text = n.Integer.ToString();
            op++;
        }

        //这个EXp功能只是在后面加0,如输入21,按此按钮,再按3,按等于得出来的结果是21000
        private void buttonExp_Click(object sender, EventArgs e)
        {
            if (op == 0)
                getNum();
            opr = 'e';
        }

        /*
         * M开头的四个功能键
         * MS为保存,即保存当前显示框内的数据,此时计算器上显示一个"M",表明已经保存了数据
         *       并且赋值tempp为1 
         *  MC为清除,即删除保存的那个数据,"M"标志去除,tempp赋值0
         *  M+ 功能,就是将保存的那个数加上当前显示框内的数据,继续保存
         *  MR,就是将这个保存的数显示出来
         *  
         * 我们在进行连加的时候,就输入一个数,MS,然后在每次输入数之后都按一下M+,最后按一下MR,结果就会显示出来
         */ 
        private void buttonMR_Click(object sender, EventArgs e)
        {
            //只有保存了数时,才有效,把这个数显示出来
            if (tempp == 1)
                tbInput.Text = temp.ToString();
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            Num n = new Num(tbInput.Text, radix);
            temp = Convert.ToDouble(n.ToString(radix));
            tempp = 1;
            label1.Text = "M";
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            tempp = 0;
            label1.Text = String.Empty;
        }

        //M+
        private void buttonMAdd_Click(object sender, EventArgs e)
        {
            //保存了数据之后tempp才为1,若为0,没有保存数据,则不进行任何操作
            if (tempp == 1)
            {
                Num n = new Num(tbInput.Text, radix);
                temp += Convert.ToDouble(n.ToString(radix));
            }
        }

        //与运算
        private void buttonAnd_Click(object sender, EventArgs e)
        {
                getNum();
                opr = 'a';
        }

        //左移操作,参见右移操作(buttonRightMove_Click(),就在下一个)
        private void buttonLeftMove_Click(object sender, EventArgs e)
        {
            Num n = new Num(tbInput.Text, radix);
            long d = Convert.ToInt64(n.ToString()) << 1;

            int q = radix;
            String s = Convert.ToString((int)d, q);
            tbInput.Text = s;
            op++;

        }

        //右移操作, int i=100>>1,这样获得的i是100右移一位之后的值,相关代码注释参见最后一个函数(buttonNot_Click())
        private void buttonRightMove_Click(object sender, EventArgs e)
        {
            Num n = new Num(tbInput.Text, radix);
            long d = Convert.ToInt64(n.ToString()) >> 1;
            int q = radix;
            String s = Convert.ToString((int)d, q);
            tbInput.Text = s;
            op++;
        }
        
        //或和异或操作，通过getNum获得当前的num1，然后，让运算符号为“o”或者"x",这和四则运算时候的处理是一样的
        private void buttonOr_Click(object sender, EventArgs e)
        {
            getNum();
            opr = 'o';
        }

        
        private void buttonXor_Click(object sender, EventArgs e)
        {
            getNum();
            opr = 'x';
        }

        /*Not功能不完善，如10进制下输入了83,按not会显示-84,这是因为not是为二进制而言的
         * 二进制110的not为001,当然,系统自动的在前面还会加一些1或者是0
         * 这个按钮,我觉得是没必要的,实现的也很粗糙
         */
        private void buttonNot_Click(object sender, EventArgs e)
        {
            int pos = tbInput.Text.IndexOf('.');  //获得显示框中的第一个小数点在那个文本中的位置，没有小数点时会返回-1
          
            //只在没有小数点的情况下，此按钮才有用
            if (pos < 0)
            {
                Num n = new Num(tbInput.Text, radix);  //根据当前的进制，获得当前显示框中的数字
             
                //用long来保存这个数字的整数部分,其实按我这个程序来说,要是有小数部分是不会执行这里的
                long p = n.Integer;         
             
                int q = radix;  //获得当前的进制
               
                /*将获得的这个数进行非运算
                 * 其实很简单,在前面加了个符号而已,然后再转化为当前的进制,用String保存
                 **/
                String s = Convert.ToString(~(int)p, q);
               
                tbInput.Text = s;         //将结果显示到显示框中
              
                //标记进行了一次运算,这样再按数字的时候,才会清空
                op++;
            }
        }

    }
}
