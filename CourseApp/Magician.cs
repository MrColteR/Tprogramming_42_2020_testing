using System;

namespace CourseApp
{
    public class Magician : Player
    {
        public Magician(string name)
        : base(name)
        {
        }

        public override int DealDamage(bool useUlt)
        {
            if (useUlt)
            {
                Console.WriteLine($"{Name} ультанул, пропуск хода");
                return 0;
            }

            return Power;
        }
    }
}