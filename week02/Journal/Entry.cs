using System;


public class Entry
{
    public Entry(DateTime date, string prompt, string response, int moodLevel)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _moodLevel = moodLevel;
    }

    private DateTime _date;
    private string _prompt;
    private string _response;
    private int _moodLevel;

    public string Display()
    {
        return $"{_date.ToShortDateString()}|{_prompt}|{_response}|{_moodLevel}";
    }
}
