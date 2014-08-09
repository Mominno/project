using System;
using System.Reflection;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess
{
	class MainClass
	{
		public static void Main (string[] args)
		{

		}

		public static void xmlToDefinition(XmlDocument doc)
		{
			//doc.LoadXml (); 

			XmlElement element = doc.DocumentElement;

			XmlAttributeCollection attr_coll = element.Attributes;

			for (int i = 0; i < attr_coll.Count; i++)
			{
				string attr_name = attr_coll[i].Name;
			}
		}

		public static void referencesToDefinition(Definice definice)
		{
			foreach (Reference reference in definice.references) 
				{
				switch (reference.type) {
				default:
					Console.Error.WriteLine ("reference type not found, shoudnt happen");
					break;
				case "oneToOne":
					DataClassDefinition class1 = definice.getDataClassDefinitionByName (reference.class1);
					DataClassDefinition class2 = definice.getDataClassDefinitionByName (reference.class2);

					Property property1 = class1.getPropertyByName (reference.key);
					Property property2 = class2.getPropertyByName (reference.key);

					AssociationAttribute foreignKey = new AssociationAttribute ("oneToOne",property2.name,property1.name);
					foreignKey.IsForeignKey = true; 

					/*
					if (property1.isKey() == false) 
					{
						property1.attributes.Add (new KeyAttribute ());
					}

					if (property2.isKey() == false) 
					{
						property2.attributes.Add (new KeyAttribute ());
					}
					*/

					property2.attributes.Add (foreignKey);


					break;
				case "oneToMany":
				//code here
					break;
				case "ManyToMany":
				//code here
					break;
				}
			}
		}


	}
}
