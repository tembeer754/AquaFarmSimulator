using System;

namespace AquaFarmSimulator.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public AquaticEntity Entity { get; set; }
        public bool IsAeratorBroken { get; set; } = false;
        public double Temperature { get; set; } = 20.0;
        public double OxygenLevel { get; set; } = 100.0;

        private Random _rnd = new Random();

        public Sector(int id, AquaticEntity entity)
        {
            Id = id;
            Entity = entity;
        }

        public void Update()
        {
            // Випадкова поломка аератора (шанс 5%)
            if (!IsAeratorBroken && _rnd.Next(0, 500) < 2)
            {
                IsAeratorBroken = true;
            }

            // Якщо аератор зламаний — кисень падає
            if (IsAeratorBroken)
            {
                OxygenLevel -= 10;
            }
            else
            {
                if (OxygenLevel < 100)
                {
                    OxygenLevel += 5;
                }
            }

            if (OxygenLevel < 0)
            {
                OxygenLevel = 0;
            }


            if (Entity != null)
            {
                Entity.Live(Temperature, IsAeratorBroken || OxygenLevel < 30);
            }

            if (Entity != null)
            {
                // Поломка аератора (шанс 2 на 500)
                if (!IsAeratorBroken && _rnd.Next(0, 500) < 2)
                {
                    IsAeratorBroken = true;
                }

                // Рівень кисню
                if (IsAeratorBroken)
                {
                    OxygenLevel -= 5;
                }
                else
                {
                    if (OxygenLevel < 100) OxygenLevel += 3;
                }

                if (OxygenLevel < 0) OxygenLevel = 0;

                // Викликаємо життєдіяльність
                Entity.Live(Temperature, IsAeratorBroken || OxygenLevel < 30);

                // Температура трохи коливається для реалізму (датчики)
                Temperature += (_rnd.NextDouble() - 0.5);
            }
            else
            {
                // Якщо секторі порожньо - він самовідновлюється до ідеалу
                IsAeratorBroken = false;
                OxygenLevel = 100;
                Temperature = 20.0;
            }
        }

        public void Repair()
        {
            IsAeratorBroken = false;
            OxygenLevel = 100;
        }
    }
}