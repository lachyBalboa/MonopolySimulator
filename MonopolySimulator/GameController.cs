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
            Console.Write("Playing turn for: ");
            Console.WriteLine(player);
            player.StartTurn();
            Byte currentIndex = player.CurrentIndex;
            while (!player.TurnHasEnded)
            {
                player.HasRolledDoubles = false;
                Byte rollValue = player.RollDice();

                if (!player.AllowPlayerToMoveFromJail() )
                {
                    player.TurnsInJail++;
                    break;
                }

                player.Move(rollValue, Board);
                Board.AddPlayerToSpace(player);
                player.CheckPosition(Board);

                if (player.HasRolledDoubles)
                {
                    player.TimesDoublesRolled++;
                    continue;
                }

                player.TurnHasEnded = true;
            }

            player.EndTurn();
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
    }
}
