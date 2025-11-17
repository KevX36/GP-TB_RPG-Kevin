using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GP_TB_RPG_Kevin
{
    internal class Program
    {



        static bool running = true;
        





        static void Main(string[] args)
        {


            while (running == true)
            {







            }











        }

        //Player
        static int playerHealth = 10;
        static int playerX = 0;
        static int playerY = 0;
        

        static void player()
        {
            Console.SetCursorPosition(0, 1);

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (!Console.KeyAvailable)
            {
                return;
            }
            if (input.Key == ConsoleKey.W)
            {
                playerY++;
            }
            if (input.Key == ConsoleKey.S)
            {
                playerY--;
            }
            if (input.Key == ConsoleKey.A)
            {
                playerX--;
            }
            if (input.Key == ConsoleKey.D)
            {
                playerX++;
            }




        }



        static int enemyHealth = 10;
        static int enemyX;
        static int enemyY;





        //damage
        static int TakeDamage(int hit)
        {


            //would add ability to set damage with second veriable but I'm using small numbers so the damage will always be 1 anyway
            hit--;

            return hit;

        }



    }
}
