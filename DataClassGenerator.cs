using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Data.Entity;

namespace DatabaseAccess
{
	public class DataClassGenerator
	{

		public string className { get; set;}

		private Definice definice;


		public DataClassGenerator (DataClassDefinition definice)
		{
		
			className = definice.className;

			createClass(definice);

		}

		private void createClass(DataClassDefinition definice)
		{

			// creates assembly	
			AssemblyName an = new AssemblyName();
			an.Name = className;
			AppDomain ad = AppDomain.CurrentDomain;
			AssemblyBuilder ab = ad.DefineDynamicAssembly(an,AssemblyBuilderAccess.Save);

			ModuleBuilder mb = ab.DefineDynamicModule(an.Name, this.className + ".exe");

			// creates class text
			TypeBuilder tb = mb.DefineType(this.className,TypeAttributes.Public|TypeAttributes.Class);

			//create default constructor
			tb.DefineDefaultConstructor (MethodAttributes.Public);

		//	createReference (definice.reference);


			//create properties
			foreach(Property property in definice.properties)
			{
				PropertyBuilder pb = tb.DefineProperty (property.name,PropertyAttributes.HasDefault, property.typ, null);
				pb.SetCustomAttribute ();


			}


		}

	

	
	}

}