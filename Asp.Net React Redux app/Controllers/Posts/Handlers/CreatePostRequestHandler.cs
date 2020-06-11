using System.Threading;
using System.Threading.Tasks;
using Asp.Net_React_Redux_app.Controllers.Posts.Commands;
using Asp.Net_React_Redux_app.Data;
using Asp.Net_React_Redux_app.Models;
using AutoMapper;
using MediatR;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Handlers {
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, CreatePostResponse> {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CreatePostRequestHandler(
            DataContext dataContext,
            IMapper mapper
        ) {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<CreatePostResponse> Handle(
            CreatePostRequest request,
            CancellationToken cancellationToken
        ) {
            var post = _mapper.Map<Post>(request);

            await _dataContext.Posts.AddAsync(post, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var createPostResponse = _mapper.Map<CreatePostResponse>(post);
            
            return createPostResponse;
        }
    }
}