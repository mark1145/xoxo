using Ballicon.API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ballicon.API
{
    public class ApplicationConfig : IApplicationConfig
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ApplicationConfig(IConfiguration configuration, ILogger<ApplicationConfig> logger)
        {
            _configuration = configuration;
            _logger = logger;
            DbConnectionString = _configuration.GetSection("ConnectionString").Value;
            _logger.LogInformation("ConnectionString={DbConnectionString}", DbConnectionString);
        }

        public string DbConnectionString { get; set; }
    }
}
