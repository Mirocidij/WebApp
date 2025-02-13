﻿using MediatR;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Queries.GetPostById {
    public class GetPostByIdRequest : IRequest<GetPostByIdResponse> {
        public long Id { get; set; }
    }
}