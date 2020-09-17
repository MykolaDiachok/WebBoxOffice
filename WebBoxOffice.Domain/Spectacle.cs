using System;

namespace WebBoxOffice.Domain
{
    public class Spectacle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
