using System;
using System.Collections.Generic;
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

namespace Harby_0._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string accessToken = "";
        int userId = 0;
        vkAPI vk;
        Login log;
        VkNet.Model.User profile;


        public MainWindow(string accessToken_, int userId_)
        {
            InitializeComponent();
            accessToken = accessToken_;
            userId = userId_;
            vk = new vkAPI(userId_, accessToken_);
            Get_Profile_API();
        }
        private void Close__MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void Get_Profile_API() //получаем основную информацию профиля
        {
            profile = vk.GetProfile();

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri((profile.PhotoPreviews.Photo100), UriKind.Absolute);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            Photo_.Source = src;

            Name_.Content = profile.FirstName + " \n" + profile.LastName;
        }

        private void Logout_() //для выхода из текущего профиля: нажимаем на иконку "Выход" и попадаем в окно браузера.
        {
            accessToken = "";
            userId = 0;
            log = new Login();
            this.Hide();
            log.ShowDialog();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           // Get_Profile_API();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LogOut__MouseDown(object sender, MouseButtonEventArgs e)
        {
            Logout_();
        }

        private void Chat__MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageWindow mesWin = new MessageWindow(accessToken, userId);
            mesWin.Show();
            
        }

       
    }
}
