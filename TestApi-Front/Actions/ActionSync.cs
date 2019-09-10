﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Helper;

namespace TestApi_Front.Actions
{
    public abstract class ActionSync<T>
    {
        private string url;
        private HttpClient _client;

        protected HttpClient client
        {
            get
            {
                _client = new HttpClient();
                _client.SetBearerToken(HttpContext.Current.Session["Token"].ToString());

                return _client;
            }
        }

        public abstract List<T> GetAll();
        public abstract T Get(string id);
    }
}