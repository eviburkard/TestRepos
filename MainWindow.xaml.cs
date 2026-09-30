using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using Siemens.Collaboration.Net.Extensions;
namespace PlayGround
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Users
        { get; set; }
        private int i = 0;

        public ObservableCollection<User> SelectedUsers
        { get; set; } = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Users = new ObservableCollection<User>();
            Users.Add(new User("Evi"));
            Users.Add(new User("Klaus"));
            Users.Add(new User("Hans"));

        }

        public class User : NotifyObject
        {
            public string Name
            {
                get => this.Get<string>();
                set => this.Set(value);
            }
            public User(string name)
            {
                Name = name;
            }
        }

        private void Button_AddUser(object sender, RoutedEventArgs e)
        {
            i++; ;
            Users.Add(new User("User_i"));
        }

        private void Button_RemoveUser(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                Users.Remove(lbUsers.SelectedItem as User);
            }
        }

        private void Button_SelectAll(object sender, RoutedEventArgs e)
        {
         // lbUsers.SelectAll();
         foreach (var item in lbUsers.Items)
            {
                lbUsers.SelectedItems.Add(item);
            }
          
        }

        private void lbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUsers.Clear();
            foreach (User user in lbUsers.SelectedItems)
            {
                SelectedUsers.Add(user);
            }
        }
    }
}