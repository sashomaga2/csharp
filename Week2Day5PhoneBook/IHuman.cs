using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public interface IHuman
    {
        string FirstName { get; set; }

        string MiddleName { get; set; }

        string FamilyName { get; set; }

        string Town { get; set; }

        string Number { get; set; }
    }
}
