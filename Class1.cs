using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TimerExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 60000;//执行间隔时间,单位为毫秒;此时时间间隔为1分钟  
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(shut);

            Console.ReadKey();
        }
        private static void shut(object source, ElapsedEventArgs e)
        {
            FileStream fs = new FileStream("settime.txt", FileMode.Open,FileAccess.Read,FileShare.Read);
            StreamReader sr = new StreamReader(fs);
            string str;
            str = sr.ReadLine();
            string[] strs;
            strs = str.Split(' ');
            int a,b;
            a = Convert.ToInt32(strs[0]);
            b = Convert.ToInt32(strs[1]);
            if (DateTime.Now.Hour == a && DateTime.Now.Minute == b - 1)
                MessageBox.Show("一分钟关机");
            if (DateTime.Now.Hour == a && DateTime.Now.Minute == b) 
                Process.Start("c:/windows/system32/shutdown.exe", "-s -t 0");
        }
    }
}