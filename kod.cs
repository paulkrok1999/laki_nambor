class TestClass {
    static void PlayGame() {
        Console.WriteLine("Выберите уровень сложности: ");
        Console.WriteLine("1 - Легкий(1-20, 10 попыток)"
            + "\n 2 - Средний(1-50, 7 попыток)"
            + "\n 3 - Сложный(1-50, 5 попыток)"
        );
        Console.Write("Ваш выбор: ");
        int num;//макс число
        int pop;//макс попытки
        string pt = Console.ReadLine();//выбор сложности        
        switch (pt) {
            case "1":
                num = 20; pop = 10;
                break;
            case "2":
                num = 50; pop = 7;
                break;
            case "3":
                num = 100; pop = 5;
                break;
            default:
                Console.WriteLine("Вы ничего не выбрали вы начинаете с среднего уровня");
                num = 50; pop = 7;
                break;
        }
        Random random = new();
        int sekret = random.Next(1, num + 1);
        Console.WriteLine($"я загадал число от 1 до {num}. у вас {pop} попыток.");
        int attempts = 0;
        bool guessed = false;
        while (attempts < num && !guessed) {
            Console.Write($"попытка {attempts + 1}/{num}. Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int guess)) {
                Console.WriteLine("ошипка введите целое число"); continue;
            }
            attempts++;//слолько было сделано попыток
            if (guess < sekret) { Console.WriteLine("больше"); }
            else if (guess > sekret) { Console.WriteLine("меньше"); }
            else {
                guessed = true;
                Console.WriteLine($"поздравляю число {sekret} за {pop} попыток!");
            }
            // после того как угадал число
            if (attempts == 1) { Console.WriteLine("c 1 попытки!"); }
            else if (attempts <= num / 2) Console.WriteLine($"отличный результат!-{attempts}");
            else { Console.WriteLine($"тоже норм-{attempts}"); }
        }
        //если не угадал число и истратил
        if (!guessed) Console.WriteLine($"попытки кончились я загадал {sekret}");
    }
    static void Main() {
        PlayGame();
    }
}