using Azure;
using Azure.Data.Tables;

public class Salt : ITableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GrainSize { get; set; }
    public string SourceSize { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}