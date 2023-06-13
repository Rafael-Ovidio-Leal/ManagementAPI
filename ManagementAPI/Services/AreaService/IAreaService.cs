using ManagementAPI.Models.Dto.AreaDto;

namespace ManagementAPI.Services.AreaService
{
    public interface IAreaService
    {
        Task<object> GetAllArea();

        Task<object> GetAreaById(int id);

        Task<object> AddArea(AddAreaDto newArea);

        Task<object> UpdateArea(UpdateAreaDto updatedArea);

        Task<object> DeleteArea(int id);

    }
}
