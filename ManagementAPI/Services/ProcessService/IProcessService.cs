using ManagementAPI.Models.Dto.ProcessDto;

namespace ManagementAPI.Services.ProcessService
{
    public interface IProcessService
    {
        Task<object> GetAllProcess();

        Task<object> GetProcessById(int id);

        Task<object> AddProcess(AddProcessDto newProcess);

        Task<object> UpdateProcess(UpdateProcessDto updatedProcess);

        Task<object> DeleteProcess(int id);
    }
}
