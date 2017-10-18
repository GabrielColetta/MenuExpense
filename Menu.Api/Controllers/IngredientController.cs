using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Menu.Domain.Contracts.Application;

namespace Menu.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ingredients")]
    public class IngredientController : Controller
    {
        public IngredientController(IIngredientApplication ingredientApplication)
        {
            _ingredientApplication = ingredientApplication;
        }

        private readonly IIngredientApplication _ingredientApplication;

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
