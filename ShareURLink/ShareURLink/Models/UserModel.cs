using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Models
{
    public class UserModel : IdentityUser
    {        
       
        public List<LinkModel> MyLinks { get; set; }
       
        public List<LikeModel> LinksILike { get; set; }
    }
}
