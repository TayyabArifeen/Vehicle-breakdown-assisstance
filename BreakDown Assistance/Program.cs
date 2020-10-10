using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakDown_Assistance.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BreakDown_Assistance
{
    public class Program
    {
        private static Purchase purchase = new Purchase();
        public static Purchase _purchase
        {
            get
            {
                return purchase;
            }
            set
            {
                purchase = value;
            }
        }
        private static Admin admin = new Admin();
        public static Admin _admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
            }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
