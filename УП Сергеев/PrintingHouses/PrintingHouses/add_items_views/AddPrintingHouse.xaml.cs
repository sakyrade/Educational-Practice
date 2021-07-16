using PrintingHousesApp;
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

namespace PrintingHouses
{
    public partial class AddPrintingHouse : Page
    {
        private PrintingHousesApp.PrintingHouses printingHouse;
        public string PrintingHouseName { get; set; }
        public string Address { get; set; }
        public int MaxEdition { get; set; }

        public AddPrintingHouse()
        {
            InitializeComponent();
        }

        private async void AddItem(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PrintingHouseName) || string.IsNullOrWhiteSpace(Address) || MaxEdition <= 0)
            {
                MessageBox.Show("Введены не все параметры.", "Ошибка");
                return;
            }

            try
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    printingHouse = new PrintingHousesApp.PrintingHouses()
                    {
                        PrintingHouseName = PrintingHouseName,
                        PrintingHouseAddress = Address,
                        MaxEdition = MaxEdition
                    };
                    dbContext.PrintingHouses.Add(printingHouse);
                    await dbContext.SaveChangesAsync();
                }
                MessageBox.Show($"Типография {printingHouse.PrintingHouseName} успешно добавлена.", "Успех");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }
    }
}
