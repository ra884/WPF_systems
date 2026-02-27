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
    /// Interaction logic for borrowed_books.xaml
    /// </summary>
    public partial class borrowed_books : Page
    {
        LibraryEntities db = new LibraryEntities();
        public List<Book> books;
  

        ObservableCollection<Book> booksObservable=new ObservableCollection<Book>();
     
        public borrowed_books()
        {
            InitializeComponent();
          
            foreach (var record in db.BorrowRecords)
            {

                if (record.Status == "Borrowed")
                {
                    Book book = db.Books.FirstOrDefault(b => b.Id == record.BookId);

                    if (book != null)
                    {
                        booksObservable.Add(book);
                    }
                }
            }
            books = booksObservable.ToList();
            borrowed.ItemsSource = booksObservable;
        }
    }
}
