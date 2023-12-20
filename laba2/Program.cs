using System;
using Lab2.Accounts;
using Lab2.Fabrics;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameAccount simpleAccount = new SimpleGameAccount("Simple");
            GameAccount goldAccount = new SimpleGameAccount("Gold");
            GameAccount brilliantAccount = new SimpleGameAccount("Brilliant");
            GameFactory factory = new GameFactory();
            
            Console.WriteLine("Training game: ");
            Console.WriteLine("Simple Vs Gold");
            factory.CreateGame("SimpleGame",10).StartGame(simpleAccount, goldAccount);
            Console.WriteLine("Simple Vs Brilliant");
            factory.CreateGame("TrainingGame",0).StartGame(simpleAccount, brilliantAccount);
            Console.WriteLine("---------------------------------------------------------------------------------");

            Console.WriteLine("Computer Game: ");
            Console.WriteLine("#1 Gold Vs Computer");
            factory.CreateGame("GameWithComputer",10).StartGame(goldAccount, null);
            Console.WriteLine("#2 Gold Vs Computer");
            factory.CreateGame("GameWithComputer",10).StartGame(goldAccount, null);
            Console.WriteLine("---------------------------------------------------------------------------------");

            Console.WriteLine("Simple Game: ");
            Console.WriteLine("Brilliant Vs Simple");
            factory.CreateGame("SimpleGame",20).StartGame(brilliantAccount, simpleAccount);
            Console.WriteLine("Brilliant Vs Gold");
            factory.CreateGame("SimpleGame",20).StartGame(brilliantAccount, goldAccount);
            
            simpleAccount.GetStats();
            goldAccount.GetStats();
            brilliantAccount.GetStats();
        }
    }
}