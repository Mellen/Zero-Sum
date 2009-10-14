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

        public override string ToString()
        {
            string val = (value > 0) ? "+" + value.ToString() : value.ToString();
            return val;
        }

        private void EmptyStopHandler(StopEventArgs e)
        {

        }

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
