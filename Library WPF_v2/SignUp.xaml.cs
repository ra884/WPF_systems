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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        LibraryEntities db=new LibraryEntities();
        public SignUp()
        {
            InitializeComponent();
        }
        private void To_login(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignIn());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Password == confirm.Password)
            {
                User user = new User();
                user.Password = pass.Password;
                user.FullName=name.Text;
                user.Email=mail.Text;
                if (mem.IsChecked==true)
                {
                    user.Role = "Member";
                }
                else
                {
                    user.Role = "Librarian";
                }
                db.Users.Add(user);
                db.SaveChanges();
                NavigationService.Navigate(new SignIn());
            }
            else
            {
                MessageBox.Show("Not Matching");
            }

        }
    }
}
