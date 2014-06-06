using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace car
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        private int i = 0;
        public Main()
        {
            InitializeComponent();
            Account.Content = "账号："+MainWindow.var_memberid;
            Nickname.Content = "昵称:" + MainWindow.var_nickname;
            Grade.Content = "等级：" + MainWindow.var_vip;
            Sign_Name.Content = MainWindow.var_qm;
        }
        #region 标题栏
        //界面颜色变化
        private void Chang_Color_Click(object sender, MouseButtonEventArgs e)
        {
            Color NewBlue1 =Color.FromArgb(100, 131, 169, 215);
            Color NewBlue2 = Color.FromArgb(100, 61, 101, 174);
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            //设置起始点和终止点，改变渐变区域的值
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            if (i % 3 == 0)
            {
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.LightBlue, 0.0));
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));
                //All_News.Foreground = new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));
            }
            if (i % 3 == 1)
            {
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.YellowGreen, 1.0));
                myVerticalGradient.GradientStops.Add(new GradientStop(Colors.GreenYellow, 0.0));
            }
            if(i%3==2)
            {
                myVerticalGradient.GradientStops.Add(new GradientStop(NewBlue1, 1.0));
                myVerticalGradient.GradientStops.Add(new GradientStop(NewBlue2, 0.0));
            }
            Grid_Title.Background = myVerticalGradient;
            Grid_Main.Background = myVerticalGradient;
            
            i++;
           
        }
        //修改按钮点击效果（按下）
        private void Upset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/1111.png", UriKind.Relative));
            Upset.Source = ima;
        }
        //修改按钮点击效果（松开）
        private void Upset_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/111.png", UriKind.Relative));
            Upset.Source = ima;
        }
        //返回按钮点击效果（按下）
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/2222.png", UriKind.Relative));
            Back.Source = ima;
        }
        //返回按钮点击效果（松开）
        private void Back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/222.png", UriKind.Relative));
            Back.Source = ima;
        }
        //返回最初按钮点击效果（按下）
        private void DBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/3333.png", UriKind.Relative));
            DBack.Source = ima;
        }
        //返回最初按钮点击效果（松开）
        private void DBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/333.png", UriKind.Relative));
            DBack.Source = ima;
        }
        //返回前进按钮点击效果（按下）
        private void Front_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/4444.png", UriKind.Relative));
            Front.Source = ima;

        }
        //返回前进按钮点击效果（松开）
        private void Front_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/444.png", UriKind.Relative));
            Front.Source = ima;
        }
        //返回删除按钮点击效果（按下）
        private void Delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/5555.png", UriKind.Relative));
            Delete.Source = ima;
        }
        //返回删除按钮点击效果（松开）
        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage ima = new BitmapImage(new Uri("image/555.png", UriKind.Relative));
            Delete.Source = ima;
        }
       //打开个人资料修改
        private void Upset_Information_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Upset_Information.Foreground = new SolidColorBrush(Colors.Blue);
            grid_Upset_Information.Visibility = System.Windows.Visibility.Visible;
            grid_News.Visibility = System.Windows.Visibility.Hidden;
            grid_SellCar.Visibility = System.Windows.Visibility.Hidden;
            grid_Book.Visibility = System.Windows.Visibility.Hidden;
            grid_ManageNews.Visibility = System.Windows.Visibility.Hidden;
            lab_UserName.Content = MainWindow.var_memberid;   
        }
        //退出程序
        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        #endregion

        #region 修改资料
        //获取身份证正面上传路径
        private void btn_SecletF_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.ShowDialog();
            txt_FileFront.Text = ofg.FileName;

        }
        //上传图片
        private void btn_SecletF_Upload(object sender, RoutedEventArgs e)
        {
            
            string filename = txt_FileFront.Text;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            HttpWebResponse response = HttpUploadFile(uri, filename);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);
            MessageBox.Show((string)obj["message"]);
            MessageBox.Show(filename);
        }
        //获取身份证反面上传路径
        private void btn_SecletE_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.ShowDialog();
            txt_FileEnd.Text = ofg.FileName;
        }
        private void btn_SecletE_Upload(object sender, RoutedEventArgs e)
        {
            string filename = txt_FileEnd.Text;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            HttpWebResponse response = HttpUploadFile(uri, filename);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);
            MessageBox.Show((string)obj["message"]);
            //MessageBox.Show(filename);
        }
        //修改个人资料
        private void Upset_Information_Button(object sender, RoutedEventArgs e)
        {
            //获取表单中的值
            string txt_question = txt_Question.Text;
            string txt_answer = txt_Answer.Text;
            string txt_qq = txt_QQ.Text;
            string txt_phone = txt_Telephone.Text;
            string txt_postalcode = txt_PostalCode.Text;
            if(chk_Pass.IsChecked==true)
            {
                string password = txt_PassW.Password;
                string new_password = txt_NPassW.Password;
            }
        }
        //修改身份信息
        private void Upset_ConfirmID_Button(object sender, RoutedEventArgs e)
        {
            string txt_idcard = txt_IDcard.Text;
            string txt_name = txt_Name.Text;
            int select_sex = Select_Sex.SelectedIndex;
            string txt_address = txt_Address.Text;
            string filename1 = txt_FileFront.Text;
            string filename2 = txt_FileEnd.Text;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            //POST上传图片
            HttpWebResponse response1 = HttpUploadFile(uri, filename1);
            HttpWebResponse response2 = HttpUploadFile(uri, filename2);
            StreamReader reader1 = new StreamReader(response1.GetResponseStream(), Encoding.UTF8);
            string content1 = reader1.ReadToEnd();
            JObject obj1 = JObject.Parse(content1);
            StreamReader reader2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
            string content2 = reader2.ReadToEnd();
            JObject obj2 = JObject.Parse(content2);
            
            MessageBox.Show((string)obj1["message"]);
            MessageBox.Show((string)obj2["message"]);
            MessageBox.Show("1");
          
        }

        #endregion 
     
        #region 菜单栏
        //工具栏，点击"我要卖车"
        private void Send_Car_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Title.Content = "卖 车 助 手";
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            //设置起始点和终止点，改变渐变区域的值
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.LightBlue, 1.7));
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 3.0));
            one_becomecolor.Background = myVerticalGradient;
            three_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            eight_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            four_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));

            grid_SellCar.Visibility = System.Windows.Visibility.Visible;
            grid_News.Visibility = System.Windows.Visibility.Hidden;
            grid_Upset_Information.Visibility = System.Windows.Visibility.Hidden;
            grid_Book.Visibility = System.Windows.Visibility.Hidden;
            grid_ManageNews.Visibility = System.Windows.Visibility.Hidden;
            Grid_Shop.Visibility = System.Windows.Visibility.Hidden;
        }
        //工具栏，点击"通讯录"
        private void Address_Book_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Title.Content = "通 讯 录";
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            //设置起始点和终止点，改变渐变区域的值
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.LightBlue, 1.7));
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 3.0));
            eight_becomecolor.Background = myVerticalGradient;
            one_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            three_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            four_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));

            grid_Book.Visibility = System.Windows.Visibility.Visible;
            grid_SellCar.Visibility = System.Windows.Visibility.Hidden;
            grid_News.Visibility = System.Windows.Visibility.Hidden;
            grid_Upset_Information.Visibility = System.Windows.Visibility.Hidden;
            grid_ManageNews.Visibility = System.Windows.Visibility.Hidden;
            Grid_Shop.Visibility = System.Windows.Visibility.Hidden;
        }
        //网上店铺
        private void Internet_shop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Title.Content = "网 上 店 铺";
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            //设置起始点和终止点，改变渐变区域的值
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.LightBlue, 1.7));
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 3.0));
            four_becomecolor.Background = myVerticalGradient;
            one_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            eight_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            three_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));

            Grid_Shop.Visibility = System.Windows.Visibility.Visible;
            grid_ManageNews.Visibility = System.Windows.Visibility.Hidden;
            grid_Book.Visibility = System.Windows.Visibility.Hidden;
            grid_SellCar.Visibility = System.Windows.Visibility.Hidden;
            grid_News.Visibility = System.Windows.Visibility.Hidden;
            grid_Upset_Information.Visibility = System.Windows.Visibility.Hidden;


            Web_Shop.Navigate("http://cheshang.2sche.cn/");
        }
        //工具栏，点击"信息管理"
        private void News_Manage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Pagfooter.Visibility = System.Windows.Visibility.Visible;
            Title.Content = "信 息 管 理";
            LinearGradientBrush myVerticalGradient = new LinearGradientBrush();
            //设置起始点和终止点，改变渐变区域的值
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.LightBlue, 1.7));
            myVerticalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 3.0));
            three_becomecolor.Background = myVerticalGradient;
            one_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));
            eight_becomecolor.Background = new SolidColorBrush(Color.FromArgb(100, 221, 231, 243));

            Grid_Shop.Visibility = System.Windows.Visibility.Hidden;
            grid_ManageNews.Visibility = System.Windows.Visibility.Visible;
            grid_Book.Visibility = System.Windows.Visibility.Hidden;
            grid_SellCar.Visibility = System.Windows.Visibility.Hidden;
            grid_News.Visibility = System.Windows.Visibility.Hidden;
            grid_Upset_Information.Visibility = System.Windows.Visibility.Hidden;
        }
        //收缩工具箱
        private void Push_Down_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (grid_Tools.Visibility == System.Windows.Visibility.Visible)
            {
                grid_Tools.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (grid_Tools.Visibility == System.Windows.Visibility.Hidden)
            {
                grid_Tools.Visibility = System.Windows.Visibility.Visible;
            }

        }
        #endregion

        #region 卖车助手
        //同行信息
        private void Together_News_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Together_News.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            All_News.Foreground = new SolidColorBrush(Color.FromRgb(201, 217, 233));
            Together_News.FontWeight = FontWeights.Bold;
            Grid_Together_News.Visibility = System.Windows.Visibility.Visible;
            Grid_All_News.Visibility = System.Windows.Visibility.Hidden;

        }
        //全部信息
        private void All_News_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            All_News.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Together_News.Foreground = new SolidColorBrush(Color.FromRgb(201, 217, 233));
            All_News.FontWeight = FontWeights.Bold;
            Grid_All_News.Visibility = System.Windows.Visibility.Visible;
            Grid_Together_News.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion

        #region 信息管理
        //显示中信息
        private void lab_Look_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lab_Look.Foreground = new SolidColorBrush(Colors.White);
            lab_Check.Foreground = new SolidColorBrush(Colors.Black);
            lab_Closed.Foreground = new SolidColorBrush(Colors.Black);
            lab_BuyM.Foreground = new SolidColorBrush(Colors.Black);


            grid_LookNews.Visibility = System.Windows.Visibility.Visible;
            grid_CheckNews.Visibility = System.Windows.Visibility.Hidden;
            grid_CloseNews.Visibility = System.Windows.Visibility.Hidden;
            grid_BuyCarNews.Visibility = System.Windows.Visibility.Hidden;
        }
        //审核中的信息
        private void lab_Check_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lab_Check.Foreground = new SolidColorBrush(Colors.White);
            lab_Look.Foreground = new SolidColorBrush(Colors.Black);
            lab_Closed.Foreground = new SolidColorBrush(Colors.Black);
            lab_BuyM.Foreground = new SolidColorBrush(Colors.Black);

            grid_CheckNews.Visibility = System.Windows.Visibility.Visible;
            grid_LookNews.Visibility = System.Windows.Visibility.Hidden;
            grid_CloseNews.Visibility = System.Windows.Visibility.Hidden;
            grid_BuyCarNews.Visibility = System.Windows.Visibility.Hidden;
        }
        //已关闭信息
        private void lab_Closed_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lab_Look.Foreground = new SolidColorBrush(Colors.Black);
            lab_Check.Foreground = new SolidColorBrush(Colors.Black);
            lab_Closed.Foreground = new SolidColorBrush(Colors.White);
            lab_BuyM.Foreground = new SolidColorBrush(Colors.Black);

            grid_CheckNews.Visibility = System.Windows.Visibility.Hidden;
            grid_LookNews.Visibility = System.Windows.Visibility.Hidden;
            grid_CloseNews.Visibility = System.Windows.Visibility.Visible;
            grid_BuyCarNews.Visibility = System.Windows.Visibility.Hidden;
        }
        //求购信息
        private void lab_BuyM_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lab_Look.Foreground = new SolidColorBrush(Colors.Black);
            lab_Check.Foreground = new SolidColorBrush(Colors.Black);
            lab_Closed.Foreground = new SolidColorBrush(Colors.Black);
            lab_BuyM.Foreground = new SolidColorBrush(Colors.White);

            grid_CheckNews.Visibility = System.Windows.Visibility.Hidden;
            grid_LookNews.Visibility = System.Windows.Visibility.Hidden;
            grid_CloseNews.Visibility = System.Windows.Visibility.Hidden;
            grid_BuyCarNews.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion

        #region 通讯录
        //添加联系人
        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            grid_AddBook.Visibility = System.Windows.Visibility.Visible;
            grid_AllBook.Visibility = System.Windows.Visibility.Hidden;
        }

        //联系人关闭
        private void AddBook_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_AddBook.Visibility = System.Windows.Visibility.Hidden;
            grid_Book.Visibility = System.Windows.Visibility.Visible;
        }
        

        private void Book_Add_Button(object sender, RoutedEventArgs e)
        {
            string book_name=Book_name.Text;
            string book_car_style = Book_Car_Style.SelectedValue.ToString();
            string book_phone = Book_Phone.Text;
            string book_memberid = Book_Memberid.Text;
            string book_qq=Book_QQ.Text;
            string book_content = Book_Content.Text;
        }

        #endregion


        #region POST模拟图片上传
        /// <summary>  
        /// 上传图片文件 
        /// </summary> 
        /// <param name="url">提交的地址</param> 
        /// <param name="poststr">发送的文本串   比如：user=eking&pass=123456  </param> 
        /// <param name="fileformname">文本域的名称  比如：name="file"，那么fileformname=file  </param> 
        /// <param name="filepath">上传的文件路径  比如： c:\12.jpg </param> 
        /// <param name="cookie">cookie数据</param> 
        /// <param name="refre">头部的跳转地址</param> 
        /// <returns></returns> 
        public static HttpWebResponse HttpUploadFile(string url, string filepath)
        {

            // 这个可以是改变的，也可以是下面这个固定的字符串 
            string boundary = "----WebKitFormBoundaryNHzwJQMlLcjJshnK";      //boundary，通过审查元素获取

            // 创建request对象 
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";
            webrequest.Headers.Add("Cookie:ASPSESSIONIDSCRTQCQT = MJNLPIDAALAHFAIADMLEPDCN "); 

            // 构造发送数据 
            StringBuilder sb = new StringBuilder();


            // 文件域的数据 
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"pic\";filename=\"" + filepath + "\"");//图片地址
            sb.Append("\r\n");

            sb.Append("Content-Type: ");
            sb.Append("image/jpeg");
            sb.Append("\r\n\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            //构造尾部数据 
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            // 输入头部数据 
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // 输入文件流数据 
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // 输入尾部数据 
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
        
            // 返回数据流(源码) 
            return webrequest.GetResponse() as HttpWebResponse;
        }
          #endregion
      
    }
}
