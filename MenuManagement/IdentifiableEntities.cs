using MenuProject;
using System;
using System.Collections.Generic;
using System.IO;
namespace MenuManagement
{
    //<summary>
    // IdentifiableEntities class is used to stores all the object.
    // This includes menus and dishes.
    // There is a list of identifiers to stores them.
    // </summary>
    public abstract class IdentifiableEntities
    {
        private List<String> identifiers;
        private String _name;
        public IdentifiableEntities(String[] Identifiers, String name)
        {
            _name = nameLength(name);
            identifiers = new List<String>();

            foreach (String s in Identifiers)
            {
                AddIdentifier(s);
            }
        }

        //This function is used to check if an entity is in the list.
        public bool identifyObject(String id)
        {
            if (identifiers.IndexOf(id.ToLower()) != -1)
                return true;
            else
                return false;
        }

        //This function is used to find an entity from the list.
        public IdentifiableEntities Locate(String id)
        {
            if (identifyObject(id))
                return this;
            else
                return null;
        }

        //Name of the object.
        public String[] Identifiers{get;set;}

        public String Name
        { 
            get { return _name; } 
            set { _name = value; } 
        }

        //This function is used to add new object.
        private void AddIdentifier(String Id)
        {
            identifiers.Add(Id.ToLower());
        }

        //This function is used to make sure all the name are under 25 characters.
        private String nameLength(String s)
        {
            if(s.Length < 25)
                return s;
            return String.Empty;
        }

    }
}
