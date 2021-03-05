using Microsoft.AspNetCore.Identity;
using ShareURLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.ViewModels
{
    public class LinkUserViewModel
    {
        public LinkModel HeadersForTable { get; }
        public ICollection<LinkModel> Links { get; set; }
        public UserModel User { get; set; }        
    }
}
