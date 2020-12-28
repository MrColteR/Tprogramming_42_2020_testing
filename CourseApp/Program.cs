using System;
using System.Threading;
using System.Collections.Generic;

namespace CourseApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите кол-во героев: ");
            int number = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            List<string> type = new List<string>();
            List<Player> excess = new List<Player>();
            List<Player> hero = new List<Player>(number);
            string[] nameArray = new string[20] { "Player_1", "Player_2", "Player_3", "Player_4", "Player_5", "Player_6", "Player_7", "Player_8", "Player_9", "Player_10", "Player_11", "Player_12", "Player_13", "Player_14", "Player_15", "Player_16", "Player_17", "Player_18", "Player_19", "Player_20" };
            if (number % 2.0 != 0)
            {
                throw new InvalidOperationException("Число героев нечетное");
            }

            for (int i = 0; i < number; i++)
            {
                Random random = new Random();
                string name = nameArray[random.Next(0, 19)];
                type.Add(GetHeroType());
                switch (type[i])
                {
                    case "Knight":
                    hero.Add(new Knight(name));
                    break;
                    case "Archer":
                    hero.Add(new Archer(name));
                    break;
                    case "Magician":
                    hero.Add(new Magician(name));
                    break;
                }
            }

            while (number > 1)
            {
                bool isExcessHero = false;
                if (hero.Count % 2.0 != 0)
                {
                    excess.Add(hero[hero.Count - 1]);
                    hero.RemoveAt(hero.Count - 1);
                    isExcessHero = true;
                }

                for (int i = 0; i < hero.Count; i = i + 2)
                {
                    Console.WriteLine($"Игрок: {hero[i].GetName()} класса {type[i]} cила = {hero[i].GetPower()}, ХР = {hero[i].GetHealth()} против Игрока: {hero[i + 1].GetName()} класса {type[i + 1]}, сила = {hero[i + 1].GetPower()} , ХР = {hero[i + 1].GetHealth()}");
                    Console.ReadKey();
                    int step = 0;
                    while (hero[i].GetHealth() > 0 && hero[i + 1].GetHealth() > 0)
                    {
                        Console.WriteLine($"{hero[i + step].GetName()} наносит урон игроку {hero[i + 1 - step].GetName()}");
                        if (!hero[i + step].Frozen)
                        {
                            hero[i + 1 - step].GetDamage(hero[i + step].DealDamage(hero[i + step].UseUlt()), type[i + step]);
                            Thread.Sleep(100);
                        }

                        Console.WriteLine($"Игрок {hero[i + 1 - step].GetName()}, XP = {hero[i + 1 - step].GetHealth()} ");
                        step = (step + 1) % 2;
                        Thread.Sleep(100);
                    }

                    if (hero[i].GetHealth() <= 0)
                    {
                        Console.WriteLine($"Игрок {hero[i + 1].GetName()} победил");
                        Console.WriteLine();
                        Console.ReadKey();
                    }

                    if (hero[i + 1].GetHealth() <= 0)
                    {
                        Console.WriteLine($"Игрок {hero[i].GetName()} победил");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }

                if (isExcessHero)
                {
                    hero.Add(excess[0]);
                    excess.RemoveAt(0);
                    isExcessHero = false;
                }

                int j = 0;
                while (j < hero.Count)
                {
                    if (hero[j].GetHealth() <= 0)
                    {
                        hero.RemoveAt(j);
                    }
                    else
                    {
                        hero[j].RestoreStats();
                        j++;
                    }
                }

                number = Convert.ToInt16(number / 2.0);
            }
        }

        private static string GetHeroType()
        {
            Random type = new Random();
            int typeHero = type.Next(1, 3);
            switch (typeHero)
                {
                    case 1:
                    return "Knight";
                    case 2:
                    return "Archer";
                    default:
                    return "Magician";
                }
        }
    }
}
