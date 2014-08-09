using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess
{
	public class Property
	{

		public Type typ;
		public string name;
		public string modifier;
		public List<PropertyAttributes> attributes;



		public Property (string inputTyp, string InputName, string dataAttributes)
		{

			name = InputName;
			//Att
		//	attribute = new PropertyAttributes ();


			if(inputTyp.ToLower() == "string"){

				typ = typeof(String);
			}

			if (inputTyp.ToLower() == "int") {

				typ = typeof(Int32);

			}
		}

		public bool isKey()
		{
			foreach (PropertyAttributes attribute in attributes)
			{
				if (attribute.GetType().Equals(typeoff(KeyAttribute))) 
				{
					return true;
				}

			}

			return false;
		}
	}
}

