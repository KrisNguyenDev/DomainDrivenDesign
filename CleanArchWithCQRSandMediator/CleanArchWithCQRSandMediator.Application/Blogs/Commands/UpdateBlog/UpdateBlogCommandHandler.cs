﻿using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
{
    internal class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog()
            {
                Id = request.Id,    
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };

            return await _blogRepository.UpdateAsync(request.Id, blogEntity);
        }
    }
}
