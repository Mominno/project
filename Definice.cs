using System;
using System.Collections.Generic;


namespace DatabaseAccess
{
	public class Definice
	{
		public List<DataClassDefinition> dataClassDefinitions;
		public List<Reference> references;

		public Definice (string name)
		{
		
		}

		public DataClassDefinition getDataClassDefinitionByName (string name)
		{
			foreach (DataClassDefinition dataClass in dataClassDefinitions)
			{
				if (dataClass.className.Equals (name) ) 
				{
					return dataClass;
				}
			}


			Console.Error.WriteLine ("DataClass definiton not found at class Definice, getDataClassDefinitionByName");

			return null;

		}

	}
}

