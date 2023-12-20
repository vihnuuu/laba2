using System;
using System.Collections.Generic;
using Lab2.Fabrics;
using Lab2.Games;

namespace Lab2
{
    public abstract class GameAccount
    {
        private struct DataStruct
        {
            public Game Game;
            public GameAccount Account;

            public DataStruct(Game game, GameAccount account)
            {
                Game = game;
                Account = account;
            }
        }
        
        private readonly Dictionary<DataStruct, bool> _gameHistory;
        private double _currentRating;
        public string UserName { get; private set; }
        public double CurrentRating
        {
            get => _currentRating;
            set
            {
                if (value < 1)
                {
                    _currentRating = 1;
                }
                else
                {
                    _currentRating = value;
                }
            }
        }
        
        public int GamesCount => 
            _gameHistory.Count;
        
        protected GameAccount(string userName)
        {
            UserName = userName;
            _gameHistory = new Dictionary<DataStruct, bool>();
        }

        protected void AddStats(Game game, GameAccount opponent, bool isWin)
        {
            _gameHistory.Add(new DataStruct(game, opponent), isWin);
        }

        public void GetStats()
        {
            Console.WriteLine($"\nСтатистика гравця {UserName}:");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine($"{"Проти кого", 10} | {"Виграш/Поразка", 10} | {"Рейтинг", 10} | {"Iндекс гри", 10}");
            Console.WriteLine("---------------------------------------------------------------------------------");

            foreach (var keyValuePair in _gameHistory)
            {
                string outcome = keyValuePair.Value ? "Виграш" : "Поразка";
                Console.WriteLine(
                    $"{keyValuePair.Key.Account.UserName,10} | {outcome,14} | {keyValuePair.Key.Game.Rating,10} | {keyValuePair.Key.Game.Id,10}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        public abstract double GetRatingForWinGame(double rating);
        public abstract double GetRatingForLoseGame(double rating);
        public abstract void WinGame(Game game, GameAccount account);
        public abstract void LoseGame(Game game, GameAccount account);
    }
}