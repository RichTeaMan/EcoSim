using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic
{
    public static class RandNum
    {
        private static Random _random = new Random();

        private static object _IntegerLock = new object();
        /// <summary>
        /// Returns a non-negative random number.
        /// </summary>
        /// <returns></returns>
        public static int Integer()
        {
            lock (_IntegerLock)
            {
                return _random.Next();
            }
        }

        /// <summary>
        /// Returns a non-negative number less than maxValue.
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int Integer(int maxValue)
        {
            lock (_IntegerLock)
            {
                return _random.Next(maxValue);
            }
        }

        /// <summary>
        /// Returns a number within the specified values.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int Integer(int minValue, int maxValue)
        {
            lock (_IntegerLock)
            {
                return _random.Next(minValue, maxValue);
            }
        }

        private static  object _DoubleLock = new object();
        /// <summary>
        /// Returns a random double between 0.0 and 1.0.
        /// </summary>
        /// <returns></returns>
        public static double Double()
        {
            lock (_IntegerLock)
            {
                return _random.NextDouble();
            }
        }
        
    }
}
