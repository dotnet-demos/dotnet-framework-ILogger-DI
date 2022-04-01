using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIFWKILoggerDIDemo.Controllers
{
    public class CircleController : ApiController
    {
        IPiValueProvider piValueProvider;
      
        public CircleController(IPiValueProvider piValueProvider )
        {
            this.piValueProvider = piValueProvider;
        }
        // GET: api/Circle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Circle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Circle
        [HttpGet]
        [Route("areaOf/{radius}")]
        public double Area(int radius)
        {
            return this.piValueProvider.Get() * radius * radius;
        }

        // PUT: api/Circle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Circle/5
        public void Delete(int id)
        {
        }
    }
}
