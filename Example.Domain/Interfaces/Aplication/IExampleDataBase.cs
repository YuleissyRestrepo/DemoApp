using System;
using System.Collections.Generic;
using System.Text;
using Example.Domain.Entities.Persistence;


namespace Example.Domain.Interfaces.Persistence.SQL
{
    public interface IExampleDataBase : IRepository<UserApp>
    {
        public UserApp GetUserApp(int Document);

    }
}
