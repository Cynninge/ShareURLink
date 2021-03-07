using ShareURLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Services.Interfaces
{
    public interface ILikeService
    {
        public void CreateLike(LinkModel link, UserModel user);
        public void RemoveLike(LinkModel link, UserModel user);
    }
}
