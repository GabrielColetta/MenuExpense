using Microsoft.AspNetCore.Mvc;
using Menu.Domain.Contracts.Application;
using Menu.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Menu.Exceptions.Handlers;

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
        public IActionResult GetPagination(int page)
        {
            try
            {
                var result = _ingredientApplication.GetPaginated(page);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                if (ex.statusCode.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _ingredientApplication.GetById(id);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                if (ex.statusCode.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public IActionResult Create(IngredientModel model)
        {
            try
            {
                _ingredientApplication.Create(model);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(IngredientModel model)
        {
            try
            {
                _ingredientApplication.Update(model);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                _ingredientApplication.Delete(id);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}