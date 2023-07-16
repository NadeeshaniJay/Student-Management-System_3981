using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeage()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4!", "Error!");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted Successfuly!", "DELETED! \a ");            
            }
            else
            {
                MessageBox.Show("Please Select User!", "Error!");
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();

                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }

            else
            {
                MessageBox.Show("Please Select the User!", "Error!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(23, "Nadeeshani", "Jayarathne", "15/1/2000",3.7,image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(24, "Widura", "Hettigamage", "09/10/1998",3.5,image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(24, "Isurika", "Perera", "17/04/1998",3.1,image3));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(22, "Kavindhya", "Dias", "02/10/2001",3.3, image4));

        }
    }
}
