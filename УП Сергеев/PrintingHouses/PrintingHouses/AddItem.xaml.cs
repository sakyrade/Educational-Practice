using PrintingHousesApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace PrintingHouses
{
    public partial class AddItem : Window
    {
        public AddItem(ICollection t)
        {
            InitializeComponent();

            if (t as BindingList<Newspapers> != null) this.Content = new add_items_views.AddNewspaper()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center
            };

            if (t as BindingList<PrintingHousesApp.PrintingHouses> != null) this.Content = new AddPrintingHouse()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center
            };

            if (t as BindingList<PostOffices> != null) this.Content = new PrintingHousesApp.add_items_views.AddPostOffice()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center
            };

            if (t as BindingList<PrintingNewspapers> != null) this.Content = new PrintingHousesApp.add_items_views.AddPrintingNewspaper()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center
            };

            if (t as List<DeliveriesPostOffices> != null) this.Content = new PrintingHousesApp.add_items_views.AddDeliveriesPostOffice()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center
            };
        }
    }
}
