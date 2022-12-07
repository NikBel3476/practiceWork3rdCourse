using System.Text.Json.Serialization;

namespace practiceWork3rdCourse.Models;

public class Post
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime? DateToUnpin { get; set; }
    [JsonIgnore]
    public User User { get; set; }
}