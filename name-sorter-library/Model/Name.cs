using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter_library.Model
{
    public class Name
    {
        public string LastName { get; }
        public string[] GivenNames { get; }

        public Name(string lastName, string[] givenNames)
        {
            LastName = lastName;
            GivenNames = givenNames;
        }

        public override string ToString()
        {
            string givenNamesStr = string.Join(" ", GivenNames);
            return $"{givenNamesStr} {LastName}";
        }
    }
}
