using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class Dice
    {
        public Byte CurrentValue { get; set; }
        public int TimesRolled { get; set; }
        public List<int> RollHistory = new List<int>();

        public Byte Roll()
        {
            Random r = new Random();
            int rollValue = r.Next(2, 12); // Two dice cannot output 1.
            RollHistory.Add(rollValue);
            TimesRolled++;
            return (Byte) rollValue;
        }
    }
}
