using CsvHelper.Configuration;

namespace DataLoaderAPI.Models
{
    public sealed class WorkItemMap : ClassMap<WorkItem>
    {
        public WorkItemMap()
        {
            Map(m => m.ID).Name("ID");
            Map(m => m.WorkItemType).Name("Work Item Type");
            Map(m => m.Title).Name("Title");
            Map(m => m.AssignedTo).Name("Assigned To");
            Map(m => m.State).Name("State");
            Map(m => m.Tags).Name("Tags");
        }
    }
}
