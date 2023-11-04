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
			Console.WriteLine($"Имя персонажа: {Name}");
			Console.WriteLine($"Координаты местоположения: {X}, {Y}");
			Console.WriteLine($"Принадлежность лагерю: {Camp}");
			Console.WriteLine($"Количество жизней: {NumberOfLives}");
		}

		public void MovingHorizontally()
		{
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

		public void DealingDamage()
		{
			if (Camp == false)
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
				Console.WriteLine("Вы не можете нанести урон союзнику.");
			}
		}

		public void Treatment()
		{
			if (NumberOfLives < 0)
			{
				Console.WriteLine("Вы уже умерли, перезагрузите игру.");
			}
			else
			{
				NumberOfLives += 1;
				Console.WriteLine($"Вы увеличили количество своих жизней на 1 единицу, количество жизней: {NumberOfLives}");
            }
		}

		public void FullRecovery()
		{
            if (NumberOfLives < 0)
            {
                Console.WriteLine("Вы уже умерли, перезагрузите игру.");
            }
            else
            {
                NumberOfLives = 10;
                Console.WriteLine($"Вы полностью вылечились, количество жизней: {NumberOfLives}");
            }
        }

		public void BelongingToTheCamp()
		{
			
			Console.WriteLine("Вы принадлежите лагерю людей.");
			
		}
    }
}

