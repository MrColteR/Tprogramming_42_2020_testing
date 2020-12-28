using System;

namespace CourseApp
{
    public class Knight : Player
    {
        public Knight(string name)
        : base(name)
        {
        }

        public override int DealDamage(bool useUlt)
        {
            if (useUlt)
            {
                Console.WriteLine($"{Name} ультанул, +30% к урону");
                return Convert.ToInt32(Math.Floor(Power * 1.3));
            }

            return Power;
        }
    }
}