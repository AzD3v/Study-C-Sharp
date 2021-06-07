using System;
using System.Collections.Generic;
using System.Text;

namespace LazyInitialization
{
    class VideoGame
    {
        // Cache dictionary
        private static Dictionary<string, VideoGame> _instances = new Dictionary<string, VideoGame>();

        // Fields (including identifier)
        public string identifier;
        public string name;
        public string genre;
        public float rating;

        // Constructor (private)
        private VideoGame(string identifier)
        {
            this.identifier = identifier;
        }

        // Method responsable for creating video game objects
        public static VideoGame GetVideoGameByIdentifier(string identifier)
        {
            VideoGame videoGame;

            if (!_instances.ContainsKey(identifier))
            {
                videoGame = new VideoGame(identifier);
                _instances.Add(identifier, videoGame);
            }
            else
            {
                videoGame = _instances.GetValueOrDefault(identifier);
            }

            return videoGame;
        }
    }
}
