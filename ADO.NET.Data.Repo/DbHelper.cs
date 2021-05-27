using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Data.Repo
{
    class DbHelper
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder conf = new ConfigurationBuilder();
            IConfigurationRoot root = conf.AddJsonFile("appsettings.json").Build();
            string connectionString = root.GetConnectionString("CompanyDB");
            return connectionString;
        }
    }
}
