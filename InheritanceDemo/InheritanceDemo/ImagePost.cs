using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    // ImagePost derives from the Post and adds a property (ImageURL) and two contructors
    class ImagePost : Post
    {
        public string ImageURL { get; set; }

        public ImagePost() { }

        public ImagePost(string title, string sendByUsername, string imageURL, bool isPublic)
        {
            // Inherit from Post
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.IsPublic = isPublic;
            
            // Member of ImagePost, but not of Post
            this.ImageURL = imageURL;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - Check it out: {3}", this.ID, this.Title, this.SendByUsername, this.ImageURL);
        }
    }
}
