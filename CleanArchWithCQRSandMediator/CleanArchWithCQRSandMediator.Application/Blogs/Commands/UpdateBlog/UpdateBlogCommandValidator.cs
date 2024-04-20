using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Id is Name.");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Id is Description.");
            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Id is Author.");
        }
    }
}
