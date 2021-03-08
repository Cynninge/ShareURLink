using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareURLink.Models
{
    public class LinkModel
    {        
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "URL cannot be shorter than 4 characters")]
        [MaxLength(200, ErrorMessage = "URL cannot be longer than 1000 characters")]
        public string LinkURL { get; set; }
        [Display(Name="Created")]
        public DateTime DateCreated { get; set; }        
        public UserModel User { get; set; }
        public IList<LikeModel> Likes { get; set; }   
        public int LikesCount { get; set; } 

        
    }
}
