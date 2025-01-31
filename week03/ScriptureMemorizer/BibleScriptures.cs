using System;
using System.Collections.Generic;


public class BibleScriptures
{
    private Dictionary<string, string> scriptures;

    public BibleScriptures()
    {
        scriptures = new Dictionary<string, string>
        {   
            { "John 18:36-38", "Jesus said, 'My kingdom is not of this world. If it were, my servants would fight to prevent my arrest by the Jews. But now my kingdom is from another place.' You are a king, then! said Pilate. Jesus answered, 'You are right in saying I am a king. In fact, for this reason I was born, and for this I came into the world, to testify to the truth. Everyone on the side of truth listens to me.' What is truth? Pilate asked. With this he went out again to the Jews and said, 'I find no basis for a charge against him.'"},
            { "John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life." },
            { "Philippians 4:13", "I can do all this through him who gives me strength." },
            { "Psalm 23:1", "The Lord is my shepherd, I lack nothing." },
            { "Romans 8:28", "And we know that in all things God works for the good of those who love him, who have been called according to his purpose." }
        };
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(0, scriptures.Count);
        string randomReferenceString = scriptures.Keys.ToArray()[index];
        string referenceBook = randomReferenceString.Split(' ')[0];
        string referenceChapterAndVerse = randomReferenceString.Split(' ')[1];

        int referenceChapter = int.Parse(referenceChapterAndVerse.Split(':')[0]);
        
        string referenceVerses = referenceChapterAndVerse.Split(':')[1];
        int referenceStartVerse = 0;
        int referenceEndVerse = 0;

        if(referenceVerses.Contains("-"))
        {
            referenceStartVerse = int.Parse(referenceVerses.Split('-')[0]);
            referenceEndVerse = int.Parse(referenceVerses.Split('-')[1]);
        }
        else
        {
            referenceStartVerse = int.Parse(referenceVerses);
        }

        Reference randomReference;

        if(referenceEndVerse == 0)
        {
            randomReference = new Reference(referenceBook, referenceChapter, referenceStartVerse);
        }
        else
        {
            randomReference = new Reference(referenceBook, referenceChapter, referenceStartVerse, referenceEndVerse);
        }

        return new Scripture(randomReference, scriptures[randomReferenceString]);
    }
}
