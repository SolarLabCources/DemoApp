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
        void AddPost(AddPostDto dto);
    }
}
