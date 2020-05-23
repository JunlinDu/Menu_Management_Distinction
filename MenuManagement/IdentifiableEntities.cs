using MenuProject;
using System;
using System.Collections.Generic;
using System.IO;
namespace MenuManagement
{
    public abstract class IdentifiableEntities
    {
        private List<String> identifiers;
        private String _name;
        public IdentifiableEntities(String[] Identifiers, String name)
        {
            name = nameLength(name);
            identifiers = new List<String>();

            foreach (String s in Identifiers)
            {
                AddIdentifier(s);
            }
        }

        public bool identifyObject(String id)
        {
            if (identifiers.IndexOf(id.ToLower()) != -1)
                return true;
            else
                return false;
        }

        public IdentifiableEntities Locate(String id)
        {
            if (identifyObject(id))
                return this;
            else
                return null;
        }

        public String[] Identifiers{get;set;}

        public String Name
        { 
            get { return _name; } 
            set { _name = value; } 
        }

        private void AddIdentifier(String Id)
        {
            identifiers.Add(Id.ToLower());
        }

        private String nameLength(String s)
        {
            if(s.Length < 25)
                return s;
            return String.Empty;
        }

    }
}
