using ShareURLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Services.Interfaces
{
    public interface ILikeService
    {
        public void Create(LinkModel link, UserModel user);
    }
}
