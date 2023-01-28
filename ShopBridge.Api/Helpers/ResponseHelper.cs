using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge.Api.Helpers
{
    public class ResponseHelper<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> TEntities { get; set; }
        public TEntity Entity { get; set; }
        public string Message { get; set; }
        public HttpStatusCode ResponseStatus { get; set; }

        public ResponseHelper(TEntity entity, List<TEntity> entities, string message, HttpStatusCode responseStatus)
        {
            TEntities = entities;
            Entity = entity;
            Message = message;
            ResponseStatus = responseStatus;

        }
        public ResponseHelper() { }
    }
}
