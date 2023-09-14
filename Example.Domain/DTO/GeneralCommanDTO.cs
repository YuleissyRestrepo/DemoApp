using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.DTO
{
    public class GeneralCommanDTO
    {
        public class GeneralCommon
        {
            public Guid? Id { get; set; }
            public DateTime? DateCreated { get; set; }
            public Guid IdUserCreated { get; set; }
            public string? UserCreated { get; set; }
            public DateTime? DateUpdated { get; set; }
            public Guid? IdUserUpdated { get; set; }
            public string? UserUpdated { get; set; }
        }
    }
}
