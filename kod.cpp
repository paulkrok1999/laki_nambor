/*
создание угадай число 
я хочу чтобы пользватель выбирал уровень
легко от 0 до 20
средний от 0 до 50 
сложный от 0 до 100 и тд.
еще нужно что бы были поддсказки больше и меньши
*/
class TestClass
{
    static void Main()
    {
        Console.Write("пр что бы начать играть выбери уровень" +
            "\n 1. легко от 0 до 20" +
            "\n 2. средний от 0 до 50 "+
            "\n 3. сложный от 0 до 100 и тд."
        );
        int num = 1;
        switch (num)
        {
            case 1:
                Random random = new();
                int rand = random.Next(1, 20);
                int po = 0;
                for (int i = 0; i < rand; i++)
                {
                    Console.Write("введи чило от 0 до 10: ");
                    string message = Console.ReadLine();
                    string res = $"{rand}";
                    if (res == message) { Console.WriteLine($"вы угадали число : {rand}"); }
                    else { Console.WriteLine($"вы не угадали число"); }
                }
                break;
            case 2:
                Random random1 = new();
                int rand1 = random1.Next(1, 50);
                int po1 = 0;
                for (int i = 0; i < rand1; i++)
                {
                    Console.Write("введи чило от 0 до 10: ");
                    string message = Console.ReadLine();
                    string res = $"{rand1}";
                    if (res == message) { Console.WriteLine($"вы угадали число : {rand1}"); }
                    else { Console.WriteLine($"вы не угадали число"); }
                }
                break;
            case 3:
                Random random2 = new();
                int rand2 = random2.Next(1, 100);
                int po2 = 0;
                for (int i = 0; i < rand2; i++)
                {
                    Console.Write("введи чило от 0 до 10: ");
                    string message = Console.ReadLine();
                    string res = $"{rand2}";
                    if (res == message) { Console.WriteLine($"вы угадали число : {rand2}"); }
                    else { Console.WriteLine($"вы не угадали число"); }
                }
                break;
        }
    } 
}