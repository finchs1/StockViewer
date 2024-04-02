using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project3
{
    abstract class Recognizer
    {
        /*
         * Recognize function. Takes list of SmartCandlesticks
         * and inputs them into the recognizePattern() function that needs to be overridden by a derived class.
         * Returns a list of indices of recognized patterns from the SmartCandlestick list.
        */
        public List<int> recognize(List<SmartCandlestick> Lscs)
        {
            List<int> result = new List<int>(Lscs.Count);

            for (int i = patternSize - 1; i < Lscs.Count; i++)
                if (recognizePattern(Lscs.GetRange(i - patternSize + 1, patternSize)))
                    result.Add(i);

            return result;
        }

        /*
         * recognizePattern function.
         * Abstract.
        */
        public abstract bool recognizePattern(List<SmartCandlestick> Lscs);

        /*
         * patternName property.
         * Abstract and readonly.
        */
        public abstract string patternName { get; }

        /*
         * patternSize property.
         * Abstract and readonly.
        */
        public abstract int patternSize { get; }
    }
}
