public class Comment
{
    private string _personName;
    private string _commentText;

    public Comment(string personName, string commentText)
    {
        _personName = personName;
        _commentText = commentText;
    }

    public string Display()
    {
        return $"{_personName}: \"{_commentText}\"";
    }
}
