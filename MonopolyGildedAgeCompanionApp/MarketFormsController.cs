using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolyGildedAgeCompanionApp
{
    internal class MarketFormsController
    {
        // Properties & Members

        private Market Market;
        public Panel MarketPanel { get; set; }
        public Label? MarketNameLabel { get; set; } // Allow nullable
        public PictureBox? MarketBackgroundPictureBox { get; set; } // Allow nullable
        public PictureBox? MarketPricePictureBox { get; set; } // Allow nullable
        public PictureBox? MarketEvaluationPictureBox { get; set; } // Allow nullable
        public PictureBox? MarketFutureIndicatorPictureBox { get; set; } // Allow nullable

        // Constructor
        public MarketFormsController(
            Market market,
            Panel marketPanel,
            Label? marketNameLabel = null,
            PictureBox? marketBackgroundPictureBox = null,
            PictureBox? marketPricePictureBox = null,
            PictureBox? marketEvaluationPictureBox = null,
            PictureBox? marketFutureIndicatorPictureBox = null)
        {
            Market = market ?? throw new ArgumentNullException(nameof(market));
            MarketPanel = marketPanel ?? throw new ArgumentNullException(nameof(marketPanel));
            MarketNameLabel = marketNameLabel;
            MarketBackgroundPictureBox = marketBackgroundPictureBox;
            MarketPricePictureBox = marketPricePictureBox;
            MarketEvaluationPictureBox = marketEvaluationPictureBox;
            MarketFutureIndicatorPictureBox = marketFutureIndicatorPictureBox;

            // Safely set attributes if the controls are not null
            if (MarketNameLabel != null && MarketBackgroundPictureBox != null)
            {
                MarketNameLabel.Parent = MarketBackgroundPictureBox;
                MarketNameLabel.BackColor = System.Drawing.Color.Transparent;
                MarketNameLabel.Visible = false;
            }

            if (MarketPricePictureBox != null && MarketBackgroundPictureBox != null)
            {
                MarketPricePictureBox.Parent = MarketBackgroundPictureBox;
                MarketPricePictureBox.BackColor = System.Drawing.Color.Transparent;
            }

            if (MarketEvaluationPictureBox != null && MarketBackgroundPictureBox != null)
            {
                MarketEvaluationPictureBox.Parent = MarketBackgroundPictureBox;
                MarketEvaluationPictureBox.BackColor = System.Drawing.Color.Transparent;
            }

            if (MarketFutureIndicatorPictureBox != null && MarketBackgroundPictureBox != null)
            {
                MarketFutureIndicatorPictureBox.Parent = MarketBackgroundPictureBox;
                MarketFutureIndicatorPictureBox.BackColor = System.Drawing.Color.Transparent;
            }
        }


        // Methods
        void GoToNextMarketState()
        {

        }

        void SetPriceImage()
        {

        }

        void SetEvaluationImage()
        {

        }

        void SetFutureIndicatorImage()
        {
            if (Market.PriceChart[Market.CurrentChartPosition].FutureIndicator == -2)
            {
                //MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Large_Rise;
            }
        }
    }
}
