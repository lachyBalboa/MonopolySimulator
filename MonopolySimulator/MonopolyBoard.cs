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
        public MonopolyBoard()
        {
            Spaces[0] = new SpecialSpace("Go");
            Spaces[1] = new Property("Old Kent Road", "Brown", 60, 2);
            Spaces[2] = new CommunityChest();
            Spaces[3] = new Property("Whitechapel Road", "Brown",60, 4);
            Spaces[4] = new Tax("Income Tax", 200);
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
