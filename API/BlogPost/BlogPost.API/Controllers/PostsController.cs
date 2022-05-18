using BlogPost.API.Data;
using BlogPost.API.Models.DTO;
using BlogPost.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Controllers
{
    //decorators
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly BlogPostDbContext dbContext;

        public PostsController(BlogPostDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]//read

        public async Task<IActionResult> GetAllPosts()
        {
           var posts= await dbContext.Posts.ToListAsync();
            return Ok(posts);
        }
        //GetsinglePost
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
           var post = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpPost]//insert
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            //convert DTO to entity
            var post = new Post()
            {
                Title = addPostRequest.Title,
                Content = addPostRequest.Content,
                Author = addPostRequest.Author,
                FeaturedImageUrl = addPostRequest.FeaturedImageUrl,
                PublishDate = addPostRequest.PublishDate,
                UpdateDate = addPostRequest.UpdateDate,
                Summary = addPostRequest.Summary,
                UrlHandle = addPostRequest.UrlHandle,
                Visible = addPostRequest.Visible

            };
            post.Id = Guid.NewGuid();
            await  dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }
        [HttpPut]//update
        [Route("{id:Guid}")]
        public async Task<IActionResult> UppdatePost([FromRoute]Guid id, UpdatePostRequest updatePostRequest)
        {
            //convert DTO to entity
            var post = new Post()
            {
                Title = updatePostRequest.Title,
                Content = updatePostRequest.Content,
                Author = updatePostRequest.Author,
                FeaturedImageUrl = updatePostRequest.FeaturedImageUrl,
                PublishDate = updatePostRequest.PublishDate,
                UpdateDate = updatePostRequest.UpdateDate,
                Summary = updatePostRequest.Summary,
                UrlHandle = updatePostRequest.UrlHandle,
                Visible = updatePostRequest.Visible

            };
        }
    }
}
