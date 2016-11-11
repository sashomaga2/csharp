using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{ 
    [Serializable]
    public class Human : IHuman
    {
        public Human()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string Town { get; set; }

        public string Number { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Human)obj;
            return FirstName == other.FirstName &&
                   MiddleName == other.MiddleName &&
                   FamilyName == other.FamilyName &&
                   Town == other.Town &&
                   Number == other.Number;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ 
                Town.GetHashCode() ^ 
                Number.GetHashCode();
        }
    }
}
