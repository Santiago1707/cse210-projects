using System;
using System.Collections.Generic;

public class Video
{
    private string _titleName;
    private string _authorName;
    private int _length;
    private List<Comment> _comments;

    public Video(string titleName, string authorName, int length)
    {
        _titleName = titleName;
        _authorName = authorName;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string textComment)
    {
        _comments.Add(new Comment(commenterName, textComment));
    }

    public int GetCountComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_titleName}");
        Console.WriteLine($"Author: {_authorName}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCountComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($" - {comment.Display()}");
        }
        Console.WriteLine();
    }
}
