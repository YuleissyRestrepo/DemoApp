using System;
using SQLite;

namespace Example.Domain.Entities.Persistence
{
    public class UserApp: GeneralCommon
    {
        public string Name { get; set; }
        public int Document { get; set; }
        public string Password { get; set; }
        public Guid IdRol { get; set; }
        public String? Rol { get; set; }
    }

    public class UserLogin
    {
        [PrimaryKey]
        public int Document { get; set; }
        public Guid IdRol { get; set; }
    }

}
