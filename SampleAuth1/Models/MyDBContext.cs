using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SampleAuth1.Models
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>

    {
        public MyDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<ScrapList> ScrapList { get; set; }

    }
}