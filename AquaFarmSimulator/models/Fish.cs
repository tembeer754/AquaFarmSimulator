using System;

namespace AquaFarmSimulator.Models
{
    public class Fish : AquaticEntity
    {
        public Fish(string name, double optTemp)
        {
            Name = name;
            OptimalTemp = optTemp;
            IsAggressive = false;
        }

        public override void Live(double currentTemp, bool isBroken)
        {
            if (!IsAlive)
            {
                return;
            }

            Hunger += 2;

            if (Math.Abs(currentTemp - OptimalTemp) > 5)
            {
                Health -= 3;
            }

            if (isBroken)
            {
                Health -= 5;
            }

            if (Hunger > 80)
            {
                Health -= 4;
            }

            CheckMortalityRisk();
        }
    }
}