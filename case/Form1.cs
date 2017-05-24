using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Teach;


namespace T1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("密码或用户名不能为空");
                return;
            }

            var user = Paser();

            user.Paser(textBox1.Text, textBox2.Text, u => label3.Text = JsonConvert.SerializeObject(u)); //必须是User的实例,才可以使用的方法
            //lambad 
            user.Paxx(textBox1.Text, textBox2.Text,
                (userId, userName, _user) =>
                {
                    var txt = $"名字:{userName},id{userId},json:{ JsonConvert.SerializeObject(_user)}";

                    var txt1 = string.Format("名字:{0},id{1},json:{2}", userName, userId, JsonConvert.SerializeObject(user));
                    label4.Text = txt;
                    _user.UserName = $"{userName}@{userId}";
                },
                u => label4.Text += JsonConvert.SerializeObject(u),
                u1 =>
                {
                    //toDo
                    return u1.UserId;
                });

            user.Paser(callBack: u => label3.Text = JsonConvert.SerializeObject(u),
                pwd: textBox2.Text, name: textBox1.Text);

            //label3.Text = JsonConvert.SerializeObject(user);
            //label3.Text += "\r\nToString()=" + user.ToString();

            int num = 8;

            User user5 = new User();

            user5.UserId = 1;
            label4.Text = user.RefTest(ref num, ref user5).ToString();
            label4.Text += "::::::" + num.ToString() + ";z=" + user5.UserId.ToString();

            //User.RefUser(user);//不需要对User进行new 实例,就可以直接调用static的方法
            //label4.Text = JsonConvert.SerializeObject(user);

            //user.Test1111("", "");



        }


        //public; 公共的,谁都可以用,[方法,属性,字段,类,事件..]
        //protected 继承者可使用,
        //private 私有的,对应不标明访问修饰符,都等于我
        //internal 内部可使用[方法,属性,字段,类,事件..]



        User Paser()
        {
            return new User(textBox1.Text, textBox2.Text); ;
            //User user = new User(textBox1.Text, textBox2.Text);
            ////var user1 = new User();
            ////user.UserName = textBox1.Text;
            ////user.Password = textBox2.Text;
            //return user;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("textbox3 不能为空");
            }
            var test = TestInterfaceFactroy.CreateTest(textBox3.Text);

            label5.Text += JsonConvert.SerializeObject(test)+"\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}

