using System;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace GameСharacter
{
	public class PersonClass
    {
        private string name;
        private string camp;
        private int numberOfLives;
        private int x;
        private int y;

		public PersonClass(string name, string camp, int numberOfLives, int x, int y)
		{
            this.name = name;
            this.camp = camp;
            this.numberOfLives = numberOfLives;
            this.x = x;
            this.y = y;
		}

        public string getCapm()
        {
            return camp;
        }

        public void InformationOutput()
        {
            Console.WriteLine($"Имя: {name}. Количество его жизней: {numberOfLives}. Координаты x:{x} y:{y}. Принадлежность к лагерю: {camp}.");
        }

        public void FullInformationOutput()
		{
            Console.WriteLine($"Имя: {name}. Количество его жизней: {numberOfLives}. Координаты x:{x} y:{y}. Принадлежность к лагерю: {camp}.");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void Moving()
        {
            Console.Write("Введите движение по X: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Введите движение по Y: ");
            y = int.Parse(Console.ReadLine());
            while (true)
            {
                if ((x<=50&&x>=-50)&&(y <= 50 && y >= -50))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Координаты не могут быть больше 50 или меньше -50.");
                    Console.ResetColor();
                    Console.Write("Введите движение по X: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Введите движение по Y: ");
                    y = int.Parse(Console.ReadLine());
                    
                }
            }
        }

        public void FullDestruction()
        {
            numberOfLives = 0;
            Console.WriteLine("Враг уничтожен.");
        }

        public void DealingDamage()
        {
            Random random = new Random();
            int damage = random.Next(0, 3);
            int damageEnemy = random.Next(0, 3);
            numberOfLives = numberOfLives - damage;
            Console.WriteLine($"Вы нанесли противнику: {damageEnemy}, осталось: {numberOfLives} единиц здоровья;\nОн вам нанес: {damage}, осталось: {numberOfLives} единиц здоровья.");
        }

        public void FullTreatment()
        {
            numberOfLives = 10;
            Console.WriteLine($"Вы полностью восстановились, количество здоровья: {numberOfLives}.");
        }

        public void Treatment()
        {
            Console.Write("Введите количество жизней на которое вы хотите пополнить:");
            int buttonTreatment =+ int.Parse(Console.ReadLine());
            while (true)
            {
                if (buttonTreatment > 10 || buttonTreatment < 0)
                {
                    Console.WriteLine("Вы не можете иметь больше 10 единиц здоровья или меньше 1.");
                    Console.Write("Введите количество жизней на которое вы хотите пополнить:");
                    buttonTreatment =+ int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
        }

    }
}