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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uriInput = uriStartInput.Text;
            uriSavedSuccessText.Visibility = Visibility.Visible;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}