using ShareURLink.Context;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Services
{
    public class LikeService : ILikeService
    {
        private readonly URLDbContext _context;
        public LikeService(URLDbContext context)
        {
            _context = context;
        }
        public void Create(LinkModel link, UserModel user)
        {
            var like = new LikeModel();
            like.User = user;
            like.Link = link;
            like.LikedOrNot = true;
            _context.Likes.Add(like);
            _context.SaveChanges();
        }
    }
}
