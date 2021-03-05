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
        public LinkModel EditLink(LinkModel linkModel);
        public void RemoveLink(int id);
        public List<LinkModel> GetLinksByUserName(string name);
        public void LikeIt(UserModel user, int id);
    }
}
