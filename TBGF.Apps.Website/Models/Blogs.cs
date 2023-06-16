namespace TBGF.Apps.Website.Models;

public class Blogs
{
    public List<Blog> Result { get; set; } = new List<Blog>();
    public int Total { get; set; } = 0;
    public int NumberOfPages { get; set; } = 0;
}