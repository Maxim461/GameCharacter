using GameСharacter;

class Program
{
    static void Main()
    {
        EmptyClass gamecharacter = new EmptyClass("", 0, 0, true, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0);
        gamecharacter.Setting();
        gamecharacter.FillingInInformation();
        Console.WriteLine("Настройка закончена.");
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 для вывода информации;");
            Console.WriteLine("2 для движения;");
            Console.WriteLine("3 для использования локатора;");
            Console.WriteLine("4 для вступления в бой;");
            Console.WriteLine("5 для входа в магазин.");
            Console.WriteLine("6 для использования чита(Для Анастасии Константиновны)");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    gamecharacter.InformationOutput();
                    break;

                case ConsoleKey.D2:
                    gamecharacter.Movement();
                    break;

                case ConsoleKey.D3:
                    gamecharacter.Locator();
                    break;

                case ConsoleKey.D4:
                    gamecharacter.Destruction();
                    break;
                case ConsoleKey.D5:
                    gamecharacter.Shop();
                    break;

                case ConsoleKey.D6:
                    gamecharacter.Cheat();
                    break;

                default: break;
            }
        }
    }
}