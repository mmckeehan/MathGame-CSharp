/* Basic build
- There are two numbers up to 6 numbers
- Number 1 must be higher than number 2 (-'s are still out of scope)
- Operation is randomized
- 10 Questions per round
- There will need to be a scoring system
*/

using System.Data.Common;
using System.Diagnostics;
using System;

const int numMin = 0;
const int numMax = 10000;

const int totalQuestions = 10;
int num1;
int num2;
int answer;
Random randNumber = new Random();

string[] operationSymbol = { "+", "-" };
Random randOp = new Random();

string guess;
int finalAnswer;
int score = 0;

bool playing = true;

while (playing == true)
{
    for (int i = 0; i < totalQuestions; i++)
    {
        int index = randOp.Next(operationSymbol.Length);


        num1 = randNumber.Next(numMin, numMax);
        num2 = randNumber.Next(numMin, numMax);

        // Making sure that num2 is less than num 1 to avoid (-) numbers
        while (num1 < num2)
        {
            num2 = randNumber.Next(numMin, numMax);
        }

        string num1String = num1.ToString();
        string num2String = num2.ToString();
        Debug.WriteLine($"Index: {index}, Op: {randOp}");

        // What they see and guess
        Console.WriteLine($"{num1String.PadLeft(10)}\n{operationSymbol[index]}{num2String.PadLeft(11 - operationSymbol.Length)}\n----------");
        guess = Console.ReadLine();


        // Logic to determine answer
        if (operationSymbol[index] == "+")
        {
            answer = num1 + num2;
        }
        else
        {
            answer = num1 - num2;
        }


        // Converting guess from String to int
        while (!int.TryParse(guess, out finalAnswer))
        {
            Console.WriteLine("That is not a valid number. Please guess again:");
            guess = Console.ReadLine();
        }
        if (finalAnswer == answer)
        {
            score++;
            Console.WriteLine("That is correct! :)\n\n");
        }
        else
        {
            Console.WriteLine("That is Incorrect. :(\n\n");
        }
    }

    Console.WriteLine($"Your score is {score} out of {totalQuestions}");
    Console.WriteLine("\n\nPlay again? Type 'Y' to keep playing, press any other key to quit");

    if (Console.ReadKey().Key == ConsoleKey.Y)
    {
        playing = true;
        score = 0;
    }
    else
    {
        playing = false;
    }

    Console.WriteLine("\n\n");

}









