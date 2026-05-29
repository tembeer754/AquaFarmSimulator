namespace AquaFarmSimulator.Models
{
    public class Shark : AquaticEntity
    {
        public Shark(string name, double optTemp)
        {
            Name = name;
            OptimalTemp = optTemp;
            IsAggressive = true;
            RequiredFood = FoodType.SharkMeat;
        }

        public override void Live(double currentTemp, bool isBroken)
        {
            if (!IsAlive)
            {
                return;
            }

            Hunger += 4;

            if (isBroken)
            {
                Health -= 2;
            }

            if (Hunger > 80)
            {
                Health -= 10;
            }

            CheckMortalityRisk();
        }
    }
}