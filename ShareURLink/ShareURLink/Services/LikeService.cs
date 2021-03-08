using ShareURLink.Context;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;

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
                Link = link,
                IsLiked = true
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public string ChangeStatus(LikeModel like)
        {
            string message;
            if (like.IsLiked == true)
            {
                like.IsLiked = false;
                message = "You don't like this link anymore";                
            }
            else
            {
                like.IsLiked = true;
                message = "You like this link";
            }
            _context.SaveChanges();
            return message;            
        }
    }
}
