using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ViewTasks_emp.xaml
    /// </summary>
    public partial class ViewTasks_emp : Page
    {
        public TaskManagementEntities db = new TaskManagementEntities();
        public Userr cur_user;
        public ViewTasks_emp(Userr user)
        {
            InitializeComponent();

            name.Content = user.Name;
            cur_user = user;
            pending.ItemsSource = db.Tasks
    .Where(x => x.UserID == user.UserID
             && (x.Status == "Pending" || x.Status == "In Progress"))
    .ToList();
            combo.ItemsSource = db.Tasks.Select(x => x.Status).Distinct().ToList();
            completed.ItemsSource = db.Tasks
              .Where(x => x.UserID == user.UserID && x.Status == "Completed")
              .ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(t_id.Text);
            var task = db.Tasks.FirstOrDefault(x => x.TaskID == id);
            if (task != null)
            {
                task.Status = combo.Text;
                db.SaveChanges();
                refresh(cur_user);
            }

        }
        private void refresh(Userr user)
        {
            pending.ItemsSource = db.Tasks
.Where(x => x.UserID == user.UserID
    && (x.Status == "Pending" || x.Status == "In Progress"))
.ToList();
            combo.ItemsSource = db.Tasks.Select(x => x.Status).Distinct().ToList();
            completed.ItemsSource = db.Tasks
              .Where(x => x.UserID == user.UserID && x.Status == "Completed")
              .ToList();
        }
    }
}
