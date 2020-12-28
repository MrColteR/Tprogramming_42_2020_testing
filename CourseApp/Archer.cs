using System;

namespace CourseApp
{
    public class Archer : Player
    {
        public Archer(string name)
        : base(name)
        {
        }

        public override int DealDamage(bool useUlt)
        {
            if (useUlt)
            {
                Console.WriteLine($"{Name} ультанул, огненные стрелы");
                return 0;
            }

            return Power;
        }
    }
}