using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // для нормального отображения русских букв в некоторых консолях
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ИГРА УГАДАЙ ЧИСЛО ===\n");

            bool playAgain = true;
            Random random = new(); // лучше один раз на всю программу

            while (playAgain)
            {
                PlayGame(random);

                Console.Write("\nХотите сыграть ещё? (да/нет): ");
                string answer = (Console.ReadLine() ?? "").Trim().ToLower();

                playAgain = answer is "да" or "yes" or "y" or "д";

                if (playAgain)
                    Console.Clear();
            }

            Console.WriteLine("\nСпасибо за игру! До свидания!");
        }

        static void PlayGame(Random random)
        {
            (int maxNumber, int maxAttempts) = GetDifficultyLevel();

            int secretNumber = random.Next(1, maxNumber + 1);

            Console.WriteLine($"\nЯ загадал число от 1 до {maxNumber}. У вас {maxAttempts} попыток.");

            int attempts = 0;
            bool guessed = false;

            while (attempts < maxAttempts && !guessed)
            {
                Console.Write($"\nПопытка {attempts + 1}/{maxAttempts}. Введите число (или 'выход'): ");

                string input = (Console.ReadLine() ?? "").Trim().ToLower();

                if (input is "выход" or "exit" or "q")
                {
                    Console.WriteLine($"Вы вышли из игры. Было загадано: {secretNumber}");
                    return;
                }

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                    continue;
                }

                attempts++;

                if (guess < secretNumber)
                    Console.WriteLine("Загаданное число больше ↑");
                else if (guess > secretNumber)
                    Console.WriteLine("Загаданное число меньше ↓");
                else
                {
                    guessed = true;
                    Console.WriteLine($"\nПОЗДРАВЛЯЮ! Вы угадали число {secretNumber} за {attempts} попыток!");

                    if (attempts == 1) Console.WriteLine("Невероятно! С первой попытки!!!");
                    else if (attempts <= maxAttempts / 2) Console.WriteLine("Отличный результат!");
                    else Console.WriteLine("Хороший результат!");
                }
            }

            if (!guessed)
            {
                Console.WriteLine($"\nПопытки закончились. Было загадано число → {secretNumber}");
            }
        }

        static (int maxNumber, int maxAttempts) GetDifficultyLevel() {
            while (true) {
                Console.WriteLine("Выберите уровень сложности:");
                Console.WriteLine("1 - Легкий(1-21, 10 попыток)"
                    + "\n 2 - Средний(1-51, 7 попыток)"
                    + "\n 3 - Сложный(1-101, 5 попыток)"
                );
                Console.Write("Ваш выбор: ");

                string choice = (Console.ReadLine() ?? "").Trim();

                switch (choice)
                {
                    case "1": return (21, 10);
                    case "2": return (51, 7);
                    case "3": return (101, 5);
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }
    }
}