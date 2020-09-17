using System;

namespace WebBoxOffice.Domain
{
    public class Hall
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FreePlaces { get; set; }
        public BoxOffice BoxOffice { get; set; }
    }
}
