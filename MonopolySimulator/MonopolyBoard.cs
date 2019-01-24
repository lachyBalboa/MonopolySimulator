﻿using System;
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
            Spaces[5] = new Property("Redding Railroad", "Black", 200, 25);
            Spaces[6] = new Property("Oriental Avenue", "Light Blue", 160, 10);
            Spaces[7] = new Chance();
            Spaces[8] = new Property("Vermont Avenue", "Light Blue", 160, 10);
            Spaces[9] = new Property("Conneticut Avenue", "Light Blue", 180, 12);
            Spaces[10] = new SpecialSpace("Jail");
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
