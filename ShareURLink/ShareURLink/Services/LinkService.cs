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

        public LinkModel EditLink(LinkModel linkModel)
        {
            throw new NotImplementedException();
        }

        public void RemoveLink(int id)
        {
            var linkModel = _context.Links.FirstOrDefault(x => x.Id == id);
            var like = _context.Likes.FirstOrDefault(x => x.Link == linkModel);
            if (!(like is null))
            {
                _context.Likes.Remove(like);
            }           
            _context.Links.Remove(linkModel);
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

        public void LikeIt(UserModel user, int id)
        {
            var link = _context.Links.Include(x => x.Likes).FirstOrDefault(x => x.Id == id);
            var userData = _context.Users.Include(y => y.MyLinks).Include(z => z.LinksILike).FirstOrDefault(x => x.Id == user.Id);
            var like = new LikeModel();            

            if (userData.LinksILike is null)
            {
                _likeService.Create(link, user);
                LikesCountOfLink(link);
            }            
            else if (userData.MyLinks.Contains(link))
            {
                return;
            }
            else if (!(userData.LinksILike.Any(x => x.Link == link)))
            {
                _likeService.Create(link, user);
                LikesCountOfLink(link);
            }
            else
            {
                like = userData.LinksILike.FirstOrDefault(x => x.Link == link);
                if (like.LikedOrNot == true)
                {
                    like.LikedOrNot = false;
                    _context.Likes.Update(like);
                    _context.SaveChanges();
                    LikesCountOfLink(link);
                }
                else
                {
                    like.LikedOrNot = true;
                    _context.Likes.Update(like);
                    _context.SaveChanges();
                    LikesCountOfLink(link);
                }
            }
        }

        public void LikesCountOfLink(LinkModel linkLikesCount)
        {
            var x = linkLikesCount.Likes.Where(x => x.LikedOrNot == true);
            linkLikesCount.LikesCount = linkLikesCount.Likes.Where(x => x.LikedOrNot == true).Count();
            _context.Links.Update(linkLikesCount);
            _context.SaveChanges();
            return;
        }
    }
}
