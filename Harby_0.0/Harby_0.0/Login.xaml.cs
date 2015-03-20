using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VkNet;
using VkNet.Enums.Filters;

namespace Harby_0._0
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private int appId = 4785272; // указываем id приложения
        Settings settings = Settings.All; // уровень доступа к данным
        string accessToken = "";
        int userId = 0;

        //string email = "380660721044"; // email для авторизации
        //string password = "oiVsyo!"; // пароль

        public Login()
        {
            InitializeComponent();
            accessToken = "";
            userId = 0;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Login_web.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token", appId, settings));
        }

        private void Login_web_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // отключаем JavaScript ошибки
            var browser = sender as WebBrowser;

            if (browser == null || browser.Document == null)
                return;

            dynamic document = browser.Document;

            if (document.readyState != "complete")
                return;

            dynamic script = document.createElement("script");
            script.type = @"text/javascript";
            script.text = @"window.onerror = function(msg,url,line){return true;}";
            document.head.appendChild(script);
            //////////////////////////////////////////////////
            //распарсиваем строку и получаем токен и id
            if (e.Uri.ToString().IndexOf("access_token") != -1)
            {
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Uri.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        userId = Convert.ToInt32(m.Groups["value"].Value);
                    }

                }
                this.Hide();
                MainWindow mainWin = new MainWindow(accessToken, userId);
                mainWin.ShowDialog();
            }
        }

        private void Auth()
        {
            var api = new VkApi();
            api.AccessToken = accessToken;

            api.Wall.Post(api.UserId, false, false, "WPF"); 
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close__MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown(); 
        }

        

        
    }
}
