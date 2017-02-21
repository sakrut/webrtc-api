using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebRTCApi.Controllers
{
    [Authorize]
    public class CallController : ApiController
    {
        
        private static Dictionary<string,Peer> Peers = new Dictionary<string, Peer>();
        public List<Peer> Get()
        {
            return Peers.Values.ToList();
        }

        public Peer Get(string ID)
        {
            return Peers[ID];
        }

        
        public void Post([FromBody]CallToPeer value)
        {
            if (Peers[value.PeerId].Offer != null)
            {
                Peers[value.CallTo].InCall = Peers[value.PeerId].InCall = true;
            }
            Peers[value.CallTo].Offer = value;
        }

        public Peer Put([FromBody]Person value)
        {
            Peer peer = new Peer(Guid.NewGuid().ToString());
            peer.Person = value;
            Peers.Add(peer.Id, peer);
            return peer;
        }
        public void Put(string ID, [FromBody]Person value)
        {
            Peers[ID].Person = value;
        }

        

        // DELETE api/values/5
        public void Delete(string ID)
        {
            var peer = Peers[ID];
            if (peer.InCall && peer.Offer!= null)
            {
                Peers[peer.Offer.PeerId].InCall = false;
                Peers[peer.Offer.PeerId].Offer = null;
            }
            Peers.Remove(ID);
        }
    }
}
