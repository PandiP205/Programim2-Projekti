using Microsoft.Extensions.Configuration;
using System; 
using System.IO;
using System.Diagnostics;

namespace ExchangeShopApp.Utils
{
    public static class DBConnection
    {
        public static string ConnectionString { get; }

        static DBConnection()
        {
            string targetConnectionStringName = "ExchangeShopDB"; 
            Debug.WriteLine($"DEBUG [DBConnection]: Static constructor entered. Attempting to load configuration for '{targetConnectionStringName}'.");

            IConfiguration configuration = null;
            try
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
                Debug.WriteLine("DEBUG [DBConnection]: ConfigurationBuilder built successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DEBUG [DBConnection]: CRITICAL ERROR building configuration: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
                throw new InvalidOperationException($"Failed to build IConfiguration: {ex.Message}", ex);
            }

            string csFromConfig = null;
            try
            {
                csFromConfig = configuration.GetConnectionString(targetConnectionStringName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DEBUG [DBConnection]: ERROR calling GetConnectionString('{targetConnectionStringName}'): {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }


            if (string.IsNullOrEmpty(csFromConfig))
            {
                Debug.WriteLine($"DEBUG [DBConnection]: Connection string '{targetConnectionStringName}' NOT FOUND or IS EMPTY in appsettings.json.");
                Debug.WriteLine("DEBUG [DBConnection]: Listing all connection strings found in appsettings.json:");
                try
                {
                    var csSection = configuration.GetSection("ConnectionStrings");
                    if (csSection.Exists())
                    {
                        foreach (var kvp in csSection.AsEnumerable(true))
                        {
                            Debug.WriteLine($"DEBUG [DBConnection]: Found in config: Key='{kvp.Key}', Value='{kvp.Value}'");
                        }
                        if (!csSection.AsEnumerable(true).Any())
                        {
                            Debug.WriteLine("DEBUG [DBConnection]: The 'ConnectionStrings' section exists but is empty.");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("DEBUG [DBConnection]: The 'ConnectionStrings' section does NOT exist in appsettings.json.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"DEBUG [DBConnection]: Error while trying to list connection strings: {ex.Message}");
                }


                Debug.WriteLine($"DEBUG [DBConnection]: CRITICAL - '{targetConnectionStringName}' not found. Throwing InvalidOperationException. Ensure appsettings.json is correct and copied to output directory.");
                throw new InvalidOperationException($"FATAL: Connection string '{targetConnectionStringName}' was not found or was empty in appsettings.json. Please check your configuration.");
            }
            else
            {
                ConnectionString = csFromConfig;
                Debug.WriteLine($"DEBUG [DBConnection]: Successfully loaded connection string '{targetConnectionStringName}' from appsettings.json.");
            }
        }
    }
}