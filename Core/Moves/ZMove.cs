namespace Poke
{
    public class ZMove : Move
    {
        public Move BaseMove { get; }

        public ZMove(MoveInfo Info, Move BaseMove) : base(Info)
        {
            this.BaseMove = BaseMove;
        }

        public override int PPLeft
        {
            get => BaseMove.PPLeft;
            set => BaseMove.PPLeft = value;
        }
    }
}