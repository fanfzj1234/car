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
        public static string changed_Ckind;                   //定义全局变量，类型选择
        public static int changed_Cbrand;                     //定义全局变量，品牌选择id
        public static int changed_Cseries;                    //定义全局变量，车系选择id
        public static int changed_Ctype;                      //定义全局变量，型号选择id
        public static string changed_Ckind_num;               //定义全局变量，类型pid
        public static string changed_Cbrand_num;              //定义全局变量，品牌pid
        public static string changed_Ctype_num;               //定义全局变量，型号pid
        public static string changed_Cseries_num;             //定义全局变量，车系pid
        public static JArray jar_Cbrand;
        public static JArray jar_Cseries;
        public static JArray jar_Ctype;
        public static string pic1;

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
        #region 下拉列表联动
        //选择菜单联动1
        private void Ckind_Changed(object sender, SelectionChangedEventArgs e)
        {
            changed_Ckind =Ckind.SelectedIndex.ToString();
            //Cbrand.Items.Add(new ValueObj { Text = "选择品牌", Value = "0" });
            //MessageBox.Show(changed_Ckind);
            if (changed_Ckind!= "0")
            {


                string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=1&cid=" + changed_Ckind;
            //MessageBox.Show(uri);


            HttpWebResponse response =HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string a = reader.ReadToEnd();
           

            JObject obj = JObject.Parse(a);
            JObject value = JObject.Parse(obj["datavalue"].ToString());
            //MessageBox.Show((string)obj[0]["pid"]);

            jar_Cbrand = JArray.Parse(value["list"].ToString());
            Cbrand.Items.Clear();
            ComboBoxItem cbrand = new ComboBoxItem();
            cbrand.Content = "选择品牌";
            Cbrand.Items.Add(cbrand);
            Cbrand.SelectedIndex=0;

            Cseries.Items.Clear();
            
            ComboBoxItem cseries = new ComboBoxItem();
            cseries.Content = "选择车系";
            Cseries.Items.Add(cseries);
            Cseries.SelectedIndex = 0;

            Ctype.Items.Clear();
            ComboBoxItem ctype = new ComboBoxItem();
            ctype.Content = "选择类型";
            ctype.TabIndex = 1;
            Ctype.Items.Add(ctype);
            Ctype.SelectedIndex = 0;
            Ctype.Visibility = System.Windows.Visibility.Hidden;

            for (var i = 0; i < jar_Cbrand.Count; i++)
            {
                JObject j_cbrand = JObject.Parse(jar_Cbrand[i].ToString());
                ComboBoxItem cbrand_com = new ComboBoxItem();
                cbrand_com.Content = j_cbrand["pname"];
                Cbrand.Items.Add(cbrand_com);
                //MessageBox.Show(j["ppy"].ToString());
            }
            }
        }
        //选择菜单联动2
        private void Cbrand_Changed(object sender, SelectionChangedEventArgs e)
        {  
            changed_Cbrand =(int)Cbrand.SelectedIndex;
            //MessageBox.Show(changed_Cbrand.ToString());
            if (changed_Cbrand > 0)
            {
                JObject cbrand = JObject.Parse(jar_Cbrand[changed_Cbrand - 1].ToString());
                changed_Cbrand_num = cbrand["pid"].ToString();
                //MessageBox.Show(changed_Cbrand_num);
                //MessageBox.Show(changed_Cbrand.Value);
                if (changed_Cbrand != 0)
                {
                    string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=2&cid=" + changed_Cbrand_num + "&did=" + Ckind.SelectedIndex.ToString();
                    //MessageBox.Show(uri);


                    HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string a = reader.ReadToEnd();


                    JObject obj = JObject.Parse(a);
                    JObject value = JObject.Parse(obj["datavalue"].ToString());
                    //MessageBox.Show((string)obj[0]["pid"]);
                    jar_Cseries = JArray.Parse(value["list"].ToString());
                    //MessageBox.Show(jar_Cseries.Count.ToString());
                    if (jar_Cseries.Count > 0)
                    {
                        //MessageBox.Show(jar_Cseries.Count.ToString());
                        Cseries.Items.Clear();
                        ComboBoxItem cseries = new ComboBoxItem();
                        cseries.Content = "选择车系";
                        Cseries.Items.Add(cseries);
                        Cseries.SelectedIndex = 0;

                        Ctype.Items.Clear();
                        ComboBoxItem ctype = new ComboBoxItem();
                        ctype.Content = "选择类型";
                        ctype.TabIndex = 1;
                        Ctype.Items.Add(ctype);
                        Ctype.SelectedIndex = 0;
                        Ctype.Visibility = System.Windows.Visibility.Hidden;

                        for (var i = 0; i < jar_Cseries.Count; i++)
                        {
                            JObject j_cseries = JObject.Parse(jar_Cseries[i].ToString());
                            ComboBoxItem cseries_com = new ComboBoxItem();
                            cseries_com.Content = j_cseries["pname"];
                            Cseries.Items.Add(cseries_com);

                            //MessageBox.Show(j["ppy"].ToString());
                        }
                    }
                
          
            else
            {
                Cseries.Items.Clear();
                ComboBoxItem cseries = new ComboBoxItem();
                cseries.Content = "暂无小类";
                Cseries.Items.Add(cseries);
                Cseries.SelectedIndex = 0;

                Ctype.Items.Clear();
                ComboBoxItem ctype = new ComboBoxItem();
                ctype.Content = "选择类型";
                ctype.TabIndex = 1;
                Ctype.Items.Add(ctype);
                Ctype.SelectedIndex = 0;
                Ctype.Visibility = System.Windows.Visibility.Hidden;
            }
                }
        }
          }
         //选择菜单联动3
        private void Cseries_Changed(object sender, SelectionChangedEventArgs e)
        {
            
            changed_Cseries =(int)Cseries.SelectedIndex;
            if (changed_Cseries > 0)
            {
                JObject cseries = JObject.Parse(jar_Cseries[changed_Cseries - 1].ToString());
                changed_Cseries_num = cseries["pid"].ToString();
                //MessageBox.Show(changed_Cseries_num);
                //MessageBox.Show(changed_Cseries);
                if (changed_Cseries != 0)
                {


                    string uri = "http://www.2sche.cn/zhushou/cartype_get.asp?id=3&cid=" + changed_Cseries_num;
                    //MessageBox.Show(uri);


                    HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(uri, null, null, HttpWebResponseUtility.web_cookie);
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string a = reader.ReadToEnd();


                    JObject obj = JObject.Parse(a);
                    JObject value = JObject.Parse(obj["datavalue"].ToString());
                    //MessageBox.Show((string)obj[0]["pid"]);
                    Ctype.Items.Clear();
                    jar_Ctype = JArray.Parse(value["list"].ToString());
                    
                    if (jar_Ctype.Count != 0)
                    {
                        Ctype.Items.Clear();
                        Ctype.Visibility = System.Windows.Visibility.Visible;

                        //Ctype.Items.Add(new ValueObj { Text = "选择类型", Value = "0" });
                        ComboBoxItem ctype = new ComboBoxItem();
                        ctype.Content = "选择类型";
                        ctype.TabIndex = 1;
                        Ctype.Items.Add(ctype);
                        Ctype.SelectedIndex = 0;

                        for (var i = 0; i < jar_Ctype.Count; i++)
                        {
                            JObject j_ctype = JObject.Parse(jar_Ctype[i].ToString());
                            ComboBoxItem ctype_com = new ComboBoxItem();
                            ctype_com.Content = j_ctype["pname"];
                            Ctype.Items.Add(ctype_com);

                        }

                    }
                    else
                    {
                        Ctype.Items.Clear();
                        ComboBoxItem first = new ComboBoxItem();
                        first.TabIndex = 1;
                        first.Content = 0;
                        Ctype.Items.Add(first);
                        Ctype.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
            }
        }
        #endregion

        //信息提交

        private void SellCar_Click(object sender, ContextMenuEventArgs e)
        {
            string sheng = Province.SelectedValue.ToString();       //获取地区
            string shi = City.SelectedValue.ToString();              //获取城市
            //获取用户选择的型号
            changed_Ctype=(int)Ctype.SelectedIndex;
            JObject ctype = JObject.Parse(jar_Ctype[changed_Ctype - 1].ToString());
            string xinghao = ctype["pname"].ToString();
            //获取用户选择的车系 
            changed_Cseries = (int)Cseries.SelectedIndex;
            JObject cseries = JObject.Parse(jar_Cseries[changed_Cseries - 1].ToString());
            string chexi= cseries["pname"].ToString();
            //获取用户选择的品牌
            changed_Cbrand = (int)Cbrand.SelectedIndex;
            JObject cbrand = JObject.Parse(jar_Cbrand[changed_Cseries - 1].ToString());
            string pinpai = cbrand["pname"].ToString();
            //获取选择的类别
            string lb = Ckind.SelectedIndex.ToString();    

            //信息类型选择
            string lx;
            if (Cperson.IsChecked==true)
            {
                lx = Cperson.Content.ToString();
            }
            else if (Ccompany.IsChecked == true)
            {
                lx = Ccompany.Content.ToString();
            }

            
            string wbao = Cprice.Text.ToString();                      //获取外网报价
            string nbao = "0";                                         //设置内网报价
            string shangpai = Ctime.SelectedDate.ToString();           //获取上牌时间
            string gongli = Ckilometre.Text.ToString();                //获取里程数
            string yanse = Ccolor.SelectedValue.ToString();             //获取选择第几个颜色
            string shigu = Caccident.SelectedValue.ToString();         //获取是否是事故车
            string pailiang = CPL.Text.ToString();                     //获取排放量
            string ranyou = CRY.SelectedValue.ToString();              //获取燃油系统类型


            //性质选择
            string peizhi;
            if (CLP.IsChecked == true)
            {
                peizhi = Cperson.Content.ToString();
            }
            else if (CMP.IsChecked == true)
            {
                peizhi = CMP.Content.ToString();
            }
            else if (CHP.IsChecked == true)
            {
                peizhi = CHP.Content.ToString();
            }
            
            string goohu = Csx.SelectedValue.ToString();               //获取是否过户
            string xingzhi = Cxz.SelectedValue.ToString();             //获取使用性质
            string jianche = Cjc.SelectedDate.ToString();              //获取检车到期时间
            string baoxian = Cbx.SelectedDate.ToString();              //获取保险到期时间
            string lianxiren = Clxr.Text.ToString();                   //获取联系人
            string wtel = CPhone.Text.ToString();                      //获取联系电话
            string qq = CQQ.Text.ToString();                           //获取联系人qq
            string wshuoming = Cxx.Text.ToString();                    //获取详细信息
            string bpeizhi="";                                        //获取标准配置选择
            if(dzwd.IsChecked==true)
            {
                bpeizhi += dzwd.Content+";,";
            }
			if(dzwd.IsChecked==false)
            {
                bpeizhi +=",";
            }
            if(tphj.IsChecked==true)
			{
			    bpeizhi += tphj.Content+";,";
			}
			if(tphj.IsChecked==false)
            {
                bpeizhi +=",";
            }
			 if(ddzy.IsChecked==true)
            {
                bpeizhi += ddzy.Content+";,";
            }
			if(ddzy.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(cqnx.IsChecked==true)
            {
                bpeizhi += cqnx.Content+";,";
            }
			if(cqnx.IsChecked==false)
            {
                bpeizhi +=",";
            }
            if(dcld.IsChecked==true)
			{
			    bpeizhi += dcld.Content+";,";
			}
			if(dcld.IsChecked==false)
            {
                bpeizhi +=",";
            }
			 if(czdh.IsChecked==true)
            {
                bpeizhi += czdh.Content+";,";
            }
			if(czdh.IsChecked==false)
            {
                bpeizhi +=",";
            }
             if(zyjr.IsChecked==true)
            {
                bpeizhi += zyjr.Content+";,";
            }
			if(zyjr.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(hzcf.IsChecked==true)
            {
                bpeizhi += hzcf.Content+";,";
            }
			if(hzcf.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(zdkt.IsChecked==true)
            {
                bpeizhi += zdkt.Content+";,";
            }
			if(zdkt.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(zddd.IsChecked==true)
            {
                bpeizhi += zddd.Content+";,";
            }
			if(zddd.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(dzss.IsChecked==true)
            {
                bpeizhi += dzss.Content+";,";
            }
			if(dzss.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(zdbs.IsChecked==true)
            {
                bpeizhi += zdbs.Content+";,";
            }
			if(zdbs.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(sdd.IsChecked==true)
            {
                bpeizhi += sdd.Content+";,";
            }
			if(sdd.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(zpzy.IsChecked==true)
            {
                bpeizhi += zpzy.Content+";,";
            }
			if(zpzy.IsChecked==false)
            {
                bpeizhi +=",";
            }
			if(sqdd.IsChecked==true)
            {
                bpeizhi += sqdd.Content+";,";
            }
			if(sqdd.IsChecked==false)
            {
                bpeizhi +=",";
            }
            string neifabu="";
            string yuanli="";
            string chuchang="";
            string cishu=="";
            string paifang="";
            string nshuoming="";
            string weixiu="";
            string ntel="";
            string chepai="";
			string pic2="";
			string tongbu="";
        }
        private void Upload_Img1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.ShowDialog();
            string filename = ofg.FileName;
            string uri = "http://www.2sche.cn/zhushou/uploadpic.asp";

            HttpWebResponse response = HttpWebResponseUtility.HttpUploadFile(uri, filename, HttpWebResponseUtility.web_cookie);
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);
            MessageBox.Show((string)obj["message"] + "，图片路径：" + (string)obj["pic"]);
            pic1 = (string)obj["pic"];
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
