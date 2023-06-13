using ManagementAPI.Models.Dto.SubprocessDto;

namespace ManagementAPI.Services.SubprocessService
{
    public interface ISubprocessService
    {
        Task<object> GetAllSubprocess();

        Task<object> GetSubprocessById(int id);

        Task<object> AddSubprocess(AddSubprocessDto newSubprocess);

        Task<object> UpdateSubprocess(UpdateSubprocessDto updatedSubprocess);

        Task<object> DeleteSubprocess(int id);
    }
}
