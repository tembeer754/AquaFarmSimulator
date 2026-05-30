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
            RequiredFood = FoodType.FishFood;
        }

        public override void Live(double currentTemp, bool isBroken)
        {
            if (!IsAlive)
            {
                return;
            }

            Hunger += 0.3;

            if (Math.Abs(currentTemp - OptimalTemp) > 5)
            {
                Health -= 0.5;
            }

            if (isBroken)
            {
                Health -= 1.0;
            }

            if (Hunger > 80)
            {
                Health -= 1.5;
            }

            CheckMortalityRisk();
        }
    }
}