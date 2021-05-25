using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InheritanceDemo
{
    class VideoPost : Post
    {
        protected bool isPlaying = false;
        protected int currDuration = 0;
        Timer timer;

        protected string VideoUrl { get; set; }
        protected int Length { get; set; }

        public VideoPost() { }

        public VideoPost(string title, string sendByUsername, string videoUrl, int length)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.VideoUrl = videoUrl;
            this.Length = length;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", this.ID, this.Title, this.SendByUsername, this.VideoUrl);
        }

        public void Play()
        {
            if (!isPlaying)
            {
                isPlaying = true;
                Console.WriteLine("Playing");
                timer = new Timer(TimerCallback, null, 0, 1000);
            }
        }

        private void TimerCallback(Object o)
        {
            if (currDuration < Length)
            {
                currDuration++;
                Console.WriteLine("Video at {0}s", currDuration);
                GC.Collect();
            } else
            {
                Stop();
            }
        }

        public void Stop()
        {
            if (isPlaying)
            {
                isPlaying = true;
                Console.WriteLine("Stopped at {0}", currDuration);
                currDuration = 0;
                timer.Dispose();
            }
        }
    }
}
