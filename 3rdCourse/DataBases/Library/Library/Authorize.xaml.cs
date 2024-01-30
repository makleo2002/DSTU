using Library.Models;
using System.Linq;
using System.Windows;

namespace Library
{
    
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow()
        {
            InitializeComponent();
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            // Показываем текст в PasswordBox
            passwordBox.Visibility = Visibility.Collapsed;
            password.Visibility = Visibility.Visible;
            password.Text = passwordBox.Password;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Скрываем текст в PasswordBox
            passwordBox.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Collapsed;
            passwordBox.Password = password.Text;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            bool user_found = false;
            bool admin_found = false;
            bool officer_found = false;
            string hashPass = md5.hashPassword(passwordBox.Password);

            using (LibraryContext db = new LibraryContext())
            {
                if (email.Text == "" || passwordBox.Password == "")
                {
                    MessageBox.Show("Введенные данные некорректны", "Ошибка ввода данных",
                        MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    return;
                }

                foreach (User user in db.Users)
                {
                    if (user.Email == email.Text && user.Password == hashPass)
                    {
                        user_found = true;
                        MainWindow window = new();
                        window.Show();
                        this.Close();
                        MessageBox.Show("Успешный вход", "Пользователь",
                             MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        break;
                    }
                }

                if (!user_found)
                {
                    foreach (Admin admin in db.Admins)
                    {
                        if (admin.Email == email.Text && admin.Password == hashPass)
                        {
                            admin_found = true;
                            Admin_panel panel = new();
                            panel.Show();
                            this.Close();
                            MessageBox.Show("Успешный вход", "Администратор",
                                 MessageBoxButton.OKCancel, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
                if (!user_found && !admin_found)
                {
                    // Load officers into memory
                    var officers = db.Officers.ToList();

                    foreach (Officer officer in officers)
                    {
                        if (officer.Email == email.Text && officer.Password == hashPass)
                        {
                            officer_found = true;
                            Officer_panel panel = new();
                            panel.Show();
                            this.Close();
                            MessageBox.Show("Успешный вход", "Кадровик", 
                                   MessageBoxButton.OKCancel, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
                if(!user_found && !admin_found && !officer_found)
                {
                    MessageBox.Show("Почта или пароль неверны", "Ошибка входа", 
                                   MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
        }
    }
}
