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
        static int playerX = 0;
        static int playerY = 0;
        

        static void player()
        {


            if(playerHealth <= 0)
            {
                running = false;
                return;
            }

            Console.SetCursorPosition(playerX + 5, playerY + 5);
            Console.Write("X");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Health: {playerHealth}");
            Console.SetCursorPosition(0, 1);

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (!Console.KeyAvailable)
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
                            TakeDamage(enemyHealth[i]);
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
                            TakeDamage(enemyHealth[i]);
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
                            TakeDamage(enemyHealth[i]);
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
                            TakeDamage(enemyHealth[i]);
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

            Console.SetCursorPosition(playerX+5, playerY+5);
            Console.Write("X");


        }

        //enemies
        static int enemiesMove = 3;
        static int moveStart = enemiesMove;
        static List <int> enemyHealth = new List<int>();
        static List <int> enemyX = new List<int>();
        static List<int> enemyY = new List<int>();
        static int enemyCount;
        
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
                }



                if(enemiesMove == 0)
                {
                    Random targeting = new Random();
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
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
                                    TakeDamage(playerHealth);
                                    enemyY[i]++;
                                }
                            }
                        }
                        enemiesMove = moveStart;
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
            }













        }



        //damage
        static int TakeDamage(int hit)
        {


            //would add ability to set damage with second veriable but I'm using small numbers so the damage will always be 1 anyway
            hit--;
            



            return hit;

        }



    }
}
