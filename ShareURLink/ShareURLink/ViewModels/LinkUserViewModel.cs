using ShareURLink.Models;
using System.Collections.Generic;

namespace ShareURLink.ViewModels
{
    public class LinkUserViewModel
    {
        public LinkModel HeadersForTable { get; }
        public ICollection<LinkModel> Links { get; set; }
        public UserModel User { get; set; }        
    }
}
