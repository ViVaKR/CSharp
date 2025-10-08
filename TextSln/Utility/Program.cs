using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
.AddUserSecrets<Program>()
.Build();


Console.WriteLine(config["Utility:ApiKey"]);

