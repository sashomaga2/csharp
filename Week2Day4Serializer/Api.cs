using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3Collections;

namespace JSONSerialization
{
    public class Api
    {
        private readonly IReader _reader;

        private List<Human> data = new List<Human>();

        public Api(IReader reader)
        {
            _reader = reader;
        }

        public void Init()
        {
            ReadHumanData();
        }

        #region Commands

        public Human[] Find(string name)
        {
            return data.Where(h => h.FirstName == name || h.MiddleName == name || h.FamilyName == name).ToArray();
        }

        public Human[] Find(string name, string town)
        {
            return data.Where(h => (h.FirstName == name || h.MiddleName == name || h.FamilyName == name) && h.Town == town).ToArray();
        }

        public void Serialize(string name, string fileName, SerializeType type)
        {
            var serializer = SerializerFactory.Create(type);
            serializer.Serialize(Find(name), fileName);
        }

        public void Add(string name, string town, string number)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(town) || string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Invalid input for create human");
            }

            data.Add(CreateHuman(new[] {name, town, number}));
        }

        #endregion

        public Human[] GetHumanData()
        {
            return data.ToArray();
        }

        private void ReadHumanData()
        {
            string line = "";
            
            while ((line = _reader.ReadLine()) != null)
            {
                var humanParts = SplitLine(line, "|");
                data.Add(CreateHuman(humanParts));
            }
        }

        private Human CreateHuman(string[] humanParts)
        {
            var nameParts = SplitLine(humanParts[0], " ");
            var middleName = nameParts.Length > 1 ? nameParts[1].Trim() : null;
            var familyName = nameParts.Length > 2 ? nameParts[2].Trim() : null;

            return new Human() {
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
