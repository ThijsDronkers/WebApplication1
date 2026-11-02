using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogpostsController : ControllerBase
    {
        private readonly IBlogpostService _blogpostService;

        public BlogpostsController(IBlogpostService blogpostService)
        {
            _blogpostService = blogpostService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogpostDto>>> GetAll()
        {
            List<BlogpostDto> blogposts = await _blogpostService.GetAllAsync();
            return Ok(blogposts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogpostDto>> GetById(int id)
        {
            var blogpost = await _blogpostService.GetByIdAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return Ok(blogpost);
        }

        [HttpPost]
        public async Task<ActionResult<BlogpostDto>> Create(BlogpostInputDto input)
        {
            BlogpostDto blogpost = await _blogpostService.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = blogpost.Id }, blogpost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogpostInputDto input)
        {
            bool gelukt = await _blogpostService.UpdateAsync(id, input);
            if (!gelukt)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool gelukt = await _blogpostService.DeleteAsync(id);
            if (!gelukt)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
