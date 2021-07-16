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

namespace PrintingHouses.add_items_views
{
    public partial class AddNewspaper : Page
    {
        private Newspapers newspaper;
        public string NewspaperName { get; set; }
        public string NewspaperIndex { get; set; }
        public string EditorFirstName { get; set; }
        public string EditorSecondName { get; set; }
        public string EditorLastName { get; set; }
        public double SubPrice { get; set; }

        public AddNewspaper()
        {
            InitializeComponent();
        }

        private async void AddItem(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewspaperIndex) || string.IsNullOrWhiteSpace(NewspaperName) || string.IsNullOrWhiteSpace(EditorFirstName) ||
                string.IsNullOrWhiteSpace(EditorSecondName) || string.IsNullOrWhiteSpace(EditorLastName) || double.IsNaN(SubPrice) || SubPrice < 0)
            {
                MessageBox.Show("Введены не все параметры.", "Ошибка");
                return;
            }
            try
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    newspaper = new Newspapers()
                    {
                        NewspaperName = NewspaperName,
                        NewspaperIndex = NewspaperIndex,
                        EditorFirstName = EditorFirstName,
                        EditorSecondName = EditorSecondName,
                        EditorLastName = EditorLastName,
                        SubPrice = SubPrice
                    };
                    dbContext.Newspapers.Add(newspaper);
                    await dbContext.SaveChangesAsync();
                }
                MessageBox.Show($"Газета {newspaper.NewspaperName} успешно добавлена.", "Успех");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }
    }
}
