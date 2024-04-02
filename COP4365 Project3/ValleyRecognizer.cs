using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project3
{
    class ValleyRecognizer : Recognizer
    {
        /*
         * Pattern recognize function
        */
        public override bool recognizePattern(List<SmartCandlestick> Lscs)
        {
            return Lscs[0].low > Lscs[1].low && Lscs[2].low > Lscs[1].low;
        }

        /*
         * Pattern name property.
         * Readonly.
        */
        public override string patternName
        {
            get
            {
                return "Valley";
            }
        }

        /*
         * Pattern size property.
         * Readonly.
        */
        public override int patternSize
        {
            get
            {
                return 3;
            }
        }
    }
}