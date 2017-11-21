namespace Poke
{
    public class StatChange
    {
        public StatChange(Stats Stat, double Probability = 1, bool Self = true, int StageChange = 0)
        {
            this.Stat = Stat;
            this.Probability = Probability;
            this.StageChange = StageChange;
            this.Self = Self;
        }

        public bool Self { get; }

        public double Probability { get; }

        public Stats Stat { get; }
        
        public int StageChange { get; }
    }
}