using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Entitys
{
    public class Blog : IEntity
    {
        [Key]
        public Int64 Id { get; set; }

        public string Title { get; set; }

        public string BloggerName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}