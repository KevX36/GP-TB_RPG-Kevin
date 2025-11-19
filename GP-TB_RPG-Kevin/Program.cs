using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GP_TB_RPG_Kevin
{
    internal class Program
    {



        static bool running = true;
        static int minBoundery = 0;
        static int maxBoundery = 20;




        static void Main(string[] args)
        {
            AddEnemy(10);
            AddEnemy(10);


            while (running == true)
            {
                Map();
                player();
                enemy();
                




            }











        }

        //map






        static void Map()
        {

        }







        //Player
        static int playerHealth = 10;
        static int playerX = minBoundery;
        static int playerY = minBoundery;
        

        static void player()
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
            Console.Write($"Health: {playerHealth}");
            Console.SetCursorPosition(0, 1);

            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.KeyAvailable)
            {
                return;
                
            }
            if (input.Key == ConsoleKey.W)
            {
                playerY--;
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
                
            }
            if (input.Key == ConsoleKey.S)
            {
                playerY++;
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
            }
            if (input.Key == ConsoleKey.A)
            {
                playerX--;
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
            }
            if (input.Key == ConsoleKey.D)
            {
                playerX++;
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
            }
            if(playerX < minBoundery)
            {
                playerX = minBoundery;
            }
            if (playerY < minBoundery)
            {
                playerY = minBoundery;
            }
            if (playerX > maxBoundery)
            {
                playerX = maxBoundery;
            }
            if (playerY > maxBoundery)
            {
                playerY = maxBoundery;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(playerX+5, playerY+5);
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;

        }

        //enemies
        static int enemiesMove = 3;
        static int moveStart = enemiesMove;
        static List <int> enemyHealth = new List<int>();
        static List <int> enemyX = new List<int>();
        static List<int> enemyY = new List<int>();
        static int enemyCount;
        static Random targeting = new Random();
        static void enemy()
        {
            enemiesMove--;
            for(int i = 0; i < enemyCount; i++)
            {
                if(enemyHealth[i] <= 0)
                {
                    enemyX.Remove(i);
                    enemyY.Remove(i);
                    enemyHealth.Remove(i);
                    enemyCount--;

                    

                }



                if(enemiesMove == 0)
                {
                    
                    int move = targeting.Next(1, 7);
                    if (move > 5)
                    {
                        return;
                    }
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
                        }
                        enemiesMove = moveStart;
                    }
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
                        }
                        enemiesMove = moveStart;
                    }
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
                        }
                        enemiesMove = moveStart;
                    }




                }

                Console.SetCursorPosition(enemyX[i]+5, enemyY[i]+5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");













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

        static Random startPoint = new Random();
        //adds new enemies
        static void AddEnemy(int HP)
        {
            
            int spawn = startPoint.Next(1, 3);
            enemyHealth.Add(HP);
            if(spawn == 1)
            {
                enemyX.Add(minBoundery);
                enemyY.Add(maxBoundery);
            }
            if (spawn == 2)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(minBoundery);
            }
            if (spawn == 3)
            {
                enemyX.Add(maxBoundery);
                enemyY.Add(maxBoundery);
            }
            enemyCount++;
        }


    }
}
