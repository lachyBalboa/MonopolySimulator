using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    class GameController
    {
        LinkedList<Player> Players = new LinkedList<Player>();
        MonopolyBoard Board = new MonopolyBoard();
        CommunityChestDeck CommunityChestDeck = new CommunityChestDeck();
        ChanceDeck ChanceDeck = new ChanceDeck();
        Space[] Spaces = new Space[40]; // Spaces will not change
        public bool GameIsOn = true;
        public int TurnsPlayed;
        public GameController(LinkedList<Player> players)
        {
            Players = players;
            InitialRoll();
        }
        public void InitialRoll()
        {   
            foreach(Player p in Players)
            {
                p.InitialRollValue = p.RollDice();
                Console.Write(p);
                Console.Write("'s initial roll is: ");
                Console.WriteLine(p.InitialRollValue);
            }

            // Sort players list based on who rolled a greater amount
            IOrderedEnumerable<Player> tempPlayers = Players.OrderByDescending(p => p.InitialRollValue);
            Players = new LinkedList<Player>(tempPlayers);
            Console.Write(Players.First.Value.PlayerName);
            Console.WriteLine(" gets to move first.");
        }

        public void PlayTurn(Player player)
        {
            TurnsPlayed++;
            Console.Write("Playing turn for: ");
            Console.WriteLine(player);
            player.StartTurn();
            while (!player.TurnHasEnded)
            {
                player.HasRolledDoubles = false;
                Byte rollValue = player.RollDice();
                
                if (!player.AllowPlayerToMoveFromJail() )
                {
                    player.TurnsInJail++;
                    break;
                }

                player.Move(rollValue, ref Board);
                player.CheckPosition(Board);

                if (player.HasRolledDoubles)
                {
                    player.TimesDoublesRolled++;
                    continue;
                }

                player.TurnHasEnded = true;
            }

            player.EndTurn();
            Console.WriteLine(player.CurrentSpace);
        }
       
        public Space GetSpaceForPlayer(Player player)
        {
            Space currentSpace = Board.Spaces[player.CurrentIndex];
            return currentSpace;
        }

        public void SwapPlayers(LinkedList<Player> players)
        {
            Player tempPlayer = players.First.Value;
            players.RemoveFirst();
            players.AddAfter(players.Last, tempPlayer);
        }

        public void PrintGameSummary()
        {
            IOrderedEnumerable<Space> SpacesInOrderOfTimesLanded = Board.Spaces.OrderByDescending(s => s.TimesLanded);
            Console.WriteLine("Game Summary");
            Console.Write("Turns played: ");
            Console.WriteLine(TurnsPlayed);
            foreach (Player p in Players)
            {
                Console.Write(p);
                Console.Write(" turns played: ");
                Console.WriteLine(p.TurnsPlayed);
            }

            Console.WriteLine("Most used Spaces: ");
            foreach(Space s in SpacesInOrderOfTimesLanded)
            {
                Console.Write(s);
                Console.Write(" : ");
                Console.WriteLine(s.TimesLanded);
            }
        }
    }
}
