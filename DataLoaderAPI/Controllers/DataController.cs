using CsvHelper;
using DataLoaderAPI.Models;
using DataLoaderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace DataLoaderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;

        public DataController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkItemsAsync(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 200)
        {
            if (page < 1)
            {
                return BadRequest("Page must be greater than 0.");
            }

            if (pageSize < 1)
            {
                return BadRequest(
                    "Page size must be greater than 0.");
            }

            var result = await _workItemService.GetAllWorkItemsAsync(
                page,
                pageSize);

            using var memoryStream = new MemoryStream();

            using (var writer = new StreamWriter(
                memoryStream,
                Encoding.UTF8,
                leaveOpen: true))
            using (var csv = new CsvWriter(
                writer,
                CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<WorkItemMap>();

                await csv.WriteRecordsAsync(result.Items);
            }

            Response.Headers["X-Page"] =
                result.Page.ToString();

            Response.Headers["X-Page-Size"] =
                result.PageSize.ToString();

            Response.Headers["X-Total-Count"] =
                result.TotalCount.ToString();

            Response.Headers["X-Has-More"] =
                result.HasMore.ToString().ToLowerInvariant();

            memoryStream.Position = 0;

            return File(
                memoryStream.ToArray(),
                "text/csv",
                $"work-items-page-{page}.csv");
        }
    }
}
