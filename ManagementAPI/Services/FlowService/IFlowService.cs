namespace ManagementAPI.Services.FlowService
{
    public interface IFlowService
    {

        Task<object> GetAllAsync(int id);

        Task<object> GetAreaAsync(int id);

        Task<object> GetProcAsync(int id);

        Task<object> GetSubAsync(int id);

    }
}