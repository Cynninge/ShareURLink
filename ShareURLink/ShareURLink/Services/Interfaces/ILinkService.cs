using Microsoft.AspNetCore.Identity;
using ShareURLink.Models;
using ShareURLink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Services.Interfaces
{
    public interface ILinkService
    {
        public List<LinkModel> GetLinks();
        public LinkModel GetLink(int id);
        public LinkModel AddLink(LinkModel linkUser);
        public void RemoveLink(int id);
        public List<LinkModel> GetLinksByUserName(string name);
        public string LikeIt(UserModel user, int id);
        public void LikesCounter(LinkModel link);
    }
}
