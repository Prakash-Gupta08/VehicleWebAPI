namespace VehicleWebAPICRUD.PaginationResult
{
    public class PageResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord {  get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
     
    }
}
