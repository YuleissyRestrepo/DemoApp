using Example.Domain.Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.DTO
{
    public class UserAppDTO
    {
        public class UserApp : GeneralCommon
        {
            public string Name { get; set; }
            public string Document { get; set; }
            public string Password { get; set; }
            public Guid? IdRol { get; set; }
            public String? Rol { get; set; }
        }

    }
}
