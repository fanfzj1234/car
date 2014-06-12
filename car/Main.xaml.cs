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
        public static string changed_Ckind;                  //定义全局变量，类型选择
        public static string changed_Cbrand;                  //定义全局变量，类型品牌
        public static string changed_Cseries;                  //定义全局变量，类型车系
        public static string changed_Ctype;                  //定义全局变量，类型型号
        public Main()
        {
            InitializeComponent();
            Account.Content = "账号："+MainWindow.var_memberid;
            lab_UserName.Content = MainWindow.var_memberid;
            Nickname.Content = "昵称:" + MainWindow.var_nickname;
            Grade.Content = "等级：" + MainWindow.var_vip;
            Sign_Name.Content = MainWindow.var_qm;
            Ctype.Visibility = System.Windows.Visibility.Hidden;
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
            string filename = txt_FileFront.Text;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            HttpWebResponse response = HttpWebResponseUtility.HttpUploadFile(uri, filename, HttpWebResponseUtility.web_cookie);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);
            MessageBox.Show((string)obj["message"] + "，图片路径：" + (string)obj["pic"]);

        }
       
        //获取身份证反面上传路径
        private void btn_SecletE_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.ShowDialog();
            txt_FileEnd.Text = ofg.FileName;

            string filename = txt_FileEnd.Text;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            HttpWebResponse response = HttpWebResponseUtility.HttpUploadFile(uri, filename,HttpWebResponseUtility.web_cookie);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);
            MessageBox.Show((string)obj["message"] + "，图片路径：" + (string)obj["pic"]);
            
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
        //选择菜单联动1
        private void Ckind_Changed(object sender, SelectionChangedEventArgs e)
        {
            changed_Ckind = Ckind.SelectedIndex.ToString();
            if (changed_Ckind != "0")
            {


                string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=1&cid=" + changed_Ckind;
            //MessageBox.Show(uri);


            HttpWebResponse response =HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string a = reader.ReadToEnd();
           

            JObject obj = JObject.Parse(a);
            JObject value = JObject.Parse(obj["datavalue"].ToString());
            //MessageBox.Show((string)obj[0]["pid"]);
            
            JArray jar = JArray.Parse(value["list"].ToString());
            Cbrand.Items.Clear();
            
            ComboBoxItem first = new ComboBoxItem();
            first.Content = "选择品牌";
            Cbrand.Items.Add(first);
            Cbrand.SelectedIndex=0; 
            for (var i = 0; i < jar.Count; i++)
            {
                JObject j = JObject.Parse(jar[i].ToString());
                //MessageBox.Show(j["pid"].ToString());
                //MessageBox.Show(j["pname"].ToString());
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = j["pname"].ToString();
                cbi.TabIndex =(int)j["pid"];
                Cbrand.Items.Add(cbi);
                //MessageBox.Show(j["ppy"].ToString());
            }
            }
        }
        //选择菜单联动2
        private void Cbrand_Changed(object sender, SelectionChangedEventArgs e)
        {
            changed_Cbrand = Cbrand.SelectedIndex.ToString();
            if (changed_Cbrand != "0")
            {


                string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=2&cid=" + changed_Cbrand;
                //MessageBox.Show(uri);


                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string a = reader.ReadToEnd();


                JObject obj = JObject.Parse(a);
                JObject value = JObject.Parse(obj["datavalue"].ToString());
                //MessageBox.Show((string)obj[0]["pid"]);

                JArray jar = JArray.Parse(value["list"].ToString());
                Cseries.Items.Clear();

                ComboBoxItem first = new ComboBoxItem();
                first.Content = "选择车系";
                Cseries.Items.Add(first);
                Cseries.SelectedIndex = 0;
                for (var i = 0; i < jar.Count; i++)
                {
                    JObject j = JObject.Parse(jar[i].ToString());
                    //MessageBox.Show(j["pid"].ToString());
                    //MessageBox.Show(j["pname"].ToString());
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = j["pname"].ToString();
                    cbi.TabIndex = (int)j["pid"];
                    Cseries.Items.Add(cbi);
                    //MessageBox.Show(j["ppy"].ToString());
                }
            }
        }
        //选择菜单联动3
        private void Cseries_Changed(object sender, SelectionChangedEventArgs e)
        {
            changed_Cseries = Cseries.SelectedIndex.ToString();
            if (changed_Cseries != "0")
            {


                string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=3&cid=" + changed_Cseries;
                //MessageBox.Show(uri);


                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string a = reader.ReadToEnd();


                JObject obj = JObject.Parse(a);
                JObject value = JObject.Parse(obj["datavalue"].ToString());
                //MessageBox.Show((string)obj[0]["pid"]);
                JArray jar = JArray.Parse(value["list"].ToString());
                if(jar.Count!=0)
                {   
                    Ctype.Items.Clear();
                    Ctype.Visibility = System.Windows.Visibility.Visible;
                    ComboBoxItem first = new ComboBoxItem();
                    first.Content = "选择车系";
                    Ctype.Items.Add(first);
                    Ctype.SelectedIndex = 0;
                    for (var i = 0; i < jar.Count; i++)
                    {
                        JObject j = JObject.Parse(jar[i].ToString());
                        //MessageBox.Show(j["pid"].ToString());
                        //MessageBox.Show(j["pname"].ToString());
                        ComboBoxItem cbi = new ComboBoxItem();
                        cbi.Content = j["pname"].ToString();
                        cbi.TabIndex = (int)j["pid"];
                        Ctype.Items.Add(cbi);
                        //MessageBox.Show(j["ppy"].ToString());
                    }
               }
                else
                {
                    Ctype.Items.Clear();
                    ComboBoxItem first = new ComboBoxItem();
                    first.TabIndex = 1;
                    Ctype.Items.Add(first);
                    Ctype.Visibility = System.Windows.Visibility.Hidden;
                }
            }
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

        

       


        
      
    }
}
