using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Entities.Infraestructure
{

    public class HttpResponse<T>
    {
        #region Properties

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Response { get; set; }

        #endregion 
    }
}
