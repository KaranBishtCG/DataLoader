using CsvHelper.Configuration;

namespace DataLoaderAPI.Models
{
    public sealed class WorkItemMap : ClassMap<WorkItem>
    {
        public WorkItemMap()
        {
            Map(m => m.AccountName).Index(0);
            Map(m => m.AccountNumber).Index(1);
            Map(m => m.BrandCode).Index(2);
            Map(m => m.BrandName).Index(3);
        }
    }
}
