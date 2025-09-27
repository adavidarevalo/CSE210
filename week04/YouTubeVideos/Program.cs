using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("How to Code in C#", "TechTutorials", 1200);
            video1.AddComment(new Comment("JohnDoe", "Great tutorial! Very helpful for beginners."));
            video1.AddComment(new Comment("JaneSmith", "I learned so much from this video. Thank you!"));
            video1.AddComment(new Comment("MikeJohnson", "Could you make a follow-up video on advanced topics?"));
            video1.AddComment(new Comment("SarahWilson", "The examples were really clear and easy to follow."));
            videos.Add(video1);

            Video video2 = new Video("Cooking Pasta Like a Pro", "ChefMaster", 900);
            video2.AddComment(new Comment("FoodLover", "This recipe is amazing! Tried it last night."));
            video2.AddComment(new Comment("CookingNewbie", "Finally, a pasta recipe that actually works!"));
            video2.AddComment(new Comment("ItalianChef", "Authentic technique! Well done."));
            videos.Add(video2);

            Video video3 = new Video("Guitar Lessons for Beginners", "MusicAcademy", 1800);
            video3.AddComment(new Comment("RockStar", "Perfect for someone just starting out."));
            video3.AddComment(new Comment("GuitarPlayer", "The chord progressions are explained really well."));
            video3.AddComment(new Comment("MusicFan", "Love the step-by-step approach."));
            video3.AddComment(new Comment("BeginnerGuitar", "This helped me play my first song!"));
            videos.Add(video3);

            Video video4 = new Video("Travel Guide: Japan", "WanderlustVideos", 2400);
            video4.AddComment(new Comment("TravelBug", "Planning my trip to Japan thanks to this video!"));
            video4.AddComment(new Comment("JapanLover", "Great recommendations for places to visit."));
            video4.AddComment(new Comment("BudgetTraveler", "Helpful tips for traveling on a budget."));
            videos.Add(video4);

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
                }
                
                Console.WriteLine();
            }
        }
    }
}
