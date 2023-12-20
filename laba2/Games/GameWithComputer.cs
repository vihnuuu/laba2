using System;
using Lab2.Accounts;

namespace Lab2.Games
{
    public class GameWithComputer : Game
    {
        public GameWithComputer(double rating) : base(rating)
        {
        }

        public override double GetRating()
        {
            return Rating;
        }

        public override void StartGame(GameAccount account1, GameAccount account2)
        {
            Console.WriteLine($"[Початок гри] {account1.UserName} vs Computer, ставка: {GetRating()}");
            Random random = new Random();

            if (random.Next(0,2) == 0)
            {
                var winAccount = account1;
                winAccount.WinGame(this, new SimpleGameAccount("Computer"));
                Console.Write($"[Кінець гри] Переміг {winAccount.UserName}");
                Console.WriteLine($" Програв Computer");
            }
            else
            {
                var loseAccount = account1;
                loseAccount.LoseGame(this, new SimpleGameAccount("Computer"));
                Console.Write($"[Кінець гри] Переміг Computer");
                Console.WriteLine($" Програв {loseAccount.UserName}");
            }
        }
    }
}