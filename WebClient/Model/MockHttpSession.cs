using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> _sessionDictionary = new Dictionary<string, object>();
        public override object this[string name]
        {
            get { return _sessionDictionary[name]; }
            set { _sessionDictionary[name] = value; }
        }
    }
}