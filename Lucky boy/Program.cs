namespace Lucky_boy
{
    internal class Program
    {
        static string scoreFile = "scores.txt";
        static void Main(string[] args)
        {
            IGame game = new Dice_Game();
            game.Start();
            game.SaveScore(scoreFile);
            Console.WriteLine("Игра окончена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();



        }
    }
}