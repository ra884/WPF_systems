using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Library_WPF_v2
{
    /// <summary>
    /// Interaction logic for book_list.xaml
    /// </summary>
    public partial class book_list : Page
    {
        public book_list(ObservableCollection<Book> ob)
        {
            InitializeComponent();
           books_list.ItemsSource= ob;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var book= books_list.SelectedItem as Book;
            NavigationService.Navigate(new book_details(book));
        }
    }
}
