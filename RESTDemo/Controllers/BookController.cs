using Microsoft.AspNetCore.Mvc;
using RESTDemo.Model;
using RESTDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }
        //localhost:335/api/Book/GetBooks
        [HttpGet]
        [Route("GetBooks")]
        public IActionResult Get()
        {
            var model = service.GetBooks();
            return new ObjectResult(model);
        }

        // GET api/Book/GetBookById/5
        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetBookById(id);
                if (model != null)
                {
                    return new ObjectResult(model);
                }
                else 
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        // GET api/Book/GetBookByAuthor/name
        [HttpGet]
        [Route("GetBookByAuthor/{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var model = service.GetBookByAuthor(name);
                if (model != null)
                {
                    return new ObjectResult(model);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddBook")]
        public IActionResult Post([FromBody] Book book)
        {

            try
            {
                var res = service.AddBook(book);
                if (res >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                var res = service.UpdateBook(book);
                if (res >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = service.DeleteBook(id);
                if (res >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
