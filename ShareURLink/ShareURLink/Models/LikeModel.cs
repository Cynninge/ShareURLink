using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Models
{
    public class LikeModel
    {        
        public int Id { get; set; }
        public UserModel User { get; set; }      
        public LinkModel Link { get; set; }
        public bool IsLiked { get; set; }
    }
}
