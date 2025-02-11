using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create and populate first video
        Video video1 = new Video("Baja, Mexico | Travel Documentary", "SLOW ROAMERS", 7318);
        video1.AddComment("marctheaaron1904", "Love the first beach. It's just north of our house.  Have called it shell beach my whole life. Great stuff y'all.");
        video1.AddComment("noelongaria6267", "I'm 70 years young, and when I grow up, I want to be just like you two.  Keep on keeping on!!");
        video1.AddComment("jessica_mccarthy", "I'm so jealous!  I've been dreaming of a trip like this for years.  Keep the videos coming!");
        videos.Add(video1);

        // Create and populate second video
        Video video2 = new Video("I Built My Dream Home For Under $500,000 | Full Breakdown", "NZ Builder // Josh Chapman", 4048);
        video2.AddComment("KonFry", "This was like 10x better than most episodes of Grand Designs");
        video2.AddComment("gregpowell8000", "That must be a NZD$1,000,000+ house today.");
        video2.AddComment("stavsmou3429", "Does anyone else notice the resemblance to Franklin's house in GTA V? Or am I going nuts?");
        videos.Add(video2);

        // Create and populate third video
        Video video3 = new Video("My New 2025 6th Gen 4Runner TRD Off Road - How Much? Build Plans?", "TRD JON", 755);
        video3.AddComment("andrewward4246", "best color on the 6th gen!  i think if I was going to buy one this is exactly how i would spec it.");
        video3.AddComment("Joe-be3pw", "Excited for some side by side comparisons with 5th gen!");
        video3.AddComment("onlyfoolriding8223", "Keeping my 14 gx460 with 94k miles for at least another 10 years.");
        video3.AddComment("CarsTechWood", "Do you think you'll still have it by its second oil change?");
        videos.Add(video3);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"\nTitle: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            
            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.DisplayComment()}");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}