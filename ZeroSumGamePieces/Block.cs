using System;
using System.Drawing;

namespace ZeroSumGamePieces
{
    public class Block : Number
    {
        private uint turnsLeft;

        public Block(uint turns)
            :base(0)
        {
            turnsLeft = turns;
            Display.ForeColor = Color.White;
            Display.BackColor = Color.Black;
        }

        public void DecreaseTurns()
        {
            --turnsLeft;
            if (turnsLeft == 0)
            {
                CurrentState = NumberState.remove;
            }
        }

        public override string ToString()
        {
            return "00";
        }
    }
}
