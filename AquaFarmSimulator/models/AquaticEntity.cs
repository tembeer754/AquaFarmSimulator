using System;
using System.Drawing;

namespace AquaFarmSimulator.Models
{
    public abstract class AquaticEntity
    {
        public string Name { get; set; }
        public double Health { get; set; } = 100;
        public double Hunger { get; set; } = 0;
        public double OptimalTemp { get; set; }
        public bool IsAlive => Health > 0;
        public bool IsAggressive { get; protected set; } = false;

        protected Random _rnd = new Random();

        public abstract void Live(double currentTemp, bool isBroken);

        public void Eat(double foodAmount)
        {
            if (!IsAlive)
            {
                return;
            }

            Hunger -= foodAmount;
            if (Hunger < 0)
            {
                Hunger = 0;
            }

            Health += 5; // Годування трохи лікує
            if (Health > 100)
            {
                Health = 100;
            }
        }

        protected void CheckMortalityRisk()
        {
           
            if (Health < 40 && Health > 0)
            {
                // Шанс померти від 40
                if (_rnd.Next(0, 100) < (40 - Health))
                {
                    Health = 0;
                }
            }
        }

        public Color GetStatusColor()
        {
            if (!IsAlive)
            {
                return Color.DimGray;
            }
            if (Health < 40) 
            {
                return Color.IndianRed;
            }
            if (Hunger > 70 || Health < 70) 
            {
                return Color.Goldenrod;
            }
            return Color.ForestGreen;
        }
    }
}