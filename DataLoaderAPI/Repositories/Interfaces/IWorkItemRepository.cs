using DataLoaderAPI.Models;

namespace DataLoaderAPI.Repositories.Interfaces
{
    public interface IWorkItemRepository
    {
        Task<PagedResult<WorkItem>> GetAllWorkItemsAsync(
            int page,
            int pageSize,
            string? brandCode,
            string? brandName);

        Task<PagedResult<WorkItem>> GetByAccountNumbersAsync(
            List<string> accountNumbers,
            int page,
            int pageSize);
    }
}
