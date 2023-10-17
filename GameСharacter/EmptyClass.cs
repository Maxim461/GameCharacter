using System;
using System.Drawing;

namespace GameСharacter
{
	public class EmptyClass
	{
		private string CharacterName;
		private int LocationCoordinatesX;
        private int LocationCoordinatesY;
        private bool Camp;
		private int NumberOfLives;
		private string Variety;
        private int LocationCoordinatesEnemyX;
        private int LocationCoordinatesEnemyY;
		private int Damage;
        private int DamageEnemy;
        private int Health;
        private int HealthEnemy;
        private int Kit;
        private int Armor;
        private int Money;

        public EmptyClass(string CharacterName, int LocationCoordinatesX, int LocationCoordinatesY, bool Camp, int NumberOfLives, string Variety, int LocationCoordinatesEnemyX, int LocationCoordinatesEnemyY, int Damage, int Health, int DamageEnemy, int HealthEnemy, int Kit, int Armor, int Money)
		{
			this.CharacterName = CharacterName;
			this.LocationCoordinatesX = LocationCoordinatesX;
            this.LocationCoordinatesY = LocationCoordinatesY;
            this.Camp = Camp;
			this.NumberOfLives = NumberOfLives;
			this.Variety = Variety;
            this.LocationCoordinatesEnemyX = LocationCoordinatesEnemyX;
            this.LocationCoordinatesEnemyY = LocationCoordinatesEnemyY;
			this.Damage = Damage;
            this.DamageEnemy = DamageEnemy;
            this.Health = Health;
            this.HealthEnemy = HealthEnemy;
            this.Kit = Kit;
            this.Armor = Armor;
            this.Money = Money;
        }
        // Сбор информации
		public void FillingInInformation()
		{
            // Изначальное здоровье персонажа
            Health = 250;
            // Здоровье противника
            HealthEnemy = 200;
            bool choise = true;
            while (choise)
            {
                // Выбор за какой лагерь играть
                Console.WriteLine("Нажмите: ");
                Console.WriteLine("1 для того чтобы играть за человка;");
                Console.WriteLine("2 для того чтобы играть за гоблина.");

                ConsoleKey keyInfo = Console.ReadKey().Key;
                switch (keyInfo)
                {
                    case ConsoleKey.D1:
                        Camp = true;
                        choise = false;
                        break;

                    case ConsoleKey.D2:
                        Camp = false;
                        choise = false;
                        break;

                    default:
                        Console.Clear();
                        break;

                }
            }
            Console.Clear();

            // Присвоение имя персонажа
            Console.WriteLine("Введите имя персонажа: ");
			CharacterName = Console.ReadLine();
            Console.Clear();
            // Запрос на количество жизней
            Console.WriteLine("Введите количество жизней вашего персонажа: ");
            while (true)
            {   int VarUser = int.Parse(Console.ReadLine());
                NumberOfLives = VarUser;
                if (NumberOfLives > 5 || NumberOfLives < 1)
                {
                    Console.WriteLine("Количество жизней не может быть больше 5 и меньше 1.");
                }
                else
                {
                    break;
                }
            }
        }
        // Настройки
        public void Setting()
        {
            // Рандомное местоположение противника по X
            Random RandomVertical = new Random();
            LocationCoordinatesEnemyX = RandomVertical.Next(10);
            // Рандомное местоположение противника по Y
            Random RandomHorizontal = new Random();
            LocationCoordinatesEnemyY = RandomHorizontal.Next(10);
        }
        // Вывод информации
        public void InformationOutput()
		{
            Console.Clear();

            Console.WriteLine($"Имя вашего персонажа: {CharacterName}");

            if (Camp == true)
			{
				Console.WriteLine("Вы играете за Человека");
			}
			else
			{
                Console.WriteLine("Вы играете за Гоблина");
            }

			Console.WriteLine($"Количество жизней: {NumberOfLives}");

            Console.WriteLine($"Вы находитесь в координатах: {LocationCoordinatesX}, {LocationCoordinatesY}");

            Console.WriteLine($"Количество монет: {Money}");
        }
        
        // Движение 
		public void Movement()
		{
			Console.Clear();
            Console.WriteLine("Движение по горизонтали:");
            Console.WriteLine("Нажмите D чтобы увеличить на 1;");
            Console.WriteLine("Нажмите A чтобы уменьшить на 1;");
            Console.WriteLine();
            Console.WriteLine("Движение по вертикали:");
            Console.WriteLine("Нажмите W чтобы увеличить на 1;");
            Console.WriteLine("Нажмите S чтобы уменьшить на 1;");
            Console.WriteLine("Нажмите Enter чтобы выйти.");
            

            while (true)
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				switch (keyInfo.Key)
				{
					case ConsoleKey.W:
						LocationCoordinatesY = LocationCoordinatesY + 1;
                        Console.WriteLine($"Вы находитесь в координатах: {LocationCoordinatesX}, {LocationCoordinatesY}");
                        break;

					case ConsoleKey.S:
						LocationCoordinatesY = LocationCoordinatesY - 1;
                        Console.WriteLine($"Вы находитесь в координатах: {LocationCoordinatesX}, {LocationCoordinatesY}");
                        break;

                    case ConsoleKey.D:
                        LocationCoordinatesX = LocationCoordinatesX + 1;
                        Console.WriteLine($"Вы находитесь в координатах: {LocationCoordinatesX}, {LocationCoordinatesY}");
                        break;

                    case ConsoleKey.A:
                        LocationCoordinatesX = LocationCoordinatesX - 1;
                        Console.WriteLine($"Вы находитесь в координатах: {LocationCoordinatesX}, {LocationCoordinatesY}");
                        break;

                    case ConsoleKey.Enter:
						return;
				}
                // Проверка на координаты строго 10
                if (LocationCoordinatesY > 10 || LocationCoordinatesX > 10)
                {
                    LocationCoordinatesY = 0;
                    LocationCoordinatesX = 0;
                    Console.WriteLine("Координаты не могут быть больше 10");
                    return;
                }
                else if (LocationCoordinatesY < 0 || LocationCoordinatesX < 0)
                {
                    LocationCoordinatesY = 0;
                    LocationCoordinatesX = 0;
                    Console.WriteLine("Координаты не могут быть меньше 0");
                    return;
                }
            }
		}
        // Локатор
		public void Locator()
		{
            Console.Clear();
            Console.WriteLine($"Враг находиться по коодинатам: {LocationCoordinatesEnemyX}, {LocationCoordinatesEnemyY}");
        }
        // Бой
        public void Destruction()
		{
            Console.Clear();
            Console.WriteLine("Бой:");
            Console.WriteLine("Нажмите E чтобы нанести урон;");
            Console.WriteLine("Нажмите Q чтобы вылечиться;");
            Console.WriteLine("Нажмите Enter чтобы выйти.");

            if (LocationCoordinatesX == LocationCoordinatesEnemyX && LocationCoordinatesY == LocationCoordinatesEnemyY)
			{
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.E:
                            if (Damage < 10000)
                            {
                                Random rnd = new Random();
                                Damage = rnd.Next(50);
                                DamageEnemy = rnd.Next(75);
                            }
                            HealthEnemy = HealthEnemy - Damage;
                            Health = Health - DamageEnemy;
                            
                            Console.WriteLine($"У вас осталось {Health} единиц здоровья.");
                            Console.WriteLine($"Вы нанесли {Damage}.");

                            Console.WriteLine($"У противника осталось {HealthEnemy} единиц здоровья;");
                            Console.WriteLine($"Вам нанесли {DamageEnemy}.");
                            break;

                        case ConsoleKey.Q:
                            Console.WriteLine("Здоровье: ");
                            Console.WriteLine("Если хотите полностью пополнить свое здоровье нажмите H(Если есть аптечка);");
                            Console.WriteLine("Если хотите подлечиться нажмите G(Каждое нажатие добавляет 1 HP);");
                            Console.WriteLine("Если хотите выйти из этого меню нажмите Enter.");
                            while (true)
                            {
                                keyInfo = Console.ReadKey(true);
                                switch (keyInfo.Key)
                                {
                                    case ConsoleKey.H:
                                        if (Kit > 1)
                                        {
                                            Health = 250;
                                            Kit = Kit - 1;
                                            Console.WriteLine($"Ваше здоровье: {Health}");
                                            Console.WriteLine($"У вас осталось аптечек: {Kit}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("У вас нету аптечек.");
                                        }
                                        break;

                                    case ConsoleKey.G:
                                        Health = Health + 1;
                                        Console.WriteLine($"Ваше здоровье: {Health}");
                                        break;

                                    case ConsoleKey.Enter:
                                        return;
                                }
                            }
                         

                        case ConsoleKey.Enter:
                            return;
                    }

                    if (Health < 0)
                    {
                        NumberOfLives = NumberOfLives - 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы проиграли этот бой.");
                        Console.ResetColor();
                        Console.WriteLine($"Жизней: {NumberOfLives}");
                        LocationCoordinatesX = 0;
                        LocationCoordinatesY = 0;
                        Health = 250;
                        return;
                    }
                    else if (HealthEnemy < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Вы выйграли этот бой!!!");
                        Console.ResetColor();
                        Random rnd = new Random();
                        Money = rnd.Next(100);
                        Money = Money + Money;
                        Health = 200;
                        Console.WriteLine($"Количество полученных монет: {Money}");
                        // Рандомное местоположение противника по X
                        Random RandomVertical = new Random();
                        LocationCoordinatesEnemyX = RandomVertical.Next(10);
                        // Рандомное местоположение противника по Y
                        Random RandomHorizontal = new Random();
                        LocationCoordinatesEnemyY = RandomHorizontal.Next(10);

                    }
                }
            }
            else
            {
                Console.WriteLine("Враг находиться слишком далеко для начала боя");
            }
		}
        // Магазин
        public void Shop()
        {
            Console.Clear();
            Console.WriteLine("Магазин: ");
            Console.WriteLine("Стоимость брони: 100 монет, нажмите B");
            Console.WriteLine("Стоимость аптечки: 50 монет, нажмите C");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Количество монет: {Money}");
            Console.ResetColor();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.B:
                        Money = Money - 100;
                        Health = 500;
                        Console.WriteLine($"Вы купили броню, теперь ваше здоровье: 500 единиц");
                        Console.WriteLine($"Количество отставшихся монет: {Money}");
                        break;

                    case ConsoleKey.C:
                        Money = Money - 50;
                        Kit = Kit + 1;
                        Console.WriteLine($"Вы купили аптечку, количество аптечек соствляет: {Kit}");
                        Console.WriteLine($"Количество отставшихся монет: {Money}");
                        break;

                    case ConsoleKey.Enter:
                        return;

                }
            }
        }
        // Чит
        public void Cheat()
        {
            Console.Clear();
            Console.WriteLine("Чтобы использовать чит на: ");
            Console.WriteLine("Одинаковые координаты с противником нажмите: Z;");
            Console.WriteLine("Большое количество монет нажмите: X;");
            Console.WriteLine("Большое количество здоровья нажмите: C;");
            Console.WriteLine("Большое количество урона нажмите: V;");
            Console.WriteLine("Чтобы выйти из меню нажмите Enter.");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Z:
                        LocationCoordinatesX = LocationCoordinatesEnemyX;
                        LocationCoordinatesY = LocationCoordinatesEnemyY;
                        Console.WriteLine("Координаты одинаковые");
                        break;

                    case ConsoleKey.X:
                        Money = 10000;
                        Console.WriteLine("Количество монет 10 000");
                        break;

                    case ConsoleKey.C:
                        Health = 10000;
                        Console.WriteLine("Количество здоровья 10 000");
                        break;

                    case ConsoleKey.V:
                        Damage = 10000;
                        Console.WriteLine("Количество урона 10 000");
                        break;

                    case ConsoleKey.Enter:
                        return;
                }
            }
        }
    }
}