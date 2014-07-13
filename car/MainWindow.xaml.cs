using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


namespace car
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string var_memberid;                  //定义全局变量,用户名
        public static string var_uid;                       //定义全局变量,id
        public static string var_head;                      //定义全局变量,头像
        public static string var_qm;                        //定义全局变量,签名
        public static string var_nickname;                  //定义全局变量,昵称
        public static string var_vip;                       //定义全局变量,vip
        public static string var_vdate;                     //定义全局变量,vip到期
        public static string var_tw;                        //定义全局变量,图文推广
        public static string var_wdate;                     //定义全局变量,文到期
        public static string var_tdate;                     //定义全局变量,图到期
        public static string var_ws;                        //定义全局变量,文数量
        public static string var_ts;                        //定义全局变量,图数量
        public static string var_password;                  //定义全局变量，密码
       

        private string accountFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
        private IDictionary accounts = new SortedList(); 
        public MainWindow()
        {
            InitializeComponent();
            Random gen = new Random();
            code.Content = gen.Next(10000); ;
            FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read);
            StreamReader m_streamReader = new StreamReader(fs);
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            // 从数据流中读取每一行，直到文件的最后一行，并在UserNametextBox和passwordBox中显示出内容
            this.UserNametextBox.Text = "";
            this.passwordBox.Password = "";
            string strLine = m_streamReader.ReadLine();
            this.UserNametextBox.Text = strLine;
            strLine = m_streamReader.ReadLine();
            this.passwordBox.Password = strLine;
            //关闭此StreamReader对象
            m_streamReader.Close();
        }
        //窗体移动
        private void Window_MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        #region 退出系统
        private void Exitbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void ImageClose_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        #endregion

        #region 设置快捷键
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Loginbutton_Click(sender, null);
            }
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }
        #endregion


        #region 登录系统
        private void Loginbutton_Click(object sender, RoutedEventArgs e)
        {
            string UserName = this.UserNametextBox.Text.Trim();
            string PassWord = this.passwordBox.Password.Trim();
            if(codeBox.Text.ToString()!=code.Content.ToString())
            {

                MessageBox.Show("验证码不正确，请重新输入");
                this.codeBox.Focus();
            }
            else
            { 
            string postdata = "memberid=" + UserName + "&password=" + PassWord;
            string uri = "http://www.2sche.cn/zhushou/login.asp";
  
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("memberid", UserName);
            parameters.Add("password", PassWord);

          HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(uri, parameters, null, null, Encoding.UTF8, null);
           StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
           string a = reader.ReadToEnd();
          
           
           JObject obj = JObject.Parse(a);
           JObject value = JObject.Parse(obj["datavalue"].ToString());
           
        if ((string)obj["status"]=="1")
            {
               // MessageBox.Show((string)obj["message"]);
                if (Me.IsChecked == true)
                {
                   FileStream fs = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write);

                    fs.Seek(0, SeekOrigin.Begin);
                    fs.SetLength(0); //清空txt文件

                    StreamWriter m_streamWriter = new StreamWriter(fs);

                    m_streamWriter.Flush();

                    // 使用StreamWriter来往文件中写入内容

                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

                    // 把UserNametextBox和passwordBox中的内容写入文件

                    m_streamWriter.Write(UserNametextBox.Text);
                    m_streamWriter.WriteLine();
                    m_streamWriter.Write(passwordBox.Password);

                    //关闭此文件

                    m_streamWriter.Flush();

                    m_streamWriter.Close();
                  }
                    string var_message = (string)obj["message"];
                    MessageBox.Show(var_message);
                    var_memberid = UserName;                                                      //全局变量保存用户名
                    var_password = PassWord;                                                      //全局变量保存密码
                    var_uid = (string)value["uid"];                                                 //全局变量保存uid
                    var_head = (string)value["head"];                                               //全局变量保存头像 
                    //MessageBox.Show(var_head);
                    var_qm = (string)value["qm"];                                                   //全局变量保存签名
                    var_nickname = (string)value["nickname"];                                       //全局变量保存昵称
                    var_vip = (string)value["vip"];                                                 //全局变量保存vip
                    var_vdate = (string)value["vdate"];                                             //全局变量保存vip到期
                    var_tw = (string)value["tw"];                                                   //全局变量保存图文推广
                    var_wdate = (string)value["wdate"];                                             //全局变量保存文到期
                    var_tdate = (string)value["tdate"];                                             //全局变量保存图到期
                    var_ws = (string)value["ws"];                                                   //全局变量保存文数量
                    var_ts = (string)value["ts"];                                                   //全局变量保存图数量
                    Main main = new Main();
                    main.Show();
                    this.Close();
            }
                else
                {
               //     MessageBox.Show((string)obj["message"]);
                    MessageBox.Show("用户名或密码不正确，请重新输入");
                    this.UserNametextBox.Clear();
                    this.passwordBox.Clear();
                    this.UserNametextBox.Focus();
                }
         }
        }
        #endregion

        private void hyperlink0_Click(object sender, RoutedEventArgs e)
        {
            Process ieProc = Process.Start("http://www.2sche.cn/");
        }
        //字符串\\\\转换
         public String string2Json(String s) 
        {
            string[] temp = s.Split('\\');
             s="";
            for(int i=0;i<temp.Length-1;i++)
            {
                s = s + temp[i] + "\\\\";
            }
            s =s+ temp[temp.Length - 1];
         return s; 
        }


       


        
    }
}
