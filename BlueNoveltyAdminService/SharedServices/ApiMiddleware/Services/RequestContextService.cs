using SharedServices.ApiMiddleware.Interfaces;

namespace SharedServices.ApiMiddleware.Services
{
    public class RequestContextService<T> : IRequestContextService<T>
    {
        private T _requestIdentifier;
        public T GetRequestIdentifier()
        {
            return _requestIdentifier;
        }

        public void SetRequestIdentifier(T userId) 
        {
            _requestIdentifier = userId;
        }
    }
}
