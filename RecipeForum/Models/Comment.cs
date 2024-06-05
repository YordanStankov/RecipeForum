﻿using System.ComponentModel.DataAnnotations;

namespace RecipeForum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserId { get; set; }
        [Required]
        public User? User { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int RecipeId { get; set; }
        [Required]
        public Recipe? Recipe { get; set; }

    }
}