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
    /// Interaction logic for UserManagement_man.xaml
    /// </summary>
    public partial class UserManagement_man : Page
    {
        TaskManagementEntities db=new TaskManagementEntities();
        public UserManagement_man(Userr user)
        {
            InitializeComponent();
            status.ItemsSource=db.Tasks.Select(x=>x.Status).Distinct().ToList();
            info.ItemsSource = db.Tasks.Where(x => x.Userr.Role == "Employee").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t=new Task();
            t.TaskID =int.Parse( t_id.Text);
            t.Status=status.SelectedItem.ToString();
            t.Title = title.Text;
            t.Description=desc.Text;
            t.Userr = db.Userrs.FirstOrDefault(x => x.Name == emp.Text);
            db.Tasks.Add(t);
            db.SaveChanges();
        }
        //crashhhhhhhhhhhhhhhhh
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(t_id.Text);
            Task t = db.Tasks.FirstOrDefault(x => x.TaskID == id);
            if(t!=null)
            {
                
                db.Tasks.Remove(t);
                db.SaveChanges();
            }
        }
        //crashhhhhhhhhhhhhh
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(t_id.Text);
            Task task = db.Tasks.FirstOrDefault(x => x.TaskID == id);
            if (task != null)
            {
                if (!string.IsNullOrWhiteSpace(title.Text))
                {
                    task.Title = title.Text;
                }
                if (!string.IsNullOrWhiteSpace(desc.Text)) { task.Description = desc.Text; }
                string stat = status.Text;
                if (stat != null)
                {
                    task.Status = stat;
                }
                Userr u = db.Userrs.FirstOrDefault(x => x.Name == emp.Text);
                if (u!=null)
                {
                    task.Userr = u;
                }
                task.DueDate = null;
                db.SaveChanges();
            }
        }

    }
}
