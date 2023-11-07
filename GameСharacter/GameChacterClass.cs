using System;
using Microsoft.VisualBasic;

namespace GameСharacter
{
	public class GameChacterClass
	{
		private string Name;
		private bool Camp;
		private int NumberOfLives;
		private int X;
		private int Y;
		private int EnemyX;
		private int EnemyY;
		private int NumberOfLivesEnemy;
		private int Damage;

        public GameChacterClass(string Name, bool Camp, int NumberOfLives, int X, int Y)
		{
			this.Name = Name;
			this.Camp = Camp;
			this.NumberOfLives = NumberOfLives;
			this.X = X;
			this.Y = Y;
            NumberOfLivesEnemy = 5;
			Damage = 1;
			Random random = new Random();
			EnemyX = random.Next(-10, 10);
            EnemyY = random.Next(-10, 10);
        }

		public void InformationOutput()
		{
            Console.Clear();
            Console.WriteLine($"Имя персонажа: {Name}");
			Console.WriteLine($"Координаты вашего местоположения: {X}, {Y}");
            Console.WriteLine($"Координаты местоположения противника: {EnemyX}, {EnemyY}");
            if (Camp == true)
			{
				Console.WriteLine($"Принадлежность лагерю: Людей.");
            }
			else
			{
                Console.WriteLine($"Принадлежность лагерю: Гоблинов.");
            }
			Console.WriteLine($"Количество жизней: {NumberOfLives}");
			if (NumberOfLivesEnemy < 0)
			{
				Console.WriteLine("Вы победили!!!");
			}

		}

		public void MovingHorizontally()
		{
            Console.Clear();
            if (X > -10 || X < 10)
            {
                Console.WriteLine("Введите движение по X:");
                X += int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Вы вышли за пределы карты.");
            }
		}

		public void MovingVertically()
		{
            Console.Clear();
            if (Y > -10 || Y < 10)
			{
				Console.WriteLine("Введите движение по Y:");
				Y += int.Parse(Console.ReadLine());
			}
			else
			{
				Console.WriteLine("Вы вышли за пределы карты.");
			}
            
        }

		public void Destruction()
		{
            Console.Clear();
            if (X == EnemyX && Y == EnemyY)
			{
				if (NumberOfLivesEnemy == 0 || NumberOfLives == 0)
				{
					Console.WriteLine("Враг и так уничтожен или вас и так уничтожили.");
				}
				else
				{
					NumberOfLivesEnemy = 0;
					Console.WriteLine($"Враг унижтожен, количество жизней: {NumberOfLivesEnemy}");
				}
			}
			else
			{
				Console.WriteLine("Вы не можете нанести урон противнику, так как он находиться очень далеко.");
			}
        }

		public void DealingDamage()
		{
            Console.Clear();
            if (X == EnemyX && Y == EnemyY)
			{
				
				if (NumberOfLivesEnemy == 0 || NumberOfLives == 0)
				{
					Console.WriteLine("Враг и так уничтожен или вас уничтожили.");
				}
				else
				{
					NumberOfLivesEnemy -= Damage;
					NumberOfLives -= Damage;

					Console.WriteLine($"У врага осталось количество жиней: {NumberOfLivesEnemy}");
					Console.WriteLine($"У вас осталось количество жиней: {NumberOfLives}");
				}
				
			}
			else
			{
                Console.WriteLine("Вы не можете нанести урон противнику, так как он находиться очень далеко.");
            }
		}

		public void Treatment()
		{
            Console.Clear();
            if (NumberOfLives < 0)
			{
				Console.WriteLine("Вы уже умерли, перезагрузите игру.");
			}
			else
			{
				if (NumberOfLives > 9)
				{
					Console.WriteLine("Вы не можете иметь больше 10 единиц здоровья");
				}
				else
				{
					NumberOfLives += 1;
					Console.WriteLine($"Вы увеличили количество своих жизней на 1 единицу, количество жизней: {NumberOfLives}");
				}
				
            }
		}

		public void FullRecovery()
		{
			Console.Clear();
            if (NumberOfLives < 0)
            {
                Console.WriteLine("Вы уже умерли, перезагрузите игру или смените лагерь.");
            }
            else
            {
                NumberOfLives = 10;
                Console.WriteLine($"Вы полностью вылечились, количество жизней: {NumberOfLives}");
            }
        }

		public void BelongingToTheCamp()
		{
            Console.Clear();
			if (Camp == true)
			{
				Console.WriteLine("Вы принадлежите лагерю Людей.");
			}
			else
			{
                Console.WriteLine("Вы принадлежите лагерю Гоблинов.");
            }
            
			
		}

		public void CharacterChange()
		{
            Console.Clear();
            Random random = new Random();
            if (Camp == true)
			{
				Camp = false;
				Name = "Гоблин";
				X = 0;
				Y = 0;
                EnemyX = random.Next(-10, 10);
                EnemyY = random.Next(-10, 10);
                NumberOfLives = 10;
				NumberOfLivesEnemy = 5;

            }
			else if (Camp == false)
			{
				Camp = true;
				Name = "Человек";
                X = 0;
                Y = 0;
                EnemyX = random.Next(-10, 10);
                EnemyY = random.Next(-10, 10);
                NumberOfLives = 10;
                NumberOfLivesEnemy = 5;
            }
			else
			{
				Console.WriteLine("Упс, что-то пошло не так...");
			}
		}
    }
}

