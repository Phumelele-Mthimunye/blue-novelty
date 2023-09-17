using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.ApiMiddleware.Interfaces
{
    public interface IRequestContextService<T>
    {
        public void SetRequestIdentifier(T requestIdentifier);
        public T GetRequestIdentifier();
    }
}
