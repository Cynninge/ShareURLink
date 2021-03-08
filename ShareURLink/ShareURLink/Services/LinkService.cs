using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShareURLink.Context;
using ShareURLink.Models;
using ShareURLink.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareURLink.Services
{
    public class LinkService : ILinkService
    {
        private readonly URLDbContext _context;
        private readonly UserManager<UserModel> _userManager;
        private readonly ILikeService _likeService;

        public LinkService(URLDbContext context, UserManager<UserModel> userManager, ILikeService likeService)
        {
            _context = context;
            _userManager = userManager;
            _likeService = likeService;
        }

        public LinkModel AddLink(LinkModel link)
        {            
            link.DateCreated = DateTime.Now;
            string urlCheck = link.LinkURL.Substring(0, 3);
            if (!(urlCheck == "htt"))
            {
                link.LinkURL = "https://" + link.LinkURL;
            }
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public void RemoveLink(int id)
        {
            var link = _context.Links.FirstOrDefault(x => x.Id == id);
            var likesOfRemovedLink = _context.Likes.Where(x => x.Link == link);
            if (!(likesOfRemovedLink is null))
            {
                _context.RemoveRange(likesOfRemovedLink);
            }           
            _context.Links.Remove(link);
            _context.SaveChanges();
        }

        public List<LinkModel> GetLinks()
        {
            var listOfLinks = _context.Links.Where(x => x.DateCreated > DateTime.Now.AddDays(-5)).OrderByDescending(y => y.LikesCount).ToList();           
            return listOfLinks;
        }

        public List<LinkModel> GetLinksByUserName(string name)
        {
            return _context.Links.Where(x => x.User.UserName == name).ToList();
        }

        public LinkModel GetLink(int id)
        {
            return _context.Links.FirstOrDefault(x => x.Id == id);
        }

        public string LikeIt(UserModel user, int id)
        {
            var link = _context.Links.Include(x => x.Likes).FirstOrDefault(x => x.Id == id);
            var userData = _context.Users.Include(y => y.MyLinks).Include(z => z.LinksILike).FirstOrDefault(x => x.Id == user.Id);
            string message;

            if (userData.LinksILike is null)
            {
                _likeService.CreateLike(link, user);
                LikesCounter(link);
                return message = "You like this link";
            }
            else if (userData.MyLinks.Contains(link))
            {                
                return message = "This is your link";
            }
            else
            {
                var like = _context.Likes.FirstOrDefault(like => like.Link == link & like.User == user);
                if (like is null)
                {
                    _likeService.CreateLike(link, user);
                    LikesCounter(link);                    
                    return message = "You like this link";
                }
                else
                {
                    message = _likeService.ChangeStatus(like);
                    LikesCounter(link);
                    return message;
                }
            }
        }

        public void LikesCounter(LinkModel link)
        {
            link.LikesCount = link.Likes.Where(x => x.IsLiked == true).Count();
            _context.Links.Update(link);
            _context.SaveChanges();
        }
    }
}
