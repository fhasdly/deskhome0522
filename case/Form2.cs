using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text += (" " + label1.Text);

            label3.Text += (" " + label2.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var lab = sender as Label;

            // var b = lab ?? new Label();

            labResult.Text += (lab?.Text ?? "") + " ; ";//C# 6.0

            //lab?.Text;

            //if (lab != null)
            //{
            //    lab.Text;
            //}
            //else {
            //    null;
            //}

            //var a = 12 as int?;
            //int?  == Nullable<int>

            //(Label)sender  这样转换,如果sender 不是Label或者其子类,会抛异常
            //sender as Label; 这样转换.称为安全转换.如果sender不是Label或其子类,不会抛异常,但是 等号前的变量等于 null

            // sender is Label 返回bool值,告知是否可以进行转换

        }
    }
}
