﻿using Asp.Net_React_Redux_app.Controllers.Posts.Commands.Create;
using Asp.Net_React_Redux_app.Controllers.Posts.Queries.GetPostById;
using Asp.Net_React_Redux_app.Models;
using AutoMapper;

namespace Asp.Net_React_Redux_app.Controllers.Posts.MappingProfiles {
    public class PostMappingProfile : Profile {
        public PostMappingProfile() {
            CreateMap<CreatePostRequest, Post>();
            CreateMap<Post, CreatePostResponse>();
            CreateMap<long, GetPostByIdRequest>()
                .AfterMap((x, y) => y.Id = x);
            CreateMap<Post, GetPostByIdResponse>();
        }
    }
}