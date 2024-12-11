using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGildedAgeCompanionApp
{
    internal class Market
    {
        public string Name { get; set; } // Name
        int PriceFloor { get; set; } // Price Boundaries
        int PriceCeiling { get; set; }
        float ShiftChanceFloor { get; set; } // Chance of Shift
        float ShiftChanceCeiling { get; set; }
        int ShiftAmountFloor { get; set; } // Shift Amount
        int ShiftAmountCeiling { get; set; }
        int StartingValueFloor { get; set; } // Starting Value
        int StartingValueCeiling { get; set; }
        int EvaluationScore {  get; set; } // Evaluation Score
        float IndicationChance { get; set; } // Indicaton Chance
        int SurgeChanceFloor { get; set; } // Surge Chance
        int SurgeChanceCeiling { get; set; }
        int CrashChacneFloor { get; set; } // Crash Chance
        int CrashChanceCeiling { get; set; }
        int DefaultChartSize { get; set; } // Default Chart Size
        public List<MarketState> PriceChart { get; set; } // The Price Chart
        public int CurrentPrice { get; set; } // Current Price
        public int CurrentChartPosition { get; set; } // Chart Position
        public ChangeType ChangeStatus { get; set; } // Change Status


        // Private Fields
        Random random = new Random();
        float surgeChanceAccumulation = 0;
        float crashChanceAccumulation = 0;
        private const int SurgeCrashProtectionAmount = 10;


        // Constructors
        public Market(
        string name,
        int priceFloor,
        int priceCeiling,
        float shiftChanceFloor,
        float shiftChanceCeiling,
        int shiftAmountFloor,
        int shiftAmountCeiling,
        int startingValueFloor,
        int startingValueCeiling,
        float indicationChance,
        int surgeChanceFloor,
        int surgeChanceCeiling,
        int crashChanceFloor,
        int crashChanceCeiling,
        int defaultChartSize)
        {
            // Initialize properties
            Name = name;
            PriceFloor = priceFloor;
            PriceCeiling = priceCeiling;
            ShiftChanceFloor = shiftChanceFloor;
            ShiftChanceCeiling = shiftChanceCeiling;
            ShiftAmountFloor = shiftAmountFloor;
            ShiftAmountCeiling = shiftAmountCeiling;
            StartingValueFloor = startingValueFloor;
            StartingValueCeiling = startingValueCeiling;
            IndicationChance = indicationChance;
            SurgeChanceFloor = surgeChanceFloor;
            SurgeChanceCeiling = surgeChanceCeiling;
            CrashChacneFloor = crashChanceFloor;
            CrashChanceCeiling = crashChanceCeiling; 
            DefaultChartSize = defaultChartSize;

            // Initialize default values for other properties
            CurrentPrice = 0;
            CurrentChartPosition = 0;
            EvaluationScore = 0;
            PriceChart = new List<MarketState>();
            PopulateChart(DefaultChartSize);
            PopulateIndicators();
        }


        // Methods
        int SelectNumberInRange(int floor, int ceiling)
        {
            // Ensure floor is less than ceiling and both are divisible by 10.
            if (floor > ceiling || floor % 10 != 0 || ceiling % 10 != 0)
                throw new ArgumentException("Floor must be less than ceiling, and both must be multiples of 10.");

            // Calculate the number of intervals of 10 in the range.
            int numberOfIntervals = (ceiling - floor) / 10 + 1;

            // Generate a random interval index.
            Random random = new Random();
            int intervalIndex = random.Next(numberOfIntervals);

            // Return the corresponding number.
            return floor + intervalIndex * 10;
        }

        void CalculateEvaluationScore()
        {
            if (PriceFloor > PriceCeiling)
                throw new InvalidOperationException("PriceFloor must be less than PriceCeiling.");

            // Calculate the position of the CurrentPrice within the range.
            float relativePosition = (float)(CurrentPrice - PriceFloor) / (PriceCeiling - PriceFloor);

            // Convert the relative position to a 7-point scale (-3 to 3).
            EvaluationScore = (int)Math.Round(relativePosition * 6) - 3;

            // Clamp the EvaluationScore to ensure it stays between -3 and 3.
            EvaluationScore = Math.Clamp(EvaluationScore, -3, 3);
        }


        void PopulateChart(int size)
        {
            // Get the midpoint
            int midPoint = ((PriceCeiling - PriceFloor) / 2) + PriceFloor;

            if (PriceFloor > PriceCeiling)
                throw new InvalidOperationException("PriceFloor must be less than PriceCeiling.");

            if (size <= 0)
                throw new ArgumentException("Chart size must be greater than 0.");

            // Initialize the PriceChart list.
            PriceChart = new List<MarketState>();

            // Determine the starting price using the starting value range.
            CurrentPrice = SelectNumberInRange(StartingValueFloor, StartingValueCeiling);

            // Populate the chart.
            for (int i = 0; i < size; i++)
            {
                // Calculate the evaluation score for the current price.
                CalculateEvaluationScore();

                // Add the current state to the chart.
                PriceChart.Add(new MarketState(CurrentPrice, EvaluationScore, 0)); // FutureIndicator can be implemented later.

                // Decide if the price should shift or stay the same.
                float shiftChance = (float)(new Random().NextDouble() * (ShiftChanceCeiling - ShiftChanceFloor) + ShiftChanceFloor);

                if (random.NextDouble() <= shiftChance) // Shift occurs
                {
                    // Decide the direction of the shift. Adjusting for midpoint.
                    bool shiftUp;

                    if (CurrentPrice < (midPoint * 0.50))
                    {
                        // 60% chance to shift up, 40% chance to shift down if CurrentPrice is less than midpoint
                        shiftUp = random.Next(100) < 60;
                    }
                    else
                    {
                        // 60% chance to shift down, 40% chance to shift up if CurrentPrice is greater than midpoint
                        shiftUp = random.Next(100) >= 60;
                    }

                    // Calculate the shift amount using the shift amount range.
                    int shiftAmount = SelectNumberInRange(ShiftAmountFloor, ShiftAmountCeiling);

                    // Apply the shift within the floor and ceiling bounds.
                    if (shiftUp)
                    {
                        CurrentPrice = Math.Min(CurrentPrice + shiftAmount, PriceCeiling);
                    }
                    else
                    {
                        CurrentPrice = Math.Max(CurrentPrice - shiftAmount, PriceFloor);
                    }

                    // Calculate the lower and upper third boundaries rounded to the nearest 10
                    int lowerThird = (int)(Math.Round((PriceFloor + (PriceCeiling - PriceFloor) / 3.0) / 10.0) * 10);
                    int upperThird = (int)(Math.Round((PriceCeiling - (PriceCeiling - PriceFloor) / 3.0) / 10.0) * 10);


                    // Accumulate surge or crash chances based on price position
                    if (CurrentPrice < lowerThird)
                    {
                        // Price is in the lower 1/3rd, accumulate surge chance.
                        surgeChanceAccumulation += random.Next(SurgeChanceFloor, SurgeChanceCeiling);
                        surgeChanceAccumulation = Math.Min(surgeChanceAccumulation, 100); // Clamp to 100%

                        // If surge chance reaches 100%, trigger a surge.
                        if (surgeChanceAccumulation >= 100)
                        {
                            // Snap price to a multiple of 10 in the upper 1/3rd.
                            CurrentPrice = SelectNumberInRange(upperThird, PriceCeiling - SurgeCrashProtectionAmount);
                            surgeChanceAccumulation = 0; // Reset surge accumulation
                        }
                    }
                    else if (CurrentPrice > upperThird)
                    {
                        // Price is in the upper 1/3rd, accumulate crash chance.
                        crashChanceAccumulation += random.Next(CrashChacneFloor, CrashChanceCeiling);
                        crashChanceAccumulation = Math.Min(crashChanceAccumulation, 100); // Clamp to 100%

                        // If crash chance reaches 100%, trigger a crash.
                        if (crashChanceAccumulation >= 100)
                        {
                            // Snap price to a multiple of 10 in the lower 1/3rd.
                            CurrentPrice = SelectNumberInRange(PriceFloor + SurgeCrashProtectionAmount, lowerThird);
                            crashChanceAccumulation = 0; // Reset crash accumulation
                        }
                    }
                    else
                    {
                        // Price is in the middle 1/3rd, reset both surge and crash accumulations.
                        surgeChanceAccumulation = 0;
                        crashChanceAccumulation = 0;
                    }
                }

                // If no shift occurs, the price remains the same.
            }
        }

        void PopulateIndicators()
        {
            if (PriceChart == null || PriceChart.Count == 0)
                throw new InvalidOperationException("PriceChart must be populated before calling PopulateIndicators.");

            Random random = new Random();

            // Loop through the PriceChart entries.
            for (int i = 0; i < PriceChart.Count; i++)
            {
                // Decide if this entry will get a FutureIndicator.
                if (random.NextDouble() >= IndicationChance)
                {
                    // No indicator, continue to the next entry.
                    PriceChart[i].FutureIndicator = 0;
                    continue;
                }

                // Initialize future price analysis.
                int currentPrice = PriceChart[i].Price;
                int futurePrice = currentPrice;
                int futureIndex = i + 1;

                // Loop through the next entries until a significant change is detected or we reach the end.
                while (futureIndex < PriceChart.Count)
                {
                    futurePrice = PriceChart[futureIndex].Price;
                    int priceDifference = futurePrice - currentPrice;

                    // Check for significant price differences.
                    if (priceDifference <= -40)
                    {
                        PriceChart[i].FutureIndicator = -2; // Large price drop
                        break;
                    }
                    else if (priceDifference <= -10)
                    {
                        PriceChart[i].FutureIndicator = -1; // Moderate price drop
                        break;
                    }
                    else if (priceDifference >= 40)
                    {
                        PriceChart[i].FutureIndicator = 2; // Large price increase
                        break;
                    }
                    else if (priceDifference >= 10)
                    {
                        PriceChart[i].FutureIndicator = 1; // Moderate price increase
                        break;
                    }

                    // If no significant change, continue to the next price in the future.
                    futureIndex++;
                }

                // If no significant change was found in the future, set the indicator to 0.
                if (PriceChart[i].FutureIndicator == 0)
                {
                    PriceChart[i].FutureIndicator = 0; // No significant change
                }
            }
        }

        public void ShiftUp()
        {
            // Check for end of PriceChart reached
            if (CurrentChartPosition < PriceChart.Count-1)
            {
                CurrentChartPosition++;
                CurrentPrice = PriceChart[CurrentChartPosition].Price;

                // Set ChangeStatus
                if (PriceChart[CurrentChartPosition].Price > PriceChart[CurrentChartPosition - 1].Price)
                {
                    ChangeStatus = ChangeType.Risen;
                }
                if (PriceChart[CurrentChartPosition].Price < PriceChart[CurrentChartPosition - 1].Price)
                {
                    ChangeStatus = ChangeType.Fallen;
                }
                if (PriceChart[CurrentChartPosition].Price == PriceChart[CurrentChartPosition - 1].Price)
                {
                    ChangeStatus = ChangeType.Same;
                }

            }
        }
    }
}
