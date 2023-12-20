using System;
using Lab2.Games;

namespace Lab2.Fabrics
{
    public class GameFactory
    {
        public Game CreateGame(string type, double r )
        {
            if (type =="SimpleGame")
            {
                return new SimpleGame(r);
            }
            if (type=="TrainingGame")
            {
                return new TrainingGame(0); 
            }
            if (type=="GameWithComputer")
            {
                return new GameWithComputer(r);
            }

            throw new NotImplementedException();
        }
    }
}