using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Day3Collections;

namespace JSONSerialization
{
    public class PhoneBook : IPhoneBook
    {
        private readonly IReader _reader;

        private readonly ISaver _saver;

        private readonly IHumanParser _parser;

        private List<IHuman> data;
        
        public PhoneBook(IReader reader, ISaver saver, IHumanParser parser)
        {
            _reader = reader;
            _saver = saver;
            _parser = parser;

            data = new List<IHuman>();
        }

        public void Init()
        {
            ReadHumanData();
        }

        #region Commands

        public IHuman[] Find(string name)
        {
            return data.Where(h => h.FirstName == name || h.MiddleName == name || h.FamilyName == name).ToArray();
        }

        public IHuman[] Find(string name, string town)
        {
            return data.Where(h => (h.FirstName == name || h.MiddleName == name || h.FamilyName == name) && h.Town == town).ToArray();
        }

        public string Serialize(IHuman[] humans, SerializeType type)
        {
            //var concreteHumans = humans as List<Human>;
            var serializer = SerializerFactory.Create(type);

            return serializer.Serialize(humans);
        }

        public void Save(string @string, string fileName)
        {
            _saver.Save(fileName, @string);
        }

        public void Add(IHuman human)
        {
            if (human == null)
            {
                throw new NullReferenceException("Human can't be null");
            }

            data.Add(human);
        }

        //public void Add(string name, string town, string number)
        //{
        //    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(town) || string.IsNullOrEmpty(number))
        //    {
        //        throw new ArgumentException("Invalid input for create human");
        //    }

        //    data.Add(CreateHuman(new[] {name, town, number}));
        //}

        #endregion

        public IHuman[] GetHumanData()
        {
            return data.ToArray();
        }

        private void ReadHumanData()
        {
            //string line = "";
            
            //while ((line = _reader.ReadLine()) != null)
            //{
            //    var humanParts = SplitLine(line, "|");
            //    data.Add(CreateHuman(humanParts));
            //}

            data = _parser.ParseHumans(_reader);
        }

        

        
    }

    
}
