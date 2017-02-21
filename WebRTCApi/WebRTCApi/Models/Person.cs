using System;

namespace WebRTCApi.Controllers
{
    public class Person
    {
        public Person()
        {
            Name = "Gość_" + new Random().Next(0,2000);
        }

        public string Name { get; set; }
    }
}