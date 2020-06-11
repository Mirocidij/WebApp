using Asp.Net_React_Redux_app.Models;
using AutoMapper;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Commands {
    public class CreatePostMappingProfile : Profile {
        public CreatePostMappingProfile() {
            CreateMap<CreatePostRequest, Post>();
            CreateMap<Post, CreatePostResponse>();
        }
    }
}