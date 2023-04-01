using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AssetManagementSystem.Models.ViewModel;

namespace AssetManagementSystem.Models
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<AssetCategoryModel> AssetCategoryMaster { get; set; }
        public DbSet<AssetSubCategoryViewModel> AssetSubCategoryMaster { get; set; }
    }
}
