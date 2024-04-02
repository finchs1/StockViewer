﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project3
{
    class MarubozuRecognizer : Recognizer
    {
        /*
         * Pattern recognize function
        */
        public override bool recognizePattern(List<SmartCandlestick> Lscs)
        {
            return Lscs[0].isMarubozu;
        }

        /*
         * Pattern name property.
         * Readonly.
        */
        public override string patternName
        {
            get
            {
                return "Marubozu";
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
                return 1;
            }
        }
    }
}
