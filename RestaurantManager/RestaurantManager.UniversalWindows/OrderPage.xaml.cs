using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RestaurantManager.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void SubmitOrder_OnClick(object sender, RoutedEventArgs e)
        {
            DataManager dataManager = this.DataContext as DataManager;

            if (dataManager != null)
            {
                if (SelectedItems.Items.Count > 0)
                {
                    dataManager.CreateOrder();
                }
            }
        }

        private void AddToOrder_OnClick(object sender, RoutedEventArgs e)
        {
            DataManager dataManager = this.DataContext as DataManager;

            if (dataManager != null)
            {
                if (MenuItems.SelectedIndex > -1)
                {
                    var selectedItem = MenuItems.SelectedItem as string;
                    if (!string.IsNullOrWhiteSpace(selectedItem))
                    {
                        dataManager.SelectMenuItem(selectedItem);
                    }
                }
            }
        }
    }
}
