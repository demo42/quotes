﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace QuoteService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            var configPath = Environment.GetEnvironmentVariable("ConfigPath");
            if (!string.IsNullOrEmpty(configPath))
            {
                builder.ConfigureAppConfiguration(config => config.AddKeyPerFile(configPath, true));
            }
            builder.UseStartup<Startup>();
            return builder;
        }
    }
}