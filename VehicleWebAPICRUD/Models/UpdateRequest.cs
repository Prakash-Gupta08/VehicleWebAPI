namespace VehicleWebAPICRUD.Models
{
    public class UpdateRequest
    {
        public int vehicle_id { get; set; }
        public string vehicle_name { get; set; }
        public int vehicle_price { get; set; }
        public string vehicle_seat { get; set; }
       
    }
}
