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
            AddEnemy(10,true);
            AddEnemy(10,true);
            

            while (running == true)
            {
                Map();
                enemy();
                player();




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
        static int count = 0;
        static int respawn = 0;

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
            Console.WriteLine($"Health: {playerHealth}\tScore: {count}                              ");
            Console.SetCursorPosition(0, 1);

            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;


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
            if (playerX < minBoundery)
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
        
        static List <int> enemyHealth = new List<int>();
        static List <int> enemyX = new List<int>();
        static List<int> enemyY = new List<int>();
        static int enemyCount = 0;
        static Random targeting = new Random();
        static void enemy()
        {
            
            
            for (int i = 0; i < enemyCount; i++)
            {
                if (enemyHealth[i] <= 0)
                {
                    enemyX.Remove(i);
                    enemyY.Remove(i);
                    enemyHealth.Remove(i);
                    enemyCount--;
                    count++;
                    respawn++;
                    if(respawn == 2)
                    {
                        AddEnemy(10);
                        AddEnemy(10);


                        respawn = 0;
                    }
                }
            }
            for (int i = 0; i < enemyCount; i++)
            {
                
                Console.SetCursorPosition(enemyX[i] + 5, enemyY[i] + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");


                int move = targeting.Next(1, 6);
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
                    
                }

                Console.SetCursorPosition(enemyX[i]+5, enemyY[i]+5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.White;












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
