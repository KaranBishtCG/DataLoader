namespace DataLoaderAPI.Models
{
    public class WorkItem
    {
        public int ID { get; set; }
        public string WorkItemType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AssignedTo { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
    }
}
