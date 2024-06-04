using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Model.Models
{
    public class Blob
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Stream Content { get; set; }
    }
}
