class TestClass {
    static void Main() {
        //random для рандомного числа я сделал его короче это не вредит программе
        Random random = new();
        //число попыток в данный момент он 0 еще я сделал чтобы не создавать несколько раз число попыток а что бы 
        int pop = 0;
        // пока мы не угадаем число он всегда будет false аесли угадаем то будет true
        bool guessed = false;
        //в данный момент число макс попыток всегда по умолчанию
        int maxpop = 0;
        //в данный момент число макс числа всегда по умолчанию
        int maxnum = 0;
       //ввыводим сообщение на консоль для ввыбора уровня
        Console.WriteLine("Выберите уровень сложности:");
        Console.Write(" 1 - Легкий(1-21, 10 попыток)"
            + "\n 2 - Средний(1-51, 7 попыток)"
            + "\n 3 - Сложный(1-101, 5 попыток)"
        );
        string mess = Console.ReadLine();
        //преобразуем string в int
        int ress = int.Parse(mess);
        switch (ress) {
            case 1:                
                maxnum = 19; maxpop = 10;
                break;
            case 2:                
                maxnum = 49; maxpop = 7;
                break;
            case 3:
                maxnum = 99; maxpop = 5;
                break;
            default:
                Console.WriteLine("Неверный выбор. Программа завершена.");
                return; 
        }
        int sekret = random.Next(1, maxnum + 1);
        Console.WriteLine($"Я загадал число от 1 до {maxnum}. У вас {maxpop} попыток.");
        while (pop < maxpop) {
            Console.Write($"попытки {pop + 1} / {maxpop}: ");
            string input = Console.ReadLine();
            pop++;
            //тут он проверяет только целый числа а не 4.7
            if (!int.TryParse(input, out int guss)) {
                Console.WriteLine("Ошибка! Введите целое число.");
                continue;
            }
            //проверка на большее и меньшие мы тогда ввод usera поменяли на guss что бы он сравнил ответ user как было сказано на больше и меньше  
            if (guss < sekret) Console.WriteLine("Загаданное число больше");
            else if (guss > sekret) Console.WriteLine("Загаданное число меньше");
            else {
                //сейчас guessed = true; это означает что мы угадали число
                guessed = true;
                //ввывод сообщение какое было число и сколько мы сделали попыток 
                Console.WriteLine($"\nПОЗДРАВЛЯЮ! Вы угадали число {sekret} за {pop} попыток!");
                //тут ввыводит когды мы с 1 попытки угадали 
                if (pop == 1) Console.WriteLine($"Невероятно! С первой попытки!!!");
                //тут ввыводит если мы угадили но не 1 раза 
                else if (pop <= maxnum / 2) Console.WriteLine($"Отличный результат: {pop}!");
                else Console.WriteLine($"Хороший результат! {pop}");
                //тут прекрощает когда мы законичили 
                break;
            }
        }
       //ввывод когда мы не угадали вывводит число какое было загадано
        if (!guessed) { Console.WriteLine($"\nК сожалению, вы не угадали. Было загадано число {sekret}."); }
    }
}