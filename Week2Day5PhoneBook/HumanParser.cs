using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public class HumanParser : IHumanParser
    {
        public List<IHuman> ParseHumans(IReader reader)
        {
            string line = "";
            var humanList = new List<IHuman>();

            while ((line = reader.ReadLine()) != null)
            {
                var humanParts = SplitLine(line, GlobalConstants.HumanPartsDelimiter);
                humanList.Add(CreateHuman(humanParts));
            }

            return humanList;
        }

        public IHuman CreateHuman(string[] humanParts)
        {
            var nameParts = SplitLine(humanParts[0], GlobalConstants.HumanNameDelimiter);
            var middleName = nameParts.Length > 1 ? nameParts[1].Trim() : null;
            var familyName = nameParts.Length > 2 ? nameParts[2].Trim() : null;

            return new Human()
            {
                FirstName = nameParts[0].Trim(),
                MiddleName = middleName,
                FamilyName = familyName,
                Town = humanParts[1].Trim(),
                Number = humanParts[2].Trim()
            };
        }

        private string[] SplitLine(string line, string delimiter)
        {
            return line.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
