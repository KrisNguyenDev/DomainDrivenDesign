﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator: AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name)
                .Equal("").WithMessage("Name is required.")
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 character.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author is required.");
        }
    }
}
