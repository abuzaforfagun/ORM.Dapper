using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ORM.Dapper.Core;
using ORM.Dapper.Repository;

namespace ORM.Dapper.Controllers
{
    [Route("api/v1/authors")]
    public class AuthorsController : Controller
    {
        private readonly IConfiguration configuration;
        private AuthorRepository repository;
        public AuthorsController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repository = new AuthorRepository(configuration);

        }
        [HttpPost]
        public IActionResult Add([FromBody] Author author)
        {
            return Ok(repository.Add(author));
        
        }
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

    }
}