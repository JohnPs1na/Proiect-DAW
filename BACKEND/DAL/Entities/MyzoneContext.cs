using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYZONE.DAL.Entities
{
    public class MyzoneContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Admins> Admins { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<TicketOrder> Orders { get; set; }
        public DbSet<AnnouncementsArtistEvent> Announcements { get; set; }
        public MyzoneContext(DbContextOptions<MyzoneContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Admins>()
                .HasOne(a => a.ContactInfo)
                .WithOne(ci => ci.Admin);

            builder.Entity<Admins>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin);

            builder.Entity<Events>()
                .HasMany(e => e.Tickets)
                .WithOne(t => t.Event)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<AnnouncementsArtistEvent>().HasKey(an => new { an.ArtistId, an.EventId });

            builder.Entity<AnnouncementsArtistEvent>()
                .HasOne<Artists>(an => an.Artist)
                .WithMany(a => a.AnnouncementsArtistEvent)
                .HasForeignKey(an => an.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnnouncementsArtistEvent>()
                .HasOne<Events>(an => an.Event)
                .WithMany(e => e.AnnouncementsArtistEvent)
                .HasForeignKey(an => an.EventId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<TicketOrder>().HasKey(an => new { an.UserId, an.TicketId });

            builder.Entity<TicketOrder>()
                .HasOne<User>(to => to.User)
                .WithMany(u => u.TicketOrders)
                .HasForeignKey(to => to.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<TicketOrder>()
                .HasOne<Tickets>(to => to.Ticket)
                .WithMany(t => t.TicketOrders)
                .HasForeignKey(to => to.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
