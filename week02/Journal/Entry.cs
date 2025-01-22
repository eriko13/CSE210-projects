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

    public DateTime _date;
    public string _prompt;
    public string _response;
    public int _moodLevel;

    public string Display()
    {
        return $"{_date.ToShortDateString()}|{_prompt}|{_response}|{_moodLevel}";
    }
}
