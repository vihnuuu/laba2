using System;
using Lab2.Games;

namespace Lab2.Accounts
{
    public class GoldGameAccount : GameAccount
    {
        private int _winGameInRow;
        
        public GoldGameAccount(string userName) : base(userName)
        {
        }

        public override double GetRatingForWinGame(double rating)
        {
            switch (_winGameInRow)
            {
                case 0:
                    return rating;
                case 1:
                    return Convert.ToInt32(rating * 1.25);
                case 2:
                    return Convert.ToInt32(rating * 1.5);
                default:
                    return Convert.ToInt32(rating * 2);
            }
        }

        public override double GetRatingForLoseGame(double rating)
        {
            switch (_winGameInRow)
            {
                case 0:
                    return rating;
                case 1:
                    return rating / 0.5;
                case 2:
                    return rating / 0.25;
                default:
                    return rating - rating;
            }
        }

        public override void WinGame(Game game, GameAccount opponent)
        {
            if (game is TrainingGame)
            {
                CurrentRating += GetRatingForWinGame(game.GetRating());
                AddStats(game, opponent,true);
                return;
            }
            _winGameInRow++;
            CurrentRating += GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent,true);
        }

        public override void LoseGame(Game game, GameAccount opponent)
        {
            if (game is TrainingGame)
            {
                CurrentRating += GetRatingForWinGame(game.GetRating());
                AddStats(game, opponent,true);
                return;
            }
            _winGameInRow = 0;
            CurrentRating -= GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent, false);
        }
    }
}