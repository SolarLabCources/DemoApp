using System.Collections.Generic;
using BusinessLogic.Objects;

namespace BusinessLogic.Abstraction
{
    /// <summary>
    /// Manager to work with news
    /// </summary>
    public interface IPostManager
    {
        /// <summary>
        /// Add news
        /// </summary>
        void AddPost(PostDto dto);
        
        /// <summary>
        /// Edit existing post
        /// </summary>
        /// <param name="dto"></param>
        void EditPost(PostDto dto);

        /// <summary>
        /// Deletes existing post
        /// </summary>
        /// <param name="postId"></param>
        void DeletePost(int postId);

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        IEnumerable<PostDto> GetPosts(PostFilter filter = null);

        /// <summary>
        /// Gets post by id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        PostDto GetById(int postId);
    }
}
