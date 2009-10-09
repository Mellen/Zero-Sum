using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZeroSumGamePieces;

namespace ZeroSumGame
{
    public class LoadNumberEventArgs : EventArgs
    {
        public LoadNumberEventArgs(Number number)
        {
            this.EventNumber = number;
        }

        public Number EventNumber;
    }

    public class ScoreChangeEventArgs : EventArgs
    {
        public uint NewScore;
        public ScoreChangeEventArgs(uint score)
        {
            NewScore = score;
        }
    }

    public enum GameState { stop, playing, pause }

    public class Game
    {
        public const int RowMax = NumberHolder.ColMax;
        public const int ColMax = NumberHolder.RowMax;
        public const int MaxNumber = 9;
        public delegate void LoadNumberEventHandler(LoadNumberEventArgs e);
        public delegate void GameOverEventHandler();
        public delegate void ScoreChangeEventHandler(ScoreChangeEventArgs e);
        public event LoadNumberEventHandler LoadNumber;
        public event LoadNumberEventHandler MoveNumber;
        public event GameOverEventHandler GameOverEvent;
        public event ScoreChangeEventHandler ScoreChange;
        public event NumberHolder.ZeroSumEventHandler RemoveEvent;
        private NumberHolder[] Rows;
        private NumberHolder[] Columns;
        private List<Number> Numbers;
        public Number CurrentNumber;
        public Number NextNumber;
        private uint score;
        private uint highScore;
        public GameState currentState;
        public uint Score
        {
            get
            {
                return Score;
            }
        }
        public uint HighScore
        {
            get
            {
                return highScore;
            }
        }

        private void IncreaseScore(uint amount)
        {
            score += amount;
            ScoreChange(new ScoreChangeEventArgs(score));
        }

        public Game()
        {
            highScore = LoadHighScore();
            currentState = GameState.stop;
            Rows = new NumberHolder[Game.RowMax];
            for(int i = 0; i < Rows.Length; ++i)
            {
                Rows[i] = new NumberHolder(NumberHolder.RowMax);
                Rows[i].ZeroSum += ZeroSum;
            }
            Columns = new NumberHolder[Game.ColMax];
            for (int i = 0; i < Columns.Length; ++i)
            {
                Columns[i] = new NumberHolder(NumberHolder.ColMax);
                Columns[i].ZeroSum += ZeroSum;
            }
            foreach (NumberHolder col in Columns)
            {
                foreach (NumberHolder row in Rows)
                {
                    row.ZeroSum += col.RemoveZeroSum;
                    col.ZeroSum += row.RemoveZeroSum;
                }
            }
            LoadNumber += EmptyLoad;
            MoveNumber += EmptyLoad;
            GameOverEvent += GameOver;
            Numbers = new List<Number>();
            GenerateNextNumber();
        }

        private uint LoadHighScore()
        {
            if (System.IO.File.Exists("hs"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("hs");
                string hs = sr.ReadToEnd();
                sr.Close();
                return Convert.ToUInt32(hs);
            }
            else
            {
                return 21;
            }
        }

        private void SaveHighScore()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("hs");
            sw.Write(highScore.ToString());
        }

        private void ZeroSum(ZeroSumEventArgs e)
        {
            uint increase = 0;
            for(int i = 0; i < e.numbers.Count; ++i)
            {
                increase += (uint)i;
                e.numbers[i].CurrentState = NumberState.remove;
                Columns[e.numbers[i].Column].SetFallingFromIndex(e.numbers[i].Row - 1);
            }
            IncreaseScore(increase);
        }

        private void EmptyLoad(LoadNumberEventArgs e)
        {
            /*
             * Why do I do this?
             * Because I believe that firing an event that has no handlers should not cause an exception.
             * Nothing should happen.
             * It's not unusual that you do something that no one cares about.
             */
        }

        private void GameOver()
        {
            currentState = GameState.stop;
            RemoveEvent(new ZeroSumEventArgs(Numbers));
            Rows = new NumberHolder[Game.RowMax];
            for (int i = 0; i < Rows.Length; ++i)
            {
                Rows[i] = new NumberHolder(NumberHolder.RowMax);
                Rows[i].ZeroSum += ZeroSum;
            }
            Columns = new NumberHolder[Game.ColMax];
            for (int i = 0; i < Columns.Length; ++i)
            {
                Columns[i] = new NumberHolder(NumberHolder.ColMax);
                Columns[i].ZeroSum += ZeroSum;
            }
            foreach (NumberHolder col in Columns)
            {
                foreach (NumberHolder row in Rows)
                {
                    row.ZeroSum += col.RemoveZeroSum;
                    col.ZeroSum += row.RemoveZeroSum;
                }
            }
            Numbers = new List<Number>();
            CurrentNumber = null;
            NextNumber = null;
            GenerateNextNumber();
        }

        private void GenerateNextNumber()
        {
            Random r = new Random();
            int val = (int)Math.Ceiling(r.NextDouble() * Game.MaxNumber);
            int signChance = (int)Math.Ceiling(r.NextDouble() * 2);
            val = val * (signChance == 1 ? -1 : 1);
            NextNumber = new Number(val);
            Numbers.Add(NextNumber);

        }

        public void Start()
        {
            score = 0;
            currentState = GameState.playing;
            ScoreChange(new ScoreChangeEventArgs(score));
            LoadNewNumber();
        }

        private void LoadNewNumber()
        {
            CurrentNumber = NextNumber;
            CurrentNumber.Row = 0;
            CurrentNumber.Column = ColMax / 2;
            CurrentNumber.CurrentState = NumberState.falling;
            bool didAddToRow = Rows[CurrentNumber.Row].AddNumber(CurrentNumber, CurrentNumber.Column);
            bool didAddToColumn = Columns[CurrentNumber.Column].AddNumber(CurrentNumber, CurrentNumber.Row);
            if (!didAddToColumn || !didAddToRow)
            {
                GameOverEvent();
            }
            else
            {
                CurrentNumber.StopEventColumn += Columns[CurrentNumber.Column].Stop;
                CurrentNumber.StopEventRow += Rows[CurrentNumber.Row].Stop;
                GenerateNextNumber();
                LoadNumber(new LoadNumberEventArgs(CurrentNumber));
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if ((CurrentNumber != null) && (currentState == GameState.playing)&&(CurrentNumber.CurrentState == NumberState.falling))
            {
                if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
                {
                    int move = (e.KeyCode == Keys.Left) ? -1 : 1;
                    int col = CurrentNumber.Column;
                    col += move;
                    if ((col > -1) && (col < Game.ColMax))
                    {
                        bool didAddToRow = Rows[CurrentNumber.Row].AddNumber(CurrentNumber, col);
                        bool didAddToColumn = Columns[col].AddNumber(CurrentNumber, CurrentNumber.Row);

                        if (didAddToRow && didAddToColumn)
                        {
                            Columns[CurrentNumber.Column].RemoveNumber(CurrentNumber.Row);
                            CurrentNumber.StopEventColumn -= Columns[CurrentNumber.Column].Stop;
                            CurrentNumber.StopEventColumn += Columns[col].Stop;
                            Rows[CurrentNumber.Row].RemoveNumber(CurrentNumber.Column);
                            CurrentNumber.Column = col;
                            MoveNumber(new LoadNumberEventArgs(CurrentNumber));
                        }
                    }
                }

                if (e.KeyCode == Keys.Space)
                {
                    int row = CurrentNumber.Row;
                    ++row;
                    if (row < Game.RowMax)
                    {
                        bool didAddToRow = Rows[row].AddNumber(CurrentNumber, CurrentNumber.Column);
                        bool didAddToColumn = Columns[CurrentNumber.Column].AddNumber(CurrentNumber, row);
                        while (didAddToRow && didAddToColumn)
                        {
                            Rows[CurrentNumber.Row].RemoveNumber(CurrentNumber.Column);
                            CurrentNumber.StopEventRow -= Rows[CurrentNumber.Row].Stop;
                            CurrentNumber.StopEventRow += Rows[row].Stop;
                            Columns[CurrentNumber.Column].RemoveNumber(CurrentNumber.Row);
                            CurrentNumber.Row = row;
                            MoveNumber(new LoadNumberEventArgs(CurrentNumber));
                            ++row;
                            if (row < Game.RowMax)
                            {
                                didAddToRow = Rows[row].AddNumber(CurrentNumber, CurrentNumber.Column);
                                didAddToColumn = Columns[CurrentNumber.Column].AddNumber(CurrentNumber, row);
                            }
                            else
                            {
                                didAddToColumn = false;
                                didAddToRow = false;
                            }
                        }
                    }

                    CurrentNumber.CurrentState = NumberState.stopped;
                }
            }
        }

        public void GameStep(object sender, EventArgs e)
        {
            if (currentState == GameState.playing)
            {
                foreach (Number n in Numbers)
                {
                    if (n.CurrentState == NumberState.falling)
                    {
                        if (n.Row == (Game.RowMax - 1))
                        {
                            n.CurrentState = NumberState.stopped;
                        }
                        else
                        {
                            int row = n.Row;
                            ++row;
                            bool didAddToRow = Rows[row].AddNumber(n, n.Column);
                            bool didAddToColumn = Columns[n.Column].AddNumber(n, row);
                            if (didAddToRow && didAddToColumn)
                            {
                                Rows[n.Row].RemoveNumber(n.Column);
                                n.StopEventRow -= Rows[n.Row].Stop;
                                n.StopEventRow += Rows[row].Stop;
                                Columns[n.Column].RemoveNumber(n.Row);
                                n.Row = row;
                                MoveNumber(new LoadNumberEventArgs(n));
                            }
                            else
                            {
                                n.CurrentState = NumberState.stopped;
                            }
                        }

                    }
                }

                if (CurrentNumber.CurrentState == NumberState.stopped)
                {
                    CurrentNumber = null;
                    LoadNewNumber();
                }

                Number[] temp = new Number[Numbers.Count];
                Numbers.CopyTo(temp);
                List<Number> removals = new List<Number>();

                foreach (Number n in temp)
                {
                    if (n.CurrentState == NumberState.remove)
                    {
                        Numbers.Remove(n);
                        removals.Add(n);
                    }
                }

                if (removals.Count > 0)
                {
                    RemoveEvent(new ZeroSumEventArgs(removals));
                    LoadNewNumber();
                }
            }
        }
    }
}
