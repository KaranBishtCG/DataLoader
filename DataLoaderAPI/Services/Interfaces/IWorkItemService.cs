using DataLoaderAPI.Models;

namespace DataLoaderAPI.Services.Interfaces
{
    public interface IWorkItemService
    {
        Task<PagedResult<WorkItem>> GetAllWorkItemsAsync(int page, int pageSize);
    }
}
