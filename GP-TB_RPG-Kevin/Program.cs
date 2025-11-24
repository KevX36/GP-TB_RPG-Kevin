using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GP_TB_RPG_Kevin
{
    internal class Program
    {



        static bool running = true;
        static int minBoundery = 0;
        static int maxBoundery = 19;




        static void Main(string[] args)
        {
            Console.CursorVisible = (false);
            
            AddEnemy(10, true);
            AddEnemy(10, true);


            while (running == true)
            {
                MapDraw();
                Enemy();
                Player();
                if (enemyCount <= 0)
                {
                    enemyX.Clear();
                    enemyY.Clear();
                    enemyHealth.Clear();
                    AddEnemy(10);
                    AddEnemy(10);
                }
                


            }


            Console.Clear();
            Console.WriteLine("GameOver");
            Console.ReadKey();








        }

        //map

        //reads map
        static string[] map1D = File.ReadAllLines(@"C:\Kevin's unity projects\GP-TB_RPG-Kevin\GP-TB_RPG-Kevin\Map.txt");
        static char[,] map = new char[,]
        {
            { map1D[0][0], map1D[0][1], map1D[0][2], map1D[0][3], map1D[0][4], map1D[0][5], map1D[0][6], map1D[0][7], map1D[0][8], map1D[0][9], map1D[0][10], map1D[0][11], map1D[0][12], map1D[0][13], map1D[0][14], map1D[0][15], map1D[0][16], map1D[0][17], map1D[0][18], map1D[0][19] },
            { map1D[1][0], map1D[1][1], map1D[1][2], map1D[1][3], map1D[1][4], map1D[1][5], map1D[1][6], map1D[1][7], map1D[1][8], map1D[1][9], map1D[1][10], map1D[1][11], map1D[1][12], map1D[1][13], map1D[1][14], map1D[1][15], map1D[1][16], map1D[1][17], map1D[1][18], map1D[1][19] },
            { map1D[2][0], map1D[2][1], map1D[2][2], map1D[2][3], map1D[2][4], map1D[2][5], map1D[2][6], map1D[2][7], map1D[2][8], map1D[2][9], map1D[2][10], map1D[2][11], map1D[2][12], map1D[2][13], map1D[2][14], map1D[2][15], map1D[2][16], map1D[2][17], map1D[2][18], map1D[2][19] },
            { map1D[3][0], map1D[3][1], map1D[3][2], map1D[3][3], map1D[3][4], map1D[3][5], map1D[3][6], map1D[3][7], map1D[3][8], map1D[3][9], map1D[3][10], map1D[3][11], map1D[3][12], map1D[3][13], map1D[3][14], map1D[3][15], map1D[3][16], map1D[3][17], map1D[3][18], map1D[3][19] },
            { map1D[4][0], map1D[4][1], map1D[4][2], map1D[4][3], map1D[4][4], map1D[4][5], map1D[4][6], map1D[4][7], map1D[4][8], map1D[4][9], map1D[4][10], map1D[4][11], map1D[4][12], map1D[4][13], map1D[4][14], map1D[4][15], map1D[4][16], map1D[4][17], map1D[4][18], map1D[4][19] },
            { map1D[5][0], map1D[5][1], map1D[5][2], map1D[5][3], map1D[5][4], map1D[5][5], map1D[5][6], map1D[5][7], map1D[5][8], map1D[5][9], map1D[5][10], map1D[5][11], map1D[5][12], map1D[5][13], map1D[5][14], map1D[5][15], map1D[5][16], map1D[5][17], map1D[5][18], map1D[5][19] },
            { map1D[6][0], map1D[6][1], map1D[6][2], map1D[6][3], map1D[6][4], map1D[6][5], map1D[6][6], map1D[6][7], map1D[6][8], map1D[6][9], map1D[6][10], map1D[6][11], map1D[6][12], map1D[6][13], map1D[6][14], map1D[6][15], map1D[6][16], map1D[6][17], map1D[6][18], map1D[6][19] },
            { map1D[7][0], map1D[7][1], map1D[7][2], map1D[7][3], map1D[7][4], map1D[7][5], map1D[7][6], map1D[7][7], map1D[7][8], map1D[7][9], map1D[7][10], map1D[7][11], map1D[7][12], map1D[7][13], map1D[7][14], map1D[7][15], map1D[7][16], map1D[7][17], map1D[7][18], map1D[7][19] },
            { map1D[8][0], map1D[8][1], map1D[8][2], map1D[8][3], map1D[8][4], map1D[8][5], map1D[8][6], map1D[8][7], map1D[8][8], map1D[8][9], map1D[8][10], map1D[8][11], map1D[8][12], map1D[8][13], map1D[8][14], map1D[8][15], map1D[8][16], map1D[8][17], map1D[8][18], map1D[8][19] },
            { map1D[9][0], map1D[9][1], map1D[9][2], map1D[9][3], map1D[9][4], map1D[9][5], map1D[9][6], map1D[9][7], map1D[9][8], map1D[9][9], map1D[9][10], map1D[9][11], map1D[9][12], map1D[9][13], map1D[9][14], map1D[9][15], map1D[9][16], map1D[9][17], map1D[9][18], map1D[9][19] },
            { map1D[10][0], map1D[10][1], map1D[10][2], map1D[10][3], map1D[10][4], map1D[10][5], map1D[10][6], map1D[10][7], map1D[10][8], map1D[10][9], map1D[10][10], map1D[10][11], map1D[10][12], map1D[10][13], map1D[10][14], map1D[10][15], map1D[10][16], map1D[10][17], map1D[10][18], map1D[10][19] },
            { map1D[11][0], map1D[11][1], map1D[11][2], map1D[11][3], map1D[11][4], map1D[11][5], map1D[11][6], map1D[11][7], map1D[11][8], map1D[11][9], map1D[11][10], map1D[11][11], map1D[11][12], map1D[11][13], map1D[11][14], map1D[11][15], map1D[11][16], map1D[11][17], map1D[11][18], map1D[11][19] },
            { map1D[12][0], map1D[12][1], map1D[12][2], map1D[12][3], map1D[12][4], map1D[12][5], map1D[12][6], map1D[12][7], map1D[12][8], map1D[12][9], map1D[12][10], map1D[12][11], map1D[12][12], map1D[12][13], map1D[12][14], map1D[12][15], map1D[12][16], map1D[12][17], map1D[12][18], map1D[12][19] },
            { map1D[13][0], map1D[13][1], map1D[13][2], map1D[13][3], map1D[13][4], map1D[13][5], map1D[13][6], map1D[13][7], map1D[13][8], map1D[13][9], map1D[13][10], map1D[13][11], map1D[13][12], map1D[13][13], map1D[13][14], map1D[13][15], map1D[13][16], map1D[13][17], map1D[13][18], map1D[13][19] },
            { map1D[14][0], map1D[14][1], map1D[14][2], map1D[14][3], map1D[14][4], map1D[14][5], map1D[14][6], map1D[14][7], map1D[14][8], map1D[14][9], map1D[14][10], map1D[14][11], map1D[14][12], map1D[14][13], map1D[14][14], map1D[14][15], map1D[14][16], map1D[14][17], map1D[14][18], map1D[14][19] },
            { map1D[15][0], map1D[15][1], map1D[15][2], map1D[15][3], map1D[15][4], map1D[15][5], map1D[15][6], map1D[15][7], map1D[15][8], map1D[15][9], map1D[15][10], map1D[15][11], map1D[15][12], map1D[15][13], map1D[15][14], map1D[15][15], map1D[15][16], map1D[15][17], map1D[15][18], map1D[15][19] },
            { map1D[16][0], map1D[16][1], map1D[16][2], map1D[16][3], map1D[16][4], map1D[16][5], map1D[16][6], map1D[16][7], map1D[16][8], map1D[16][9], map1D[16][10], map1D[16][11], map1D[16][12], map1D[16][13], map1D[16][14], map1D[16][15], map1D[16][16], map1D[16][17], map1D[16][18], map1D[16][19] },
            { map1D[17][0], map1D[17][1], map1D[17][2], map1D[17][3], map1D[17][4], map1D[17][5], map1D[17][6], map1D[17][7], map1D[17][8], map1D[17][9], map1D[17][10], map1D[17][11], map1D[17][12], map1D[17][13], map1D[17][14], map1D[17][15], map1D[17][16], map1D[17][17], map1D[17][18], map1D[17][19] },
            { map1D[18][0], map1D[18][1], map1D[18][2], map1D[18][3], map1D[18][4], map1D[18][5], map1D[18][6], map1D[18][7], map1D[18][8], map1D[18][9], map1D[18][10], map1D[18][11], map1D[18][12], map1D[18][13], map1D[18][14], map1D[18][15], map1D[18][16], map1D[18][17], map1D[18][18], map1D[18][19] },
            { map1D[19][0], map1D[19][1], map1D[19][2], map1D[19][3], map1D[19][4], map1D[19][5], map1D[19][6], map1D[19][7], map1D[19][8], map1D[19][9], map1D[19][10], map1D[19][11], map1D[19][12], map1D[19][13], map1D[19][14], map1D[19][15], map1D[19][16], map1D[19][17], map1D[19][18], map1D[19][19] } 
        };

        static int mapX = map.GetLength(0);
        static int mapY = map.GetLength(1);
        static void MapDraw()
        {
            for(int i = 0; i < mapX; i++)
            {
                for (int j = 0; j < mapY; j++)
                {
                    //map draw and color cheak
                    Console.SetCursorPosition(j + 5, i + 5);
                    if (map[i, j] == '^')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else if (map[i, j] == '~')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (map[i, j] == '`')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(map[i, j]);
                    


                    //border draw
                    if (i == 0)
                    {
                        Console.SetCursorPosition(j + 5, i + 4);
                        Console.Write("-");
                        if (j == 0)
                        {
                            Console.SetCursorPosition(j + 4, i + 4);
                            Console.Write("+");
                        }
                        if (j == mapY - 1)
                        {
                            Console.SetCursorPosition(j + 6, i + 4);
                            Console.Write("+");
                        }
                    }
                    if (j == 0)
                    {
                        Console.SetCursorPosition(j + 4, i + 5);
                        Console.Write("|");
                    }
                    if (i == mapX - 1)
                    {
                        Console.SetCursorPosition(j + 5, i + 6);
                        Console.Write("-");
                        if (j == mapY - 1)
                        {
                            Console.SetCursorPosition(j + 6, i + 6);
                            Console.Write("+");
                        }
                        if (j == 0)
                        {
                            Console.SetCursorPosition(j + 4, i + 6);
                            Console.Write("+");
                        }
                    }
                    if (j == mapY - 1)
                    {
                        Console.SetCursorPosition(j + 6, i + 5);
                        Console.Write("|");
                    }

















                }
                
            }
        }







        //Player
        static int playerHealth = 100;
        static int playerX = minBoundery;
        static int playerY = minBoundery;
        static int count = 0;
        static int respawn = 0;
        
        static void Player()
        {


            if(playerHealth <= 0)
            {
                running = false;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(playerX + 5, playerY + 5);
            Console.Write("X");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Health: {playerHealth}   \tScore: {count}                              ");
            Console.SetCursorPosition(0, 1);

            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;


            if (input.Key == ConsoleKey.W)
            {
                playerY--;
                if (playerY < minBoundery)
                {
                    playerY = minBoundery;
                }
                for (int i = 0; i < enemyCount; i++)
                {
                    if (playerX == enemyX[i])
                    {
                        if (playerY == enemyY[i])
                        {
                            enemyHealth[i] = TakeDamage(enemyHealth[i]);
                            playerY++;
                        }
                    }
                }
                if (map[playerY,playerX] != '`')
                {
                    playerY++;
                }

            }
            if (input.Key == ConsoleKey.S)
            {
                playerY++;
                if (playerY > maxBoundery)
                {
                    playerY = maxBoundery;
                }
                for (int i = 0; i < enemyCount; i++)
                {
                    if (playerX == enemyX[i])
                    {
                        if (playerY == enemyY[i])
                        {
                            enemyHealth[i] = TakeDamage(enemyHealth[i]);
                            playerY--;
                        }
                    }
                    
                }
                if (map[playerY, playerX] != '`')
                {
                    playerY--;
                }
            }
            if (input.Key == ConsoleKey.A)
            {
                playerX--;
                if (playerX < minBoundery)
                {
                    playerX = minBoundery;
                }
                for (int i = 0; i < enemyCount; i++)
                {
                    if (playerX == enemyX[i])
                    {
                        if (playerY == enemyY[i])
                        {
                            enemyHealth[i] = TakeDamage(enemyHealth[i]);
                            playerX++;
                        }
                    }
                    
                }
                if (map[playerY, playerX] != '`')
                {
                    playerX++;
                }
            }
            if (input.Key == ConsoleKey.D)
            {
                playerX++;
                if (playerX > maxBoundery)
                {
                    playerX = maxBoundery;
                }
                for (int i = 0; i < enemyCount; i++)
                {
                    if (playerX == enemyX[i])
                    {
                        if (playerY == enemyY[i])
                        {
                            enemyHealth[i] = TakeDamage(enemyHealth[i]);
                            playerX--;
                        }
                    }
                    
                }
                if (map[playerY, playerX] != '`')
                {
                    playerX--;
                }
            }
            
            
            //draws player
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(playerX+5, playerY+5);
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;

        }

        //enemies
        
        static List <int> enemyHealth = new List<int>();
        static List <int> enemyX = new List<int>();
        static List<int> enemyY = new List<int>();
        static int enemyCount = 0;
        static Random targeting = new Random();
        //moves enemies
        static void Enemy()
        {
            
            
            
            //moves living
            for (int i = 0; i < enemyCount; i++)
            {
                
                


                int move = targeting.Next(1, 7);
                //does nothing
                if (move > 5)
                {
                    
                }
                // move on x
                else if (move > 3)
                {
                    if (playerX > enemyX[i])
                    {
                        enemyX[i]++;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyX[i]--;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyX[i]--;
                        }
                    }
                    if (playerX < enemyX[i])
                    {
                        enemyX[i]--;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyX[i]++;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyX[i]++;
                        }
                    }
                    
                }
                //move on y
                else if (move > 1)
                {
                    if (playerY > enemyY[i])
                    {
                        enemyY[i]++;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyY[i]--;
                            }
                            
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyY[i]--;
                        }
                    }
                    if (playerY < enemyY[i])
                    {
                        enemyY[i]--;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyY[i]++;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyY[i]++;
                        }
                    }
                    
                }
                //move on both
                else
                {
                    if (playerX > enemyX[i])
                    {
                        enemyX[i]++;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyX[i]--;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyX[i]--;
                        }
                    }
                    if (playerX < enemyX[i])
                    {
                        enemyX[i]--;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyX[i]++;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyX[i]++;
                        }
                    }
                    if (playerY > enemyY[i])
                    {
                        enemyY[i]++;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyY[i]--;
                            }
                            
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyY[i]--;
                        }
                    }
                    if (playerY < enemyY[i])
                    {
                        enemyY[i]--;
                        if (playerX == enemyX[i])
                        {
                            if (playerY == enemyY[i])
                            {
                                playerHealth = TakeDamage(playerHealth);
                                enemyY[i]++;
                            }
                        }
                        if (map[enemyY[i], enemyX[i]] != '`')
                        {
                            enemyY[i]++;
                        }
                    }
                    
                }
                
                
                












                if (enemyX[i] < minBoundery)
                {
                    enemyX[i] = minBoundery;
                }
                if (enemyY[i] < minBoundery)
                {
                    enemyY[i] = minBoundery;
                }
                if (enemyX[i] > maxBoundery)
                {
                    enemyX[i] = maxBoundery;
                }
                if (enemyY[i] > maxBoundery)
                {
                    enemyY[i] = maxBoundery;
                }
                Console.SetCursorPosition(enemyX[i] + 5, enemyY[i] + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
            }
            for (int i = enemyCount; i > 0; i--)
            {
                if (enemyHealth[i-1]== 0)
                {
                    enemyHealth.Remove(i - 1);
                    enemyX.Remove(i - 1);
                    enemyX.Remove(i - 1);
                    enemyCount --;
                    count++;
                    
                }
            }
            






            Console.ForegroundColor = ConsoleColor.White;



            
        }



        //damage
        static int TakeDamage(int hit)
        {


            //would add ability to set damage with second veriable but I'm using small numbers so the damage will always be 1 anyway
            hit--;
            



            return hit;

        }
        //can do other amounts of damage, unused here
        static int TakeDamage(int hit, int damage)
        {


            
            hit-= damage;




            return hit;

        }
        static Random startPoint = new Random();
        //adds new enemies
        static void AddEnemy(int HP)
        {
            
            int spawn = startPoint.Next(1, 5);
            enemyHealth.Add(HP);
            if(spawn == 1)
            {
                enemyX.Add(minBoundery);
                enemyY.Add(maxBoundery);
                Console.SetCursorPosition(minBoundery + 5, maxBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (spawn == 2)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(minBoundery);
                Console.SetCursorPosition(maxBoundery + 5, minBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (spawn == 3)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(maxBoundery);
                Console.SetCursorPosition(maxBoundery + 5, maxBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (spawn == 4)
            {
                enemyX.Add(minBoundery);
                enemyY.Add(minBoundery);
                Console.SetCursorPosition(minBoundery + 5, minBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            enemyCount++;
        }
        static void AddEnemy(int HP, bool start)
        {

            int spawn = startPoint.Next(1, 3);
            enemyHealth.Add(HP);
            if (spawn == 1)
            {
                enemyX.Add(minBoundery);
                enemyY.Add(maxBoundery);
                Console.SetCursorPosition(minBoundery + 5, maxBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (spawn == 2)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(minBoundery);
                Console.SetCursorPosition(maxBoundery + 5, minBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (spawn == 3)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(maxBoundery);
                Console.SetCursorPosition(maxBoundery + 5, maxBoundery + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;
            }
            enemyCount++;
        }

    }
}
