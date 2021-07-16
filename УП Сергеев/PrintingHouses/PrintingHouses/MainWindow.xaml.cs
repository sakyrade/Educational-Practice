using PrintingHouses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrintingHousesApp
{
    public partial class MainWindow : Window
    {
        private List<DataGridTextColumn> columns;
        private Type targetTableType;
        public ICollection TargetTable { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetDataGridHeaders(ref DataGrid dataGrid, List<DataGridTextColumn> columns)
        {
            foreach (var c in columns) dataGrid.Columns.Add(c);
        }

        private async void AboutNewspapers(object sender, EventArgs e)
        {
            using (var dbContext = new CerberusDBEntities())
            {
                dataGrid.Visibility = Visibility.Visible;
                defaultLabel.Visibility = Visibility.Hidden;
                dataGrid.Columns.Clear();
                try
                {
                    await dbContext.Newspapers.LoadAsync();
                }
                catch (System.Data.Entity.Core.EntityException) 
                { 
                    dataGrid.Visibility = Visibility.Hidden; 
                    defaultLabel.Visibility = Visibility.Visible; 
                    defaultLabel.Content = "Не удалось подключиться к базе данных"; 
                }
                this.TargetTable = dbContext.Newspapers.Local.ToBindingList();
                targetTableType = typeof(Newspapers);
                columns = new List<DataGridTextColumn>()
                {
                    new DataGridTextColumn()
                    {
                        Header = "Наименование газеты",
                        Binding = new Binding("NewspaperName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Индекc",
                        Binding = new Binding("NewspaperIndex")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Фамилия редактора",
                        Binding = new Binding("EditorSecondName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Имя редактора",
                        Binding = new Binding("EditorFirstName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Отчество редактора",
                        Binding = new Binding("EditorLastName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Стоимость подписки",
                        Binding = new Binding("SubPrice")
                    }
                };
                SetDataGridHeaders(ref dataGrid, columns);
                dataGrid.ItemsSource = TargetTable;
            }
        }

        private async void PrintingNewspapers(object sender, EventArgs e)
        {
            using (var dbContext = new CerberusDBEntities())
            {
                dataGrid.Visibility = Visibility.Visible;
                defaultLabel.Visibility = Visibility.Hidden;
                dataGrid.Columns.Clear();
                try
                {
                    await dbContext.PrintingNewspapers.LoadAsync();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                    defaultLabel.Visibility = Visibility.Visible;
                    defaultLabel.Content = "Не удалось подключиться к базе данных";
                }
                this.TargetTable = dbContext.PrintingNewspapers.Local.ToBindingList();
                targetTableType = typeof(PrintingNewspapers);
                columns = new List<DataGridTextColumn>()
                {
                    new DataGridTextColumn()
                    {
                        Header = "Типография",
                        Binding = new Binding("PrintingHouseName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Название газеты",
                        Binding = new Binding("NewspaperName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Тираж",
                        Binding = new Binding("Edition")
                    }
                };
                SetDataGridHeaders(ref dataGrid, columns);
                dataGrid.ItemsSource = TargetTable;
            }
        }

        private async void DeliveriesPostOffices(object sender, EventArgs e)
        {
            using (var dbContext = new CerberusDBEntities())
            {
                dataGrid.Visibility = Visibility.Visible;
                defaultLabel.Visibility = Visibility.Hidden;
                dataGrid.Columns.Clear();
                try
                {
                    await dbContext.DeliveriesPostOffices.LoadAsync();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                    defaultLabel.Visibility = Visibility.Visible;
                    defaultLabel.Content = "Не удалось подключиться к базе данных";
                }
                this.TargetTable = await dbContext.DeliveriesPostOffices.Include(dpo => dpo.PrintingNewspapers).Include(dpo => dpo.PostOffices).ToListAsync();
                targetTableType = typeof(DeliveriesPostOffices);
                columns = new List<DataGridTextColumn>()
                {
                    new DataGridTextColumn()
                    {
                        Header = "Типография",
                        Binding = new Binding("PrintingNewspapers.PrintingHouseName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Название поставляемой газеты",
                        Binding = new Binding("PrintingNewspapers.NewspaperName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Тираж поставляемой газеты",
                        Binding = new Binding("PrintingNewspapers.Edition")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Почтовое отделение",
                        Binding = new Binding("PostOffices.PostOfficeName")
                    }
                };
                SetDataGridHeaders(ref dataGrid, columns);
                dataGrid.ItemsSource = TargetTable;
            }
        }

        private async void PrintingHouses(object sender, EventArgs e)
        {
            using (var dbContext = new CerberusDBEntities())
            {
                dataGrid.Visibility = Visibility.Visible;
                defaultLabel.Visibility = Visibility.Hidden;
                dataGrid.Columns.Clear();
                try
                {
                    await dbContext.PrintingHouses.LoadAsync();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                    defaultLabel.Visibility = Visibility.Visible;
                    defaultLabel.Content = "Не удалось подключиться к базе данных";
                }
                this.TargetTable = dbContext.PrintingHouses.Local.ToBindingList();
                targetTableType = typeof(PrintingHouses);
                columns = new List<DataGridTextColumn>()
                {
                    new DataGridTextColumn()
                    {
                        Header = "Типография",
                        Binding = new Binding("PrintingHouseName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Адрес",
                        Binding = new Binding("PrintingHouseAddress")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Максимальный тираж",
                        Binding = new Binding("MaxEdition")
                    }
                };
                SetDataGridHeaders(ref dataGrid, columns);
                dataGrid.ItemsSource = TargetTable;
            }
        }

        private async void PostOffices(object sender, EventArgs e)
        {
            using (var dbContext = new CerberusDBEntities())
            {
                dataGrid.Visibility = Visibility.Visible;
                defaultLabel.Visibility = Visibility.Hidden;
                dataGrid.Columns.Clear();
                try
                {
                    await dbContext.PostOffices.LoadAsync();
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                    defaultLabel.Visibility = Visibility.Visible;
                    defaultLabel.Content = "Не удалось подключиться к базе данных";
                }
                this.TargetTable = dbContext.PostOffices.Local.ToBindingList();
                targetTableType = typeof(PostOffices);
                columns = new List<DataGridTextColumn>()
                {
                    new DataGridTextColumn()
                    {
                        Header = "Наименование",
                        Binding = new Binding("PostOfficeName")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Адрес",
                        Binding = new Binding("PostOfficeAddress")
                    },
                    new DataGridTextColumn()
                    {
                        Header = "Номер телефона",
                        Binding = new Binding("PhoneNumber")
                    }
                };
                SetDataGridHeaders(ref dataGrid, columns);
                dataGrid.ItemsSource = TargetTable;
            }
        }

        private void InsertItem(object sender, EventArgs e)
        {
            if (TargetTable == null) return;
            AddItem addItem = new AddItem(TargetTable);
            addItem.ShowDialog();
            if (targetTableType == typeof(PrintingNewspapers))
                PrintingNewspapers(sender, e);
            if (targetTableType == typeof(DeliveriesPostOffices))
                DeliveriesPostOffices(sender, e);
            if (targetTableType == typeof(PostOffices))
                PostOffices(sender, e);
            if (targetTableType == typeof(PrintingHouses))
                PrintingHouses(sender, e);
            if (targetTableType == typeof(Newspapers))
                AboutNewspapers(sender, e);
        }

        private async void UpdateItem(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new CerberusDBEntities())
                {
                    foreach (var selectedItem in dataGrid.Items)
                    {
                        if (selectedItem is PrintingNewspapers)
                        {
                            var sum = ((ICollection<PrintingNewspapers>)dataGrid.ItemsSource).Where(pn => pn.NewspaperName == ((PrintingNewspapers)selectedItem).NewspaperName && pn.PrintingHouseName == ((PrintingNewspapers)selectedItem).PrintingHouseName).Select(pn => pn.Edition).Sum();

                            if (sum > (await dbContext.PrintingNewspapers.Include(pn => pn.PrintingHouses).ToListAsync()).FirstOrDefault().PrintingHouses.MaxEdition)
                            {
                                MessageBox.Show("Суммарный тираж газеты превышает максимальный тираж типографии", "Ошибка");
                                return;
                            }

                            if (((PrintingNewspapers)selectedItem).Edition < 0)
                            {
                                MessageBox.Show("Тираж не может быть меньше нуля.", "Ошибка");
                                return;
                            }

                            if (((PrintingNewspapers)selectedItem).Edition > (await dbContext.PrintingNewspapers.Include(pn => pn.PrintingHouses).ToListAsync()).FirstOrDefault().PrintingHouses.MaxEdition)
                            {
                                MessageBox.Show("Указан слишком большой тираж.", "Ошибка");
                                return;
                            }

                            var t = await dbContext.PrintingNewspapers.Where(n => n.C_id == ((PrintingNewspapers)selectedItem).C_id).FirstOrDefaultAsync();
                            t.NewspaperName = ((PrintingNewspapers)selectedItem).NewspaperName;
                            t.PrintingHouseName = ((PrintingNewspapers)selectedItem).PrintingHouseName;
                            t.Edition = ((PrintingNewspapers)selectedItem).Edition;

                            dbContext.Entry(t).State = EntityState.Modified;
                            await dbContext.SaveChangesAsync();
                            continue;
                        }

                        if (selectedItem is Newspapers)
                        {
                            if (((Newspapers)selectedItem).SubPrice < 0)
                            {
                                MessageBox.Show("Стоимость подписки не может быть меньше нуля", "Ошибка");
                                return;
                            }
                        }

                        if (selectedItem is PrintingHouses)
                        {
                            if (((PrintingHouses)selectedItem).MaxEdition < 0)
                            {
                                MessageBox.Show("Максимальный тираж не может быть меньше нуля.", "Ошибка");
                                return;
                            }
                        }

                        dbContext.Entry(selectedItem).State = EntityState.Modified;
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Такой объект уже существует.", "Ошибка");
            }
        }

        private async void DeleteItem(object sender, EventArgs e)
        {
            if (dataGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выделили ни одной строки для удаления.", "Ошибка");
                return;
            }

            using (var dbContext = new CerberusDBEntities())
            {
                foreach (var selectedItem in dataGrid.SelectedItems)
                    dbContext.Entry(selectedItem).State = EntityState.Deleted;
                MessageBoxResult r = Task.Run(() =>
                {
                    return MessageBox.Show("Вы действительно хотите удалить эти строки?", "Выберите действие", MessageBoxButton.YesNo);
                }).Result;

                if (r == MessageBoxResult.Yes)
                    await dbContext.SaveChangesAsync();
                else return;

                if (targetTableType == typeof(PrintingNewspapers))
                    PrintingNewspapers(sender, e);
                if (targetTableType == typeof(DeliveriesPostOffices))
                    DeliveriesPostOffices(sender, e);
                if (targetTableType == typeof(PostOffices))
                    PostOffices(sender, e);
                if (targetTableType == typeof(PrintingHouses))
                    PrintingHouses(sender, e);
                if (targetTableType == typeof(Newspapers))
                    AboutNewspapers(sender, e);
            }
        }
    }
}
