using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Infra
{
    public class DataContext
    {
        public IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("LojaLeo").Value;
        }
    }
}
