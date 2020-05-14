using System;
using System.Collections.Generic;
namespace MenuProject
{
    public abstract class IdentifiableEntities
    {
        private List<String> _identifiers;
        private String _name;
        public IdentifiableEntities(String[] Identifiers, String name)
        {
            _name = nameLength(name);
            _identifiers = new List<String>();

            foreach (String s in Identifiers)
            {
                AddIdentifier(s);
            }
        }

        public bool identifyObject(String id)
        {
            if (_identifiers.IndexOf(id.ToLower()) != -1)
                return true;
            else
                return false;
        }

        public abstract void Locate();

        public abstract void Save(string fileLocation);

        public abstract void Load(string fileLocation);

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private void AddIdentifier(String Id)
        {
            _identifiers.Add(Id.ToLower());
        }

        private String nameLength(String s)
        {
            if(s.Length < 25)
                return s;
            return String.Empty;
        }

    }
}
