using ProofOfConcept.Interfaces;
using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Fakes
{
    public class FakeSettings : ISettings
    {
        public User User { get; set; }
        public void Save() { }
    }
}
