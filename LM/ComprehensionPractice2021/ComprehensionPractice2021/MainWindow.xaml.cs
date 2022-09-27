using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComprehensionPractice2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(changeBtn.Content) != "🗗")
            {
                Rect rect = SystemParameters.WorkArea;
                Left = 0;
                this.Top = 0;
                this.Width = rect.Width;
                this.Height = rect.Height;
                changeBtn.Content = "🗗";
            }
            else if (Convert.ToString(changeBtn.Content) != "🗖")
            {
                this.Width = 900;
                this.Height = 450;
                changeBtn.Content = "🗖";
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void closeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            closeBtn.Background = System.Windows.Media.Brushes.IndianRed;
        }
        private void closeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            closeBtn.Background = System.Windows.Media.Brushes.Transparent;
        }
        private void minBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            minBtn.Background = System.Windows.Media.Brushes.SandyBrown;
        }
        private void minBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            minBtn.Background = System.Windows.Media.Brushes.Transparent;
        }
        private void changeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            changeBtn.Background = System.Windows.Media.Brushes.SandyBrown;
        }
        private void changeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            changeBtn.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)//注销
        {                    
            if (LoginTbk.Text == "游客")
            {
                CleanAll();
                HiddenAll();
                Login_Id_Lab.Visibility = Visibility.Visible;
                Login_Id_Tbx.Visibility = Visibility.Visible;
                Login_Id_Udl.Visibility = Visibility.Visible;
                Login_Pwd_Lab.Visibility = Visibility.Visible;
                Login_Pwd_Udl.Visibility = Visibility.Visible;
                Login_Pwd_Pwbx.Visibility = Visibility.Visible;
                Login_Det_Btn.Visibility = Visibility.Visible;
            }
            else
            {
                if (MessageBox.Show("您确定要退出或更换其他账号登录吗？", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    LoginTbk.Text = "游客";
                    Borrow.Visibility = Visibility.Hidden;
                    Borrow_Bor.Visibility = Visibility.Hidden;
                    Borrow_Han.Visibility = Visibility.Hidden;
                    Borrow_Ret.Visibility = Visibility.Hidden;
                    Books.Visibility = Visibility.Hidden;
                    Books_Add.Visibility = Visibility.Hidden;
                    Books_Del.Visibility = Visibility.Hidden;
                    Books_Rev.Visibility = Visibility.Hidden;
                    User.Visibility = Visibility.Hidden;
                    User_Add.Visibility = Visibility.Hidden;
                    User_Que.Visibility = Visibility.Hidden;
                    Account.Visibility = Visibility.Hidden;
                    CleanAll();
                    FirstPage_Click(sender, e);

                }
            }
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            Storyboard story = (Storyboard)this.FindResource("Borrow");
            story.Begin(this);
        }
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Storyboard story = (Storyboard)this.FindResource("Books");
            story.Begin(this);
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            Storyboard story = (Storyboard)this.FindResource("User");
            story.Begin(this);
        }

        private void CleanAll()
        {
            Query_Tittle_Tbx.Text = "";
            Query_Author_Tbx.Text = "";
            Query_Publisher_Tbx.Text = "";
            Query_ISBN_Tbx.Text = "";
            Borrow_Bor_ID_Tbx.Text = "";
            Borrow_Bor_ISBN_Tbx.Text = "";
            Borrow_Bor_Message_RTbx.Document.Blocks.Clear();
            Borrow_Bor_Name_Tbx.Text = "";
            Borrow_Ret_ID_Tbx.Text = "";
            Borrow_Han_ID_Tbx.Text = "";
            Borrow_Han_Name_Tbx.Text = "";
            Books_Add_Author_Tbx.Text = "";
            Books_Add_Stock_Tbx.Text = "";
            Books_Add_Isbn_Tbx.Text = "";
            Books_Add_Location_Tbx.Text = "";
            Books_Add_Price_Tbx.Text = "";
            Books_Add_Publisher_Tbx.Text = "";
            Books_Add_Tattle_Tbx.Text = "";
            Books_Add_Year_Tbx.Text = "";
            Books_Dev_Isbn_Tbx.Text = "";
            Books_Dev_Tattle_Tbx.Text = "";
            Books_Dev_Author_Tbx.Text = "";
            Books_Dev_Publisher_Tbx.Text = "";
            Books_Dev_Stock_Tbx.Text = "";
            Books_Dev_Year_Tbx.Text = "";
            Books_Dev_Price_Tbx.Text = "";
            Books_Dev_Location_Tbx.Text = "";
            Books_Del_Search_Tbx.Text = "";
            Books_Del_ISBN_Rbtn.IsChecked = true;
            User_Add_Id_Tbx.Text = "";
            User_Add_Name_Tbx.Text = "";
            User_Add_Jur_Staff_Rbtn.IsChecked = true;
            Account_Mes_Id_Tbx.Text = "";
            Account_Mes_Jur_Tbx.Text = "";
            Account_Mes_Name_Tbx.Text = "";
            //Account_ChangePassword_Old_Tbx.Text = "请输入原密码";
            //Account_ChangePassword_Old_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            //Account_ChangePassword_New1_Tbx.Text = "请输入新密码";
            //Account_ChangePassword_New1_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            //Account_ChangePassword_New2_Tbx.Text = "请再次输入新密码";
            //Account_ChangePassword_New2_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            Query_Tittle_Tbx.Text = "";
            Query_Author_Tbx.Text = "";
            Query_Publisher_Tbx.Text = "";
            Query_ISBN_Tbx.Text = "";
            Login_Id_Tbx.Text = "";
            Login_Pwd_Pwbx.Password = "";
        }

        private void HiddenAll()
        {
            HomePage.Visibility = Visibility.Hidden;
            Query_Tittle_Lab.Visibility = Visibility.Hidden;
            Query_Tittle_Tbx.Visibility = Visibility.Hidden;
            Query_Tittle_Udl.Visibility = Visibility.Hidden;
            Query_Author_Lab.Visibility = Visibility.Hidden;
            Query_Author_Tbx.Visibility = Visibility.Hidden;
            Query_Author_Udl.Visibility = Visibility.Hidden;
            Query_Publisher_Lab.Visibility = Visibility.Hidden;
            Query_Publisher_Tbx.Visibility = Visibility.Hidden;
            Query_Publisher_Udl.Visibility = Visibility.Hidden;
            Query_ISBN_Lab.Visibility = Visibility.Hidden;
            Query_ISBN_Tbx.Visibility = Visibility.Hidden;
            Query_ISBN_Udl.Visibility = Visibility.Hidden;
            Query_Query_Btn.Visibility = Visibility.Hidden;
            Query_Show_Dtg.Visibility = Visibility.Hidden;
            Borrow_Bor_ID_Lab.Visibility = Visibility.Hidden;
            Borrow_Bor_ID_Tbx.Visibility = Visibility.Hidden;
            Borrow_Bor_ID_Udl.Visibility = Visibility.Hidden;
            Borrow_Bor_ISBN_Lab.Visibility = Visibility.Hidden;
            Borrow_Bor_ISBN_Tbx.Visibility = Visibility.Hidden;
            Borrow_Bor_ISBN_Udl.Visibility = Visibility.Hidden;
            Borrow_Bor_Message_Lab.Visibility = Visibility.Hidden;
            Borrow_Bor_Message_RTbx.Visibility = Visibility.Hidden;
            Borrow_Bor_Name_Lab.Visibility = Visibility.Hidden;
            Borrow_Bor_Name_Tbx.Visibility = Visibility.Hidden;
            Borrow_Bor_Name_Udl.Visibility = Visibility.Hidden;
            Borrow_Bor_Det_Btn.Visibility = Visibility.Hidden;
            Borrow_Bor_Can_Btn.Visibility = Visibility.Hidden;
            Borrow_Ret_ID_Lab.Visibility = Visibility.Hidden;
            Borrow_Ret_ID_Tbx.Visibility = Visibility.Hidden;
            Borrow_Ret_ID_Udl.Visibility = Visibility.Hidden;
            Borrow_Ret_Query_Btn.Visibility = Visibility.Hidden;
            Borrow_Ret_Message_Dtg.Visibility = Visibility.Hidden;
            Borrow_Han_ID_Lab.Visibility = Visibility.Hidden;
            Borrow_Han_ID_Tbx.Visibility = Visibility.Hidden;
            Borrow_Han_ID_Udl.Visibility = Visibility.Hidden;
            Borrow_Han_Name_Lab.Visibility = Visibility.Hidden;
            Borrow_Han_Name_Tbx.Visibility = Visibility.Hidden;
            Borrow_Han_Name_Udl.Visibility = Visibility.Hidden;
            Borrow_Han_Can_Btn.Visibility = Visibility.Hidden;
            Borrow_Han_Det_Btn.Visibility = Visibility.Hidden;
            Borrow_Han_Import_Tbk.Visibility = Visibility.Hidden;
            Books_Add_Author_Lab.Visibility = Visibility.Hidden;
            Books_Add_Author_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Author_Udl.Visibility = Visibility.Hidden;
            Books_Add_Can_Btn.Visibility = Visibility.Hidden;
            Books_Add_Det_Btn.Visibility = Visibility.Hidden;
            Books_Add_Import_Tbk.Visibility = Visibility.Hidden;
            Books_Add_Isbn_Lab.Visibility = Visibility.Hidden;
            Books_Add_Isbn_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Isbn_Udl.Visibility = Visibility.Hidden;
            Books_Add_Location_Lab.Visibility = Visibility.Hidden;
            Books_Add_Location_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Location_Udl.Visibility = Visibility.Hidden;
            Books_Add_Price_Lab.Visibility = Visibility.Hidden;
            Books_Add_Price_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Price_Udl.Visibility = Visibility.Hidden;
            Books_Add_Publisher_Lab.Visibility = Visibility.Hidden;
            Books_Add_Publisher_Udl.Visibility = Visibility.Hidden;
            Books_Add_Publisher_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Stock_Lab.Visibility = Visibility.Hidden;
            Books_Add_Stock_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Stock_Udl.Visibility = Visibility.Hidden;
            Books_Add_Tattle_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Tattle_Udl.Visibility = Visibility.Hidden;
            Books_Add_Tittle_Lab.Visibility = Visibility.Hidden;
            Books_Add_Year_Lab.Visibility = Visibility.Hidden;
            Books_Add_Year_Tbx.Visibility = Visibility.Hidden;
            Books_Add_Year_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Author_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Author_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Author_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Can_Btn.Visibility = Visibility.Hidden;
            Books_Dev_Det_Btn.Visibility = Visibility.Hidden;
            Books_Dev_Isbn_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Isbn_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Isbn_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Location_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Location_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Location_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Price_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Price_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Price_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Publisher_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Publisher_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Publisher_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Stock_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Stock_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Stock_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Tattle_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Tattle_Udl.Visibility = Visibility.Hidden;
            Books_Dev_Tittle_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Year_Lab.Visibility = Visibility.Hidden;
            Books_Dev_Year_Tbx.Visibility = Visibility.Hidden;
            Books_Dev_Year_Udl.Visibility = Visibility.Hidden;
            Books_Del_Search_Lab.Visibility = Visibility.Hidden;
            Books_Del_Search_Tbx.Visibility = Visibility.Hidden;
            Books_Del_Search_Udl.Visibility = Visibility.Hidden;
            Books_Del_ISBN_Rbtn.Visibility = Visibility.Hidden;
            Books_Del_Tittle_Rbtn.Visibility = Visibility.Hidden;
            Books_Del_Author_Rbtn.Visibility = Visibility.Hidden;
            Books_Del_Det_Btn.Visibility = Visibility.Hidden;
            Books_Del_Message_Dtg.Visibility = Visibility.Hidden;
            User_Add_Id_Lab.Visibility = Visibility.Hidden;
            User_Add_Id_Tbx.Visibility = Visibility.Hidden;
            User_Add_Id_Udl.Visibility = Visibility.Hidden;
            User_Add_Name_Lab.Visibility = Visibility.Hidden;
            User_Add_Name_Tbx.Visibility = Visibility.Hidden;
            User_Add_Name_Udl.Visibility = Visibility.Hidden;
            User_Add_Jur_Lab.Visibility = Visibility.Hidden;
            User_Add_Jur_Staff_Rbtn.Visibility = Visibility.Hidden;
            User_Add_Jur_Admin_Rbtn.Visibility = Visibility.Hidden;
            User_Add_Can_Btn.Visibility = Visibility.Hidden;
            User_Add_Det_Btn.Visibility = Visibility.Hidden;
            User_Que_Search_Lab.Visibility = Visibility.Hidden;
            User_Que_Search_Tbx.Visibility = Visibility.Hidden;
            User_Que_Search_Udl.Visibility = Visibility.Hidden;
            User_Que_Name_Rbtn.Visibility = Visibility.Hidden;
            User_Que_Id_Rbtn.Visibility = Visibility.Hidden;
            User_Que_Det_Btn.Visibility = Visibility.Hidden;
            User_Que_Message_Dtg.Visibility = Visibility.Hidden;
            Account_Mes_Id_Lab.Visibility = Visibility.Hidden;
            Account_Mes_Id_Tbx.Visibility = Visibility.Hidden;
            Account_Mes_Id_Udl.Visibility = Visibility.Hidden;
            Account_Mes_Jur_Lab.Visibility = Visibility.Hidden;
            Account_Mes_Jur_Tbx.Visibility = Visibility.Hidden;
            Account_Mes_Jur_Udl.Visibility = Visibility.Hidden;
            Account_Mes_Name_Lab.Visibility = Visibility.Hidden;
            Account_Mes_Name_Tbx.Visibility = Visibility.Hidden;
            Account_Mes_Name_Udl.Visibility = Visibility.Hidden;
            Account_ChangePassword_Tbk.Visibility = Visibility.Hidden;
            Account_ChangePassword_Can_Btn.Visibility = Visibility.Hidden;
            Account_ChangePassword_Det_Btn.Visibility = Visibility.Hidden;
            Account_ChangePassword_New1_Lab.Visibility = Visibility.Hidden;
            Account_ChangePassword_New1_Tbx.Visibility = Visibility.Hidden;
            Account_ChangePassword_New1_Udl.Visibility = Visibility.Hidden;           
            Account_ChangePassword_Old_Lab.Visibility = Visibility.Hidden;
            Account_ChangePassword_Old_Tbx.Visibility = Visibility.Hidden;
            Account_ChangePassword_Old_Udl.Visibility = Visibility.Hidden;
            Account_ChangePassword_Tips1_Lab.Visibility = Visibility.Hidden;
            Account_ChangePassword_Tips2_Lab.Visibility = Visibility.Hidden;
            Login_Id_Lab.Visibility = Visibility.Hidden;
            Login_Id_Tbx.Visibility = Visibility.Hidden;
            Login_Id_Udl.Visibility = Visibility.Hidden;
            Login_Pwd_Lab.Visibility = Visibility.Hidden;
            Login_Pwd_Udl.Visibility = Visibility.Hidden;
            Login_Pwd_Pwbx.Visibility = Visibility.Hidden;
            Login_Det_Btn.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            CleanAll();
            HomePage.Visibility = Visibility.Visible;
            Borrow.Visibility = Visibility.Hidden;
            Books.Visibility = Visibility.Hidden;
            User.Visibility = Visibility.Hidden;
            Account.Visibility = Visibility.Hidden;
            Storyboard story = (Storyboard)this.FindResource("PutAway");
            story.Begin(this);


            //Style style = this.Resources["TxtPwd"] as Style;
            //Style newStyle = new Style(typeof(TextBox)) { BasedOn = style };
            //_123.Style = newStyle;
            //Account_ChangePassword_New1_Tbx.Style = newStyle;
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            HomePage.Visibility = Visibility.Visible;
            Storyboard story = (Storyboard)this.FindResource("PutAway");
            story.Begin(this);
        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Query_Tittle_Lab.Visibility = Visibility.Visible;
            Query_Tittle_Tbx.Visibility = Visibility.Visible;
            Query_Tittle_Udl.Visibility = Visibility.Visible;
            Query_Author_Lab.Visibility = Visibility.Visible;
            Query_Author_Tbx.Visibility = Visibility.Visible;
            Query_Author_Udl.Visibility = Visibility.Visible;
            Query_Publisher_Lab.Visibility = Visibility.Visible;
            Query_Publisher_Tbx.Visibility = Visibility.Visible;
            Query_Publisher_Udl.Visibility = Visibility.Visible;
            Query_ISBN_Lab.Visibility = Visibility.Visible;
            Query_ISBN_Tbx.Visibility = Visibility.Visible;
            Query_ISBN_Udl.Visibility = Visibility.Visible;
            Query_Query_Btn.Visibility = Visibility.Visible;
            Query_Show_Dtg.Visibility = Visibility.Visible;
            CleanAll();
            Storyboard story = (Storyboard)this.FindResource("PutAway");
            story.Begin(this);
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            string sql = @"Select ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置 from Books";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            da.Fill(ds, "Staff");
            DataView dv = new DataView(ds.Tables["Staff"]);
            Query_Show_Dtg.ItemsSource = dv;
        }

        private void Query_Query_Btn_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            string sql = String.Format("select * from [Books] where 书名 like '%{0}%' and 作者 like '%{1}%' and 出版社 like '%{2}%' and ISBN like '%{3}%'", 
                Query_Tittle_Tbx.Text, Query_Author_Tbx.Text, Query_Publisher_Tbx.Text, Query_ISBN_Tbx.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            da.Fill(ds, "Staff");
            DataView dv = new DataView(ds.Tables["Staff"]);
            Query_Show_Dtg.ItemsSource = dv;
        }

        private void Borrow_Bor_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Borrow_Bor_ID_Lab.Visibility = Visibility.Visible;
                Borrow_Bor_ID_Tbx.Visibility = Visibility.Visible;
                Borrow_Bor_ID_Udl.Visibility = Visibility.Visible;
                Borrow_Bor_ISBN_Lab.Visibility = Visibility.Visible;
                Borrow_Bor_ISBN_Tbx.Visibility = Visibility.Visible;
                Borrow_Bor_ISBN_Udl.Visibility = Visibility.Visible;
                Borrow_Bor_Message_Lab.Visibility = Visibility.Visible;
                Borrow_Bor_Message_RTbx.Visibility = Visibility.Visible;
                Borrow_Bor_Name_Lab.Visibility = Visibility.Visible;
                Borrow_Bor_Name_Tbx.Visibility = Visibility.Visible;
                Borrow_Bor_Name_Udl.Visibility = Visibility.Visible;
                Borrow_Bor_Det_Btn.Visibility = Visibility.Visible;
                Borrow_Bor_Can_Btn.Visibility = Visibility.Visible;
            }
        }

        private void Borrow_Ret_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Borrow_Ret_ID_Lab.Visibility = Visibility.Visible;
                Borrow_Ret_ID_Tbx.Visibility = Visibility.Visible;
                Borrow_Ret_ID_Udl.Visibility = Visibility.Visible;
                Borrow_Ret_Query_Btn.Visibility = Visibility.Visible;
                Borrow_Ret_Message_Dtg.Visibility = Visibility.Visible;
            }         
        }

        private void Borrow_Han_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Borrow_Han_ID_Lab.Visibility = Visibility.Visible;
                Borrow_Han_ID_Tbx.Visibility = Visibility.Visible;
                Borrow_Han_ID_Udl.Visibility = Visibility.Visible;
                Borrow_Han_Name_Lab.Visibility = Visibility.Visible;
                Borrow_Han_Name_Tbx.Visibility = Visibility.Visible;
                Borrow_Han_Name_Udl.Visibility = Visibility.Visible;
                Borrow_Han_Can_Btn.Visibility = Visibility.Visible;
                Borrow_Han_Det_Btn.Visibility = Visibility.Visible;
                Borrow_Han_Import_Tbk.Visibility = Visibility.Visible;
            }        
        }

        private void Books_Add_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Books_Add_Author_Lab.Visibility = Visibility.Visible;
                Books_Add_Author_Tbx.Visibility = Visibility.Visible;
                Books_Add_Author_Udl.Visibility = Visibility.Visible;
                Books_Add_Can_Btn.Visibility = Visibility.Visible;
                Books_Add_Det_Btn.Visibility = Visibility.Visible;
                Books_Add_Import_Tbk.Visibility = Visibility.Visible;
                Books_Add_Isbn_Lab.Visibility = Visibility.Visible;
                Books_Add_Isbn_Tbx.Visibility = Visibility.Visible;
                Books_Add_Isbn_Udl.Visibility = Visibility.Visible;
                Books_Add_Location_Lab.Visibility = Visibility.Visible;
                Books_Add_Location_Tbx.Visibility = Visibility.Visible;
                Books_Add_Location_Udl.Visibility = Visibility.Visible;
                Books_Add_Price_Lab.Visibility = Visibility.Visible;
                Books_Add_Price_Tbx.Visibility = Visibility.Visible;
                Books_Add_Price_Udl.Visibility = Visibility.Visible;
                Books_Add_Publisher_Lab.Visibility = Visibility.Visible;
                Books_Add_Publisher_Udl.Visibility = Visibility.Visible;
                Books_Add_Publisher_Tbx.Visibility = Visibility.Visible;
                Books_Add_Stock_Lab.Visibility = Visibility.Visible;
                Books_Add_Stock_Tbx.Visibility = Visibility.Visible;
                Books_Add_Stock_Udl.Visibility = Visibility.Visible;
                Books_Add_Tattle_Tbx.Visibility = Visibility.Visible;
                Books_Add_Tattle_Udl.Visibility = Visibility.Visible;
                Books_Add_Tittle_Lab.Visibility = Visibility.Visible;
                Books_Add_Year_Lab.Visibility = Visibility.Visible;
                Books_Add_Year_Tbx.Visibility = Visibility.Visible;
                Books_Add_Year_Udl.Visibility = Visibility.Visible;
            }          
        }

        private void Books_Rev_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Books_Dev_Author_Lab.Visibility = Visibility.Visible;
                Books_Dev_Author_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Author_Udl.Visibility = Visibility.Visible;
                Books_Dev_Can_Btn.Visibility = Visibility.Visible;
                Books_Dev_Det_Btn.Visibility = Visibility.Visible;
                Books_Dev_Isbn_Lab.Visibility = Visibility.Visible;
                Books_Dev_Isbn_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Isbn_Udl.Visibility = Visibility.Visible;
                Books_Dev_Location_Lab.Visibility = Visibility.Visible;
                Books_Dev_Location_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Location_Udl.Visibility = Visibility.Visible;
                Books_Dev_Price_Lab.Visibility = Visibility.Visible;
                Books_Dev_Price_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Price_Udl.Visibility = Visibility.Visible;
                Books_Dev_Publisher_Lab.Visibility = Visibility.Visible;
                Books_Dev_Publisher_Udl.Visibility = Visibility.Visible;
                Books_Dev_Publisher_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Stock_Lab.Visibility = Visibility.Visible;
                Books_Dev_Stock_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Stock_Udl.Visibility = Visibility.Visible;
                Books_Dev_Tattle_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Tattle_Udl.Visibility = Visibility.Visible;
                Books_Dev_Tittle_Lab.Visibility = Visibility.Visible;
                Books_Dev_Year_Lab.Visibility = Visibility.Visible;
                Books_Dev_Year_Tbx.Visibility = Visibility.Visible;
                Books_Dev_Year_Udl.Visibility = Visibility.Visible;
            }

        }

        private void Books_Del_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            {
                Books_Del_Search_Lab.Visibility = Visibility.Visible;
                Books_Del_Search_Tbx.Visibility = Visibility.Visible;
                Books_Del_Search_Udl.Visibility = Visibility.Visible;
                Books_Del_ISBN_Rbtn.Visibility = Visibility.Visible;
                Books_Del_Tittle_Rbtn.Visibility = Visibility.Visible;
                Books_Del_Author_Rbtn.Visibility = Visibility.Visible;
                Books_Del_Det_Btn.Visibility = Visibility.Visible;
                Books_Del_Message_Dtg.Visibility = Visibility.Visible;
            }          
            CleanAll();
            Books_Del_ISBN_Rbtn.IsChecked = true;
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);  
            string sql = @"Select ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置 from Books";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            da.Fill(ds, "Staff");
            DataView dv = new DataView(ds.Tables["Staff"]);
            Books_Del_Message_Dtg.ItemsSource = dv;
        }

        private void Books_Add_Import_Tbk_MouseDown(object sender, MouseButtonEventArgs e)//DDDD
        {       
            OpenFileDialog a = new OpenFileDialog(); //new一个方法
            a.Filter = "Excel文档|*.xlsx;"; ; //删选、设定文件显示类型
            a.ShowDialog(); //显示打开文件的窗口
            string fileName = a.FileName; //获得选择的文件路径

            //读取文件内容，并保存在DataTable中
            IWorkbook workbook = null;  //新建IWorkbook对象  
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) 
            {
                workbook = new XSSFWorkbook(fileStream);  //xls数据读入workbook  
            }
            ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表 
            IRow row;

            //datatable数据表
            DataTable dt1 = new DataTable();
            //创建七个纵列
            dt1.Columns.Add("ISBN", typeof(System.String));
            dt1.Columns.Add("书名", typeof(System.String));
            dt1.Columns.Add("作者", typeof(System.String));
            dt1.Columns.Add("出版社", typeof(System.String));
            dt1.Columns.Add("库存", typeof(System.String));
            dt1.Columns.Add("出版年份", typeof(System.String));
            dt1.Columns.Add("图书单价", typeof(System.String));
            dt1.Columns.Add("图书位置", typeof(System.String));

            for (int i = 1; i < sheet.LastRowNum + 1; i++)  //对工作表每一行  
            {
                DataRow dr1 = dt1.NewRow();//新建行
                row = sheet.GetRow(i);   //row读入第i行数据  
                if (row != null)
                {
                    dr1["ISBN"] = row.GetCell(0).ToString().Trim(); //获取i行j列数据 
                    dr1["书名"] = row.GetCell(1).ToString().Trim(); //获取i行j列数据 
                    dr1["作者"] = row.GetCell(2).ToString().Trim(); //获取i行j列数据 
                    dr1["出版社"] = row.GetCell(3).ToString().Trim(); //获取i行j列数据                     
                    dr1["库存"] = row.GetCell(4).ToString().Trim(); //获取i行j列数据 
                    dr1["出版年份"] = row.GetCell(5).ToString().Trim(); //获取i行j列数据  
                    dr1["图书单价"] = row.GetCell(6).ToString().Trim(); //获取i行j列数据   
                    dr1["图书位置"] = row.GetCell(7).ToString().Trim(); //获取i行j列数据   
                    
                }
                dt1.Rows.Add(dr1);//将行加入数据表dt1
            }
            fileStream.Close();
            workbook.Close();



            //连接数据库并去重
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            //using SqlConnection conn = new SqlConnection("Data Source = (local);Initial Catalog = Library1;Integrated Security=True");
            connection.Open();
            //若与数据库成员重合，则在此删除dt中重合行，下面再进行插入操作
            SqlCommand cmd = new SqlCommand("select * from [Books]", connection);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (sdr.GetString(0).ToString().Trim() == dt1.Rows[i][0].ToString())
                    {
                        dt1.Rows[i].Delete();
                    }
                }
            }
            sdr.Close();
            //插入数据库



            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
              
                try
                {
                    bulkCopy.DestinationTableName = "Books";//要插入的表的表名
                    bulkCopy.BatchSize = dt1.Rows.Count;
                    bulkCopy.ColumnMappings.Add("ISBN", "ISBN");//表中的字段名 第一个“id”是dt中的字段名，第二个“id”表中的字段名
                    bulkCopy.ColumnMappings.Add("书名", "书名");
                    bulkCopy.ColumnMappings.Add("作者", "作者");
                    bulkCopy.ColumnMappings.Add("出版社", "出版社");
                    bulkCopy.ColumnMappings.Add("库存", "库存");
                    bulkCopy.ColumnMappings.Add("出版年份", "出版年份");
                    bulkCopy.ColumnMappings.Add("图书单价", "图书单价");
                    bulkCopy.ColumnMappings.Add("图书位置", "图书位置");
                    bulkCopy.WriteToServer(dt1);
                    MessageBox.Show("录入成功！共录入" + dt1.Rows.Count + "条数据", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
            connection.Dispose();
        }

        private void User_Add_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            User_Add_Id_Lab.Visibility = Visibility.Visible;
            User_Add_Id_Tbx.Visibility = Visibility.Visible;
            User_Add_Id_Udl.Visibility = Visibility.Visible;
            User_Add_Name_Lab.Visibility = Visibility.Visible;
            User_Add_Name_Tbx.Visibility = Visibility.Visible;
            User_Add_Name_Udl.Visibility = Visibility.Visible;
            User_Add_Jur_Lab.Visibility = Visibility.Visible;
            User_Add_Jur_Staff_Rbtn.Visibility = Visibility.Visible;
            User_Add_Jur_Admin_Rbtn.Visibility = Visibility.Visible;
            User_Add_Can_Btn.Visibility = Visibility.Visible;
            User_Add_Det_Btn.Visibility = Visibility.Visible;
            CleanAll();
            User_Add_Jur_Staff_Rbtn.IsChecked = true;
            //User_Que_Id_Rbtn.IsChecked = true;
        }

        private void User_Que_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
            User_Que_Id_Rbtn.IsChecked = true;
            HiddenAll();
            {
                User_Que_Search_Lab.Visibility = Visibility.Visible;
                User_Que_Search_Tbx.Visibility = Visibility.Visible;
                User_Que_Search_Udl.Visibility = Visibility.Visible;
                User_Que_Name_Rbtn.Visibility = Visibility.Visible;
                User_Que_Id_Rbtn.Visibility = Visibility.Visible;
                User_Que_Det_Btn.Visibility = Visibility.Visible;
                User_Que_Message_Dtg.Visibility = Visibility.Visible;
            }
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            string sql = @"Select 账号,姓名,权限 from Account";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            da.Fill(ds, "Staff");
            DataView dv = new DataView(ds.Tables["Staff"]);
            User_Que_Message_Dtg.ItemsSource = dv;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Account_Mes_Id_Lab.Visibility = Visibility.Visible;
            Account_Mes_Id_Tbx.Visibility = Visibility.Visible;
            Account_Mes_Id_Udl.Visibility = Visibility.Visible;
            Account_Mes_Jur_Lab.Visibility = Visibility.Visible;
            Account_Mes_Jur_Tbx.Visibility = Visibility.Visible;
            Account_Mes_Jur_Udl.Visibility = Visibility.Visible;
            Account_Mes_Name_Lab.Visibility = Visibility.Visible;
            Account_Mes_Name_Tbx.Visibility = Visibility.Visible;
            Account_Mes_Name_Udl.Visibility = Visibility.Visible;
            Account_ChangePassword_Tbk.Visibility = Visibility.Visible;
            CleanAll();
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                string sql1 = String.Format("select count(*) from[Account] where 姓名='{0}'", LoginTbk.Text);
                string sql2 = String.Format("select 账号 from[Account] where 姓名='{0}'", LoginTbk.Text);
                string sql3 = String.Format("select 权限 from[Account] where 姓名='{0}'", LoginTbk.Text);
                SqlCommand command1 = new SqlCommand(sql1, connection);
                SqlCommand command2 = new SqlCommand(sql2, connection);
                SqlCommand command3 = new SqlCommand(sql3, connection);
                //string Name = (string)command1.ExecuteScalar();
                int num1 = (int)command1.ExecuteScalar();
                //if (Name != "")
                if(num1==1)
                {
                    Account_Mes_Name_Tbx.Text = LoginTbk.Text;
                    Account_Mes_Id_Tbx.Text = (string)command2.ExecuteScalar();
                    int jur = (int)command3.ExecuteScalar();
                    if (jur == 1)
                        Account_Mes_Jur_Tbx.Text = "工作人员";
                    if (jur == 2)
                        Account_Mes_Jur_Tbx.Text = "管理员";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Account_ChangePassword_Tbk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HiddenAll();
            {
                Account_ChangePassword_Can_Btn.Visibility = Visibility.Visible;
                Account_ChangePassword_Det_Btn.Visibility = Visibility.Visible;
                Account_ChangePassword_New1_Lab.Visibility = Visibility.Visible;
                Account_ChangePassword_New1_Tbx.Visibility = Visibility.Visible;
                Account_ChangePassword_New1_Udl.Visibility = Visibility.Visible;
                Account_ChangePassword_Old_Lab.Visibility = Visibility.Visible;
                Account_ChangePassword_Old_Tbx.Visibility = Visibility.Visible;
                Account_ChangePassword_Old_Udl.Visibility = Visibility.Visible;
                Account_ChangePassword_Tips1_Lab.Visibility = Visibility.Visible;
                Account_ChangePassword_Tips2_Lab.Visibility = Visibility.Visible;
            }
        }

        private void Borrow_Bor_ISBN_Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Borrow_Bor_Message_RTbx.Document.Blocks.Clear();
            if (Borrow_Bor_ISBN_Tbx.Text.Length == 10)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("select 书名 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    string sql2 = String.Format("select 作者 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    string sql3 = String.Format("select 出版社 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    string sql4 = String.Format("select 库存 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    string sql5 = String.Format("select 出版年份 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    string sql6 = String.Format("select 图书单价 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    SqlCommand command3 = new SqlCommand(sql3, connection);
                    SqlCommand command4 = new SqlCommand(sql4, connection);
                    SqlCommand command5 = new SqlCommand(sql5, connection);
                    SqlCommand command6 = new SqlCommand(sql6, connection);
                    string Tittle = (string)command1.ExecuteScalar();
                    if (Tittle != null)
                    {
                        string Author = (string)command2.ExecuteScalar();
                        string Publisher = (string)command3.ExecuteScalar();
                        int Stock = (int)command4.ExecuteScalar();
                        int year = (int)command5.ExecuteScalar();
                        double price = (double)command6.ExecuteScalar();
                        Borrow_Bor_Message_RTbx.Document.Blocks.Add(new Paragraph(new Run("书名：" + Tittle + "\r\n作者：" + Author + "\r\n出版社：" + Publisher + "\r\n库存：" + Stock + "本\r\n出版年份：" + year + "年\r\n图书单价：" + price + "元")));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        private void Borrow_Bor_ID_Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Borrow_Bor_Name_Tbx.Text = "";
            if (Borrow_Bor_ID_Tbx.Text.Length == 8)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("select 姓名 from[Card] where 借阅证号='{0}'", Borrow_Bor_ID_Tbx.Text);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    Borrow_Bor_Name_Tbx.Text = (string)command1.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Borrow_Bor_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
        }

        private void Borrow_Bor_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(Borrow_Bor_Message_RTbx.Document.ContentStart, Borrow_Bor_Message_RTbx.Document.ContentEnd);
            if (Borrow_Bor_ISBN_Tbx.Text == "")
            {
                MessageBox.Show("ISBN号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Borrow_Bor_Name_Tbx.Text == "")
            {
                MessageBox.Show("借阅证号不存在！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (textRange.Text == "")
            {
                MessageBox.Show("该书籍不存在！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql1 = String.Format("select 库存 from[Books] where ISBN='{0}'", Borrow_Bor_ISBN_Tbx.Text);
                string sql2 = String.Format("insert into [Record] (ISBN,借阅证号,借书时间) values ('{0}','{1}','{2}')", Borrow_Bor_ISBN_Tbx.Text, Borrow_Bor_ID_Tbx.Text, DateTime.Now);
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    int num1 = (int)command1.ExecuteScalar();
                    if (num1 <= 0)
                    {
                        MessageBox.Show("图书库存不足！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        int num2 = (int)command2.ExecuteNonQuery();
                        if (num2 > 0)
                        {
                            string sql3 = String.Format("update [Books] set 库存 = '{0}' where ISBN='{1}'", num1 - 1, Borrow_Bor_ISBN_Tbx.Text);
                            SqlCommand command3 = new SqlCommand(sql3, connection);
                            int num3 = (int)command3.ExecuteNonQuery();
                            MessageBox.Show("借书成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            CleanAll();
                        }
                        else
                        {
                            MessageBox.Show("借书失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        private void Borrow_Ret_Query_Btn_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString); 
            string sql = String.Format("select Record.ISBN,书名,作者,借书时间 from[Record],[Books] where 还书时间 is null and 借阅证号='{0}' and Record.ISBN=Books.ISBN", Borrow_Ret_ID_Tbx.Text);
            //string sql = String.Format("select Record.ISBN,书名,作者,借书时间,还书时间,赔款 from[Record],[Books] where 借阅证号='{0}' and Record.ISBN=Books.ISBN", Borrow_Ret_ID_Tbx.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            da.Fill(ds, "Staff");
            DataView dv = new DataView(ds.Tables["Staff"]);
            Borrow_Ret_Message_Dtg.ItemsSource = dv;
        }

        private double GetPrice(String ISBN)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string sql1 = String.Format("select 图书单价 from[Books] where ISBN='{0}'", ISBN);
            SqlCommand command1 = new SqlCommand(sql1, connection);
            double price = (double)command1.ExecuteScalar();
            return price;
        }

        private void Borrow_Ret_Message_Dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            var vLst = this.Borrow_Ret_Message_Dtg.SelectedItems;
            for (int i = 0; i < vLst.Count; i++)
            {
                string ISBN = (Borrow_Ret_Message_Dtg.Columns[0].GetCellContent(vLst[i]) as TextBlock).Text;
                string Tittle = (Borrow_Ret_Message_Dtg.Columns[1].GetCellContent(vLst[i]) as TextBlock).Text;
                string Time = (Borrow_Ret_Message_Dtg.Columns[3].GetCellContent(vLst[i]) as TextBlock).Text;
                try
                {                   
                    connection.Open();
                    double price = GetPrice(ISBN);
                    double compensate = 0;
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = Convert.ToDateTime(Time);
                    TimeSpan ts = date1 - date2;
                    int days = ts.Days;
                    if (days > 30)
                        compensate = 0.5 * price;
                    else if (days > 60)
                        compensate = price;
                    if (MessageBox.Show("是否确定归还" + Time + "借出的" + Tittle + "?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (MessageBox.Show("超期应赔偿" + compensate + "元，图书是否有破损?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            compensate = price;
                            MessageBox.Show("图书有破损，应全额赔偿" + compensate + "元！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            string sql1 = String.Format("update [Record] set 还书时间 = '{0}',赔款='{1}' where ISBN='{2}'and 借阅证号='{3}'and 借书时间='{4}'", DateTime.Now, compensate, ISBN, Borrow_Ret_ID_Tbx.Text, Time);
                            string sql2 = String.Format("update [Books] set 库存 = 库存+'1' where ISBN='{0}'", ISBN);  //库存+1                        
                            SqlCommand command1 = new SqlCommand(sql1, connection);
                            SqlCommand command2 = new SqlCommand(sql2, connection);
                            int num1 = (int)command1.ExecuteNonQuery();
                            int num2 = (int)command2.ExecuteNonQuery();
                            if (num1 == 1 && num2 == 1)
                            {
                                MessageBox.Show("还书成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            string sql1 = String.Format("update [Record] set 还书时间 = '{0}',赔款='{1}' where ISBN='{2}'and 借阅证号='{3}'and 借书时间='{4}'", DateTime.Now, compensate, ISBN, Borrow_Ret_ID_Tbx.Text, Time);
                            string sql2 = String.Format("update [Books] set 库存 = 库存+'1' where ISBN='{0}'", ISBN);  //库存+1                        
                            SqlCommand command1 = new SqlCommand(sql1, connection);
                            SqlCommand command2 = new SqlCommand(sql2, connection);
                            int num1 = (int)command1.ExecuteNonQuery();
                            int num2 = (int)command2.ExecuteNonQuery();
                            if (num1 == 1 && num2 == 1)
                            {
                                MessageBox.Show("还书成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        private void Borrow_Han_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
        }

        private void Borrow_Han_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            if (Borrow_Han_ID_Tbx.Text == "")
            {
                MessageBox.Show("学号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (Borrow_Han_ID_Tbx.Text.Length != 8)
            {
                MessageBox.Show("学号长度有误！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Borrow_Han_Name_Tbx.Text == "")
            {
                MessageBox.Show("姓名不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }           
            try
            {                
                connection.Open();
                string sql1 = String.Format("select count(*) from[Card] where 借阅证号='{0}'", Borrow_Han_ID_Tbx.Text);
                string sql2 = String.Format("insert into [Card] (借阅证号,姓名) values ('{0}','{1}')", Borrow_Han_ID_Tbx.Text, Borrow_Han_Name_Tbx.Text);                
                SqlCommand command1 = new SqlCommand(sql1, connection);
                SqlCommand command2 = new SqlCommand(sql2, connection);
                int num1 = (int)command1.ExecuteScalar();
                if(num1>0)
                {
                    MessageBox.Show("该学号已办理过借阅证！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    int num2 = (int)command2.ExecuteNonQuery();
                    if (num2 > 0)
                    {
                        MessageBox.Show("办理成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                        CleanAll();
                    }
                    else
                    {
                        MessageBox.Show("办理失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            finally
            {
                connection.Close();
            }
        }

        private void Books_Add_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
        }

        private void Books_Add_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Books_Add_Isbn_Tbx.Text == "")
            {
                MessageBox.Show("ISBN号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Tattle_Tbx.Text == "")
            {
                MessageBox.Show("书名不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Author_Tbx.Text == "")
            {
                MessageBox.Show("作者不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Publisher_Tbx.Text == "")
            {
                MessageBox.Show("出版社不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Stock_Tbx.Text == "")
            {
                MessageBox.Show("库存不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Year_Tbx.Text == "")
            {
                MessageBox.Show("出版年份不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Price_Tbx.Text == "")
            {
                MessageBox.Show("图书单价不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Add_Location_Tbx.Text == "")
            {
                MessageBox.Show("图书位置不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("select count(*) from[Books] where ISBN='{0}'", Books_Add_Isbn_Tbx.Text);
                    string sql2 = String.Format("insert into [Books] (ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                        Books_Add_Isbn_Tbx.Text, Books_Add_Tattle_Tbx.Text, Books_Add_Author_Tbx.Text, Books_Add_Publisher_Tbx.Text, Books_Add_Stock_Tbx.Text, Books_Add_Year_Tbx.Text,
                        Books_Add_Price_Tbx.Text, Books_Add_Location_Tbx.Text);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    int num1 = (int)command1.ExecuteScalar();
                    if (num1 > 0)
                    {
                        MessageBox.Show("书籍已存在！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        int num2 = (int)command2.ExecuteNonQuery();
                        if (num2 > 0)
                        {

                            MessageBox.Show("添加图书信息成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            CleanAll();
                        }
                        else
                        {
                            MessageBox.Show("添加图书信息失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }   
        }

        private void Books_Dev_Isbn_Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Books_Dev_Tattle_Tbx.Text = "";
            Books_Dev_Author_Tbx.Text = "";
            Books_Dev_Publisher_Tbx.Text = "";
            Books_Dev_Stock_Tbx.Text = "";
            Books_Dev_Year_Tbx.Text = "";
            Books_Dev_Price_Tbx.Text = "";
            Books_Dev_Location_Tbx.Text = "";
            if (Books_Dev_Isbn_Tbx.Text.Length == 10)//
            {               
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("select 书名 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql2 = String.Format("select 作者 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql3 = String.Format("select 出版社 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql4 = String.Format("select 库存 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql5 = String.Format("select 出版年份 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql6 = String.Format("select 图书单价 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    string sql7 = String.Format("select 图书位置 from[Books] where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    SqlCommand command2 = new SqlCommand(sql2, connection);
                    SqlCommand command3 = new SqlCommand(sql3, connection);
                    SqlCommand command4 = new SqlCommand(sql4, connection);
                    SqlCommand command5 = new SqlCommand(sql5, connection);
                    SqlCommand command6 = new SqlCommand(sql6, connection);
                    SqlCommand command7 = new SqlCommand(sql7, connection);
                    string Tittle = (string)command1.ExecuteScalar();
                    if (Tittle != null)
                    {
                        Books_Dev_Tattle_Tbx.Text = Tittle;
                        Books_Dev_Author_Tbx.Text = (string)command2.ExecuteScalar();
                        Books_Dev_Publisher_Tbx.Text = (string)command3.ExecuteScalar();
                        Books_Dev_Stock_Tbx.Text = Convert.ToString((int)command4.ExecuteScalar());
                        Books_Dev_Year_Tbx.Text = Convert.ToString((int)command5.ExecuteScalar());
                        Books_Dev_Price_Tbx.Text = Convert.ToString((double)command6.ExecuteScalar());
                        Books_Dev_Location_Tbx.Text= (string)command7.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Books_Dev_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
        }

        private void Books_Dev_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Books_Dev_Isbn_Tbx.Text == "")
            {
                MessageBox.Show("ISBN号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Tattle_Tbx.Text == "")
            {
                MessageBox.Show("书名不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Author_Tbx.Text == "")
            {
                MessageBox.Show("作者不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Publisher_Tbx.Text == "")
            {
                MessageBox.Show("出版社不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Stock_Tbx.Text == "")
            {
                MessageBox.Show("库存不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Year_Tbx.Text == "")
            {
                MessageBox.Show("出版年份不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Price_Tbx.Text == "")
            {
                MessageBox.Show("图书单价不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Books_Dev_Location_Tbx.Text == "")
            {
                MessageBox.Show("图书位置不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("update [Books] set 书名='{1}',作者='{2}',出版社='{3}',库存='{4}',出版年份='{5}',图书单价='{6}',图书位置='{7}' " +
                        "where ISBN='{0}'", Books_Dev_Isbn_Tbx.Text, Books_Dev_Tattle_Tbx.Text, Books_Dev_Author_Tbx.Text, Books_Dev_Publisher_Tbx.Text, Books_Dev_Stock_Tbx.Text, Books_Dev_Year_Tbx.Text,
                        Books_Dev_Price_Tbx.Text, Books_Dev_Location_Tbx.Text);
                    if (Books_Dev_Tattle_Tbx.Text == "")
                    {
                        MessageBox.Show("该书籍不存在，请先添加！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        if (MessageBox.Show("是否确定修改书籍信息?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            SqlCommand command1 = new SqlCommand(sql1, connection);
                            int num1 = (int)command1.ExecuteNonQuery();
                            if (num1 > 0)
                            {
                                MessageBox.Show("更新图书信息成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                                CleanAll();
                            }
                            else
                            {
                                MessageBox.Show("更新图书信息失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Books_Del_Message_Dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            var vLst = Books_Del_Message_Dtg.SelectedItems;
            for (int i = 0; i < vLst.Count; i++)
            {
                string ISBN = (Books_Del_Message_Dtg.Columns[0].GetCellContent(vLst[i]) as TextBlock).Text;
                string Tittle = (Books_Del_Message_Dtg.Columns[1].GetCellContent(vLst[i]) as TextBlock).Text;
                try
                {
                    connection.Open();
                    if (MessageBox.Show("是否确定删除《" + Tittle + "》的书籍信息?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        string sql1 = String.Format("DELETE FROM [Books] WHERE ISBN='{0}' ", ISBN);
                        SqlCommand command1 = new SqlCommand(sql1, connection);
                        int num1 = (int)command1.ExecuteNonQuery();
                        if (num1 == 1)
                        {
                            MessageBox.Show("删除书籍数据成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            Books_Del_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("删除书籍数据失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Books_Del_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(Books_Del_Search_Tbx.Text=="")
                Books_Del_Click(sender, e);
            else if(Books_Del_ISBN_Rbtn.IsChecked==true)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql = String.Format(@"Select ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置 from Books where ISBN like '%{0}%'", Books_Del_Search_Tbx.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(ds, "Staff");
                DataView dv = new DataView(ds.Tables["Staff"]);
                Books_Del_Message_Dtg.ItemsSource = dv;
            }
            else if (Books_Del_Tittle_Rbtn.IsChecked == true)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql = String.Format(@"Select ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置 from Books where 书名 like '%{0}%'", Books_Del_Search_Tbx.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(ds, "Staff");
                DataView dv = new DataView(ds.Tables["Staff"]);
                Books_Del_Message_Dtg.ItemsSource = dv;
            }
            else if (Books_Del_Author_Rbtn.IsChecked == true)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql = String.Format(@"Select ISBN,书名,作者,出版社,库存,出版年份,图书单价,图书位置 from Books where 作者 like '%{0}%'", Books_Del_Search_Tbx.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(ds, "Staff");
                DataView dv = new DataView(ds.Tables["Staff"]);
                Books_Del_Message_Dtg.ItemsSource = dv;
            }
        }

        private void User_Add_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
        }

        private void User_Add_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (User_Add_Id_Tbx.Text == "")
            {
                MessageBox.Show("账号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (User_Add_Name_Tbx.Text == "")
            {
                MessageBox.Show("姓名不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (User_Add_Id_Tbx.Text.Length != 8)
            {
                MessageBox.Show("账号长度错误！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                int Jur = 1;
                if (User_Add_Jur_Admin_Rbtn.IsChecked == true)
                    Jur = 2;
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string sql1 = String.Format("select count(*) from[Account] where 账号='{0}'", User_Add_Id_Tbx.Text);
                    string sql2 = String.Format("insert into [Account] (账号,姓名,密码,权限) values ('{0}','{1}','{0}','{2}')", User_Add_Id_Tbx.Text, User_Add_Name_Tbx.Text, Jur);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    int num1 = (int)command1.ExecuteScalar();
                    if (num1 > 0)
                    {
                        MessageBox.Show("该账户已被注册！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        int num2 = (int)command2.ExecuteNonQuery();
                        if (num2 > 0)
                        {
                            MessageBox.Show("用户注册成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                            CleanAll();
                        }
                        else
                        {
                            MessageBox.Show("用户注册失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void User_Que_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (User_Que_Search_Tbx.Text == "")
                User_Que_Click(sender, e);
            else if (User_Que_Id_Rbtn.IsChecked == true)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql = String.Format(@"Select 账号,姓名,权限 from Account where 账号 like '%{0}%'", User_Que_Search_Tbx.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(ds, "Staff");
                DataView dv = new DataView(ds.Tables["Staff"]);
                User_Que_Message_Dtg.ItemsSource = dv;
            }
            else if (User_Que_Name_Rbtn.IsChecked == true)
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql = String.Format(@"Select 账号,姓名,权限 from Account where 姓名 like '%{0}%'", User_Que_Search_Tbx.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(ds, "Staff");
                DataView dv = new DataView(ds.Tables["Staff"]);
                User_Que_Message_Dtg.ItemsSource = dv;
            }
        }

        private void User_Que_Message_Dtg_KeyDown(object sender, KeyEventArgs e)
        {
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            if (e.Key == Key.Q)
            {
                if (MessageBox.Show("是否确定删除该用户信息?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    
                    var vLst = User_Que_Message_Dtg.SelectedItems;
                    for (int i = 0; i < vLst.Count; i++)
                    {
                        string ID = (User_Que_Message_Dtg.Columns[0].GetCellContent(vLst[i]) as TextBlock).Text;
                        try
                        {
                            connection.Open();
                            string sql1 = String.Format("DELETE FROM [Account] WHERE 账号='{0}' ", ID);
                            SqlCommand command1 = new SqlCommand(sql1, connection);
                            int num1 = (int)command1.ExecuteNonQuery();
                            if (num1 == 1)
                            {
                                MessageBox.Show("删除数据成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                                User_Que_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("删除数据失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
            if (e.Key == Key.W)
            {
                if (MessageBox.Show("是否确定重置该用户密码?", "西邮图管", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    var vLst = User_Que_Message_Dtg.SelectedItems;
                    for (int i = 0; i < vLst.Count; i++)
                    {
                        string ID = (User_Que_Message_Dtg.Columns[0].GetCellContent(vLst[i]) as TextBlock).Text;
                        try
                        {
                            connection.Open();
                            string sql1 = String.Format("update [Account] set 密码 = '{0}' where 账号='{0}'", ID);
                            SqlCommand command1 = new SqlCommand(sql1, connection);
                            int num1 = (int)command1.ExecuteNonQuery();
                            if (num1 == 1)
                            {
                                MessageBox.Show("重置密码成功！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                                User_Que_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("重置密码失败，请稍后重试！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void User_Que_Message_Dtg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        private void Account_ChangePassword_Can_Btn_Click(object sender, RoutedEventArgs e)
        {
            CleanAll();
            Account_Click(sender, e);
        }

        private void Account_ChangePassword_Old_Tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Account_ChangePassword_Old_Tbx.Text=="请输入原密码")
            {
                Account_ChangePassword_Old_Tbx.Text = "";
                Account_ChangePassword_Old_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
        }

        private void Account_ChangePassword_Old_Tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Account_ChangePassword_Old_Tbx.Text == "")
            {
                Account_ChangePassword_Old_Tbx.Text = "请输入原密码";
                Account_ChangePassword_Old_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            }
        }

        private void Account_ChangePassword_New1_Tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Account_ChangePassword_New1_Tbx.Text == "请输入新密码")
            {
                Account_ChangePassword_New1_Tbx.Text = "";
                Account_ChangePassword_New1_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
        }

        private void Account_ChangePassword_New1_Tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Account_ChangePassword_New1_Tbx.Text == "")
            {
                Account_ChangePassword_New1_Tbx.Text = "请输入新密码";
                Account_ChangePassword_New1_Tbx.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            }
        }      

        private void Account_ChangePassword_New1_Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Account_ChangePassword_New1_Tbx.Text!= "请输入新密码")
            {
                //提示1
                if (Account_ChangePassword_New1_Tbx.Text.Length > 7 && Account_ChangePassword_New1_Tbx.Text.Length < 17)
                    Account_ChangePassword_Tips1_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF21D9C6"));
                else
                    Account_ChangePassword_Tips1_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));

                //Account_ChangePassword_New1_Tbx.Foreground = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                //Account_ChangePassword_New1_Tbx.TextDecorations = new TextDecorationCollection(new TextDecoration[]{
                //new TextDecoration(){
                //      Location= TextDecorationLocation.Strikethrough,
                //      Pen= new Pen(Brushes.Black, 10){
                //      DashCap =  PenLineCap.Round,
                //      StartLineCap= PenLineCap.Round,
                //      EndLineCap= PenLineCap.Round,
                //      DashStyle= new DashStyle(new double[] {0.0,1.2 }, 0.6)}}});
                ////Style style = this.Resources["TxtPwd"] as Style;
                ////Style newStyle = new Style(typeof(TextBox)) { BasedOn = style };
                ////Account_ChangePassword_New1_Tbx.Style = newStyle;

                //提示2
                char[] c = new char[20];
                Account_ChangePassword_New1_Tbx.Text.CopyTo(0, c, 0, Account_ChangePassword_New1_Tbx.Text.Length);
                bool num = false;
                bool UpperCase = false;
                bool LowerCase = false;
                bool Sign = false;
                for (var i = 0; i < Account_ChangePassword_New1_Tbx.Text.Length; i++)
                {
                    if (c[i] >= 48 && c[i] <= 57)
                        num = true;
                    else if (c[i] >= 65 && c[i] <= 90)
                        UpperCase = true;
                    else if (c[i] >= 97 && c[i] <= 122)
                        LowerCase = true;
                    else if (c[i] >= 32 && c[i] <= 126)
                        Sign = true;
                }
                int count = 0;
                if (num == true)
                    count += 1;
                if (UpperCase == true)
                    count += 1;
                if (LowerCase == true)
                    count += 1;
                if (Sign == true)
                    count += 1;
                if (count > 1)
                    Account_ChangePassword_Tips2_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF21D9C6"));
                else
                    Account_ChangePassword_Tips2_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB2B8B8"));
            }
            else
            {
                
            }
        }

        private void Account_ChangePassword_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Account_ChangePassword_Old_Tbx.Text == "请输入原密码")
            {
                MessageBox.Show("请输入原密码！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Account_ChangePassword_Old_Tbx.Focus();
            }
            else if (Account_ChangePassword_New1_Tbx.Text == "请输入新密码")
            {
                MessageBox.Show("请输入新密码！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Account_ChangePassword_New1_Tbx.Focus();
            }
            else if(Convert.ToString( Account_ChangePassword_Tips1_Lab.Foreground) == "#FFB2B8B8"&& Convert.ToString(Account_ChangePassword_Tips2_Lab.Foreground) == "#FFB2B8B8")
            {
                Account_ChangePassword_Tips1_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFC3003"));
                Account_ChangePassword_Tips2_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFC3003"));
            }
            else if(Convert.ToString(Account_ChangePassword_Tips1_Lab.Foreground) == "#FFB2B8B8")
                Account_ChangePassword_Tips1_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFC3003"));
            else if (Convert.ToString(Account_ChangePassword_Tips2_Lab.Foreground) == "#FFB2B8B8")
                Account_ChangePassword_Tips2_Lab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFC3003"));           
            else//执行
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql1 = String.Format("select 密码 from[Account] where 姓名='{0}'", LoginTbk.Text);
                string sql2 = String.Format("update [Account] set 密码 = '{0}' where 姓名='{1}'", Account_ChangePassword_New1_Tbx.Text, LoginTbk.Text);
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    String password = (string)command1.ExecuteScalar();
                    if (password != Account_ChangePassword_Old_Tbx.Text)
                    {
                        MessageBox.Show("原密码错误！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Account_ChangePassword_Old_Tbx.Text = "";
                        Account_ChangePassword_Old_Tbx.Focus();
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        int num2 = (int)command2.ExecuteNonQuery();
                        if (num2 == 1)
                        {
                            MessageBox.Show("密码修改成功，请重新登录！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);

                            string strAppFileName = Process.GetCurrentProcess().MainModule.FileName;
                            Process myNewProcess = new Process();
                            myNewProcess.StartInfo.FileName = strAppFileName;
                            myNewProcess.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            myNewProcess.Start();
                            this.Close();

                        }
                        CleanAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

      

        private void Login_Det_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Login_Id_Tbx.Text == "")
                MessageBox.Show("账号不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else if(Login_Pwd_Pwbx.Password=="")
                MessageBox.Show("密码不得为空！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connString);
                string sql1 = String.Format("select count(*) from[Account] where 账号='{0}'", Login_Id_Tbx.Text);
                string sql2 = String.Format("select 密码 from[Account] where 账号='{0}'", Login_Id_Tbx.Text);
                string sql3 = String.Format("select 姓名 from[Account] where 账号='{0}'", Login_Id_Tbx.Text);
                string sql4 = String.Format("select 权限 from[Account] where 账号='{0}'", Login_Id_Tbx.Text);
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    int Num1 = (int)command1.ExecuteScalar();
                    if (Num1 == 1)
                    {
                        SqlCommand command2 = new SqlCommand(sql2, connection);
                        string Password = (string)command2.ExecuteScalar();
                        if (Password == Login_Pwd_Pwbx.Password)
                        {
                            SqlCommand command3 = new SqlCommand(sql3, connection);
                            SqlCommand command4 = new SqlCommand(sql4, connection);
                            LoginTbk.Text = (string)command3.ExecuteScalar();
                            int Jurisdiction = (int)command4.ExecuteScalar();
                            if (Jurisdiction == 1)
                            {
                                Borrow.Visibility = Visibility.Visible;
                                //Books.Visibility = Visibility.Hidden;
                                //User.Visibility = Visibility.Hidden;
                                Account.Visibility = Visibility.Visible;
                            }
                            if (Jurisdiction == 2)
                            {
                                Borrow.Visibility = Visibility.Visible;
                                Books.Visibility = Visibility.Visible;
                                User.Visibility = Visibility.Visible;
                                Account.Visibility = Visibility.Visible;
                            }
                            FirstPage_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("账号或密码错误！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            Login_Pwd_Pwbx.Password = "";
                            Login_Pwd_Pwbx.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误！", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Login_Pwd_Pwbx.Password = "";
                        Login_Pwd_Pwbx.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错，请稍后重试！", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        private void Borrow_Han_Import_Tbk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog(); //new一个方法
            a.Filter = "Excel文档|*.xlsx;"; ; //删选、设定文件显示类型
            a.ShowDialog(); //显示打开文件的窗口
            string fileName = a.FileName; //获得选择的文件路径

            //读取文件内容，并保存在DataTable中
            IWorkbook workbook = null;  //新建IWorkbook对象  
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0)
            {
                workbook = new XSSFWorkbook(fileStream);  //xls数据读入workbook  
            }
            ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表 
            IRow row;

            //datatable数据表
            DataTable dt1 = new DataTable();
            //创建纵列
            dt1.Columns.Add("借阅证号", typeof(System.String));
            dt1.Columns.Add("姓名", typeof(System.String));           

            for (int i = 1; i < sheet.LastRowNum + 1; i++)  //对工作表每一行  
            {
                DataRow dr1 = dt1.NewRow();//新建行
                row = sheet.GetRow(i);   //row读入第i行数据  
                if (row != null)
                {
                    dr1["借阅证号"] = row.GetCell(0).ToString().Trim(); //获取i行j列数据 
                    dr1["姓名"] = row.GetCell(1).ToString().Trim(); //获取i行j列数据 
                    

                }
                dt1.Rows.Add(dr1);//将行加入数据表dt1
            }
            fileStream.Close();
            workbook.Close();



            //连接数据库并去重
            string connString = @"Data Source=LAPTOP-IADT0VMG;Initial Catalog=Library1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            //using SqlConnection conn = new SqlConnection("Data Source = (local);Initial Catalog = Library1;Integrated Security=True");
            connection.Open();
            //若与数据库成员重合，则在此删除dt中重合行，下面再进行插入操作
            SqlCommand cmd = new SqlCommand("select * from [Card]", connection);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (sdr.GetString(0).ToString().Trim() == dt1.Rows[i][0].ToString())
                    {
                        dt1.Rows[i].Delete();
                    }
                }
            }
            sdr.Close();
            //插入数据库



            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {

                try
                {
                    bulkCopy.DestinationTableName = "Card";//要插入的表的表名
                    bulkCopy.BatchSize = dt1.Rows.Count;
                    bulkCopy.ColumnMappings.Add("借阅证号", "借阅证号");//表中的字段名 第一个“id”是dt中的字段名，第二个“id”表中的字段名
                    bulkCopy.ColumnMappings.Add("姓名", "姓名");
                    bulkCopy.WriteToServer(dt1);
                    MessageBox.Show("录入成功！共录入" + dt1.Rows.Count + "条数据", "西邮图管", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
            connection.Dispose();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }



}
//累死老子了(´▽`)ﾉ 