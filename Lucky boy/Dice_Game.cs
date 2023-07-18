using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lucky_boy
{
    interface IGame
    {
        void Start();
        void SaveScore(string fileName);
    }

    internal class Dice_Game : Object, IGame
    {

        private int sides;
        private int rounds;
        private int mode;
        private string player1;
        private string player2;
        private int score1;
        private int score2;
        private Random random;

        public Dice_Game()
        {
            sides = 6;
            rounds = 3;
            mode = 1;
            player1 = "Игрок1";
            player2 = "БОТ";
            score1 = 0;
            score2 = 0;
            random = new Random();

        }

        private int RollDice(string player)
        {
            Console.WriteLine($"{player} бросает кубик...");
            int roll = random.Next(1, sides + 1);
            Console.WriteLine($"На кубике выпало {roll}.");
            Console.WriteLine();
            return roll;
        }

        private int ReadInt(string messege, int min, int max)
        {
            int result = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write(messege);
                valid = int.TryParse(Console.ReadLine(), out result);
                if (!valid || result < min || result > max)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число в диапазоне от {0} до {1}.",
                        min, max);
                    valid = false;


                }

            }

            return result;


        }

        private string ReadString(string message)
        {
            string result = "";
            bool valid = false;

            while (!valid)
            {
                Console.Write(message);
                result = Console.ReadLine().Trim();


                if (result != "")
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите непустую строку.");
                }
            }


            return result;
        }



        public void Start()
        {
            Console.WriteLine("Добро пожаловать в игру Кости!");
            Console.WriteLine("Правила игры: каждый игрок бросает кубик с заданным количеством граней." +
                              " Выигрывает тот, у кого выпало большее число. В случае равенства ничья. " +
                              "Игра идет заданное количество раундов. Побеждает тот, кто выиграл больше раундов.");

            sides = ReadInt("Введите количество граней у кубика (от 6 до 20): ", 6, 20);
            rounds = ReadInt("Введите количество раундов в игре (от 1 до 10): ", 1, 10);
            mode = ReadInt("Выберите режим игры: 1 - с компьютером, 2 - с человеком: ", 1, 2);
            player1 = ReadString("Введите имя первого игрока: ");


            if (mode == 1)
            {
                player2 = "БОГ Рандома";
            }
            else
            {
                player2 = ReadString("Введите имя второго игрока: ");
            }

            Console.WriteLine("Игра началась");

            int round = 1;
            while (round <= rounds)
            {
                
                Console.WriteLine($"Раунд {round}");
                Console.WriteLine("Нажми пробел чтобы кинуть кубик");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
               

                    if (keyInfo.Key == ConsoleKey.Spacebar) // Если нажата кнопка пробела
                    {
                        int roll1 = RollDice(player1);
                        int roll2 = RollDice(player2);

                        if (roll1 > roll2)
                        {
                            score1++;
                        }
                        else if (roll1 < roll2)
                        {
                            score2++;
                        }
                        else
                        {
                            Console.WriteLine("Ничья");
                        }  

                        round++;
                    }
                

                
            }

            Console.WriteLine("Конец");
            Console.WriteLine($"Результаты: " +
                              $"\n{player1} - {score1}" +
                              $"\n{player2} - {score2}");

            if (score1 > score2)
            {
                Console.WriteLine($"{player1} Победил");
            }
            else if (score1 < score2)
            {
                Console.WriteLine($"{player2} Победил");
            }
            else
            {
                Console.WriteLine("Ничья");
            }



        }

        public void SaveScore(string fileName)
        {
            Console.WriteLine($"Результаты игры сохранены в файл {fileName}");
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine($"{DateTime.Now}\t{player1}\t{score1}\t{player2}\t{score2}");
            writer.Close();


        }
    }
}





