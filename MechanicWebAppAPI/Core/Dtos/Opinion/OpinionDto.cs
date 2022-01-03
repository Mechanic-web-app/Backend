using System;

namespace MechanicWebAppAPI.Core.Dtos.Opinion
{
    public class OpinionDto
    {
        public Guid Opinion_id { get; set; }
        public string Opinion_description { get; set; }

        public int Opinion_rate { get; set; }
        public Guid Opinion_user_id { get; set; }
        public string Opinion_user_name { get; set; }
        public string Opinion_user_lastname { get; set; }
    }
}
