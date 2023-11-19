using System;
using System.Numerics;
using GameСharacter;
using System.Threading.Channels;
using System.Collections.Generic;
using System.Drawing;

class Program
{
    static void Main()
    {
        List<PersonClass> persons = new List<PersonClass>();
        //Создание персонажей
        Console.Write("Введите количество персонажей: ");
        int numberOfPersons = int.Parse(Console.ReadLine());
        while (true)
        {
            if (numberOfPersons <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Количество персонажей не может быть меньше или ровно одного.");
                Console.ResetColor();
                Console.Write("Введите количество персонажей: ");
                numberOfPersons = int.Parse(Console.ReadLine());
            }
            else
            {
                break;
            }
        }
        //Создание рандомов для персонажей и присвоение
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.Write("Введите количество жизней: ");
            int numberOfLives = int.Parse(Console.ReadLine());
            Console.Write("Введите координату X: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Введите координату Y: ");
            int y = int.Parse(Console.ReadLine());
            Console.Write("Введите имя персонажа: ");
            string name = Console.ReadLine();
            Console.Write("Введите название лагеря: ");
            string camp = Console.ReadLine();
            persons.Add(new PersonClass(name, camp, numberOfLives, x, y));
        }
        //Вывод персонажей
        Console.Clear();
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.Write(i + 1 + " ");
            persons[i].FullInformationOutput();
        }
        //Выбор персонажа
        Console.Write("Введите цифру под каким вы персонажем хотите играть: ");
        int hero = int.Parse(Console.ReadLine()) - 1;
        while (true)
        {
            if (hero < 0 || hero >= numberOfPersons)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы можете выбрать персонажа только из того количетсва которое вы создали.");
                Console.ResetColor();
                Console.Write("Введите цифру под каким вы персонажем хотите играть: ");
                hero = int.Parse(Console.ReadLine()) - 1;
            }
            else
            {
                break;
            }
        }
        while (true)
        {   //Выбор действия для персонажа
            Console.WriteLine("Нажмите:\n0 - если хотите вывести информацию о себе;\n1 - если хотите вывести информацию об игроках;\n2 - если хотите выполнить движение по X и Y;\n3 - если хотите вступить в бой;\n4 - если хотите полностью вылечиться;\n5 - если хотите подлечиться;\n6 - если хотите сменить персонажа.");
            int button = int.Parse(Console.ReadLine());
            while (true)
            {
                if (button <= -1 || button >= 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы можете выбрать действия которого нету в списке.");
                    Console.ResetColor();
                    Console.WriteLine("Нажмите:\n0 - если хотите вывести информацию о себе;\n1 - если хотите вывести информацию об игроках;\n2 - если хотите выполнить движение по X и Y;\n3 - если хотите вступить в бой;\n4 - если хотите полностью вылечиться;\n5 - если хотите подлечиться;\n6 - если хотите сменить персонажа.");
                    button = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            //Действия для персонажа
            switch(button)
            {   //Вывод информации о себе
                case 0:
                    Console.Clear();
                    persons[hero].InformationOutput();
                break;
                //Вывод информации об игроках
                case 1:
                    Console.Clear();
                    for (int i = 0; i < numberOfPersons; i++)
                    {
                        Console.Write(i  + 1 + " ");
                        persons[i].FullInformationOutput();
                    }
                break;
                //Движение по X и по Y
                case 2:
                    Console.Clear();
                    persons[hero].Moving();
                break;
                //Бой с выбором полное уничтожение или нанесение урона
                case 3:
                    Console.Clear();
                    //Выбор противника
                    Console.Write("Введите цифру какого противника вы хотите атаковать: ");
                    int opponent = int.Parse(Console.ReadLine()) - 1;
                    while (true)
                    {
                        if (opponent < 0 || opponent >= numberOfPersons)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы можете выбрать персонажа только из того количетсва которое вы создали.");
                            Console.ResetColor();
                            Console.Write("Введите цифру какого противника вы хотите атаковать: ");
                            opponent = int.Parse(Console.ReadLine()) - 1;
                        }
                        else
                        {
                            if (persons[hero].getCapm() != persons[opponent].getCapm())
                            {
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Вы не можете атаковать своих.");
                                Console.ResetColor();
                            }
                        }
                    }
                    //Выбор боя: полное уничтожение или нанесение урона
                    Console.WriteLine("Нажмите:\n1 - если вы хотите выполнить полное уничтожение;\n2 - если вы хотите нанести урон.");
                    button = int.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (button == 1)
                        {
                            persons[opponent].FullDestruction();
                            break;
                        }
                        else if (button == 2)
                        {
                            persons[opponent].DealingDamage();
                            persons[hero].DealingDamage();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка, вы ввели не правильные данные.");
                            Console.ResetColor();
                            Console.WriteLine("Нажмите:\n1 - если вы хотите выполнить полное уничтожение;\n2 - если вы хотите нанести урон.");
                            button = int.Parse(Console.ReadLine());
                        }
                    }
                    
                break;
                //Полное восстановление здоровья
                case 4:
                    Console.Clear();
                    persons[hero].FullTreatment();
                break;
                //Восстановление здоровья с выбором количетсва 
                case 5:
                    Console.Clear();
                    persons[hero].Treatment();
                break;
                //Смена персонажа
                case 6:
                    Console.Clear();
                    for (int i = 0; i < numberOfPersons; i++)
                    {
                        Console.Write(i + 1 + " ");
                        persons[i].FullInformationOutput();
                    }
                    Console.Write("Введите цифру под каким вы персонажем хотите играть: ");
                    hero = int.Parse(Console.ReadLine()) - 1;
                    while(true)
                    {
                        if (hero < 0 || hero >= numberOfPersons)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы можете выбрать персонажа только из того количетсва которое вы создали.");
                            Console.ResetColor();
                            Console.Write("Введите цифру под каким вы персонажем хотите играть: ");
                            hero = int.Parse(Console.ReadLine()) - 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                break;
            }
        }
    }
}