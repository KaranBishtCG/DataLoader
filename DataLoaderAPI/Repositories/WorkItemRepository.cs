
using CsvHelper;
using CsvHelper.Configuration;
using DataLoaderAPI.Models;
using DataLoaderAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace DataLoaderAPI.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {

        private readonly string _filepath;

        public WorkItemRepository(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var configuredPath = configuration["DataSource:Path"]
                ?? throw new InvalidOperationException("Missing configuration key 'DataSource:Path'.");

            _filepath = Path.IsPathRooted(configuredPath)
                ? configuredPath
                : Path.Combine(environment.ContentRootPath, configuredPath);
        }


        public async Task<PagedResult<WorkItem>> GetAllWorkItemsAsync(int page,int pageSize)
        {
            if(!File.Exists(_filepath))
            {
                throw new FileNotFoundException($"The file {_filepath} does not exist.");
            }   
            
            using var reader = new StreamReader(_filepath);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "\t",
                HasHeaderRecord = false
            };

            using var csv = new CsvReader(reader, csvConfig);

            csv.Context.RegisterClassMap<WorkItemMap>();

            var records = csv.GetRecords<WorkItem>().ToList();

            var totalCount = records.Count;

            var items = records.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var hasMore = page * pageSize < totalCount;

            return new PagedResult<WorkItem>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                HasMore = hasMore
            };
        }
    }
}
