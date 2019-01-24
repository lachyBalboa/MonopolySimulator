using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class MonopolyBoard
    {
        public Space[] Spaces = new Space[40];
        public MonopolyBoard (Space[] spaces)
        {
            Spaces = spaces;
        }

        public void AddPlayerToSpace(Player player)
        {
            // Add player to space
            Spaces[player.CurrentIndex].AddPlayerToSpace(player);
            Console.Write("Players on space: ");
            Console.WriteLine(Spaces[player.CurrentIndex].Name);
            foreach(Player p in Spaces[player.CurrentIndex].PlayersOnSpace)
            {
                Console.WriteLine(p);
            }
        }
    }
}
