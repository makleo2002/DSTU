using System.Diagnostics;

namespace InfoLab5
{
    public partial class Form1 : Form
    {
        private const int mapSize = 10;
        private const int cellSize = 30;
        private string curUser;
        private static TextBox UserNameTextBox = new TextBox();
        private TextBox regTextBox = new();
        private ListBox infoListBox = new ListBox();
        private List<string> users = new List<string>();
        private List<string> phrases;
        private Dictionary<string, Dictionary<string, List<double>>> userStats;
        private int count = 4;
        private int attempts = 5;
        private const int lockTime = 20;
        private DateTime? lockoutTime = null;
        public Form1()
        {
            InitializeComponent();
            userStats = new();

            phrases= new() { "Какое же чудо - снежинка на ладони!", "Синхронные пробеги на лыжах - отличный способ нагрузиться.",
            "Жизнь - как океан, надо уметь нырять и выбирать правильный курс.", "Вечер, здание университета - только здесь ты понимаешь, как много не знаешь.",
            "Убегать от проблем - это не решение, лучше смотреть правде в глаза.", "Человек должен расти и развиваться каждый день, иначе он начинает угасать.",
            "Работа над ошибками - это то, что отличает чемпиона от проигравшего.", "Счастливые люди не те, у кого все идеально, а те, кто умеют находить счастье в простых вещах.",
            "Любовь - это когда не нужно говорить словами, все понимается по взгляду.", "Без мечты жизнь была бы скучной, но без действий мечта останется мечтой." };
                    
            // Создаем Panel для размещения элементов входа
            Panel loginPanel = new Panel();
            loginPanel.Location = new Point(mapSize * cellSize, 0);
            loginPanel.Size = new Size(200, this.ClientSize.Height);
            this.Controls.Add(loginPanel);

            // Создаем ListBox для вывода информации
            infoListBox.Location = new Point(mapSize * cellSize, 100);
            infoListBox.Size = new Size(500, 350);
              this.Controls.Add(infoListBox);
            // перемещаем ListBox вверх списка элементов
            infoListBox.BringToFront();
            infoListBox.ScrollAlwaysVisible = true;

            Label label = new();
            label.Location = new Point(125, (mapSize - 4) * cellSize);
            label.Text = "Имя";
            this.Controls.Add(label);

            // Создаем TextBox для ввода имени пользователя
            UserNameTextBox.Location = new Point(45, (mapSize - 3) * cellSize);
            UserNameTextBox.Size = new Size(200, 25);
            this.Controls.Add(UserNameTextBox);

            // Создаем кнопку для ввода
            Button regButton = new Button();
            regButton.Location = new Point(45, (mapSize - 2) * cellSize);
            regButton.Size = new Size(200, cellSize);
            regButton.Text = "Регистрация";
            regButton.Click += new EventHandler(RegisterButton_Click);
            this.Controls.Add(regButton);

            Button findButton = new Button();
            findButton.Location = new Point(45, (mapSize - 1) * cellSize);
            findButton.Size = new Size(200, cellSize);
            findButton.Text = "Поиск";
            findButton.Click += new EventHandler(FindButton_Click);
            this.Controls.Add(findButton);

            // Создаем кнопку входа
            Button loginButton = new Button();
            loginButton.Location = new Point(45, (mapSize) * cellSize);
            loginButton.Size = new Size(200, cellSize);
            loginButton.Text = "Войти";
            loginButton.Click += new EventHandler(LoginButton_Click);
            this.Controls.Add(loginButton);

            // Создаем кнопку выхода
            Button logoutButton = new Button();
            logoutButton.Location = new Point(45, (mapSize + 1) * cellSize);
            logoutButton.Size = new Size(200, cellSize);
            logoutButton.Text = "Выйти";
            logoutButton.Click += new EventHandler(LogoutButton_Click);
            this.Controls.Add(logoutButton);
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string phrase;
            string user = UserNameTextBox.Text;
            //если поле ввода пользователя пустое
            if (string.IsNullOrWhiteSpace(user))
                infoListBox.Items.Add("Вы не ввели имя пользователя");
            //если нет
            else
            {
                List<double> times = new(count);
                var num = new Random().Next(0, phrases.Count);
                phrase = phrases[num];
                Stopwatch stopwatch = new Stopwatch();
                double time = 0;
                for (int i = 0; i < count; i++)
                {
                    // создаем новое окно с TextBox и кнопкой...
                    Form form = new Form();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Text = $"Введите фразу ({i + 1}/{count})";
                    form.Width = 450;
                    form.Height = 200;

                    stopwatch.Start();

                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(50, 100);
                    textBox.Width = 200;

                    Label label = new Label();
                    label.Text =  phrase;
                    label.Location = new Point(10, 20);
                    label.Size = new Size(390, 100);

                    Button button = new Button();
                    button.Text = "OK";
                    button.Location = new Point(270, 100);
                    button.Size = new(100,30);
                    button.Click += (s, ev) =>
                    {
                        if (textBox.Text == phrase)
                        {
                            stopwatch.Stop();
                            time = stopwatch.Elapsed.Seconds;
                            infoListBox.Items.Add($"Время ввода {i+1} фразы: {time} c");
                            times.Add(time);
                            stopwatch.Reset();
                            form.Close();
                        }
                        else MessageBox.Show("Неправильно введена фраза");
                    };
                    form.Controls.Add(textBox);
                    form.Controls.Add(button);
                    form.Controls.Add(label);
                    form.ShowDialog();
                }
                if (time > 0 && times.Count>3)
                {
                    infoListBox.Items.Add($"Пользователь {user} успешно зарегистрирован.");
                    Dictionary<string, List<double>> dict = new();
                    dict.Add(phrase, times);
                    userStats.Add(user, dict);
                    users.Add(user);
                    infoListBox.Items.Add($"Среднее время ввода фразы: {userStats[user].Values.ElementAt(0).Average()} c");
                }
                else infoListBox.Items.Add($"Пользователя \"{user}\" не удалось зарегистрировать.");
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            string user = UserNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(curUser)) {
                infoListBox.Items.Add("Пользователь "+curUser + " еще не вышел.");
                return;
            } 
                // если поле ввода пользователя пустое
            if (string.IsNullOrWhiteSpace(user))
            {
                infoListBox.Items.Add("Вы не ввели имя пользователя");
                return;
            }

            // если пользователь не зарегистрирован
            if (!userStats.ContainsKey(user))
                infoListBox.Items.Add("Пользователь с таким именем не зарегистрирован");
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                double time = 0;

                // создаем новое окно с TextBox и кнопкой...
                Form form = new Form();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"Введите фразу";
                form.Width = 450;
                form.Height = 200;

                stopwatch.Start();

                TextBox textBox = new TextBox();
                textBox.Location = new Point(50, 100);
                textBox.Width = 200;

                Button button = new Button();
                button.Text = "OK";
                button.Location = new Point(270, 100);
                button.Size = new(100, 30);
                button.Click += (s, ev) =>
                {
                    Dictionary<string, List<double>> dict = userStats[user];
                    string phrase = dict.Keys.ElementAt(0);
                    if (textBox.Text == phrase)
                    {
                        stopwatch.Stop();
                        time = stopwatch.Elapsed.Seconds;

                        infoListBox.Items.Add($"Время ввода фразы: {time} с");

                        double idealValue = 0;
                        double deviation = 0;
                        double userIdealValue = 0.0;
                        double userDeviation = 0.0;
                        double EPS = 0.09;
                        int len = phrase.Length;

                       //рассчитываем идеальное значение и отклонение для пользователя
                  
                        userIdealValue = time;

                        userIdealValue /= len;

                        userDeviation = Math.Abs(time - userIdealValue);

                        userDeviation /= len;

                        // вычисляем идеальное значение и отклонение
                        for (int i = 0; i < dict.Values.Count; i++)
                            idealValue += dict.Values.ElementAt(0)[i];
                        idealValue /= len;

                        for (int i = 0; i < dict.Values.Count; i++)
                            deviation += dict.Values.ElementAt(0)[i] - idealValue;
                        deviation /= len;

                      //  infoListBox.Items.Add($"idealValue: {idealValue} ");
                     //   infoListBox.Items.Add($"userIdealValue: {userIdealValue} ");
                      //  infoListBox.Items.Add($"deviation: {deviation}  ");
                      //  infoListBox.Items.Add($"userDeviation: {userDeviation}  ");
                        // проверяем идеальное значение и отклонение пользователя
                        if (Math.Abs(idealValue - userIdealValue) < EPS && Math.Abs(deviation - userDeviation) < EPS)
                        {
                            infoListBox.Items.Add($"Пользователь {user} успешно вошел");
                            curUser = user;
                            attempts = 5;
                        }
                        else
                        {
                            if (attempts == 0)
                            {
                                // Устанавливаем время блокировки пользователя и выводим сообщение
                                lockoutTime = DateTime.Now.AddSeconds(lockTime);
                                infoListBox.Items.Add($"Пользователь {user} заблокирован на {lockTime} секунд");

                                // Делаем неактивной кнопку входа и выводим сообщение о том, сколько времени осталось до разблокировки        
                                System.Windows.Forms.Timer unlockTimer = new System.Windows.Forms.Timer();
                                unlockTimer.Interval = 1000; // задаем интервал в одну секунду
                                unlockTimer.Tick += (s, ev) =>
                                {
                                    TimeSpan timeLeft = (DateTime)lockoutTime - DateTime.Now;
                                    if (timeLeft <= TimeSpan.Zero) // если время блокировки истекло
                                    {
                                        unlockTimer.Stop(); // останавливаем таймер
                                        infoListBox.Items.Add($"Пользователь {user} разблокирован");
                                    }
                                    else // если время блокировки еще не истекло
                                    {
                                        infoListBox.Items.Add($"Пользователь {user} заблокирован еще {timeLeft.TotalSeconds:F0} сек");
                                    }
                                };
                                unlockTimer.Start(); // запускаем таймер
                            }
                            else 
                            {
                                attempts--;
                                infoListBox.Items.Add($"Пользователь {user} не смог войти, осталось {attempts} попыток");
                            }
                        }

                        stopwatch.Reset();
                        form.Close();
                    }
                    else MessageBox.Show("Неправильно введена фраза");
                };

                form.Controls.Add(textBox); 
                form.Controls.Add(button);
                form.ShowDialog();
            }
        }
        private void FindButton_Click(object sender, EventArgs e)
        {
            bool find = false;
            string user = UserNameTextBox.Text;
            foreach(var i in userStats.Keys)
                if (user == i)
                {
                    find = true;
                    infoListBox.Items.Add("Пользователь "+user+":");
                    infoListBox.Items.Add("Ключевая фраза: " + userStats[user].Keys.ElementAt(0));
                    infoListBox.Items.Add("Среднее время ввода: " + userStats[user].Values.ElementAt(0).Average());
                }
            if (!find) infoListBox.Items.Add("Пользователь "+user + " не найден.");
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(curUser))
            {
                infoListBox.Items.Add("Выход пользователя " + curUser);
                curUser = "";
            }
            else infoListBox.Items.Add("Вы уже вышли.");
        }
    }
}