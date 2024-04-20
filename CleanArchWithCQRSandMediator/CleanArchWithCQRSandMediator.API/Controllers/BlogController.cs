using CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSandMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetBlogsQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id});

            if(blog == null)
            {
                //return NotFound();
                return Problem(statusCode: StatusCodes.Status404NotFound, title: "Không tìm thấy Blog.");
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogCommand command)
        {
            var blog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = blog.Id}, blog); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateBlogCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest("Không tìm thấy Blog.");
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteBlogCommand() {Id= id});

            if(result == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
