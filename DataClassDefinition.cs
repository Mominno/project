using System;
using System.Collections.Generic;

namespace DatabaseAccess
{
	public class DataClassDefinition
	{
		public string className;
		public List<Property> properties;

		public DataClassDefinition (string name)
		{
			className = name;
			properties = new List<Property> ();
		}

		public void addProperty(Property property)
		{
			this.properties.Add (property);
		}

		public Property getPropertyByName (string name)
		{
			foreach (Property property in properties)
			{
				if (property.name.Equals (name) ) 
				{
					return property;
				}
			}

			Console.Error.WriteLine ("Property not found at class DataClassDefinition, getPropertyByName");
			return null;


		}
	}
}

