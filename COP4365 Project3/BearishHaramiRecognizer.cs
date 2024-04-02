using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project3
{
    class BearishHaramiRecognizer : Recognizer
    {
        /*
         * Pattern recognize function
        */
        public override bool recognizePattern(List<SmartCandlestick> Lscs)
        {
            return Lscs[0].isBullish && Lscs[1].isBearish && Lscs[0].bodyRange > Lscs[1].bodyRange;
        }

        /*
         * Pattern name property.
         * Readonly.
        */
        public override string patternName
        {
            get
            {
                return "Bearish Harami";
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
                return 2;
            }
        }
    }
}
