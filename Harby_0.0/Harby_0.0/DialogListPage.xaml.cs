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
    /// Interaction logic for DialogListPage.xaml
    /// </summary>
    public partial class DialogListPage : Page
    {
        public DialogListPage()
        {
            InitializeComponent();
        }

        private void Friends__MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FriendsListPage.xaml", UriKind.Relative));
        }

        private void Chat__MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DialogListPage.xaml", UriKind.Relative));
        }

        private void Dialog__MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DialogPage.xaml", UriKind.Relative));
        }
    }
}
