﻿using System.Collections.Generic;
using System.Web;

namespace WebshopClient.Model
{
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> _sessionDictionary = new Dictionary<string, object>();

        public void insertIntoDictionary(string Cart, List<ProductLine> productLines)
        {
            _sessionDictionary.Add(Cart, productLines);
        }

        public override object this[string name]
        {
            get { return _sessionDictionary[name]; }
            set { _sessionDictionary[name] = value; }
        }
    }
}