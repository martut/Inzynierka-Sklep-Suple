using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace InzSklep.Infrastructure
{
    public class SessionCart : ISession
    {
        private HttpSessionState _session;
        public SessionCart()
        {
            _session = HttpContext.Current.Session;
        }

        public void Abandon()
        {
            _session.Abandon();
        }

        public T Get<T>(string key)
        {
            return (T)_session[key];
        }

        public T Get<T>(string key, Func<T> createDefault)
        {
            T returnValue;
            if (_session[key] != null && _session[key].GetType() == typeof(T))
            {
                returnValue = (T)_session[key];
            }
            else
            {
                returnValue = createDefault();
                _session[key] = returnValue;
            }
            return returnValue;
        }

        public void Set<T>(string name, T value)
        {
            _session[name] = value;
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T)_session[key];
            }
            catch (NullReferenceException)
            {
                return default(T);
            }
            
        }
    }
}