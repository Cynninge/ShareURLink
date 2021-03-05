using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareURLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareURLink.Context
{
    public class URLDbContext : IdentityDbContext<UserModel>
    {
        public URLDbContext(DbContextOptions<URLDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<LinkModel> Links { get; set; }
        public DbSet<LikeModel> Likes { get; set; }

    }
}
