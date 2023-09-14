using System;
using System.Collections.Generic;
using System.Text;
using static Example.Domain.Resources.Variables.ServiceSettings;

namespace Example.Domain.Resources.Environment
{
    public static class ServiceSettings
    {
        
        public static string BASE_ADDRESS { get { return BASE_ADDRESS_KEY;} }
        // Ruta para optener el toquen
        public static string SERVICE_GET_TOKEN { get { return SERVICE_GET_TOKEN; } }

        // Ruta para descargar todod los usuarios 
        public static string GET_ALL_USER_PATH {get { return GET_ALL_USER_PATH_KEY; } }
    }
}
