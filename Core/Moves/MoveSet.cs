using System;
using System.Collections;
using System.Collections.Generic;

namespace Poke
{
    public class MoveSet : IEnumerable<Move>
    {
        readonly Move[] _moves = new Move[4];

        public Move this[int Index]
        {
            get
            {
                if (Index < 0 || Index > 3)
                    throw new IndexOutOfRangeException();

                return _moves[Index];
            }
            private set
            {
                if (Index < 0 || Index > 3)
                    throw new IndexOutOfRangeException();

                _moves[Index] = value;
            }
        }

        public void Assign(int Index, MoveInfo Info)
        {
            this[Index] = new Move(Info);
        }

        public void Assign(MoveInfo First, MoveInfo Second, MoveInfo Third, MoveInfo Fourth)
        {
            Assign(0, First);
            Assign(1, Second);
            Assign(2, Third);
            Assign(3, Fourth);
        }

        public IEnumerator<Move> GetEnumerator() => ((IEnumerable<Move>) _moves).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}