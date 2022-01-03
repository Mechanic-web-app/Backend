using System;

namespace MechanicWebAppAPI.Core.Dtos.Car
{
    public class CarDto
    {
        public Guid Car_id { get; set; }
        public string Car_brand { get; set; }

        public string Car_model { get; set; }
        public string Car_reg_number { get; set; }
        public Guid Car_user_id { get; set; }
    }
}
