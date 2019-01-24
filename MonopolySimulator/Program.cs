using System;
using System.Collections.Generic;

namespace MonopolySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChanceDeck deck = new ChanceDeck();
            //deck.SwapCards();
            LinkedList<Player> GamePlayers = new LinkedList<Player>();
            GamePlayers.AddFirst(new Player("Lachlan"));
            GamePlayers.AddFirst(new Player("Kate"));
            GameController game = new GameController(GamePlayers);
            game.InitialRoll();
            
            while (game.GameIsOn)
            {
                game.PlayTurn();
                Console.ReadKey();
            }
            

            Console.ReadLine();
        }
    }
}
