using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndDelegatesProgram
{
    class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Message service: Sending a text message..." + args.Video.Title);
        }
    }
}
