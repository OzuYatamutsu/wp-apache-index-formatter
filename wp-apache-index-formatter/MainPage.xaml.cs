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
            
            formatList.get();

            // Once loaded, stop loading animation
            // (How can tell when loaded? When view is populated?)
            // Comment out for now
            //loadingBarText.Visibility = System.Windows.Visibility.Collapsed;
            //loadingBar.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void loadingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Do nothing
            // This should never be called anyways, loading bar is indeterminate
            System.Threading.Thread.Sleep(1);
        }

        /// <summary>
        /// Tests parse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testParseButton_Click(object sender, RoutedEventArgs e)
        {
            ApacheMapList myTestList = new ApacheMapList(DEFAULT_URI);
            myTestList.testResponse();
        }
    }
}
