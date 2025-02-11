using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        _comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public string GetTitle()
    {
        return _title;
    }
    
    public string GetAuthor()
    {
        return _author;
    }   

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }
    
    
    



} 