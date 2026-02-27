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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        LibraryEntities db = new LibraryEntities();
        public SignIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = db.Users.FirstOrDefault(x => x.Email == mail.Text );
                if (user != null && user.Password == pass.Password)
                {
                    NavigationService.Navigate(new book_filter());
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password");
                }
            }
        }
    }


