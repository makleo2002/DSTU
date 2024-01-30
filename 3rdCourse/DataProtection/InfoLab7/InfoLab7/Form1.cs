

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
            // ������� Panel ��� ���������� ��������� �����
            Panel loginPanel = new Panel();
            loginPanel.Location = new Point(mapSize * cellSize, 0);
            loginPanel.Size = new Size(200, this.ClientSize.Height);
            this.Controls.Add(loginPanel);

            // ������� ������ ��� ������������ �����
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
            // ������� ListBox ��� ������ ����������
            infoListBox.Location = new Point(mapSize * cellSize, 100);
            infoListBox.Size = new Size(500, 350);
            this.Controls.Add(infoListBox);
            // ���������� ListBox ����� ������ ���������
            infoListBox.BringToFront();
            infoListBox.ScrollAlwaysVisible = true;

            // ������� TextBox ��� ����� ����� ������������
            UserNameTextBox.Location = new Point(10, 10);
            UserNameTextBox.Size = new Size(180, 25);
            loginPanel.Controls.Add(UserNameTextBox);

            // ������� ������ �����
            Button loginButton = new Button();
            loginButton.Location = new Point(10, 40);
            loginButton.Size = new Size(180, 25);
            loginButton.Text = "�����";
            loginButton.Click += new EventHandler(LoginButton_Click);
            loginPanel.Controls.Add(loginButton);

            Button logoutButton = new Button();
            logoutButton.Location = new Point(10, 70);
            logoutButton.Size = new Size(180, 25);
            logoutButton.Text = "�����";
            logoutButton.Click += new EventHandler(LogoutButton_Click);
            loginPanel.Controls.Add(logoutButton);

            // ������� ������ ��� ������� ������������ �����
            Button clearButton = new Button();
            clearButton.Location = new Point(0, mapSize * cellSize);
            clearButton.Size = new Size(mapSize * cellSize, cellSize);
            clearButton.Text = "��������";
            clearButton.Click += new EventHandler(ClearButton_Click);
            this.Controls.Add(clearButton);

            // ������� ������ ��� ���������� ������������ �����
            Button saveButton = new Button();
            saveButton.Location = new Point(0, (mapSize + 1) * cellSize);
            saveButton.Size = new Size(mapSize * cellSize, cellSize);
            saveButton.Text = "���������������� ����";
            saveButton.Click += new EventHandler(SaveButton_Click);
            this.Controls.Add(saveButton);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text;
            if (lockoutTime != null)
            {
                TimeSpan remainingTime = lockoutTime.Value.Add(TimeSpan.FromSeconds(lockTime)) - DateTime.Now;//��������� ���������� �����
                if ((int)remainingTime.TotalSeconds>0)
                {
                    infoListBox.Items.Add("���������� ����� ����� " + (int)remainingTime.TotalSeconds + " ������");
                    return;
                }
                else//���� ����� 0,�� ������� ����������� �� ����
                {
                    lockoutTime = null;
                    attempts = 5;
                    infoListBox.Items.Add("���������� ����� �����");
                    return;
                }
            }
            if (attempts == 0)
            {
                lockoutTime = DateTime.Now;
                infoListBox.Items.Add("������� ���������. ���������� ����� ����� " + lockTime + " ������");
                return;
            }
            if (!string.IsNullOrWhiteSpace(curUser))
            {
                infoListBox.Items.Add(curUser + " �� ����� �� �������");
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
                        infoListBox.Items.Add(curUser + " ����� � �������");
                    }
                    else
                    {
                        infoListBox.Items.Add("����������� ���� �� �����. ���������� ���.");
                        infoListBox.Items.Add("�������� "+attempts+" �������");
                        attempts--;
                    }
                }
                else
                {
                    infoListBox.Items.Add("����������� ���� ��� ������������ " + userName + " �� ������.");
                }
            }
            else
            {
                infoListBox.Items.Add("������������ " + userName + " �� ������.");
            }
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(curUser)) {
                infoListBox.Items.Add("����� ������������ " + curUser);
                curUser = "";
            }
            else infoListBox.Items.Add("�� �� ������ ����� ��� ��� �����");
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
            // ���������, ��� ����������� ���� �� ������
            if (!IsKeyValid())
            {
                infoListBox.Items.Add("����������� ���� �� ����� ���� ������.");
                return;
            }
            string userName = "";
            userName = Microsoft.VisualBasic.Interaction.InputBox("������� ��� ������������:", "����������� ������������", "");
            if (users.Contains(userName))
            {
                // ��������� ���� � ������� ��� ������� ������������
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
                // ������� ��������� �� �������� ����������
                infoListBox.Items.Add("����������� ���� ��� ������������ " + userName + " ��������.");
            }
            else
            {
                infoListBox.Items.Add("������������ " + userName + " �� ������.");
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