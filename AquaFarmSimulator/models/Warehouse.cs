namespace AquaFarmSimulator.Models
{
    public static class Warehouse
    {
        public static double Food { get; set; } = 100;
        public static int RepairKits { get; set; } = 5;

        public static bool TryGetFood(double amount)
        {
            if (Food >= amount)
            {
                Food -= amount;
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
    }
}