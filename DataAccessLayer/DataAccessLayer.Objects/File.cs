using System;
using System.Collections.Generic;

namespace DataAccessLayer.Objects
{
    /// <summary>
    /// Files
    /// </summary>
    public class File : BaseEntity<Guid>
    {
        /// <summary>
        /// Имя файла от пользователя
        /// </summary>
        public string UserFileName { get; set; }

        /// <summary>
        /// Контент файла
        /// </summary>
        public byte[] Content { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}
