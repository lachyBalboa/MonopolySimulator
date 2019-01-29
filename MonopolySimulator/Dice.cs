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
            int rollValue = r.Next(1, 7); // MaxValue is not inclusive, must set to 7 to allow roll of 6.
            RollHistory.Add(rollValue);
            TimesRolled++;
            CurrentValue = (Byte)rollValue;
            return CurrentValue;
        }
    }
}
