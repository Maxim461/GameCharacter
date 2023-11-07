using GameСharacter;

class Program
{
    static void Main()
    {
        GameChacterClass GameCharacter = new GameChacterClass("Человек", true, 10, 0, 0);
        
        while (true)
        {
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 для вывода информации;");
            Console.WriteLine("2 для перемещения по горизонтали;");
            Console.WriteLine("3 для перемещения по вертикали;");
            Console.WriteLine("4 для полного уничтожения;");
            Console.WriteLine("5 для нанесения урона;");
            Console.WriteLine("6 для лечения;");
            Console.WriteLine("7 для полноного восстановления;");
            Console.WriteLine("8 для принадлежности лагерю;");
            Console.WriteLine("9 для смены лагеря.");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    GameCharacter.InformationOutput();
                    break;

                case ConsoleKey.D2:
                    GameCharacter.MovingHorizontally();
                    break;

                case ConsoleKey.D3:
                    GameCharacter.MovingVertically();
                    break;

                case ConsoleKey.D4:
                    GameCharacter.Destruction();
                    break;

                case ConsoleKey.D5:
                    GameCharacter.DealingDamage();
                    break;

                case ConsoleKey.D6:
                    GameCharacter.Treatment();
                    break;

                case ConsoleKey.D7:
                    GameCharacter.FullRecovery();
                    break;

                case ConsoleKey.D8:
                    GameCharacter.BelongingToTheCamp();
                    break;

                case ConsoleKey.D9:
                    GameCharacter.CharacterChange();
                    break;

                default: break;
            }
        }
    }
}