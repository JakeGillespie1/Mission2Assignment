using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Mission2Assignment
{
    internal class DiceRoll
    {
        public int[] RollDice(int number)
        {
            /*Initialize the roll and the array to store the rolls*/
            System.Random rnd = new Random();
            int[] array = new int[number];

            /*Loop to simulate a roll and return the arry to be printed*/
            for (int i = 0; i < number; i++) 
            { 
               int randomInt = rnd.Next(2,13);
               array[i] = randomInt;
            }
            Array.Sort(array);
            return array;
        }
    }
}
