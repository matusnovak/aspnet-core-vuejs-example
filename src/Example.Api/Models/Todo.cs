using System;
using System.ComponentModel.DataAnnotations;
using Example.Api.Data;

namespace Example.Api.Models
{
    public class Todo : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1024, MinimumLength = 3)]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
    }
}
