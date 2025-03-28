using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create video objects
        Video video1 = new Video("Understanding C# Classes", "CodeAcademy", 300);
        Video video2 = new Video("Introduction to Object-Oriented Programming", "TechTalks", 450);
        Video video3 = new Video("C# Abstraction Explained", "ProgrammingHub", 600);

        // Add comments to Video 1
        video1.AddComment("Alice", "Great explanation! Very helpful.");
        video1.AddComment("Bob", "I finally understand classes, thanks!");
        video1.AddComment("Charlie", "Can you make a video on interfaces?");

        // Add comments to Video 2
        video2.AddComment("David", "This was so clear, thanks!");
        video2.AddComment("Eve", "OOP makes more sense now.");
        video2.AddComment("Frank", "Loved the examples!");

        // Add comments to Video 3
        video3.AddComment("Grace", "C# is so powerful!");
        video3.AddComment("Hank", "This video was a game-changer for me.");
        video3.AddComment("Ivy", "Thanks for making this topic easy to understand!");

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all videos and their comments
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
