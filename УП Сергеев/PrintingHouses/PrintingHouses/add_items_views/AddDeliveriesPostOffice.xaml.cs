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

namespace PrintingHousesApp.add_items_views
{
    public partial class AddDeliveriesPostOffice : Page
    {
        private DeliveriesPostOffices deliveriesPostOffice;
        public AddDeliveriesPostOffice()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            using (var dbContext = new CerberusDBEntities())
            {
                cmdPrintingNewspapers.ItemsSource = dbContext.PrintingNewspapers.ToList();
                cmdPostOffices.ItemsSource = dbContext.PostOffices.ToList();
            }
        }

        private async void AddItem(object sender, EventArgs e)
        {
            if (cmdPostOffices.SelectedItem == null || cmdPrintingNewspapers.SelectedItem == null)
            {
                MessageBox.Show("Введены не все параметры.", "Ошибка");
                return;
            }

            try
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    deliveriesPostOffice = new DeliveriesPostOffices()
                    {
                        C_idPostOffices = ((PostOffices)cmdPostOffices.SelectedItem).C_id,
                        C_idPrintingNewspapers = ((PrintingNewspapers)cmdPrintingNewspapers.SelectedItem).C_id
                    };
                    dbContext.DeliveriesPostOffices.Add(deliveriesPostOffice);
                    await dbContext.SaveChangesAsync();
                }
                MessageBox.Show($"Доставка газет {deliveriesPostOffice.PrintingNewspapers.Newspapers.NewspaperName} в почтовое отделение {deliveriesPostOffice.PostOffices.PostOfficeName} успешно оформлена.", "Успех");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }
    }
}
