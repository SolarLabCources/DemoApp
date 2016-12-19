using System.Collections.Generic;

namespace DataAccessLayer.Objects
{
    /// <summary>
    /// Модель - объявления
    /// </summary>
    public class Post : BaseEntity<long>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual List<File> Files { get; set; }
    }
}
