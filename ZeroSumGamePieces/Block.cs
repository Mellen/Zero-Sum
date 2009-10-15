using System;
using System.Drawing;

namespace ZeroSumGamePieces
{
    /// <summary>
    /// Secondary game piece. Prevents zero sums.
    /// </summary>
    public class Block : Number
    {
        private uint turnsLeft;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="turns">Number of turns the block will be in place</param>
        public Block(uint turns)
            :base(0)
        {
            turnsLeft = turns;
            Display.ForeColor = Color.White;
            Display.BackColor = Color.Black;
        }

        /// <summary>
        /// Deacreases the number of turns the block will be in place.
        /// </summary>
        public void DecreaseTurns()
        {
            --turnsLeft;
            if (turnsLeft == 0)
            {
                CurrentState = NumberState.remove;
            }
        }

        /// <summary>
        /// Outputs the value of the block as a string.
        /// </summary>
        /// <returns>00</returns>
        public override string ToString()
        {
            return "00";
        }
    }
}
