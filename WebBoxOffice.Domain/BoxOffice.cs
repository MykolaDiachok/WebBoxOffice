using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBoxOffice.Domain
{
    public class BoxOffice
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Hall> Halls { get; set; }
    }
}
