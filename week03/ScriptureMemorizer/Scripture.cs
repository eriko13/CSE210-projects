
public class Scripture
{
    private Reference _reference;
    private string _text;
    private Word[] _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = GenerateListOfWordsFromString(text);
    }

    private static Word[] GenerateListOfWordsFromString(string text)
    {
        // Split the text into words
        string[] words = text.Split(' ');
        Word[] wordList = new Word[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            wordList[i] = new Word(words[i]);
        }

        return wordList;
    }

    public void HideRandomWords(int count)
    {   
        Random random = new Random();
        List<int> listOfNonHiddenIndexes = [];

        for (int i = 0; i < _words.Length; i++)
        {
            if (!_words[i].IsHidden())
            {
                listOfNonHiddenIndexes.Add(i);
            }
        }

        for (int j = 0; j < count; j++)
        {   
            if(listOfNonHiddenIndexes.Count == 0)
            {
                break;
            }
            
            int index = listOfNonHiddenIndexes[random.Next(0, listOfNonHiddenIndexes.Count)];
            _words[index].Hide();
            listOfNonHiddenIndexes.Remove(index);
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} {displayText}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
