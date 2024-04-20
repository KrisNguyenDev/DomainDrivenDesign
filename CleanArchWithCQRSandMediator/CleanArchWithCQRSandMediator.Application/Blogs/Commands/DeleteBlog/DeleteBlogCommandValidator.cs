using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
