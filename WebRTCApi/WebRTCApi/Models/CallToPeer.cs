using System;

namespace WebRTCApi.Controllers
{
    public class CallToPeer
    {
        public string PeerId { get; set; }
        public string CallTo { get; set; }
        
        public String SDP { get; set; }
    }
}