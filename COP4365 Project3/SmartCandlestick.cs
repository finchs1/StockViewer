using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_Project3
{
    internal class SmartCandlestick : Candlestick
    {
        /*
         * Constructs SmartCandlestick and calls init functions
        */
        public SmartCandlestick(string ticker, string period, DateTime date, decimal open, decimal high, decimal low, decimal close, long volume) : base(ticker, period, date, open, high, low, close, volume)
        {
            initHighLevelProperties();
            computePatterns();
        }

        /* 
         * Constructs SmartCandlestick with a Candlestick object
        */
        public SmartCandlestick(Candlestick cs) : base(cs)
        {
            initHighLevelProperties();
            computePatterns();
        }

        /*
         * Initializes high level properties of SmartCandlestick.
         * Range, bodyRange, topPrice. bottomPrice, topTail, bottomTail
        */
        private void initHighLevelProperties()
        {
            Range = high - low;
            bodyRange = Math.Abs(open - close);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = high - topPrice;
            bottomTail = bottomPrice - low;
        }

        /*
         * Computes pattern properties - isBullish, isBearish, isNeutral, isDoji, isMarubozu, isHammer, isDragonFlyDoji, isGravestoneDoji, isInvertedHammer
         * using leeway variables
        */
        private void computePatterns()
        {
            isBullish = close > open;
            isBearish = close < open;
            isNeutral = bodyRange <= leeway * Range;
            isDoji = isNeutral;
            isMarubozu = topTail <= leeway * Range && bottomTail <= leeway * Range;
            isHammer = bodyRange <= Range * hammerUpperRange && bodyRange >= Range * hammerLowerRange && topTail <= hammerLeeway * Range;
            isDragonFlyDoji = isNeutral && topTail <= Range * leeway;
            isGravestoneDoji = isNeutral && bottomTail <= Range * leeway;
            isInvertedHammer = bodyRange <= Range * hammerUpperRange && bodyRange >= Range * hammerLowerRange && bottomTail <= hammerLeeway * Range;
        }

        public decimal Range { get; set; }

        public decimal bodyRange { get; set; }

        public decimal topPrice { get; set; }

        public decimal bottomPrice { get; set; }

        public decimal topTail { get; set; }

        public decimal bottomTail { get; set; }

        public bool isBullish { get; set; }

        public bool isBearish { get; set; }

        public bool isNeutral { get; set; }

        public bool isHammer { get; set; } 
        
        public bool isMarubozu { get; set; }

        public bool isDoji { get; set; }

        public bool isDragonFlyDoji { get; set; }

        public bool isGravestoneDoji { get; set; }

        public bool isInvertedHammer { get; set; }

        public static decimal leeway = 0.03M;

        public static decimal hammerLeeway = 0.1M;

        public static decimal hammerUpperRange = 0.33M;

        public static decimal hammerLowerRange = 0.25M;
    }
}
