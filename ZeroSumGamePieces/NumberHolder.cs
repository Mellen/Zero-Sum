using System;
using System.Collections.Generic;

namespace ZeroSumGamePieces
{
    public class ZeroSumEventArgs
    {
        public List<Number> numbers;
        public ZeroSumEventArgs(List<Number> numbers)
        {
            this.numbers = numbers;
        }
    }

    /// <summary>
    /// A container for Number objects
    /// </summary>
    public class NumberHolder
    {
        public const int RowMax = 6;
        public const int ColMax = 23;
        public delegate void ZeroSumEventHandler(ZeroSumEventArgs e);
        public event ZeroSumEventHandler ZeroSum;
        private Number[] numbers;
        public int NumberCount
        {
            get
            {
                return numbers.Length;
            }
        }

        public Number this[int index]
        {
            get
            {
                return numbers[index];
            }
        }

        /// <summary>
        /// Contrsuctor.
        /// Creates a new array of numbers.
        /// </summary>
        /// <param name="MaxNumbers">Size of the array</param>
        public NumberHolder(int MaxNumbers)
        {
            numbers = new Number[MaxNumbers];
        }

        /// <summary>
        /// Sets the states of all the numbers below and including index to falling.
        /// </summary>
        /// <param name="index">Index of the first number to set to falling</param>
        public void SetFallingFromIndex(int index)
        {
            while (index > -1)
            {
                if (numbers[index] != null)
                {
                    numbers[index].CurrentState = NumberState.falling;
                }
                --index;
            }
        }

        /// <summary>
        /// Removes a number from the numbers array
        /// </summary>
        /// <param name="index">Index of the number to be removed</param>
        /// <returns>The number that's been removed</returns>
        public Number RemoveNumber(int index)
        {
            Number result = numbers[index];
            numbers[index] = null;
            return result;
        }

        /// <summary>
        /// Event handler for Number.OnRemove.
        /// Removes a number the numbrs array.
        /// </summary>
        /// <param name="e">Number to be removed</param>
        public void RemoveNumberEvent(RemoveEventArgs e)
        {
            int index = 0;
            bool found = false;
            while((index < numbers.Length)&&(!found))
            {
                if (numbers[index] == e.number)
                {
                    numbers[index] = null;
                    found = true;
                    SetFallingFromIndex(index);
                }
                ++index;
            }
        }

        /// <summary>
        /// Event handler for Number Stop events.
        /// Checks if a zero sum has been made. If one has the a ZeroSum event is raised.
        /// </summary>
        /// <param name="e">Contains the index of the number that has stopped</param>
        public void Stop(StopEventArgs e)
        {
            int index = e.index;
            int nextIndex = index + 1;
            Number Start = numbers[e.index];
            int sum = 0;
            if (Start != null)
            {
                sum = Start.Value;
            }
            List<Number> gonners = new List<Number>();
            while ((Start != null) && (Start.Value != 0) && (sum != 0) && (index > -1))
            {
                sum = Start.Value;
                while ((nextIndex < numbers.Length) && (sum != 0) && (numbers[nextIndex] != null) && (numbers[nextIndex].Value != 0))
                {
                    sum += numbers[nextIndex].Value;
                    if (sum == 0)
                    {
                        for (int i = index; i <= nextIndex; ++i)
                        {
                            gonners.Add(numbers[i]);
                        }
                    }
                    ++nextIndex;
                }
                --index;
                nextIndex = index + 1;
                if (index > -1)
                {
                    Start = numbers[index];
                }
            }
            if (gonners.Count > 0)
            {
                ZeroSum(new ZeroSumEventArgs(gonners));
            }
        }

        /// <summary>
        /// Tries to add a number to the numbers array.
        /// </summary>
        /// <param name="number">Number to add to the array</param>
        /// <param name="index">Array index to add the Number at</param>
        /// <returns>True if the number gets added, else false</returns>
        public bool AddNumber(Number number, int index)
        {
            if (numbers[index] == null)
            {
                numbers[index] = number;
                return true;
            }
            return false;
        }
    }
}
