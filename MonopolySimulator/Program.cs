﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Monopoly Simulator";
            //ChanceDeck deck = new ChanceDeck();
            //deck.SwapCards();
            LinkedList<Player> GamePlayers = new LinkedList<Player>();
            GamePlayers.AddFirst(new Player("Lachlan"));
            GamePlayers.AddFirst(new Player("Kate"));
            GameController game = new GameController(GamePlayers);
            
            while (game.GameIsOn)
            {   
                
                game.PlayTurn(GamePlayers.First.Value);
                game.SwapPlayers(GamePlayers);
                Console.ReadKey();
                if (game.TurnsPlayed >= 100)
                {
                    game.PrintGameSummary();
                    break;
                }
                if (GamePlayers.Any(p => p.TotalFunds <= 0))
                {
                    game.GameIsOn = false;
                }
            }

            Console.WriteLine("Game is over");
            Console.ReadLine();
        }
    }
}
