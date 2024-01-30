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

            phrases= new() { "����� �� ���� - �������� �� ������!", "���������� ������� �� ����� - �������� ������ �����������.",
            "����� - ��� �����, ���� ����� ������ � �������� ���������� ����.", "�����, ������ ������������ - ������ ����� �� ���������, ��� ����� �� ������.",
            "������� �� ������� - ��� �� �������, ����� �������� ������ � �����.", "������� ������ ����� � ����������� ������ ����, ����� �� �������� �������.",
            "������ ��� �������� - ��� ��, ��� �������� �������� �� ������������.", "���������� ���� �� ��, � ���� ��� ��������, � ��, ��� ����� �������� ������� � ������� �����.",
            "������ - ��� ����� �� ����� �������� �������, ��� ���������� �� �������.", "��� ����� ����� ���� �� �������, �� ��� �������� ����� ��������� ������." };
                    
            // ������� Panel ��� ���������� ��������� �����
            Panel loginPanel = new Panel();
            loginPanel.Location = new Point(mapSize * cellSize, 0);
            loginPanel.Size = new Size(200, this.ClientSize.Height);
            this.Controls.Add(loginPanel);

            // ������� ListBox ��� ������ ����������
            infoListBox.Location = new Point(mapSize * cellSize, 100);
            infoListBox.Size = new Size(500, 350);
              this.Controls.Add(infoListBox);
            // ���������� ListBox ����� ������ ���������
            infoListBox.BringToFront();
            infoListBox.ScrollAlwaysVisible = true;

            Label label = new();
            label.Location = new Point(125, (mapSize - 4) * cellSize);
            label.Text = "���";
            this.Controls.Add(label);

            // ������� TextBox ��� ����� ����� ������������
            UserNameTextBox.Location = new Point(45, (mapSize - 3) * cellSize);
            UserNameTextBox.Size = new Size(200, 25);
            this.Controls.Add(UserNameTextBox);

            // ������� ������ ��� �����
            Button regButton = new Button();
            regButton.Location = new Point(45, (mapSize - 2) * cellSize);
            regButton.Size = new Size(200, cellSize);
            regButton.Text = "�����������";
            regButton.Click += new EventHandler(RegisterButton_Click);
            this.Controls.Add(regButton);

            Button findButton = new Button();
            findButton.Location = new Point(45, (mapSize - 1) * cellSize);
            findButton.Size = new Size(200, cellSize);
            findButton.Text = "�����";
            findButton.Click += new EventHandler(FindButton_Click);
            this.Controls.Add(findButton);

            // ������� ������ �����
            Button loginButton = new Button();
            loginButton.Location = new Point(45, (mapSize) * cellSize);
            loginButton.Size = new Size(200, cellSize);
            loginButton.Text = "�����";
            loginButton.Click += new EventHandler(LoginButton_Click);
            this.Controls.Add(loginButton);

            // ������� ������ ������
            Button logoutButton = new Button();
            logoutButton.Location = new Point(45, (mapSize + 1) * cellSize);
            logoutButton.Size = new Size(200, cellSize);
            logoutButton.Text = "�����";
            logoutButton.Click += new EventHandler(LogoutButton_Click);
            this.Controls.Add(logoutButton);
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string phrase;
            string user = UserNameTextBox.Text;
            //���� ���� ����� ������������ ������
            if (string.IsNullOrWhiteSpace(user))
                infoListBox.Items.Add("�� �� ����� ��� ������������");
            //���� ���
            else
            {
                List<double> times = new(count);
                var num = new Random().Next(0, phrases.Count);
                phrase = phrases[num];
                Stopwatch stopwatch = new Stopwatch();
                double time = 0;
                for (int i = 0; i < count; i++)
                {
                    // ������� ����� ���� � TextBox � �������...
                    Form form = new Form();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Text = $"������� ����� ({i + 1}/{count})";
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
                            infoListBox.Items.Add($"����� ����� {i+1} �����: {time} c");
                            times.Add(time);
                            stopwatch.Reset();
                            form.Close();
                        }
                        else MessageBox.Show("����������� ������� �����");
                    };
                    form.Controls.Add(textBox);
                    form.Controls.Add(button);
                    form.Controls.Add(label);
                    form.ShowDialog();
                }
                if (time > 0 && times.Count>3)
                {
                    infoListBox.Items.Add($"������������ {user} ������� ���������������.");
                    Dictionary<string, List<double>> dict = new();
                    dict.Add(phrase, times);
                    userStats.Add(user, dict);
                    users.Add(user);
                    infoListBox.Items.Add($"������� ����� ����� �����: {userStats[user].Values.ElementAt(0).Average()} c");
                }
                else infoListBox.Items.Add($"������������ \"{user}\" �� ������� ����������������.");
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            string user = UserNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(curUser)) {
                infoListBox.Items.Add("������������ "+curUser + " ��� �� �����.");
                return;
            } 
                // ���� ���� ����� ������������ ������
            if (string.IsNullOrWhiteSpace(user))
            {
                infoListBox.Items.Add("�� �� ����� ��� ������������");
                return;
            }

            // ���� ������������ �� ���������������
            if (!userStats.ContainsKey(user))
                infoListBox.Items.Add("������������ � ����� ������ �� ���������������");
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                double time = 0;

                // ������� ����� ���� � TextBox � �������...
                Form form = new Form();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"������� �����";
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

                        infoListBox.Items.Add($"����� ����� �����: {time} �");

                        double idealValue = 0;
                        double deviation = 0;
                        double userIdealValue = 0.0;
                        double userDeviation = 0.0;
                        double EPS = 0.09;
                        int len = phrase.Length;

                       //������������ ��������� �������� � ���������� ��� ������������
                  
                        userIdealValue = time;

                        userIdealValue /= len;

                        userDeviation = Math.Abs(time - userIdealValue);

                        userDeviation /= len;

                        // ��������� ��������� �������� � ����������
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
                        // ��������� ��������� �������� � ���������� ������������
                        if (Math.Abs(idealValue - userIdealValue) < EPS && Math.Abs(deviation - userDeviation) < EPS)
                        {
                            infoListBox.Items.Add($"������������ {user} ������� �����");
                            curUser = user;
                            attempts = 5;
                        }
                        else
                        {
                            if (attempts == 0)
                            {
                                // ������������� ����� ���������� ������������ � ������� ���������
                                lockoutTime = DateTime.Now.AddSeconds(lockTime);
                                infoListBox.Items.Add($"������������ {user} ������������ �� {lockTime} ������");

                                // ������ ���������� ������ ����� � ������� ��������� � ���, ������� ������� �������� �� �������������        
                                System.Windows.Forms.Timer unlockTimer = new System.Windows.Forms.Timer();
                                unlockTimer.Interval = 1000; // ������ �������� � ���� �������
                                unlockTimer.Tick += (s, ev) =>
                                {
                                    TimeSpan timeLeft = (DateTime)lockoutTime - DateTime.Now;
                                    if (timeLeft <= TimeSpan.Zero) // ���� ����� ���������� �������
                                    {
                                        unlockTimer.Stop(); // ������������� ������
                                        infoListBox.Items.Add($"������������ {user} �������������");
                                    }
                                    else // ���� ����� ���������� ��� �� �������
                                    {
                                        infoListBox.Items.Add($"������������ {user} ������������ ��� {timeLeft.TotalSeconds:F0} ���");
                                    }
                                };
                                unlockTimer.Start(); // ��������� ������
                            }
                            else 
                            {
                                attempts--;
                                infoListBox.Items.Add($"������������ {user} �� ���� �����, �������� {attempts} �������");
                            }
                        }

                        stopwatch.Reset();
                        form.Close();
                    }
                    else MessageBox.Show("����������� ������� �����");
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
                    infoListBox.Items.Add("������������ "+user+":");
                    infoListBox.Items.Add("�������� �����: " + userStats[user].Keys.ElementAt(0));
                    infoListBox.Items.Add("������� ����� �����: " + userStats[user].Values.ElementAt(0).Average());
                }
            if (!find) infoListBox.Items.Add("������������ "+user + " �� ������.");
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(curUser))
            {
                infoListBox.Items.Add("����� ������������ " + curUser);
                curUser = "";
            }
            else infoListBox.Items.Add("�� ��� �����.");
        }
    }
}