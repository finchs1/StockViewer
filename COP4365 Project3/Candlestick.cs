using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Project3
{
    /*
     * Period enum
     */
    public enum Period
    {
        Daily,
        Weekly,
        Monthly
    }

    /*
     * Candlestick class.
     * Stores ticker, period, date, open, high, low, close, and volume.
     */
    public class Candlestick
    {
        /*
         * Constructs candlestick with the given arguments.
         */
        public Candlestick(string ticker, string period, DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
        {
            this.ticker = ticker;
            this.period = period;
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        /*
         * Constructs candlestick with another candlestick; copy constructor 
        */
        public Candlestick(Candlestick cs)
        {
            this.ticker = cs.ticker;
            this.period = cs.period;
            this.date = cs.date;
            this.open = cs.open;
            this.high = cs.high;
            this.low = cs.low;
            this.close = cs.close;
            this.volume = cs.volume;
        }

        /*
         * Converts a string to a period.
         */
        public static Period strToPeriod(string str)
        {
            if (str.Length != 0 && str[0] == 'D')
                return Period.Daily;
            else if (str.Length != 0 && str[0] == 'W')
                return Period.Weekly;
            else
                return Period.Monthly;
        }

        /*
         * Converts a period to a string.
         */
        public static string periodToStr(Period p)
        {
            if (p == Period.Daily)
                return "Daily";
            else if (p == Period.Weekly)
                return "Weekly";
            else
                return "Monthly";
        }

        //Internal Period object
        private Period _period;

        //Ticker string
        public string ticker { get; set; }

        //period object getter/setter
        public string period
        {
            get
            {
                return periodToStr(_period);
            }
            set
            {
                _period = strToPeriod(value);
            }
        }

        //date for candlestick
        public DateTime date { get; set; }

        //open
        public decimal open { get; set; }

        //high
        public decimal high { get; set; }

        //low
        public decimal low { get; set; }

        //close
        public decimal close { get; set; }
        
        //volume
        public long volume { get; set; }
    }
}
