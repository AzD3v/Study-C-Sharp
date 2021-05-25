using System;
using System.Threading;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post("Post 1 content", true, "Paulo Cunha");
            Console.WriteLine(post1.ToString());

            ImagePost imagePost1 = new ImagePost("Check out my new shoes", "Paulo Cunha", "https://images.com/shows", true);
            Console.WriteLine(imagePost1.ToString());

            VideoPost videoPost1 = new VideoPost("Check out this video", "Paulo Cunha", "https://youtube.com", 5);

            Console.WriteLine("Press any key to stop the timer");
            Console.WriteLine(videoPost1.ToString());

            videoPost1.Play();
            Console.WriteLine("Press any key to stop the video");
            Console.ReadKey();
            videoPost1.Stop();

            Console.Read();
        }
    }
}
