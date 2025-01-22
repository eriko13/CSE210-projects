using System;


public class Entry
{
    public Entry(DateTime date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public DateTime _date;
    public string _prompt;
    public string _response;

    public string Display()
    {
        return $"{_date.ToShortDateString()} - {_prompt}: {_response}";
    }

    public string ToFormattedString()
    {
        return $"{_date.ToShortDateString()}|{_prompt}|{_response}";
    }
}
