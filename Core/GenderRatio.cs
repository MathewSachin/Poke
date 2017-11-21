using System;

namespace Poke
{
    public class GenderRatio
    {
        GenderRatio() { }

        public GenderRatio(double Male, double Female)
        {
            if (Math.Abs(Male + Female - 100) > 0.1 || Male < 0 || Female < 0)
                throw new ArgumentException();

            this.Male = Male;
            this.Female = Female;
        }

        public static GenderRatio Genderless { get; } = new GenderRatio();

        public static GenderRatio Balanced { get; } = new GenderRatio(50, 50);

        public static GenderRatio MaleOnly { get; } = new GenderRatio(100, 0);

        public static GenderRatio FemaleOnly { get; } = new GenderRatio(0, 100);

        public double Male { get; } = -1;

        public double Female { get; } = -1;
    }
}