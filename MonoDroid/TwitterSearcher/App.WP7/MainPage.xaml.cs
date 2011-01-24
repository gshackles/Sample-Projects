using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using TwitterSearcher;

namespace App.WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Searcher _searcher;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            _searcher = new Searcher("http://search.twitter.com/search.atom?q=");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Visibility = System.Windows.Visibility.Visible;
            Results.Visibility = System.Windows.Visibility.Collapsed;

            _searcher.Search(Query.Text, results => 
            {
                Results.ItemsSource = results;

                ProgressBar.Visibility = System.Windows.Visibility.Collapsed;
                Results.Visibility = System.Windows.Visibility.Visible;
            });
        }
    }
}