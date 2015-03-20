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
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        string accessToken = "";
        int userId = 0;
        FriendsListPage fr = new FriendsListPage();

        public MessageWindow(string accessToken_, int userId_)
        {
            InitializeComponent();
            accessToken = accessToken_;
            userId = userId_;

        }

        private void Window_Loaded_2(object sender, RoutedEventArgs e)
        {
            //FriendsListPage fr = new FriendsListPage();
            this.Content = fr;
            //NavigationService.Navigate(new Uri("Frieds_page.xaml", UriKind.Relative));
            //NavigationWindow win = new NavigationWindow();
            //win.Content = "Frieds_page.xaml";
            //win.Show();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
