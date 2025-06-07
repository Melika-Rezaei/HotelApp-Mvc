using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Models.Dbase;
using HotelApp_Mvc.Models;

namespace HotelApp_Mvc.Data
{
    public class HotelApp_MvcContext : IdentityDbContext
        /*DbContext*/
    {
        public HotelApp_MvcContext (DbContextOptions<HotelApp_MvcContext> options)
            : base(options)
        {
        }

        public DbSet<HotelApp_Mvc.Models.Dbase.Rooms> Rooms { get; set; } = default!;

        public DbSet<HotelApp_Mvc.Models.Dbase.Payment>? Payment { get; set; }

        public DbSet<HotelApp_Mvc.Models.Dbase.Reserve>? Reserve { get; set; }

        public DbSet<HotelApp_Mvc.Models.Comments>? Comments { get; set; }

        public DbSet<HotelApp_Mvc.Models.Dbase.Users>? Users { get; set; }

        public DbSet<HotelApp_Mvc.Models.Dbase.Discount>? Discount { get; set; }
    }
}
