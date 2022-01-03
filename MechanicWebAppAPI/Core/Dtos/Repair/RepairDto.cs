using System;

namespace MechanicWebAppAPI.Core.Dtos.Repair
{
    public class RepairDto
    {
        public string Repair_description { get; set; }

        public int Repair_cost { get; set; }

        public string Repair_date { get; set; }

        public Guid Repaired_car_id { get; set; }
    }
}
