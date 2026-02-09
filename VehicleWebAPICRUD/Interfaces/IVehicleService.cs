using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleWebAPICRUD.CommonResponse;
using VehicleWebAPICRUD.Data;
using VehicleWebAPICRUD.Models;
using VehicleWebAPICRUD.PaginationResult;

namespace VehicleWebAPICRUD.Interfaces
{
    public interface IVehicleService
    {
        Task<ApiResponse> GetAllVehicle();
        Task<ApiResponse> GetVehicleById(int id);
        Task<ApiResponse> GetPage(string? searchText, int pageNumber, int pageSize);
        Task<ApiResponse> CreateDetail(vehicle std);
        Task<ApiResponse> UpdateDetail(UpdateRequest res);
        Task<ApiResponse> DeleteDetail(int id);
        Task<ApiResponse> GetVehicles
            (
            string vehicle_seat, decimal minPrice,
            decimal maxPrice
            );

    }
}
