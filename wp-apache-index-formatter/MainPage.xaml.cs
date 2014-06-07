using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using wp_apache_index_formatter.Resources;

namespace wp_apache_index_formatter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string DEFAULT_URI = "http://steakscorp.org/expressions.png";
        string uriInput;
        ApacheMapList formatList;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // On start, load default page
            // (Maybe save and load from config file?)

            formatList = new ApacheMapList(DEFAULT_URI);
            uriInput = DEFAULT_URI;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Loading animation
            loadingBarText.Visibility = System.Windows.Visibility.Visible;
            loadingBar.Visibility = System.Windows.Visibility.Visible;

            if (!uriInput.Equals(uriStartInput.Text))
            {
                uriInput = uriStartInput.Text;
                formatList = new ApacheMapList(uriInput);
            }

            PopulateLongList();
        }

        private async void PopulateLongList()
        {
            await formatList.Get();
            indexScroller.ItemsSource = formatList.GetKeyList();

            // Once list is loaded, remove loading animation and show list
            loadingBarText.Visibility = System.Windows.Visibility.Collapsed;
            loadingBar.Visibility = System.Windows.Visibility.Collapsed;
            indexScroller.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Not implemented. Loading bar should be indeterminate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Do nothing
            System.Threading.Thread.Sleep(1);
        }

        /// <summary>
        /// Tests parse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testParseButton_Click(object sender, RoutedEventArgs e)
        {
            // Loading animation
            loadingBarText.Visibility = System.Windows.Visibility.Visible;
            loadingBar.Visibility = System.Windows.Visibility.Visible;

            ApacheMapList myTestList = new ApacheMapList(DEFAULT_URI);
            myTestList.testResponse();
            //indexScroller.ItemsSource = myTestList.GetKeyList();
            List<AlphaKeyGroup<string>> DataSource = AlphaKeyGroup<string>.CreateGroups(myTestList.GetKeyList(),
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (string s) => { return s; }, true);
            indexScroller.ItemsSource = DataSource;
            // Once list is loaded, remove loading animation and show list
            loadingBarText.Visibility = System.Windows.Visibility.Collapsed;
            loadingBar.Visibility = System.Windows.Visibility.Collapsed;
            indexScroller.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
