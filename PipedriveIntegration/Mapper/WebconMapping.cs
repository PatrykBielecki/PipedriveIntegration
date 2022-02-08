using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipedriveIntegration.Mapper
{
    public class WebconMapping
    {
        public Guids guids { get; set; }
    }

    public class Guids
    {
        public string nazwa { get; set; }
        public string nip { get; set; }
        public string adres { get; set; }
        public string miejscowosc { get; set; }
        public string kodPocztowy { get; set; }
        public string REGON { get; set; }
        public string path { get; set; }
        public string workflow { get; set; }
        public string formType { get; set; }
    }
}
