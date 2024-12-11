using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGildedAgeCompanionApp
{
    internal class MarketState
    {
        // Properties
        public int Price { get; set; }
        public int Evaluation { get; set; }
        public int FutureIndicator { get; set; }

        // Constructor
        public MarketState(int price, int evaluation, int futureIndicator)
        {
            Price = price;
            Evaluation = evaluation;
            FutureIndicator = futureIndicator;
        }
    }
}
