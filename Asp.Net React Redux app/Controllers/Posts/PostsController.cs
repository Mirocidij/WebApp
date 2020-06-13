using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.Net_React_Redux_app.Controllers.Posts.Commands.Create;
using Asp.Net_React_Redux_app.Controllers.Posts.Queries.GetPostById;
using Asp.Net_React_Redux_app.Data.Repositories.PostRepo;
using Asp.Net_React_Redux_app.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_React_Redux_app.Controllers.Posts {
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PostsController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostsController(
            IMediator mediator,
            IMapper mapper,
            IPostRepository postRepository
        ) {
            _mediator = mediator;
            _mapper = mapper;
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Post>>> GetAllPosts() {
            var posts = await _postRepository.GetAllAsync();

            if (posts.Count > 0) {
                return Ok(posts);
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = nameof(GetPostById))]
        public async Task<ActionResult<GetPostByIdResponse>> GetPostById([FromRoute] long id) {
            var getPostByIdRequest = _mapper.Map<GetPostByIdRequest>(id);

            var getPostByIdResponse = await _mediator.Send(getPostByIdRequest);

            if (getPostByIdResponse == null) {
                return NotFound();
            }

            return Ok(getPostByIdResponse);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePostResponse>> CreatePost(
            [FromBody] CreatePostRequest request
        ) {
            var createPostResponse = await _mediator.Send(request);

            return CreatedAtRoute(
                nameof(GetPostById),
                new { id = createPostResponse.Id },
                createPostResponse
            );
        }
    }
}