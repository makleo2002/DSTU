

namespace InfoLab7
{
    public partial class Form1 : Form
    {
        private const int mapSize = 10;
        private const int cellSize = 30;
        private string curUser;
        private static TextBox UserNameTextBox = new TextBox();
        ListBox infoListBox = new ListBox();
        private List<string> users = new List<string> { "user1", "user2", "user3" };
        private Dictionary<string, Color[,]> userKeys = new Dictionary<string, Color[,]>();
        private static Button[,] Buttons = new Button[mapSize, mapSize];
        private int attempts = 5;
        private const int lockTime = 20;
        private DateTime? lockoutTime = null;
        public Form1()
        {
            InitializeComponent();
            // Создаем Panel для размещения элементов входа
            Panel loginPanel = new Panel();
            loginPanel.Location = new Point(mapSize * cellSize, 0);
            loginPanel.Size = new Size(200, this.ClientSize.Height);
            this.Controls.Add(loginPanel);

            // Создаем кнопки для графического ключа
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    button.Click += new EventHandler(Button_Click);
                    button.Name = i + "," + j;
                    Buttons[i,j]= button;
                    this.Controls.Add(button);
                }
            }
            // Создаем ListBox для вывода информации
            infoListBox.Location = new Point(mapSize * cellSize, 100);
            infoListBox.Size = new Size(500, 350);
            this.Controls.Add(infoListBox);
            // перемещаем ListBox вверх списка элементов
            infoListBox.BringToFront();
            infoListBox.ScrollAlwaysVisible = true;

            // Создаем TextBox для ввода имени пользователя
            UserNameTextBox.Location = new Point(10, 10);
            UserNameTextBox.Size = new Size(180, 25);
            loginPanel.Controls.Add(UserNameTextBox);

            // Создаем кнопку входа
            Button loginButton = new Button();
            loginButton.Location = new Point(10, 40);
            loginButton.Size = new Size(180, 25);
            loginButton.Text = "Войти";
            loginButton.Click += new EventHandler(LoginButton_Click);
            loginPanel.Controls.Add(loginButton);

            Button logoutButton = new Button();
            logoutButton.Location = new Point(10, 70);
            logoutButton.Size = new Size(180, 25);
            logoutButton.Text = "Выйти";
            logoutButton.Click += new EventHandler(LogoutButton_Click);
            loginPanel.Controls.Add(logoutButton);

            // Создаем кнопку для очистки графического ключа
            Button clearButton = new Button();
            clearButton.Location = new Point(0, mapSize * cellSize);
            clearButton.Size = new Size(mapSize * cellSize, cellSize);
            clearButton.Text = "Очистить";
            clearButton.Click += new EventHandler(ClearButton_Click);
            this.Controls.Add(clearButton);

            // Создаем кнопку для сохранения графического ключа
            Button saveButton = new Button();
            saveButton.Location = new Point(0, (mapSize + 1) * cellSize);
            saveButton.Size = new Size(mapSize * cellSize, cellSize);
            saveButton.Text = "Зарегистрировать ключ";
            saveButton.Click += new EventHandler(SaveButton_Click);
            this.Controls.Add(saveButton);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text;
            if (lockoutTime != null)
            {
                TimeSpan remainingTime = lockoutTime.Value.Add(TimeSpan.FromSeconds(lockTime)) - DateTime.Now;//вычисляем оставшееся время
                if ((int)remainingTime.TotalSeconds>0)
                {
                    infoListBox.Items.Add("Попробуйте снова через " + (int)remainingTime.TotalSeconds + " секунд");
                    return;
                }
                else//если время 0,то снимаем ограничение на вход
                {
                    lockoutTime = null;
                    attempts = 5;
                    infoListBox.Items.Add("Попробуйте войти снова");
                    return;
                }
            }
            if (attempts == 0)
            {
                lockoutTime = DateTime.Now;
                infoListBox.Items.Add("Попытки кончились. Попробуйте снова через " + lockTime + " секунд");
                return;
            }
            if (!string.IsNullOrWhiteSpace(curUser))
            {
                infoListBox.Items.Add(curUser + " не вышел из системы");
                return;
            }
            if(users.Contains(userName))
            {
                if (userKeys.ContainsKey(userName))
                {
                    Color[,] key = userKeys[userName];
                    if (CheckKey(key))
                    {
                        curUser = userName;
                        infoListBox.Items.Add(curUser + " вошел в систему");
                    }
                    else
                    {
                        infoListBox.Items.Add("Графический ключ не верен. Попробуйте еще.");
                        infoListBox.Items.Add("Осталось "+attempts+" попыток");
                        attempts--;
                    }
                }
                else
                {
                    infoListBox.Items.Add("Графический ключ для пользователя " + userName + " не найден.");
                }
            }
            else
            {
                infoListBox.Items.Add("Пользователь " + userName + " не найден.");
            }
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(curUser)) {
                infoListBox.Items.Add("Выход пользователя " + curUser);
                curUser = "";
            }
            else infoListBox.Items.Add("Вы не смогли войти или уже вышли");
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string[] str = button.Name.Split(',');
            int row = int.Parse(str[0]);
            int col = int.Parse(str[1]);
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Blue;
                Buttons[row, col] = button;
            }
            else if(button.BackColor == Color.Blue)
            {
                button.BackColor = Color.White;
                Buttons[row, col] = button;
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapSize; i++)
                for (int j = 0; j < mapSize; j++)
                    Buttons[i, j].BackColor = Color.White;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Проверить, что графический ключ не пустой
            if (!IsKeyValid())
            {
                infoListBox.Items.Add("Графический ключ не может быть пустым.");
                return;
            }
            string userName = "";
            userName = Microsoft.VisualBasic.Interaction.InputBox("Введите имя пользователя:", "Регистрация пользователя", "");
            if (users.Contains(userName))
            {
                // Сохранить ключ в словаре для данного пользователя
                if (userKeys.ContainsKey(userName))
                {
                    Color[,] mas = new Color[mapSize, mapSize];
                    for (int i = 0; i < mapSize; i++)
                        for (int j = 0; j < mapSize; j++)
                            mas[i, j] = Buttons[i, j].BackColor;
                    userKeys[userName] = mas;
                }
                else
                {
                    Color[,] mas = new Color[mapSize, mapSize];
                    for (int i = 0; i < mapSize; i++)
                        for (int j = 0; j < mapSize; j++)
                            mas[i, j] = Buttons[i, j].BackColor;
                    userKeys.Add(userName, mas);
                }
                // Вывести сообщение об успешном сохранении
                infoListBox.Items.Add("Графический ключ для пользователя " + userName + " сохранен.");
            }
            else
            {
                infoListBox.Items.Add("Пользователь " + userName + " не найден.");
            }
            
        }
        private bool IsKeyValid()
        {
            for (int i = 0; i < Buttons.GetLength(0); i++)
            {
                for (int j = 0; j < Buttons.GetLength(1); j++)
                    if (Buttons[i, j].BackColor == Color.Blue)
                        return true;
            }
            return false;
        }
        private bool CheckKey(Color[,] key)
        {
            for (int i = 0; i < key.GetLength(0); i++)
            {
                for (int j = 0; j < key.GetLength(1); j++)
                    if (key[i, j] != Buttons[i, j].BackColor)
                        return false;
            }
            return true;
        }
    }
}