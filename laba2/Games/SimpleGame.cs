namespace Lab2.Games
{
    public class SimpleGame : Game
    {
        public SimpleGame(double rating) : base(rating)
        {
        }

        public override double GetRating()
        {
            return Rating;
        }
    }
}