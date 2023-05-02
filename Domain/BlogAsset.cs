namespace BlogEducation.Domain;

public class BlogAsset : BaseEntity
{
    public string FileName { get; set;}
    public int BlogId { get; set;}
    public Blog Blog { get; }
}