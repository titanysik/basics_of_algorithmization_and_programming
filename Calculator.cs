using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Calculator
{
    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("Доступные операции: +, -, *, /");
        Console.WriteLine("Введите 'exit' для выхода\n");

        while (true)
        {
            try
            {
                Console.Write("Введите первое число: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;
                double num1 = double.Parse(input);

                Console.Write("Введите операцию (+, -, *, /): ");
                char op = char.Parse(Console.ReadLine());

                Console.Write("Введите второе число: ");
                double num2 = double.Parse(Console.ReadLine());

                double result = Calculate(num1, num2, op);
                Console.WriteLine($"Результат: {result}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, вводите числа корректно.\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}\n");
            }
        }
    }

    static double Calculate(double a, double b, char operation)
    {
        switch (operation)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/':
                if (b == 0) throw new DivideByZeroException();
                return a / b;
            default: throw new ArgumentException("Недопустимая операция");
        }
    }
}