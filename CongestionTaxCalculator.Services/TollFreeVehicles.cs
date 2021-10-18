using System.Collections.Generic;

namespace CongestionTaxCalculator.Helpers
{
    public static class TollFreeVehicles
    {
        static List<string> vehicles;

        static TollFreeVehicles()
        {
            vehicles = new List<string>();
            vehicles.Add("Motorcycle");
            vehicles.Add("Tractor");
            vehicles.Add("Emergency");
            vehicles.Add("Diplomat");
            vehicles.Add("Foreign");
            vehicles.Add("Military");
        }

        public static bool CheckListOfFreeTollVehicles(string vehicle)
        {
            if(vehicles.Contains(vehicle))
            {
                return true;
            }

            return false;
        }
    }
}
