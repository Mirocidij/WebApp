using System.Threading;
using System.Threading.Tasks;
using Asp.Net_React_Redux_app.Controllers.Posts.Queries;
using Asp.Net_React_Redux_app.Data;
using AutoMapper;
using MediatR;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Handlers {
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest, GetPostByIdResponse> {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public GetPostByIdHandler(
            IMapper mapper,
            DataContext dataContext
        ) {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<GetPostByIdResponse> Handle(
            GetPostByIdRequest request,
            CancellationToken cancellationToken
        ) {
            var post = await _dataContext.Posts.FindAsync(request.Id);

            if (post == null) {
                return null;
            }

            var getPostByIdRepsonse = _mapper.Map<GetPostByIdResponse>(post);

            return getPostByIdRepsonse;
        }
    }
}