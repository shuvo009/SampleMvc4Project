using System;
using System.ComponentModel.DataAnnotations;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Entitys
{
    public class Comment : IEntity
    {
        [Key]
        public Int64 Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string Content { get; set; }

        public Int64 PostId { get; set; }

        public Post Post { get; set; }
    }
}