namespace AquaFarmSimulator.Models
{
    public class Algae : AquaticEntity
    {
        public Algae(string name)
        {
            Name = name;
            OptimalTemp = 22;
            RequiredFood = FoodType.AlgaeFertilizer;
        }

        public override void Live(double currentTemp, bool isBroken)
        {
            if (!IsAlive)
            {
                return;
            }

            Hunger += 1; // Брак мінералів
            if (Hunger > 90)
            {
                Health -= 2;
            }

            CheckMortalityRisk();
        }

        public double ProduceOxygen()
        {
            if (IsAlive)
            {
                return 5.0;
            }
            else
            {
                return 0;
            }
        }
    }
}