using Library.Models;
using System.Windows;
using System.Windows.Controls;

namespace Library
{

    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
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
            AuthorizeWindow window = new();
            this.Close();
            window.Show();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            bool reg_user = false;
            bool reg_admin = false;
            bool reg_officer = false;
            string hashPass = md5.hashPassword(password.Text);

            if (fname.Text == "" || lname.Text == "" || email.Text == "" || password.Text == "")
            {
                MessageBox.Show("Введенные данные некорректны", "Ошибка ввода данных",
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            using (LibraryContext db = new LibraryContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Email == email.Text && user.Password == hashPass)
                    {
                        MessageBox.Show("Такой пользователь уже зарегистрирован", "Ошибка регистрации"
                            , MessageBoxButton.OKCancel, MessageBoxImage.Error);

                        reg_user = true;
                        break;
                    }
                }

                if (!reg_user)
                {
                    foreach (Admin admin in db.Admins)
                    {
                        if (admin.Email == email.Text && admin.Password == hashPass)
                        {
                            MessageBox.Show("Такой администратор уже зарегистрирован", "Ошибка регистрации",
                                MessageBoxButton.OKCancel, MessageBoxImage.Error);

                            reg_admin = true;
                            break;
                        }
                    }
                }

                if (!reg_user && !reg_admin)
                {
                    foreach (Officer officer in db.Officers)
                    {
                        if (officer.Email == email.Text && officer.Password == hashPass)
                        {
                            MessageBox.Show("Такой кадровик уже зарегистрирован", "Ошибка регистрации",
                                MessageBoxButton.OKCancel, MessageBoxImage.Error);

                            reg_officer = true;
                            break;
                        }
                    }
                }

                if (!reg_user && !reg_admin && !reg_officer)
                {
                    MessageBox.Show("Пользователь " + fname.Text + " " + lname.Text + " зарегистрирован", "Успешная регистрация",
                             MessageBoxButton.OKCancel, MessageBoxImage.Information);

                    db.Users.Add(new User(fname.Text, lname.Text, email.Text, hashPass));
                    db.SaveChanges();
                }
            }
        }
    }
}
