using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ShareURLink.Models
{
    public class UserModel : IdentityUser
    {              
        public IList<LinkModel> MyLinks { get; set; }       
        public IList<LikeModel> LinksILike { get; set; }
    }
}
