using Menu.Domain.Contracts.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Menu.Domain.Dto;

namespace Menu.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cooks")]
    public class CookController : Controller
    {
        public CookController(ICookApplication cookApplication)
        {
            _cookApplication = cookApplication;
        }

        private readonly ICookApplication _cookApplication;

        [HttpGet]
        public IActionResult GetPagination(int page)
        {
            try
            {
                var result = _cookApplication.GetPaginated(page);
                return Ok(result);
            }
            catch (Exceptions.Handlers.ApplicationException ex)
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
                var result = _cookApplication.GetById(id);
                return Ok(result);
            }
            catch (Exceptions.Handlers.ApplicationException ex)
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
        public IActionResult Create(CookModel model)
        {
            try
            {
                _cookApplication.Create(model);
                return Ok();
            }
            catch (Exceptions.Handlers.ApplicationException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                _cookApplication.Delete(id);
                return Ok();
            }
            catch (Exceptions.Handlers.ApplicationException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}