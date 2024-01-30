
using System.Runtime.CompilerServices;

namespace SeaFight
{
    class Map
    {
        public static int mapSize = 10;
        public static int cellSize = 30;
        public static Label game_over;
        public static int[,] myMap = new int[mapSize, mapSize];
        public static int[,] enemyMap = new int[mapSize, mapSize];

        public static Button[,] myButtons = new Button[mapSize, mapSize];
        public static Button[,] enemyButtons = new Button[mapSize, mapSize];

        public static void initShips(Ship[] ships)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    ships[i] = new Ship(4, rnd.Next(2) > 0);
                }
                else if (i > 0 && i <= 2)
                {
                    ships[i] = new Ship(3, rnd.Next(2) > 0);
                }
                else if (i > 2 && i <= 5)
                {
                    ships[i] = new Ship(2, rnd.Next(2) > 0);
                }
                else if (i > 5 && i < 10)
                {
                    ships[i] = new Ship(1, rnd.Next(2) > 0);
                }
            }
        }
        public static void positionShips(Ship[] ships, int[,] map)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10;)
            {
                if (ships[i].setPosition(rnd.Next(0, 10), rnd.Next(0, 10), map)) i++;
            }
        }
    }
    public partial class SeaFight : Form
    {
    
        public string alphabet = "АБВГДЕЖЗИК";
       
        public bool isPlaying = false;

        public Bot bot;

        public SeaFight()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Text = "Морской бой";
            Init();
        }

        public void Init()
        {
            isPlaying = false;
            CreateMaps();
            bot = new Bot();
            ConfigureShips();
            Map.enemyMap = bot.ConfigureShips();
        }

        public void CreateMaps()
        {
            this.Width = Map.mapSize * 2 * Map.cellSize + 50;
            this.Height = (Map.mapSize + 3) * Map.cellSize + 50;
            for (int i = 0; i < Map.mapSize; i++)
            {
                for (int j = 0; j < Map.mapSize; j++)
                {
                    Map.myMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(j * Map.cellSize, i * Map.cellSize);
                    button.Size = new Size(Map.cellSize, Map.cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    Map.myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < Map.mapSize; i++)
            {
                for (int j = 0; j < Map.mapSize; j++)
                {
                    Map.myMap[i, j] = 0;
                    Map.enemyMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(320 + j * Map.cellSize, i * Map.cellSize);
                    button.Size = new Size(Map.cellSize, Map.cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    Map.enemyButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            Label map1 = new Label();
            map1.Text = "Player's map";
            map1.Location = new Point((Map.mapSize * Map.cellSize / 2) - 40, Map.mapSize * Map.cellSize + 10);
            this.Controls.Add(map1);

            Label map2 = new Label();
            map2.Text = "Enemy's map";
            map2.Location = new Point(280 + Map.mapSize * Map.cellSize / 2, Map.mapSize * Map.cellSize + 10);
            this.Controls.Add(map2);

            Map.game_over = new Label();
            Map.game_over.Location = new Point(120 + Map.mapSize * Map.cellSize / 2, Map.mapSize * Map.cellSize + 60);
            this.Controls.Add(Map.game_over);

            Button clear = new Button();
            clear.Height = 30;
            clear.Text = "New game";
            clear.Location = new Point(280 + Map.mapSize * Map.cellSize / 2, Map.mapSize * Map.cellSize + 40);
            clear.Click += Clear_Click;
            this.Controls.Add(clear);

            Button startButton = new Button();
            startButton.Height = 30;
            startButton.Text = "Start Game";
            startButton.Click += Start;
            startButton.Location = new Point((Map.mapSize * Map.cellSize / 2) - 40, Map.mapSize * Map.cellSize + 40);
            this.Controls.Add(startButton);
        }

        private void Clear_Click(object? sender, EventArgs e)
        {
            this.Controls.Clear();
            Init();
        }

        public void Start(object sender, EventArgs e)
        {
            isPlaying = true;
            StartGame();
        }
        public async Task StartGame()
        {
            await Task.Run(() => PlayerShoot());
        }

        public bool CheckIfMapIsNotEmpty()//is map empty
        {
            bool isEmpty1 = true;
            bool isEmpty2 = true;
            for (int i = 1; i < Map.mapSize; i++)
            {
                for (int j = 1; j < Map.mapSize; j++)
                {
                    if (Map.myMap[i, j] != 0)
                        isEmpty1 = false;
                    if (Map.enemyMap[i, j] != 0)
                        isEmpty2 = false;
                }
            }
            if (isEmpty1 || isEmpty2)
                return false;
            else return true;
        }

        public int[,] ConfigureShips()
        {
            Ship[] ships = new Ship[10];
            Map.initShips(ships);
            Map.positionShips(ships, Map.myMap);
            return Map.myMap;
        }


        public void PlayerShoot()
        {
            if (isPlaying)
            {
                while (Map.game_over.Text == "")
                {
                    Random r = new Random();
                    int posX = r.Next(1, Map.mapSize);
                    int posY = r.Next(1, Map.mapSize);

                    while (Map.enemyButtons[posX, posY].BackColor == Color.Blue || Map.enemyButtons[posX, posY].BackColor == Color.Black)
                    {
                        posX = r.Next(1, Map.mapSize);
                        posY = r.Next(1, Map.mapSize);
                    }
                    Button pressedButton = Map.enemyButtons[posX, posY];
  
                    Shoot(pressedButton);

                    bool you_win = true;

                    bool enemy_win = true;

                    for (int i = 0; i < Map.mapSize - 1; i++)
                    {
                        for (int j = 0; j < Map.mapSize - 1; j++)
                        {
                            if (Map.myMap[i, j] == 1 && Map.myButtons[i, j].Text != "X")//если найден неподбитый корабль
                            {
                                enemy_win = false;
                                break;
                            }
                            if (!enemy_win) break;
                        }

                    }

                    for (int i = 0; i < Map.mapSize - 1; i++)
                    {
                        for (int j = 0; j < Map.mapSize - 1; j++)
                        {
                            if (Map.enemyMap[i, j] == 1 && Map.enemyButtons[i, j].Text != "X")//если найден неподбитый корабль
                            {
                                you_win = false;
                                break;
                            }
                            if (!you_win) break;
                        }

                    }


                    if (you_win || enemy_win)
                    {
                        if (you_win)
                        {
                            Map.game_over.Text = "Bot №1 win";
                            Map.game_over.BackColor = Color.Green;
                            isPlaying = false;
                            break;
                        }
                        if (enemy_win)
                        {
                            Map.game_over.Text = "Bot №2 win";
                            Map.game_over.BackColor = Color.Green;
                            isPlaying = false;
                            break;
                        }

                    }
                }
               
            }
          
            
        }
     
    
        public bool Shoot(Button pressedButton)
        {
         
            bool hit = false;
            if (isPlaying)
            {
                Thread.Sleep(1000);
               
                int delta = 0;
                if (pressedButton.Location.X > 320)
                    delta = 320;
                if (Map.enemyMap[pressedButton.Location.Y / Map.cellSize, (pressedButton.Location.X - delta) / Map.cellSize] != 0)
                {
                    hit = true;
                    Map.enemyMap[pressedButton.Location.Y / Map.cellSize, (pressedButton.Location.X - delta) / Map.cellSize] = 0;
                    pressedButton.BackColor = Color.Red;
                    pressedButton.Text = "X";
                }
                else
                {
                    hit = false;
                    if (pressedButton.BackColor != Color.Black && pressedButton.BackColor != Color.Red) bot.Shoot();
                    if (pressedButton.BackColor!=Color.Red) pressedButton.BackColor = Color.Black;

                }
            }
            if (hit) {
                Random r = new Random();
                int posX = r.Next(1, Map.mapSize);
                int posY = r.Next(1, Map.mapSize);

                while (Map.enemyButtons[posX, posY].BackColor == Color.Red || Map.enemyButtons[posX, posY].BackColor == Color.Black)
                {
                    posX = r.Next(1, Map.mapSize);
                    posY = r.Next(1, Map.mapSize);
                }

                Button button = Map.enemyButtons[posX,posY];
                Shoot(button);
            }
            return  hit;
        }
    }
}