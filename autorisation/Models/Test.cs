using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autorisation.Models
{
    public class Test
    {
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }
        public Prepod Autor { get; set; }
    }
}
