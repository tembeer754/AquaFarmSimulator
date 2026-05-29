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
            if (!IsAeratorBroken && _rnd.Next(0, 100) < 5)
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

            // Риба "живе" залежно від умов
            Entity.Live(Temperature, IsAeratorBroken || OxygenLevel < 30);
        }

        public void Repair()
        {
            IsAeratorBroken = false;
            OxygenLevel = 100;
        }
    }
}