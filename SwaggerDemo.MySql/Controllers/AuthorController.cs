using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.MySql.Models;

namespace SwaggerDemo.MySql.Controllers.v1
{
    [Produces("application/json")]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/Author")]
    [Route("api/Author")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthorController : Controller
    {
        private readonly SwaggerDemoContext _swaggerDemoContext;

        public AuthorController(SwaggerDemoContext swaggerDemoContext)
        {
            _swaggerDemoContext = swaggerDemoContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            var authors = _swaggerDemoContext.Authors.ToList();
            return authors;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get([FromRoute]int id)
        {
            var author = _swaggerDemoContext.Authors.Find(id);
            return author;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _swaggerDemoContext.Authors.Add(author);
            _swaggerDemoContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromRoute]int id, [FromBody] Author author)
        {
            author.Id = id;
            _swaggerDemoContext.Authors.Update(author);
            _swaggerDemoContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            var author = _swaggerDemoContext.Authors.Find(id);
            _swaggerDemoContext.Authors.Remove(author);
            _swaggerDemoContext.SaveChanges();
        }
    }
}