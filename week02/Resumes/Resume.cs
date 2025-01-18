using System;

public class Resume
{
    public Resume()
    {
        _name = "";
        _jobs = [];
    }
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Resume for {_name}");
        Console.WriteLine("List of Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}