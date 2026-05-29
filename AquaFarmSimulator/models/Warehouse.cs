namespace AquaFarmSimulator.Models
{
    public static class Warehouse
    {

        public static double Money { get; set; } = 1000;
        public static double FishFood { get; set; } = 100;
        public static double MolluskFood { get; set; } = 50;
        public static double SharkMeat { get; set; } = 30;
        public static double Fertilizer { get; set; } = 50;
        public static int RepairKits { get; set; } = 5;


        public static bool TryGetFood(double amount)
        {
            if (FishFood >= amount)
            {
                FishFood -= amount;
                return true;
            }
            return false;
        }

        public static bool TryGetRepairKit()
        {
            if (RepairKits > 0)
            {
                RepairKits--;
                return true;
            }
            return false;
        }

        public static bool SpendMoney(double amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            return false;
        }
    }
}