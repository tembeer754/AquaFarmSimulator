using System;

namespace AquaFarmSimulator.Models
{
    public class Mollusk : AquaticEntity
    {
        public Mollusk(string name, double optTemp)
        {
            Name = name;
            OptimalTemp = optTemp;
            IsAggressive = false;
            RequiredFood = FoodType.MolluskPlankton;
        }

        public override void Live(double currentTemp, bool isBroken)
        {
            if (!IsAlive)
            {
                return;
            }

            // Молюски - повільний метоболізм
            Hunger += 0.2;

            if (Math.Abs(currentTemp - OptimalTemp) > 5)
            {
                Health -= 2;
            }

            if (isBroken)
            {
                Health -= 4;
            }

            CheckMortalityRisk();
        }
    }
}