using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogic.Abstraction;
using BusinessLogic.Objects;
using DataAccessLayer;
using DataAccessLayer.Objects;
using Extensions;

namespace BusinessLogic.Implementation
{
    public class PostManager : IPostManager
    {
        private DemoContext _context;

        public PostManager(DemoContext ctx)
        {
            _context = ctx;
        }

        public void AddPost(PostDto dto)
        {
            Validate(dto);
            var postEntity = Mapper.Map<Post>(dto);
            _context.Posts.Add(postEntity);
            _context.SaveChanges();
        }

        public void EditPost(PostDto dto)
        {
            Validate(dto);
            var existingPost = _context.Posts.Find(dto.Id);

            if (existingPost != null)
            {
                Mapper.Map(dto, existingPost);
                _context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var existingPost = _context.Posts.Find(postId);

            if (existingPost != null)
            {
                _context.Posts.Remove(existingPost);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PostDto> GetPosts(PostFilter filter = null)
        {
            IQueryable<Post> postQuery = _context.Posts;
            postQuery = ApplyFiltering(postQuery, filter);
            var posts = postQuery.ToList();
            return Mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetById(int postId)
        {
            var post = _context.Posts.Find(postId);
            return Mapper.Map<PostDto>(post);
        }

        private void Validate(PostDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            if (string.IsNullOrEmpty(dto.Title))
            {
                throw new Exception("Fill string title");
            }
        }

        /// <summary>
        /// Applies post filter parameters to the input query and return a result of a filtered posts query
        /// </summary>
        /// <param name="postQuery"></param>
        /// <param name="postFilter"></param>
        /// <returns></returns>
        private IQueryable<Post> ApplyFiltering(IQueryable<Post> postQuery, PostFilter postFilter)
        {
            var filteredPosts = postQuery;

            if (postFilter == null || postQuery.IsEmpty())
            {
                return filteredPosts;
            }

            if (postFilter.PostId.HasValue)
            {
                filteredPosts = filteredPosts.Where(p => p.Id == postFilter.PostId.Value);
            }

            if (!string.IsNullOrWhiteSpace(postFilter.Title))
            {
                filteredPosts = filteredPosts.Where(p => p.Title.Contains(postFilter.Title));
            }

            return filteredPosts;
        } 
    }
}
