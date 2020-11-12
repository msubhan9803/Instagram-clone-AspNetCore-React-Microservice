using System;

namespace Instagram.Services.Post.Domain.Models
{
    public class PostFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Thumbail { get; set; }

        public PostFile()
        {
            
        }

        public PostFile(string name, string type, string thumbnail)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Thumbail = thumbnail;
        }
    }
}