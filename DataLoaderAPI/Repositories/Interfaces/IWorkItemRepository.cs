
using DataLoaderAPI.Models;
namespace DataLoaderAPI.Repositories.Interfaces
{
    public interface IWorkItemRepository
    {
        Task<PagedResult<WorkItem>> GetAllWorkItemsAsync(int page, int pageSize);
    }
}
