using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VehicleWebAPICRUD.CommonResponse;
using VehicleWebAPICRUD.Data;
using VehicleWebAPICRUD.Interfaces;
using VehicleWebAPICRUD.Models;
using VehicleWebAPICRUD.PaginationResult;
using VehicleWebAPICRUD.VehicleDBContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VehicleWebAPICRUD.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly db_context _context;

        public ApiResponse apiResponse;
        public VehicleService(db_context sqlDBContext)
        {
            _context = sqlDBContext;
            apiResponse = new ApiResponse();
        }

        public async Task<ApiResponse> GetAllVehicle()
        {


            var data = await _context.vehicle.ToListAsync();
            if (data == null || data.Count == 0)
            {

                apiResponse.IsSuccess = false;
                apiResponse.Message = "not found:";
                return apiResponse;
            }

            apiResponse.IsSuccess = true;
            apiResponse.Message = "Data Found:";
            apiResponse.Data = data;
            return apiResponse;
                


        }

        public async Task<ApiResponse> GetVehicleById(int id)
        {
            var data = await _context.vehicle.FindAsync(id);
            if (data == null)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "Incorrect Vehicle ID:";              
                return apiResponse;
            }
            apiResponse.IsSuccess = true;
            apiResponse.Message = "Vehicle By-Id Found:";
            apiResponse.Data = data;
            return apiResponse;
          
        }


        public async Task<ApiResponse> GetPage(string? searchText, int pageNumber, int pageSize)
        {
            var query =  _context.vehicle.AsQueryable();
            if(!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(s => s.vehicle_name.Contains(searchText));
            }
            var totalRecord = await _context.vehicle.CountAsync();
            var res = await _context.vehicle.OrderBy(s => s.vehicle_id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            apiResponse.Message = "Fetched Successfully:";
            apiResponse.IsSuccess = true;
            apiResponse.Data = res;
            return apiResponse;
           
            

        }
        public async Task<ApiResponse> CreateDetail(vehicle std)
        {
            await _context.vehicle.AddAsync(std);
            if(std.vehicle_id == null)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "Vehicle-id is Required :";

            }
            apiResponse.IsSuccess = true;
            apiResponse.Message = "New vehicle Created :";
            apiResponse.Data = std;
            await _context.SaveChangesAsync();
            return apiResponse;
        }



        public async Task<ApiResponse> UpdateDetail(UpdateRequest res)
        {
            var data = await _context.vehicle.FindAsync(res.vehicle_id);


            if (res == null)
            {
                apiResponse.Message = "Enter right information:";
                apiResponse.IsSuccess = false;
                return apiResponse;
               
            }

            if (res.vehicle_id <= 0)
            {
                apiResponse.Message = "Incorrect vehicle Id :";
                apiResponse.IsSuccess = false;
                return apiResponse;
            }

            if (string.IsNullOrEmpty(res.vehicle_name))
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "Please enter vehicle name:";
                return apiResponse;

            }

            if (res != null && res.vehicle_id > 0)
            {
               
                if (data == null)
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = "Id can't be null or 0";
                    apiResponse.Data = data;
                    return apiResponse;
                }
                data.vehicle_name = res.vehicle_name;
                data.vehicle_price = res.vehicle_price;
                data.vehicle_seat = res.vehicle_seat;
                await _context.SaveChangesAsync();

                apiResponse.IsSuccess = true;
                apiResponse.Message = "Update Successfully";
                apiResponse.Data = data;
   

            }
            return apiResponse;

        }

        public async Task<ApiResponse> DeleteDetail(int id)
        {
            var data = await _context.vehicle.FindAsync(id);
            if(data == null)
            {
                apiResponse.IsSuccess = false;
                apiResponse.Message = "Data Not Matched:";

            }
            _context.vehicle.Remove(data);
            _context.SaveChangesAsync();
            apiResponse.IsSuccess = true;
            apiResponse.Message = "Deleted Sucessfully";
              
            return apiResponse;
            
        }

        public async Task<ApiResponse> GetVehicles(string vehicle_seat, decimal minPrice, decimal maxPrice)
        {
            var query = _context.vehicle.AsQueryable();
            var data = await _context.vehicle.Where(x => x.vehicle_seat == vehicle_seat).ToListAsync();

            if (!string.IsNullOrEmpty(vehicle_seat))
            {
                query = query.Where(x => x.vehicle_seat== vehicle_seat);
                apiResponse.IsSuccess = true;
                apiResponse.Data = data;
            }
            if(minPrice>0)
            {
                query = query.Where(x => x.vehicle_price >= minPrice);
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Min-Price";
                apiResponse.Data = data;
                
            }
            return apiResponse;
        }
    }
}
