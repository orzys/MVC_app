using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApp
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogAppConectionString")
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}