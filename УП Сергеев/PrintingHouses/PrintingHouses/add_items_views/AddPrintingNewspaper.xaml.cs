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
    public partial class AddPrintingNewspaper : Page
    {
        private PrintingNewspapers printingNewspaper;
        public double Edition { get; set; }

        public AddPrintingNewspaper()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            using (var dbContext = new CerberusDBEntities())
            {
                cmdPrintingHouses.ItemsSource = dbContext.PrintingHouses.Select(pn => pn.PrintingHouseName).ToList();
                cmdNewspapers.ItemsSource = dbContext.Newspapers.Select(n => n.NewspaperName).ToList();
            }
        }

        private async void AddItem(object sender, EventArgs e)
        {
            if (cmdNewspapers.SelectedItem == null || cmdPrintingHouses.SelectedItem == null || Edition <= 0)
            {
                MessageBox.Show("Введены не все параметры.", "Ошибка");
                return;
            }

            try 
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    var temp = dbContext.PrintingNewspapers.Where(pn => pn.NewspaperName == cmdNewspapers.SelectedItem.ToString() && pn.PrintingHouseName == cmdPrintingHouses.SelectedItem.ToString()).Select(pn => pn.Edition);
                    int sum = 0;

                    if (temp.Count() != 0)
                        sum = (int)temp.Sum();

                    if (sum >= dbContext.PrintingHouses.Where(ph => ph.PrintingHouseName == cmdPrintingHouses.SelectedItem.ToString()).FirstOrDefault().MaxEdition ||
                        sum + Edition > dbContext.PrintingHouses.Where(ph => ph.PrintingHouseName == cmdPrintingHouses.SelectedItem.ToString()).FirstOrDefault().MaxEdition)
                    {
                        MessageBox.Show("Суммарный тираж газет превышает максимальный тираж типографии", "Ошибка");
                        return;
                    }

                    printingNewspaper = new PrintingNewspapers()
                    {
                        PrintingHouseName = cmdPrintingHouses.SelectedItem.ToString(),
                        NewspaperName = cmdNewspapers.SelectedItem.ToString(),
                        Edition = Edition
                    };
                    dbContext.PrintingNewspapers.Add(printingNewspaper);
                    await dbContext.SaveChangesAsync();
                }
                MessageBox.Show($"Печать газет {printingNewspaper.NewspaperName} в типографии {printingNewspaper.PrintingHouseName} успешно оформлена.", "Успех");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }
    }
}
