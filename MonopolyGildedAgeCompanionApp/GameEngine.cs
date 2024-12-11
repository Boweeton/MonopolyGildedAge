using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGildedAgeCompanionApp
{
    internal class GameEngine
    {
        // === CONSTANTS / CONSTRUCTOR ===
        public List<Market> AllMarkets;
        private const int Default_ChartSize = 75;

        public GameEngine()
        {
            AllMarkets = new List<Market>();

            AllMarkets.Add(new Market( // Position 0
                name: "Agriculture Stock",
                priceFloor: 30,
                priceCeiling: 120,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 40,
                startingValueFloor: 50,
                startingValueCeiling: 70,
                indicationChance: 0.85f,
                surgeChanceFloor: 25,
                surgeChanceCeiling: 33,
                crashChanceFloor: 25,
                crashChanceCeiling: 33,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 1
                name: "Textiles Stock",
                priceFloor: 30,
                priceCeiling: 190,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.88f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 70,
                startingValueFloor: 60,
                startingValueCeiling: 100,
                indicationChance: 0.70f,
                surgeChanceFloor: 25,
                surgeChanceCeiling: 33,
                crashChanceFloor: 25,
                crashChanceCeiling: 33,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 2
                name: "Oil Stock",
                priceFloor: 30,
                priceCeiling: 270,
                shiftChanceFloor: 0.67f,
                shiftChanceCeiling: 0.88f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 110,
                startingValueFloor: 50,
                startingValueCeiling: 90,
                indicationChance: 0.20f,
                surgeChanceFloor: 2,
                surgeChanceCeiling: 59,
                crashChanceFloor: 20,
                crashChanceCeiling: 76,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 3
                name: "Pharmaceuticals Stock",
                priceFloor: 30,
                priceCeiling: 250,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 110,
                startingValueFloor: 70,
                startingValueCeiling: 100,
                indicationChance: 0.35f,
                surgeChanceFloor: 18,
                surgeChanceCeiling: 39,
                crashChanceFloor: 5,
                crashChanceCeiling: 33,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 4
                name: "Steel Stock",
                priceFloor: 40,
                priceCeiling: 220,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 60,
                startingValueFloor: 70,
                startingValueCeiling: 110,
                indicationChance: 0.35f,
                surgeChanceFloor: 1,
                surgeChanceCeiling: 40,
                crashChanceFloor: 1,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 5
                name: "Factory Goods",
                priceFloor: 40,
                priceCeiling: 100,
                shiftChanceFloor: 0.55f,
                shiftChanceCeiling: 0.78f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 20,
                startingValueFloor: 50,
                startingValueCeiling: 70,
                indicationChance: 0.25f,
                surgeChanceFloor: 9,
                surgeChanceCeiling: 12,
                crashChanceFloor: 9,
                crashChanceCeiling: 12,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 6
                name: "Brown Housing",
                priceFloor: 20,
                priceCeiling: 80,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 20,
                startingValueFloor: 50,
                startingValueCeiling: 50,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 7
                name: "Light Blue Housing",
                priceFloor: 30,
                priceCeiling: 100,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 20,
                startingValueFloor: 50,
                startingValueCeiling: 50,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 8
                name: "Purple Housing",
                priceFloor: 30,
                priceCeiling: 130,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 30,
                startingValueFloor: 100,
                startingValueCeiling: 100,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 9
                name: "Orange Housing",
                priceFloor: 40,
                priceCeiling: 140,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 30,
                startingValueFloor: 100,
                startingValueCeiling: 100,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 10
                name: "Red Housing",
                priceFloor: 80,
                priceCeiling: 180,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 40,
                startingValueFloor: 150,
                startingValueCeiling: 150,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 11
                name: "Yellow Housing",
                priceFloor: 90,
                priceCeiling: 190,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 40,
                startingValueFloor: 150,
                startingValueCeiling: 150,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 12
                name: "Green Housing",
                priceFloor: 130,
                priceCeiling: 230,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 50,
                startingValueFloor: 200,
                startingValueCeiling: 200,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));

            AllMarkets.Add(new Market( // Position 13
                name: "Blue Housing",
                priceFloor: 140,
                priceCeiling: 260,
                shiftChanceFloor: 0.75f,
                shiftChanceCeiling: 0.98f,
                shiftAmountFloor: 10,
                shiftAmountCeiling: 50,
                startingValueFloor: 200,
                startingValueCeiling: 200,
                indicationChance: 0.50f,
                surgeChanceFloor: 20,
                surgeChanceCeiling: 25,
                crashChanceFloor: 20,
                crashChanceCeiling: 25,
                defaultChartSize: Default_ChartSize
            ));
        }
        // =================
    }
}