using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guesses = { 15, 30, 45, 60, 75, 90, 100 };

            Console.WriteLine("Загадайте число от 0 до 100. Я угадаю его");

            foreach (int guess in guesses)
            {
                Console.WriteLine($"Я думаю, это {guess}.");
                Console.Write("Это (1) больше (2) меньше  (3) равно ");

                int answer = int.Parse(Console.ReadLine());

                if (answer == 1)
                {
                    continue; 
                }
                else if (answer == 2)
                {
                    
                    for (int i = guess - 14; i < guess; i++)
                    {
                        Console.WriteLine($"Тогда может, {i}?");
                        Console.Write("Это (1) больше (2) меньше  (3) равно ");

                        answer = int.Parse(Console.ReadLine());
                        if (answer == 3)
                        {
                            Console.WriteLine("Я угадал");
                            return;
                        }
                    }
                    break;
                }
                else if (answer == 3)
                {
                    Console.WriteLine("Я угадал");
                    return;
                }
            }

            Console.WriteLine("Вы точно загадали число от 0 до 100?");
        }
    }
}
    

