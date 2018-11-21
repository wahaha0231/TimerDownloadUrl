using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM25
{
    public partial class Form1 : Form
    {
        int num;//檔名編號
        int n=0;//計數器
        

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            num = Int32.Parse(textBox1.Text);
            timer1.Interval = 1000; // 設定每秒觸發一次
            timer1.Enabled = true; // 啟動 Timer

            button1.Enabled = false;
            textBox1.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            n++;
            label1.Text = n.ToString();
            if (n == 3600 )
            {
                using (WebClient myWebClient = new WebClient())
                {
                    myWebClient.DownloadFile("http://opendata.epa.gov.tw/webapi/Data/REWIQA/?$orderby=SiteName&$skip=0&$top=1000&format=csv", @"C:\Users\mis6\Desktop\DataPM2.5\" + num + ".csv");
                }
                num++;
                n = 0;
            }

        }
    }
}
