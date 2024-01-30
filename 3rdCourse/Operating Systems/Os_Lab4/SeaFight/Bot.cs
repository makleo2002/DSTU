using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeaFight
    {
        public class Bot
        {
            public int[,] myMap = new int[Map.mapSize, Map.mapSize];//bot`s map
            public int[,] enemyMap = new int[Map.mapSize, Map.mapSize];//player`s map

            public Button[,] myButtons = new Button[Map.mapSize, Map.mapSize];//bot's cells
            public Button[,] enemyButtons = new Button[Map.mapSize, Map.mapSize];//player's cells

            public Bot()
            {
                this.myMap = Map.enemyMap;
                this.enemyMap = Map.myMap;
                this.enemyButtons = Map.myButtons;
                this.myButtons = Map.enemyButtons;
            }

            public bool IsInsideMap(int i, int j)//check valid cell
            {
                if (i < 0 || j < 0 || i >= Map.mapSize || j >= Map.mapSize)
                {
                    return false;
                }
                return true;
            }

            public bool IsEmpty(int i, int j, int length)//check empty cell
            {
                bool isEmpty = true;

                for (int k = j; k < j + length; k++)
                {
                    if (myMap[i, k] != 0)
                    {
                        isEmpty = false;
                        break;
                    }
                }

                return isEmpty;
            }

       
        public int[,] ConfigureShips()
        {
            Ship[] ships = new Ship[10];
            Map.initShips(ships);
            Map.positionShips(ships, myMap);
            return myMap;
        }


            public bool Shoot()
            {

                bool hit = false;
                Random r = new Random();

                int posX = r.Next(1, Map.mapSize);
                int posY = r.Next(1, Map.mapSize);

                while (enemyButtons[posX, posY].BackColor == Color.Blue || enemyButtons[posX, posY].BackColor == Color.Black)
                {
                    posX = r.Next(1, Map.mapSize);
                    posY = r.Next(1, Map.mapSize);
                }

                if (enemyMap[posX, posY] != 0)
                {
                    hit = true;
                    enemyMap[posX, posY] = 0;
                    enemyButtons[posX, posY].BackColor = Color.Blue;
                    enemyButtons[posX, posY].Text = "X";
                }
                else
                {
                    hit = false;
                    enemyButtons[posX, posY].BackColor = Color.Black;
                }
            if (hit) {
                Shoot();
            }
          
                return hit;
            }
        }
    }


