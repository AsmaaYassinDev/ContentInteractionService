using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContentInteractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment([FromBody] Comment comment)
        {
            var createdComment = await _commentService.AddCommentAsync(comment);
            return CreatedAtAction(nameof(AddComment), new { id = createdComment.Id }, createdComment);
        }

        [HttpGet("{imageId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(string imageId)
        {
            var comments = await _commentService.GetCommentsAsync(imageId);
            return Ok(comments);
        }
    }

}
