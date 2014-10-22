using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EsthaHelpers.Time
{
    /// <summary>
    /// Class for an easy-peasy use of stopwatches;
    /// </summary>
    public class EasyStopwatch
    {
        //DIctionary with all stopwatches started.
        private static Dictionary<string, Stopwatch> easyStopwatchDictionary = new Dictionary<string, Stopwatch>();

        public static void start(String whichTitle)
        {
            try
            {
                if (!easyStopwatchDictionary.ContainsKey(whichTitle))
                {
                    easyStopwatchDictionary.Add(whichTitle, new Stopwatch());
                }

                easyStopwatchDictionary[whichTitle].Start();
            }
            catch (Exception e)
            {
                Debug.Write("EsthaHelpers.Time Exception: " + e.ToString());
            }
        }

        public static long inter(String whichTitle)
        {
            try
            {
                if (easyStopwatchDictionary.ContainsKey(whichTitle))
                {
                    Debug.Write(System.String.Format(
                            "\"" + whichTitle + "\" stopwatch: " +
                            easyStopwatchDictionary[whichTitle].Elapsed.ToString() +
                            "\n"
                    ));
                    return  easyStopwatchDictionary[whichTitle].Elapsed.Ticks;
                }
            }
            catch (Exception e)
            {
                Debug.Write("EsthaHelpers.Time Exception: " + e.ToString());
            }
            return 0;
        }

        public static long end__(String whichTitle)
        {
            try
            {
                if (easyStopwatchDictionary.ContainsKey(whichTitle))
                {
                    easyStopwatchDictionary[whichTitle].Stop();
                    Debug.Write(System.String.Format(
                            "\"" + whichTitle + "\" stopwatch: " +
                            easyStopwatchDictionary[whichTitle].Elapsed.ToString() +
                            "\n"
                    ));
                    long elapsetTicks = easyStopwatchDictionary[whichTitle].Elapsed.Ticks;
                    easyStopwatchDictionary.Remove(whichTitle);
                    return elapsetTicks;
                }
            }
            catch (Exception e)
            {
                Debug.Write("EsthaHelpers.Time Exception: " + e.ToString());
            }
            return 0;
        }

    }
}