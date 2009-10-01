namespace Community.Example
{
	using System.Configuration;
	using System.Diagnostics.Contracts;

	public class DataConnectionConfiguration : ConfigurationSection
	{
		private const string Path = "community/data";

		private static readonly ConfigurationPropertyCollection PropertyRegistry =
			new ConfigurationPropertyCollection
			{
				new ConfigurationProperty("server", typeof (string), null, ConfigurationPropertyOptions.IsRequired),
				new ConfigurationProperty("database", typeof (string), null, ConfigurationPropertyOptions.IsRequired),
				new ConfigurationProperty("username", typeof (string), null, ConfigurationPropertyOptions.IsRequired),
				new ConfigurationProperty("timeout", typeof (int), null, ConfigurationPropertyOptions.IsRequired),
			};

		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return PropertyRegistry;
			}
		}
	
		[ConfigurationProperty("server", IsRequired = true)]
		public string Server
		{
			get
			{
				return (string)base["server"];
			}
			set
			{
				base["server"] = value;
			}
		}
	
		[ConfigurationProperty("database", IsRequired = true)]
		public string Database
		{
			get
			{
				return (string)base["database"];
			}
			set
			{
				base["database"] = value;
			}
		}
	
		[ConfigurationProperty("username", IsRequired = true)]
		public string Username
		{
			get
			{
				return (string)base["username"];
			}
			set
			{
				base["username"] = value;
			}
		}
	
		[ConfigurationProperty("timeout", IsRequired = true)]
		public int Timeout
		{
			get
			{
				return (int)base["timeout"];
			}
			set
			{
				base["timeout"] = value;
			}
		}

		public static DataConnectionConfiguration GetDefault()
		{
			Contract.Ensures(Contract.Result<DataConnectionConfiguration>() != null);

			var configuration = (DataConnectionConfiguration)ConfigurationManager.GetSection(Path);
			if (configuration == null)
			{
				throw new ConfigurationErrorsException("Configuration section ('community/data') was not found.");
			}
			
			return configuration;
		}
	}
}
