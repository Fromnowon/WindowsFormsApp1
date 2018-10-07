using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MyListview()
        {
            for (int i = 0; i < 6; i++)
            {
                //这里i需要是字符型的，所以转换一下，i为第1列的内容
                ListViewItem item = new ListViewItem(Convert.ToString(i));
                string[] first = { "测试内容", "测试内容", "测试内容" };
                item.SubItems.AddRange(first);
                listView1.Items.Add(item);
            }
        }

        public string CreateWeb(string url)
        {

            StringBuilder sb = new StringBuilder();
            //抓取网页
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            //读取文件流
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")); //reader.ReadToEnd() 表示取得网页的源码
            //FileStream fs = new FileStream("~/baidu.html", FileMode.OpenOrCreate);
            string strhtml = reader.ReadToEnd();
            //正则匹配网站的标签
            //string Rxg = "<a([\\s]+|[\\s]+[^<>]+[\\s]+)href=(\"(?<href>[^<>\"']*)\"|'(?<href>[^<>\"']*)')[^<>]*>";
            string Rxg = "<a.+?href=\"(.+?)\".*>(.+)</a>";
            //匹配出标签的集合
            MatchCollection mc = Regex.Matches(strhtml, Rxg);
            for (int i = 0; i < mc.Count; i++)
            {
                sb.Append(mc[i].Groups[2].Value);

            }
            //返回图片标签HTML输出
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(CreateWeb("http://localhost:77/"));
        }
    }
}
