using System;

namespace LazyInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoGame videoGame1 = VideoGame.GetVideoGameByIdentifier("Mad Max");
            VideoGame videoGame2 = VideoGame.GetVideoGameByIdentifier("Assassin's Creed");
            VideoGame videoGame3 = VideoGame.GetVideoGameByIdentifier("Mad Max");

            Console.WriteLine(Object.ReferenceEquals(videoGame1, videoGame2));
            Console.WriteLine(Object.ReferenceEquals(videoGame1, videoGame3));
        }
    }
}
