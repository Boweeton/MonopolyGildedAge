using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MonopolyGildedAgeCompanionApp
{
    public partial class MainAppForm : Form
    {
        GameEngine myGameEngine;
        MarketFormsController StockMarket1_Aggriculture;
        MarketFormsController StockMarket2_Textiles;
        MarketFormsController StockMarket3_Oil;
        MarketFormsController StockMarket4_Pharma;
        MarketFormsController StockMarket5_Steel;
        MarketFormsController GoodsMarket;
        MarketFormsController HouseMarket1_Brown;
        MarketFormsController HouseMarket2_LightBlue;
        MarketFormsController HouseMarket3_Purple;
        MarketFormsController HouseMarket4_Orange;
        MarketFormsController HouseMarket5_Red;
        MarketFormsController HouseMarket6_Yellow;
        MarketFormsController HouseMarket7_Green;
        MarketFormsController HouseMarket8_Blue;
        List<MarketFormsController> AllMarketControllers;

        int marketNumber = 2;
        int carrot = 0;
        public MainAppForm()
        {
            InitializeComponent();
        }

        private void MainAppForm_Load(object sender, EventArgs e)
        {
            myGameEngine = new GameEngine();
            AllMarketControllers = new List<MarketFormsController>();

            StockMarket1_Aggriculture = new MarketFormsController( // Form Controller: AGGRICULTURE stock market
            market: myGameEngine.AllMarkets[0],
            marketPanel: panel_StockMarketAggriculture,
            marketNameLabel: label_StockMarketAggriculture,
            marketBackgroundPictureBox: pictureBox_StockMarketAggriculture_Background,
            marketPricePictureBox: pictureBox_StockMarketAggriculture_Price,
            marketEvaluationPictureBox: pictureBox_StockMarketAggriculture_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_StockMarketAggriculture_FutureIndicator
            );
            AllMarketControllers.Add(StockMarket1_Aggriculture);

            StockMarket2_Textiles = new MarketFormsController( // Form Controller: TEXTILES stock market
            market: myGameEngine.AllMarkets[1],
            marketPanel: panel_StockMarketTextiles,
            marketNameLabel: label_StockMarketTextiles,
            marketBackgroundPictureBox: pictureBox_StockMarketTextiles_Background,
            marketPricePictureBox: pictureBox_StockMarketTextiles_Price,
            marketEvaluationPictureBox: pictureBox_StockMarketTextiles_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_StockMarketTextiles_FutureIndicator
            );
            AllMarketControllers.Add(StockMarket2_Textiles);

            StockMarket3_Oil = new MarketFormsController( // Form Controller: OIL stock market
            market: myGameEngine.AllMarkets[2],
            marketPanel: panel_StockMarketOil,
            marketNameLabel: label_StockMarketOil,
            marketBackgroundPictureBox: pictureBox_StockMarketOil_Background,
            marketPricePictureBox: pictureBox_StockMarketOil_Price,
            marketEvaluationPictureBox: pictureBox_StockMarketOil_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_StockMarketOil_FutureIndicator
            );
            AllMarketControllers.Add(StockMarket3_Oil);

            StockMarket4_Pharma = new MarketFormsController( // Form Controller: PHARMA stock market
            market: myGameEngine.AllMarkets[3],
            marketPanel: panel_StockMarketPharma,
            marketNameLabel: label_StockMarketPharma,
            marketBackgroundPictureBox: pictureBox_StockMarketPharma_Background,
            marketPricePictureBox: pictureBox_StockMarketPharma_Price,
            marketEvaluationPictureBox: pictureBox_StockMarketPharma_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_StockMarketPharma_FutureIndicator
            );
            AllMarketControllers.Add(StockMarket4_Pharma);

            StockMarket5_Steel = new MarketFormsController( // Form Controller: STEEL stock market
            market: myGameEngine.AllMarkets[4],
            marketPanel: panel_StockMarketSteel,
            marketNameLabel: label_StockMarketSteel,
            marketBackgroundPictureBox: pictureBox_StockMarketSteel_Background,
            marketPricePictureBox: pictureBox_StockMarketSteel_Price,
            marketEvaluationPictureBox: pictureBox_StockMarketSteel_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_StockMarketSteel_FutureIndicator
            );
            AllMarketControllers.Add(StockMarket5_Steel);

            GoodsMarket = new MarketFormsController( // Form Controller: GOODS market
            market: myGameEngine.AllMarkets[5],
            marketPanel: panel_GoodsMarket,
            marketNameLabel: label_GoodsMarket,
            marketBackgroundPictureBox: pictureBox_GoodsMarket_Background,
            marketPricePictureBox: pictureBox_GoodsMarket_Price,
            marketEvaluationPictureBox: pictureBox_GoodsMarket_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_GoodsMarket_FutureIndicator
            );
            AllMarketControllers.Add(GoodsMarket);

            HouseMarket1_Brown = new MarketFormsController( // Form Controller: BROWN housing market
            market: myGameEngine.AllMarkets[6],
            marketPanel: panel_HousingMarketFullDisplay,
            marketNameLabel: label_HouseMarket_Brown,
            marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
            marketPricePictureBox: pictureBox_HouseMarket_Brown_Price,
            marketEvaluationPictureBox: pictureBox_HouseMarket_Brown_Evaluation,
            marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Brown_FutureIndicator
);
            AllMarketControllers.Add(HouseMarket1_Brown);

            HouseMarket2_LightBlue = new MarketFormsController( // Form Controller: LIGHT BLUE housing market
                market: myGameEngine.AllMarkets[7],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_LightBlue,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_LightBlue_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_LightBlue_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_LightBlue_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket2_LightBlue);

            HouseMarket3_Purple = new MarketFormsController( // Form Controller: PURPLE housing market
                market: myGameEngine.AllMarkets[8],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Purple,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Purple_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Purple_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Purple_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket3_Purple);

            HouseMarket4_Orange = new MarketFormsController( // Form Controller: ORANGE housing market
                market: myGameEngine.AllMarkets[9],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Orange,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Orange_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Orange_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Orange_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket4_Orange);

            HouseMarket5_Red = new MarketFormsController( // Form Controller: RED housing market
                market: myGameEngine.AllMarkets[10],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Red,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Red_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Red_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Red_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket5_Red);

            HouseMarket6_Yellow = new MarketFormsController( // Form Controller: YELLOW housing market
                market: myGameEngine.AllMarkets[11],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Yellow,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Yellow_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Yellow_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Yellow_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket6_Yellow);

            HouseMarket7_Green = new MarketFormsController( // Form Controller: GREEN housing market
                market: myGameEngine.AllMarkets[12],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Green,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Green_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Green_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Green_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket7_Green);

            HouseMarket8_Blue = new MarketFormsController( // Form Controller: BLUE housing market
                market: myGameEngine.AllMarkets[13],
                marketPanel: panel_HousingMarketFullDisplay,
                marketNameLabel: label_HouseMarket_Blue,
                marketBackgroundPictureBox: pictureBox_HousingMarket_FullDisplay_Background,
                marketPricePictureBox: pictureBox_HouseMarket_Blue_Price,
                marketEvaluationPictureBox: pictureBox_HouseMarket_Blue_Evaluation,
                marketFutureIndicatorPictureBox: pictureBox_HouseMarket_Blue_FutureIndicator
            );
            AllMarketControllers.Add(HouseMarket8_Blue);


            DoTheShift();
        }

        // Method to export MarketState list to CSV in the Downloads folder
        static void ExportMarketStatesToCSV(List<Market> markets)
        {
            try
            {
                // Get the path to the Downloads folder
                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                // Define the file path for the CSV file
                string filePath = Path.Combine(downloadsFolder, "MarketStates.csv");

                // Open or create the file in the Downloads folder
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($" , , , , ,ALL STOCKS COMPARED");
                    writer.WriteLine($"{markets[0].Name},{markets[1].Name},{markets[2].Name},{markets[3].Name},{markets[4].Name}");
                    for (int i = 0; i < markets[0].PriceChart.Count; i++)
                    {
                        writer.WriteLine($"{markets[0].PriceChart[i].Price},{markets[1].PriceChart[i].Price},{markets[2].PriceChart[i].Price},{markets[3].PriceChart[i].Price},{markets[4].PriceChart[i].Price}");
                    }

                    foreach (Market market in markets)
                    {
                        // Write the header line
                        writer.WriteLine($" , , ,{market.Name}");
                        writer.WriteLine($"Price,Value,Future, ");

                        // Write each MarketState entry as a CSV row
                        foreach (var marketState in market.PriceChart)
                        {
                            writer.WriteLine($"{marketState.Price},{marketState.Evaluation},{marketState.FutureIndicator}, ");
                        }

                        // Write the header finisher
                        writer.WriteLine($"===,===,===, ");
                    }
                }

                // Confirm file creation
                Console.WriteLine($"File successfully saved to: {filePath}");

                // Open the file after it is created
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void button_ExportAllMarkets_Click(object sender, EventArgs e)
        {
            ExportMarketStatesToCSV(myGameEngine.AllMarkets);
        }

        private void button_MarketShiftForward_Click(object sender, EventArgs e)
        {
            DoTheShift();
        }

        void DoTheShift()
        {
            foreach (MarketFormsController mfc in AllMarketControllers)
            {
                mfc.GoToNextMarketState();
            }
        }
    }
}
