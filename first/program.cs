using System;

namespace task1
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Enter your number in range of 1 to 100: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number >= 1 && number <= 100)
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    Console.WriteLine("Fizz Buzz");
                }
                else if (number % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (number % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("You entered incorrect number");
            }
        }
    }
}


namespace Task2
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Enter your number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter persantage you want to get: ");
            int perc = Convert.ToInt32(Console.ReadLine());
            double resault = number * (perc / 100.0);
            Console.WriteLine(resault);
        }
    }
}


namespace Task3
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Enter first number from 0 to 9: ");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number from 0 to 9: ");
            int second = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter third number from 0 to 9: ");
            int third = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter fourth number from 0 to 9:");
            int fourth = Convert.ToInt32(Console.ReadLine());
            if (first != 0)
            {
                int resault = first * 1000 + second * 100 + third * 10 + fourth;
                Console.WriteLine(resault);
            }
            else
            {
                int resault = second * 100 + third * 10 + fourth;
                Console.WriteLine(resault);

            }
        }
    }
}


namespace Task4
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Enter six digit number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 100000 || number > 999999)
            {
                Console.WriteLine("Error! Number must contain 6 digits.");
                return;
            }
            Console.WriteLine("Enter two digit positions (for example 16):");
            string positions = Console.ReadLine();

            int first = positions[0] - '1';
            int second = positions[1] - '1';
            if (positions.Length != 2 || first < 0 || first > 5 ||
               second < 0 || second > 5 || first == second)
            {
                Console.WriteLine("Invalid positions!");
                return;
            }
            char[] digit = number.ToString().ToCharArray();
            char temp = digit[first];
            digit[first] = digit[second];
            digit[second] = temp;

            Console.WriteLine(new string(digit));
        }
    }
}

namespace Task5
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Enter date (ex: 24.08.1991):");
            string date = Console.ReadLine();

            string[] parts = date.Split('.');

            int day = Convert.ToInt32(parts[0]);
            int month = Convert.ToInt32(parts[1]);
            int year = Convert.ToInt32(parts[2]);

            string season = "";


            if (month == 12 || month == 1 || month == 2)
                season = "Winter";
            else if (month >= 3 && month <= 5)
                season = "Spring";
            else if (month >= 6 && month <= 8)
                season = "Summer";
            else if (month >= 9 && month <= 11)
                season = "Autumn";

            DateTime dateTime = new DateTime(year, month, day);

            string dayOfWeek = dateTime.DayOfWeek.ToString();

            Console.WriteLine(season + " " + dayOfWeek);
        }
    }
}


namespace Task6
{
    class Program
    {
        public static void Run()
        {
            Console.WriteLine("Temperature converter");
            Console.WriteLine("1 - Fahrenheit to Celsius");
            Console.WriteLine("2 - Celsius to Fahrenheit");

            Console.Write("Choose conversion: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter temperature: ");
            double temperature = Convert.ToDouble(Console.ReadLine());

            double result = 0;

            switch (choice)
            {
                case 1:
                    result = (temperature - 32) * 5 / 9;
                    Console.WriteLine("Celsius: " + result);
                    break;

                case 2:
                    result = temperature * 9 / 5 + 32;
                    Console.WriteLine("Fahrenheit: " + result);
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}



namespace idk
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1.Program.Run();
            //Task2.Program.Run();
            //Task3.Program.Run();
            //Task4.Program.Run();
            //Task5.Program.Run();
            Task6.Program.Run();
        }
    }

}
