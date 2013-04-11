using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Entitys
{
    public class Post : IEntity
    {
        [Key]
        public Int64 Id { get; set; }

        public string Title { get; set; }

        public DateTime DateCreate { get; set; }

        public string Content { get; set; }

        public Int64 BlogId { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}