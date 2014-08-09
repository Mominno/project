using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Data.Entity;

namespace DatabaseAccess
{
	public class DataDbContextGenerator
	{

		private DataClassDefinition definice;

		public string className { get; set;}

		public DataDbContextGenerator ()
		{
			className = definice.className+"DbContext";

			createDbContextClass();


		}

		private void createDbContextClass()
		{
			// creates assembly	
			AssemblyName an = new AssemblyName();
			an.Name = className;
			AppDomain ad = AppDomain.CurrentDomain;
			AssemblyBuilder ab = ad.DefineDynamicAssembly(an,AssemblyBuilderAccess.Save);

			ModuleBuilder mb = ab.DefineDynamicModule(an.Name, this.className + ".exe");

			// creates class text
			TypeBuilder tb = mb.DefineType(this.className,TypeAttributes.Public|TypeAttributes.Class);

			tb.SetParent (typeof(DbContext));
			tb.AddInterfaceImplementation (typeof(IDataAccess));

			//create default constructor
			tb.DefineDefaultConstructor (MethodAttributes.Public);
				
			//create properties
			foreach(Property property in definice.properties)
			{
				var d = typeof(DbSet<>);

				Type type = Type.GetType (definice.className);

				var dbType = d.MakeGenericType (type);

				PropertyBuilder pb = tb.DefineProperty (property.name,(PropertyAttributes)property.attributes,dbType, null);

			}

			//has to be implemented to db context class
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StudentAddress>()
				.HasKey(e => e.StudentId);
			modelBuilder.Entity<StudentAddress>()
				.Property(e => e.StudentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<StudentAddress>()
				.HasRequired(e => e.Student)
				.WithRequiredDependent(s => s.StudentAddress);

			base.OnModelCreating(modelBuilder);
		}

	}
}

