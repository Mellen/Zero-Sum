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
    public class NumberHolder
    {
        public const int RowMax = 6;
        public const int ColMax = 23;
        public delegate void ZeroSumEventHandler(ZeroSumEventArgs e);
        public event ZeroSumEventHandler ZeroSum;
        private Number[] numbers;

        public NumberHolder(int MaxNumbers)
        {
            numbers = new Number[MaxNumbers];
            this.ZeroSum += RemoveZeroSum;
        }

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

        public Number RemoveNumber(int index)
        {
            Number result = numbers[index];
            numbers[index] = null;
            return result;
        }

        public void RemoveZeroSum(ZeroSumEventArgs e)
        {
            for(int i = 0; i < numbers.Length; ++i)
            {
                if (e.numbers.Contains(numbers[i]))
                {
                    numbers[i] = null;
                }
            }
        }

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
            while ((Start != null) && (sum != 0) && (index > -1))
            {
                sum = Start.Value;
                while ((nextIndex < numbers.Length) && (sum != 0) && (numbers[nextIndex] != null))
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
