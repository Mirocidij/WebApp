using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace Asp.Net_React_Redux_app.Controllers.Posts.Commands.Create {
    public class CreatePostRequest : IRequest<CreatePostResponse> {
        [NotNull]
        [MaxLength(50)]
        public string Title { get; set; }

        [NotNull]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}