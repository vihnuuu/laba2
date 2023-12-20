using System;

namespace Lab2.Games
{
    public abstract class Game
    {
        public Guid Id { get; private set; }
        public double Rating { get; }

        public Game(double rating)
        {
            Id = Guid.NewGuid();
            Rating = rating;
        }

        public abstract double GetRating();

        public virtual void StartGame(GameAccount account1, GameAccount account2)
        {
            Console.WriteLine($"[Початок гри] {account1.UserName} vs {account2.UserName}, ставка: {GetRating()}");
            Random random = new Random();
            
            if (random.Next(0,2) == 0)
            {
                account1.WinGame(this, account2);
                account2.LoseGame(this, account1);
                Console.Write($"[Кінець гри] Переміг {account1.UserName} ");
                Console.WriteLine($" Програв {account2.UserName}");
            }
            else
            {
                account2.WinGame(this, account1);
                account1.LoseGame(this, account2);
                Console.Write($"[Кінець гри] Переміг {account2.UserName} ");
                Console.WriteLine($" Програв {account1.UserName}");
            }
        }
    }
}