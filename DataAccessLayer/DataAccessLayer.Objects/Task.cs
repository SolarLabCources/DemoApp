using System;
using System.Collections.Generic;

namespace DataAccessLayer.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class Task : BaseEntity<long>
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
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<File> Files{ get; set; }
    }
}
