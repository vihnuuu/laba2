using Lab2.Games;

namespace Lab2.Accounts
{
    public class BrilliantGameAccount : GameAccount
    {
        public BrilliantGameAccount(string userName) : base(userName)
        {
        }

        public override double GetRatingForWinGame(double rating)
        {
            return rating * 2;
        }

        public override double GetRatingForLoseGame(double rating)
        {
            return rating / 2;
        }

        public override void WinGame(Game game, GameAccount opponent)
        {
            CurrentRating += GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent,true);
        }

        /* public override void LoseGame(Game game, GameAccount opponent)
        {
            CurrentRating -= GetRatingForWinGame(game.GetRating());
            AddStats(game, opponent, false);
        }
    }*/
        public override void LoseGame(Game game, GameAccount opponent)
        {
            CurrentRating -= GetRatingForLoseGame(game.GetRating());
            if (CurrentRating < 0)
            {
                CurrentRating = 0;
            }
            AddStats(game, opponent, false);
        }

    }
}