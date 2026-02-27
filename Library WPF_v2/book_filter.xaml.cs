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
    /// Interaction logic for book_filter.xaml
    /// </summary>
    public partial class book_filter : Page
    {
        LibraryEntities db=new LibraryEntities();
        public List<Book> books;
       ObservableCollection<Book> filtered_books=new ObservableCollection<Book>();
        public book_filter()
        {
            InitializeComponent();
            combo.ItemsSource = db.Books.Select(x => x.Category).Distinct().ToList();
            books=db.Books.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(combo.SelectedItem != null)
            {
                string ca=combo.SelectedItem.ToString();
                books=books.Where(x=>x.Category==ca).ToList();
            }
            if (check.IsChecked == true)
            {
                books=books.Where(x => x.Quantity>0).ToList();
            }
            if (tit.IsChecked == true)
            {
                books=books.OrderBy(x => x.Title).ToList();
            }
            else
            {
                books = books.OrderBy(x => x.Quantity).ToList();
            }
            foreach(Book book in books)
            {
                filtered_books.Add(book);
            }
            NavigationService.Navigate(new book_list(filtered_books));
        }
    }
}
