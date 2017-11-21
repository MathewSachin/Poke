namespace Poke
{
    public class NonVolatileStatusDefinition
    {
        public NonVolatileStatusDefinition(NonVolatileStatus Status, double Probability = 1)
        {
            this.Status = Status;
            this.Probability = Probability;
        }

        public NonVolatileStatus Status { get; }

        public double Probability { get; }
    }
}