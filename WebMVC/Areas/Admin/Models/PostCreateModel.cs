namespace WebMVC.Areas.Admin.Models;

public class PostCreateModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }
}
