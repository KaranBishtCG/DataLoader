using DataLoaderAPI.Models;
using DataLoaderAPI.Repositories.Interfaces;
using DataLoaderAPI.Services.Interfaces;

namespace DataLoaderAPI.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IWorkItemRepository _workItemRepository;

        public WorkItemService(IWorkItemRepository workItemRepository)
        {
            _workItemRepository = workItemRepository;
        }

        public async Task<PagedResult<WorkItem>> GetAllWorkItemsAsync(
        int page,
        int pageSize)
        {
            return await _workItemRepository.GetAllWorkItemsAsync(
                page,
                pageSize);
        }
    }
}
