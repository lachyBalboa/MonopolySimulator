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
            Console.WriteLine("Hello World!");
            LinkedList<String> linked = new LinkedList<string>();
            linked.AddFirst("One");
            linked.AddFirst("Two");
            linked.AddFirst("Three");
            linked.AddAfter(linked.Last, "FOUR");

            foreach (String s in linked)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
