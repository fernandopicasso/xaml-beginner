using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using RestaurantManager.Models.Annotations;

namespace RestaurantManager.Models
{
    public class DataManager
    {
        public DataManager()
        {
            this.OrderItems = new ObservableCollection<string>(
                new List<string>
                {
                    "Steak, Chicken, Peas",
                    "Rice, Chicken",
                    "Hummus, Pita"
                }
            );

            this.MenuItems = new ObservableCollection<string>
            {
                "Steak",
                "Chicken",
                "Peas",
                "Rice",
                "Hummus",
                "Pita"
            };

            this.CurrentlySelectedMenuItems = new ObservableCollection<string>
            {
                "Rice",
                "Pita"
            };

        }

        public ObservableCollection<string> OrderItems { get; set; }
        public ObservableCollection<string> MenuItems { get; set; }
        public ObservableCollection<string> CurrentlySelectedMenuItems { get; set; }

        public void SelectMenuItem(string menuItem)
        {
            if (MenuItems.Contains(menuItem))
            {
                MenuItems.Remove(menuItem);
                CurrentlySelectedMenuItems.Add(menuItem);
            }
        }

        public void CreateOrder()
        {
            if (CurrentlySelectedMenuItems.Count > 0)
            {
                string order = string.Join(", ", CurrentlySelectedMenuItems);
                OrderItems.Add(order);
                foreach (string selectedItem in CurrentlySelectedMenuItems)
                {
                    if (!MenuItems.Contains(selectedItem))
                    {
                        MenuItems.Add(selectedItem);
                    }
                }
                CurrentlySelectedMenuItems.Clear();
            }
        }

        public void ClearAllOrders()
        {
            OrderItems.Clear();
        }
    }
}