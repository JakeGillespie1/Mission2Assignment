using Mission2Assignment;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    private static void Main(string[] args)
    {
        /*Initialize a variable for number*/
        int number = 0;

        /*Create a new dice roll instance*/
        DiceRoll diceRoll = new DiceRoll();

        /*Get a number from the user and then store that number to a variable*/
        System.Console.WriteLine("Welcome to the dice throwing simulator!");
        System.Console.WriteLine("How many dice rolls would you like to simulate?");
        number = int.Parse(System.Console.ReadLine());

        /*Use the instance's class to call one of its class's methods.
         Store the return method to a new array in this program to be processed*/
        int[] numberArray = new int[number];
        numberArray = diceRoll.RollDice(number);

        /*Print initial results*/
        System.Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        System.Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        System.Console.WriteLine("Total number of rolls = " +  number.ToString());

        /*Set up a dictionary to count occurances also initialize a floating point number*/
        Dictionary<int, int> numberOccurances = new Dictionary<int, int>();

        /*Loop to process the array formed previously
        This loop will take each value in the numberArray and
        count the number of times it occurs*/
        foreach (int value in numberArray) 
        { 
            /*If the number is in the dictionary already, increment the number of times it occurs*/
            if (numberOccurances.ContainsKey(value))
            {
                numberOccurances[value] += 1;
            }

            /*If the number is not yet in the dictionary, then start it off at 1 occurance*/
            else
            {
                numberOccurances[value] = 1;
            }
        }

        for (int value = 2; value < 13; value++)
        {
            if (numberOccurances.ContainsKey(value)) 
            {
                continue;
            }
            else
            {
                numberOccurances[value] = 0;
            }
        }

        /*Sort the old dictionary, store that to a variable and then create a new sorted dictionary*/
        var sorted = numberOccurances.OrderBy(pair => pair.Key);
        Dictionary<int, int> sortedDictionary = new Dictionary<int, int>(sorted);

        /*Convert numbers to Percentages and print by iterating through the dictionary*/
        string stars = "";
        foreach (KeyValuePair<int, int> pair in sortedDictionary)
        {
            /*Convert dictionary value to a percentage*/
            int xValue = (int)Math.Floor((decimal)(pair.Value * 100) / number);
            /*Assign the proper number of 1% stars to the variable stars according to the conversion
             that just took place above*/
            for (int i = 0; i < xValue; i++)
            {
                stars += "*";
            }

            /*Print out the key and the results*/
            Console.WriteLine(pair.Key + ": " + stars);

            /*Re-initialize variables*/
            stars = "";
            xValue = 0;
        }

        /*Final Output*/
        System.Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");

    }
}