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

namespace Demo2_WPF
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public TaskManagementEntities db = new TaskManagementEntities();
        public LogIn()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Userr userr = db.Userrs.FirstOrDefault(x => x.Password == pass.Text);
            if (userr != null&&userr.Name==name.Text)
            {
                if (userr.Role == "Employee")
                {
                    NavigationService.Navigate(new ViewTasks_emp(userr));
                }
                else
                {
                    NavigationService.Navigate(new UserManagement_man(userr));
                }
            }
        }
    }
}
