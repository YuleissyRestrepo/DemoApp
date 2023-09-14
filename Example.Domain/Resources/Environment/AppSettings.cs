using System;
using System.Collections.Generic;
using System.Text;
using static Example.Domain.Resources.Variables.AppSettings;

namespace Example.Domain.Resources.Environment
{
    public static class AppSettings
    {
        //nombre del codigo de seguridad
        public static string HEADER_CODENAME_SECURITYID {get { return HEADER_CODENAME_SECURITYID_KEY; } }

        //codigo o id de seuridad
        public static string SECURITY_ID { get { return SECURITY_ID_KEY; } }

        // Contraseña del usuario
        public static string USER_PASSWORD { get { return USER_PASSWORD_KEY; } }

        public static string HEADER_CODENAME_GATEWAYID { get { return HEADER_CODENAME_GATEWAYID_KEY; } }

        public static string GATEWAY_ID { get { return GATEWAY_ID_KEY; } }
    }
}
