using System;
using System.Web.UI.WebControls.WebParts;

namespace WebRTCApi.Controllers
{
    public class Peer
    {
        public string Id { get; set; }
        public Person Person { get; set; }

        public bool InCall { get; set; }
        public CallToPeer Offer { get; set; }

        public Peer(string id)
        {
            Id = id;
            Person = new Person();
        }
    }
}