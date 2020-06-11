using Asp.Net_React_Redux_app.Models;
using AutoMapper;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Queries {
    public class GetPostByIdMappingProfile  : Profile{
        public GetPostByIdMappingProfile() {
            CreateMap<long, GetPostByIdRequest>()
                .AfterMap((x, y) => y.Id = x);
            CreateMap<Post, GetPostByIdResponse>();
        }
    }
}