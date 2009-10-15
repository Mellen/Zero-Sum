using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZeroSumGamePieces
{
    public class StopEventArgs : EventArgs
    {
        public int index;
        public StopEventArgs(int index)
        {
            this.index = index;
        }
    }
    public class RemoveEventArgs : EventArgs
    {
        public Number number;
        public RemoveEventArgs(Number number)
        {
            this.number = number;
        }
    }

    public enum NumberState { falling, stopped, remove };

    /// <summary>
    /// Primary game piece.
    /// </summary>
    public class Number
    {
        public delegate void StopEventHandler(StopEventArgs e);
        public delegate void RemoveEventHandler(RemoveEventArgs e);
        public event StopEventHandler StopEventRow;
        public event StopEventHandler StopEventColumn;
        public event RemoveEventHandler OnRemove;
        public Label Display;
        private int value;
        public int Value
        {
            get
            {
                return value;
            }
        }
        public int Row;
        public int Column;
        private NumberState currentState;
        /// <summary>
        /// Accessor for the current state of the number.
        /// Fires a Stop event if the state becomes stopped.
        /// Fires an OnRemove event if the state becomes remove.
        /// </summary>
        public NumberState CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                if (currentState == NumberState.stopped)
                {
                    StopEventColumn(new StopEventArgs(Row));
                    StopEventRow(new StopEventArgs(Column));
                }
                if (currentState == NumberState.remove)
                {
                    OnRemove(new RemoveEventArgs(this));
                }
            }
        }

        public void BlankRemove(RemoveEventArgs e)
        {
        }

        /// <summary>
        /// Outputs the string value for the Number.
        /// </summary>
        /// <returns>Value of the Number</returns>
        public override string ToString()
        {
            string val = (value > 0) ? "+" + value.ToString() : value.ToString();
            return val;
        }

        private void EmptyStopHandler(StopEventArgs e)
        {

        }

        /// <summary>
        /// Constructor.
        /// Set event handlers and creates the label for viewing the Number.
        /// </summary>
        /// <param name="val">Value for the number</param>
        public Number(int val)
        {
            OnRemove += BlankRemove;
            StopEventColumn += EmptyStopHandler;
            StopEventRow += EmptyStopHandler;
            value = val;
            Display = new Label();
            Display.AutoSize = true;
            Display.Text = this.ToString();
            currentState = NumberState.stopped;
        }
    }
}
