using System;
using Lab2.Games;

namespace Lab2.Accounts
{
    public class SimpleGameAccount : GameAccount
    {
        public SimpleGameAccount(string userName) : base(userName)
        {
            
        }

        public override void WinGame(Game game, GameAccount opponent)
        {
            CurrentRating += GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent, true);
        }

        public override void LoseGame(Game game, GameAccount opponent)
        {
            CurrentRating -= GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent, false);
        }

        public override double GetRatingForWinGame(double rating) => 
            rating;

        public override double GetRatingForLoseGame(double rating) => 
            rating;
    }
}