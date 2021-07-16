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
    public partial class AddPostOffice : Page
    {
        private PostOffices postOffice;
        public string PostOfficeName { get; set; }
        public string PhoneNumber { get; set; }
        public string PostOfficeAddress { get; set; }
        
        public AddPostOffice()
        {
            InitializeComponent();
        }

        private async void AddItem(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PostOfficeName) || string.IsNullOrWhiteSpace(PhoneNumber) || string.IsNullOrWhiteSpace(PostOfficeAddress))
            {
                MessageBox.Show("Введены не все параметры.", "Ошибка");
                return;
            }

            try
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    postOffice = new PostOffices()
                    {
                        PostOfficeName = PostOfficeName,
                        PhoneNumber = PhoneNumber,
                        PostOfficeAddress = PostOfficeAddress
                    };
                    dbContext.PostOffices.Add(postOffice);
                    await dbContext.SaveChangesAsync();
                }
                MessageBox.Show($"Почтовое отделение {postOffice.PostOfficeName} успешно добавлено.", "Успех");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }
    }
}
