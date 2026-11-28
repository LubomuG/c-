namespace All
{
    public class Program
    {
        static System.Random random = new System.Random();

        public static void Run1()
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            for (int i = 0; i < 5; i++)
            {
                System.Console.Write("Введіть A[" + i + "]: ");
                A[i] = int.Parse(System.Console.ReadLine());
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.Next(0, 100) / 10.0;
                }
            }

            System.Console.WriteLine("Масив A:");

            for (int i = 0; i < 5; i++)
            {
                System.Console.Write(A[i] + " ");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Масив B:");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    System.Console.Write(B[i, j] + " ");
                }

                System.Console.WriteLine();
            }

            double min = A[0];
            double max = A[0];
            double sum = 0;
            double product = 1;
            int evenSum = 0;
            double oddColumnsSum = 0;

            for (int i = 0; i < 5; i++)
            {
                if (A[i] < min) min = A[i];
                if (A[i] > max) max = A[i];

                sum += A[i];
                product *= A[i];

                if (A[i] % 2 == 0)
                {
                    evenSum += A[i];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (B[i, j] < min) min = B[i, j];
                    if (B[i, j] > max) max = B[i, j];

                    sum += B[i, j];
                    product *= B[i, j];

                    if (j == 0 || j == 2)
                    {
                        oddColumnsSum += B[i, j];
                    }
                }
            }

            System.Console.WriteLine("Мінімум: " + min);
            System.Console.WriteLine("Максимум: " + max);
            System.Console.WriteLine("Сума всіх елементів: " + sum);
            System.Console.WriteLine("Добуток усіх елементів: " + product);
            System.Console.WriteLine("Сума парних елементів A: " + evenSum);
            System.Console.WriteLine("Сума непарних стовпців B: " + oddColumnsSum);
        }

        public static void Run2()
        {
            int[,] array = new int[5, 5];
            int min = 101;
            int max = -101;
            int minPosition = 0;
            int maxPosition = 0;

            System.Console.WriteLine("Масив:");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = random.Next(-100, 101);
                    System.Console.Write(array[i, j] + "\t");

                    int position = i * 5 + j;

                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minPosition = position;
                    }

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxPosition = position;
                    }
                }

                System.Console.WriteLine();
            }

            int start = minPosition;
            int end = maxPosition;

            if (start > end)
            {
                start = maxPosition;
                end = minPosition;
            }

            int sum = 0;

            for (int position = start + 1; position < end; position++)
            {
                int row = position / 5;
                int column = position % 5;
                sum += array[row, column];
            }

            System.Console.WriteLine("Мінімум: " + min);
            System.Console.WriteLine("Максимум: " + max);
            System.Console.WriteLine("Сума між ними: " + sum);
        }

        static string Caesar(string text, int shift)
        {
            string result = "";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string smallAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string ukrainianAlphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
            string smallUkrainianAlphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                string currentAlphabet = "";
                int position = -1;

                position = alphabet.IndexOf(letter);
                if (position >= 0) currentAlphabet = alphabet;

                if (position < 0)
                {
                    position = smallAlphabet.IndexOf(letter);
                    if (position >= 0) currentAlphabet = smallAlphabet;
                }

                if (position < 0)
                {
                    position = ukrainianAlphabet.IndexOf(letter);
                    if (position >= 0) currentAlphabet = ukrainianAlphabet;
                }

                if (position < 0)
                {
                    position = smallUkrainianAlphabet.IndexOf(letter);
                    if (position >= 0) currentAlphabet = smallUkrainianAlphabet;
                }

                if (position >= 0)
                {
                    int newPosition = (position + shift) % currentAlphabet.Length;

                    if (newPosition < 0)
                    {
                        newPosition += currentAlphabet.Length;
                    }

                    result += currentAlphabet[newPosition];
                }
                else
                {
                    result += letter;
                }
            }

            return result;
        }

        public static void Run3()
        {
            System.Console.Write("Введіть текст: ");
            string text = System.Console.ReadLine();

            System.Console.Write("Введіть зсув: ");
            int shift = int.Parse(System.Console.ReadLine());

            string encrypted = Caesar(text, shift);
            string decrypted = Caesar(encrypted, -shift);

            System.Console.WriteLine("Зашифрований текст: " + encrypted);
            System.Console.WriteLine("Розшифрований текст: " + decrypted);
        }

        static int[,] ReadMatrix(string name, int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];

            System.Console.WriteLine("Введіть матрицю " + name + ":");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    System.Console.Write(name + "[" + i + "," + j + "]: ");
                    matrix[i, j] = int.Parse(System.Console.ReadLine());
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Console.Write(matrix[i, j] + "\t");
                }

                System.Console.WriteLine();
            }
        }

        public static void Run4()
        {
            System.Console.WriteLine("1 — помножити матрицю на число");
            System.Console.WriteLine("2 — додати матриці");
            System.Console.WriteLine("3 — перемножити матриці");
            System.Console.Write("Ваш вибір: ");

            int choice = int.Parse(System.Console.ReadLine());

            if (choice == 1)
            {
                System.Console.Write("Кількість рядків: ");
                int rows = int.Parse(System.Console.ReadLine());

                System.Console.Write("Кількість стовпців: ");
                int columns = int.Parse(System.Console.ReadLine());

                int[,] matrix = ReadMatrix("A", rows, columns);

                System.Console.Write("На яке число помножити: ");
                int number = int.Parse(System.Console.ReadLine());

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] *= number;
                    }
                }

                PrintMatrix(matrix);
            }
            else if (choice == 2)
            {
                System.Console.Write("Кількість рядків: ");
                int rows = int.Parse(System.Console.ReadLine());

                System.Console.Write("Кількість стовпців: ");
                int columns = int.Parse(System.Console.ReadLine());

                int[,] first = ReadMatrix("A", rows, columns);
                int[,] second = ReadMatrix("B", rows, columns);
                int[,] result = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = first[i, j] + second[i, j];
                    }
                }

                PrintMatrix(result);
            }
            else if (choice == 3)
            {
                System.Console.Write("Рядків у матриці A: ");
                int rowsA = int.Parse(System.Console.ReadLine());

                System.Console.Write("Стовпців у матриці A: ");
                int columnsA = int.Parse(System.Console.ReadLine());

                System.Console.Write("Рядків у матриці B: ");
                int rowsB = int.Parse(System.Console.ReadLine());

                System.Console.Write("Стовпців у матриці B: ");
                int columnsB = int.Parse(System.Console.ReadLine());

                if (columnsA != rowsB)
                {
                    System.Console.WriteLine("Стовпців у A має дорівнювати рядкам у B.");
                    return;
                }

                int[,] first = ReadMatrix("A", rowsA, columnsA);
                int[,] second = ReadMatrix("B", rowsB, columnsB);
                int[,] result = new int[rowsA, columnsB];

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < columnsB; j++)
                    {
                        for (int k = 0; k < columnsA; k++)
                        {
                            result[i, j] += first[i, k] * second[k, j];
                        }
                    }
                }

                PrintMatrix(result);
            }
        }

        public static void Run5()
        {
            System.Console.Write("Введіть приклад, наприклад 10+5-3: ");
            string expression = System.Console.ReadLine();
            expression = expression.Replace(" ", "");

            int position = 0;

            while (position < expression.Length &&
                   expression[position] != '+' &&
                   expression[position] != '-')
            {
                position++;
            }

            int result = int.Parse(expression.Substring(0, position));

            while (position < expression.Length)
            {
                char operation = expression[position];
                position++;

                int start = position;

                while (position < expression.Length &&
                       expression[position] != '+' &&
                       expression[position] != '-')
                {
                    position++;
                }

                int number = int.Parse(expression.Substring(start, position - start));

                if (operation == '+')
                {
                    result += number;
                }
                else
                {
                    result -= number;
                }
            }

            System.Console.WriteLine("Результат: " + result);
        }

        public static void Run6()
        {
            System.Console.Write("Введіть текст: ");
            string text = System.Console.ReadLine();

            string result = "";
            bool beginningOfSentence = true;

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];

                if (beginningOfSentence && char.IsLetter(letter))
                {
                    result += char.ToUpper(letter);
                    beginningOfSentence = false;
                }
                else
                {
                    result += letter;
                }

                if (letter == '.' || letter == '!' || letter == '?')
                {
                    beginningOfSentence = true;
                }
            }

            System.Console.WriteLine(result);
        }

        static bool IsLetterOrNumber(char symbol)
        {
            return char.IsLetterOrDigit(symbol);
        }

        public static void Run7()
        {
            System.Console.Write("Введіть текст: ");
            string text = System.Console.ReadLine();

            System.Console.Write("Введіть неприпустиме слово: ");
            string forbiddenWord = System.Console.ReadLine();

            string result = "";
            string currentWord = "";
            int replacements = 0;

            for (int i = 0; i <= text.Length; i++)
            {
                if (i < text.Length && IsLetterOrNumber(text[i]))
                {
                    currentWord += text[i];
                }
                else
                {
                    if (currentWord != "")
                    {
                        if (currentWord.ToLower() == forbiddenWord.ToLower())
                        {
                            for (int j = 0; j < currentWord.Length; j++)
                            {
                                result += "*";
                            }

                            replacements++;
                        }
                        else
                        {
                            result += currentWord;
                        }

                        currentWord = "";
                    }

                    if (i < text.Length)
                    {
                        result += text[i];
                    }
                }
            }

            System.Console.WriteLine(result);
            System.Console.WriteLine("Кількість замін: " + replacements);
        }

        public static void Run8(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine("Потрібно ввести текст і зсув.");
                System.Console.WriteLine("Приклад: 8 Hello 3");
                return;
            }

            string text = args[0];
            int shift = int.Parse(args[1]);

            System.Console.WriteLine(Caesar(text, shift));
        }

        public static void Run9(string[] args)
        {
            if (args.Length < 3)
            {
                System.Console.WriteLine("Потрібно ввести рядки, стовпці та число.");
                System.Console.WriteLine("Приклад: 9 3 3 2");
                return;
            }

            int rows = int.Parse(args[0]);
            int columns = int.Parse(args[1]);
            int number = int.Parse(args[2]);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = random.Next(-10, 11);
                    value *= number;

                    System.Console.Write(value + "\t");
                }

                System.Console.WriteLine();
            }
        }
    }
}

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string choice;

            if (args.Length > 0)
            {
                choice = args[0];
            }
            else
            {
                System.Console.WriteLine("1 — масиви");
                System.Console.WriteLine("2 — сума між мінімумом і максимумом");
                System.Console.WriteLine("3 — шифр Цезаря");
                System.Console.WriteLine("4 — матриці");
                System.Console.WriteLine("5 — арифметичний приклад");
                System.Console.WriteLine("6 — великі літери в реченнях");
                System.Console.WriteLine("7 — неприпустиме слово");
                System.Console.WriteLine("8 — шифр Цезаря з параметрами");
                System.Console.WriteLine("9 — масив з параметрами");
                System.Console.Write("Виберіть завдання: ");

                choice = System.Console.ReadLine();
            }

            string[] taskArgs = new string[args.Length - 1];

            for (int i = 1; i < args.Length; i++)
            {
                taskArgs[i - 1] = args[i];
            }

            switch (choice)
            {
                case "1":
                    All.Program.Run1();
                    break;
                case "2":
                    All.Program.Run2();
                    break;
                case "3":
                    All.Program.Run3();
                    break;
                case "4":
                    All.Program.Run4();
                    break;
                case "5":
                    All.Program.Run5();
                    break;
                case "6":
                    All.Program.Run6();
                    break;
                case "7":
                    All.Program.Run7();
                    break;
                case "8":
                    All.Program.Run8(taskArgs);
                    break;
                case "9":
                    All.Program.Run9(taskArgs);
                    break;
                default:
                    System.Console.WriteLine("Такого завдання немає.");
                    break;
            }
        }
    }
}