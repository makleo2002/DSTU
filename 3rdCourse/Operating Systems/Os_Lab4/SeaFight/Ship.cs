using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Ship
    {
        private int[,] configMap;
        private int size;
        private bool horizont;
        public bool Horizont
        {
            get { return horizont; }
            set { horizont = value; }
        }
        public Ship(int size, bool horizont) {
            this.size = size;
            configMap = new int[10, 10];
            this.horizont = horizont;
            clearShip();
        }
        public bool setPosition(int x, int y, int[,] map) // set x,y from 1 to 10
        {

            if (map[y, x] != 1 && size != 1)
            {

                if (horizont)
                {
                    if ((x + size) < 10 - 1)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (scanAround(x + i, y, map) == false)
                            {
                                return false;
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                            configMap[y, x + i] = 1;
                        }
                        setMap(map);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((y + size) < 10 - 1)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (scanAround(x, y + i, map) == false)
                            {
                                return false;
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                           configMap[y + i, x] = 1;
                        }
                        setMap(map);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (map[y, x] != 1 && size == 1)
            {
                if (scanAround(x, y, map))
                {
                    configMap[y, x] = 1;
                    setMap(map);
                    return true;
                }
                else {
                    return false;
                }
            }
            else
                return false;
        }
        public int[,] getConfigMap() {
            return configMap;
        }
        private bool scanAround(int x, int y, int[,] map)
        {
            try
            {
                if (
                map[y, x + 1] != 1 && map[y + 1, x + 1] != 1 &&
                map[y + 1, x] != 1 && map[y + 1, x - 1] != 1 &&
                map[y, x - 1] != 1 && map[y - 1, x - 1] != 1 &&
                map[y - 1, x] != 1 && map[y - 1, x + 1] != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) { }
            return false;
        }
        public void setMap(int[,] map)
        {

            for (int i = 1; i < 10 - 1; i++)
            {
                for (int j = 1; j < 10 - 1; j++)
                {
                    if (getConfigMap()[i, j] == 1)
                        map[i, j] = 1;
                }
            }
        }
        public void clearShip() {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <10; j++)
                {
                    configMap[j, i] = 0;
                }
            }
        }

    }
}
