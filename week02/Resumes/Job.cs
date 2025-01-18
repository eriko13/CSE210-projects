using System;

public class Job
{
    public Job()
    {
        _jobTitle = "";
        _company = "";
        _startYear = 0;
        _endYear = 0;
    }
    
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}