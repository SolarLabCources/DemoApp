using System;
using BusinessLogic.Abstraction;
using BusinessLogic.Objects;
using DataAccessLayer;
using DataAccessLayer.Objects;

namespace BusinessLogic.Implementation
{
    public class PostManager : IPostManager
    {
        private DemoContext _context;
        public PostManager(DemoContext ctx)
        {
            _context = ctx;
            AutoMapperConfig.Initialize();
        }

        public void AddPost(AddPostDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            if (string.IsNullOrEmpty(dto.Title))
            {
                throw new Exception("Fill string title");
            }
            var postEntity = AutoMapper.Mapper.Map<Post>(dto);
            _context.Posts.Add(postEntity);
            _context.SaveChanges();
        }
    }
}
