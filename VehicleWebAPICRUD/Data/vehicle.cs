using System.ComponentModel.DataAnnotations;

namespace VehicleWebAPICRUD.Data
{
    public class vehicle
    {
        [Key]
        public int vehicle_id { get; set; }
        public string vehicle_name { get; set; }
        public int vehicle_price { get; set; }
        public string vehicle_service { get; set; }
        public string vehicle_seat { get; set; }  
        public string vehicle_details { get; set; }
    }
}
