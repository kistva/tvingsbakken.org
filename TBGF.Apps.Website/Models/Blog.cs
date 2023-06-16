namespace TBGF.Apps.Website.Models;
public class Blog
{
    public DateTime PublishDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string AltTitle { get; set; } = string.Empty;
}