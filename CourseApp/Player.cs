using System;

namespace CourseApp
{
    public class Player
    {
        private int health;
        private int power;
        private string name;
        private bool isOnFire = false;
        private bool frozen;
        private int defaultHealth;
        private int defaultPower;

        public Player(string name)
        {
            this.Name = name;
            Random random = new Random();
            this.defaultHealth = random.Next(40, 70);
            this.Health = this.defaultHealth;
            this.defaultPower = random.Next(10, 20);
            this.Power = this.defaultPower;
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Не верное значение");
                }
                else
                {
                    health = value;
                }
            }
        }

        public int Power
        {
            get
            {
                return power;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Не верное значение");
                }
                else
                {
                    power = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == " ")
                {
                    Console.WriteLine("Нет значения");
                }
                else
                {
                    name = value;
                }
            }
        }

        public virtual bool Frozen
        {
            get
            {
                return frozen;
            }

            set
            {
                value = false;
            }
        }

        public virtual int DealDamage(bool useUlt)
        {
            return Power;
        }

        public virtual int GetDamage(int damage, string type)
        {
            if (Health - damage < 0)
            {
                Health = 0;
                this.isOnFire = false;
            }
            else
            {
                Health -= damage;
            }

            if (this.isOnFire && type == "Archer")
            {
                return Health - 2;
            }

            if (damage == 0 && type == "Archer")
            {
                this.isOnFire = true;
            }

            if (this.frozen = true && type == "Magician")
            {
                this.frozen = false;
            }

            if (damage == 0 && type == "Magician")
            {
                this.frozen = true;
            }

            return Health;
        }

        public virtual bool UseUlt()
        {
            Random a = new Random();
            int powerA = a.Next(1, 4);
            return powerA == 2;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetPower()
        {
            return Power;
        }

        public string GetName()
        {
            return Name;
        }

        public void RestoreStats()
        {
            this.Health = this.defaultHealth;
            this.Power = this.defaultPower;
            this.isOnFire = false;
        }
    }
}