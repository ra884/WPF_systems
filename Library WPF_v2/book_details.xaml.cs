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

namespace Library_WPF_v2
{
    /// <summary>
    /// Interaction logic for book_details.xaml
    /// </summary>
    public partial class book_details : Page
    {
        public book_details(Book book)
        {
            InitializeComponent();
            title.Text= book.Title;
            cat.Text= book.Category;
            ISBN.Text=book.ISBN;
            author.Text= book.Author;
            qua.Text = book.Quantity.ToString();
            desc.Text= book.Description;
        }
    }
}
