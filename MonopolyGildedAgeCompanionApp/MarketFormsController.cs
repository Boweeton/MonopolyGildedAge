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
        public Label? MarketLabel { get; set; } // Allow nullable
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
            MarketLabel = marketNameLabel;
            MarketBackgroundPictureBox = marketBackgroundPictureBox;
            MarketPricePictureBox = marketPricePictureBox;
            MarketEvaluationPictureBox = marketEvaluationPictureBox;
            MarketFutureIndicatorPictureBox = marketFutureIndicatorPictureBox;

            // Safely set attributes if the controls are not null
            if (MarketPricePictureBox != null && MarketBackgroundPictureBox != null)
            {
                MarketPricePictureBox.Parent = MarketBackgroundPictureBox;
                MarketPricePictureBox.BackColor = System.Drawing.Color.Transparent;
                MarketPricePictureBox.Visible = false;
                MarketPricePictureBox.Enabled = false;
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

            if (MarketLabel != null && MarketBackgroundPictureBox != null)
            {
                MarketLabel.Parent = MarketBackgroundPictureBox;
                MarketLabel.BackColor = System.Drawing.Color.Transparent;
                //MarketNameLabel.Visible = false;
            }
        }


        // Methods
        public void GoToNextMarketState()
        {
            // If there are MarketStates remaining
            if (Market.CurrentChartPosition < Market.PriceChart.Count)
            {
                Market.ShiftUp();
                SetPriceImage(Market.CurrentPrice);
                SetEvaluationImage(Market.PriceChart[Market.CurrentChartPosition].Evaluation);
                SetFutureIndicatorImage(Market.PriceChart[Market.CurrentChartPosition].FutureIndicator);
            }
        }

        void SetPriceImage(int newPrice)
        {
            MarketLabel.Text = $"${newPrice}";
        }

        void SetEvaluationImage(int evaluationScore)
        {
            if (evaluationScore == -3)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_Low3;
            }
            if (evaluationScore == -2)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_Low2;
            }
            if (evaluationScore == -1)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_Low1;
            }
            if (evaluationScore == 0)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_Mid;
            }
            if (evaluationScore == 1)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_High1;
            }
            if (evaluationScore == 2)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_High2;
            }
            if (evaluationScore == 3)
            {
                MarketEvaluationPictureBox.Image = Properties.Resources.EVALUATION_STRIP_High3;
            }
        }

        void SetFutureIndicatorImage(int indicatorScore)
        {
            if (indicatorScore == -2)
            {
                MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Large_Fall;
            }
            if (indicatorScore == -1)
            {
                MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Fall;
            }
            if (indicatorScore == 0)
            {
                MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Nutral;
            }
            if (indicatorScore == 1)
            {
                MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Rise;
            }
            if (indicatorScore == 2)
            {
                MarketFutureIndicatorPictureBox.Image = Properties.Resources.FUTURE_INDICATOR_Large_Rise;
            }
        }
    }
}
