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
        public void CreateLike(LinkModel link, UserModel user)
        {
            var like = new LikeModel
            {
                User = user,
                Link = link
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public void RemoveLike(LinkModel link, UserModel user)
        {
            var like = _context.Likes.FirstOrDefault(like => like.Link == link & like.User == user);

            _context.SaveChanges();
        }
    }
}
