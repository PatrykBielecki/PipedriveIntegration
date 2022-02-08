using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipedriveIntegration.DTO
{
    public class Organization
    {
        public string name { get; set; }
        public string nip { get; set; }
        public string adres { get; set; }
        public string miejscowosc { get; set; }
        public string kodPocztowy { get; set; }
        public string REGON { get; set; }
    }

    public class PipedriveOrganization
    {
        public const string name = "name";
        public const string nip = "051be51afb9fc85540c681c7de590bc372446b1d";
        public const string adres = "address";
        public const string miejscowosc = "a1b2ee7f3ca8c65f0931873257915c614a40ef85";
        public const string kodPocztowy = "eb1f8521604d1cb6fa7fc40dd27317b1ec801ea1";
        public const string REGON = "e4ad8409320c20ab048379a7abfc751a55d533ed";
    }
}
