using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.Interfaces.Aplication
{
    public interface IGeneral<T> 
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
