﻿using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<PostSocial> Posts { get; set; }
        public DbSet<UserSocial> Users { get; set; }
        public DbSet<FileSocial> fileSocial { get; set; }
        public DbSet<FoldersForToDo> FolderForToDo { get; set; }
        public DbSet<IssuesForToDo> IssueForToDo { get; set; }
        public DbSet<SocialComment> SocialComments { get; set; }
        public DbSet<GroupSocial> GroupSocial { get; set; }
        public DbSet<ImageComment> ImageComments { get; set; }
        public DbSet<DaysNote> DaysNotes { get; set; }
        public DbSet<CalendarUser> CalendarUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserFriendRequest> UserFriendRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<StoreImage> StoreImages { get; set; }
        public DbSet<GroupTags> GroupTags { get; set; }
        public DbSet<SocialMessages> SocialMessages { get; set; }
        public DbSet<SocialPhoto> SocialPhotos { get; set; }
        public DbSet<FoldersForToDo> FoldersForToDo { get; set; }
        public DbSet<IssuesForToDo> IssuesForToDo { get; set; }
        public DbSet<ComplainsSocial> ComplainsSocial { get; set; }
        public DbSet<SocialReport> Reports { get; set; }



        public DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.Photos)
                .WithOne(p => p.Owner);

            modelBuilder.Entity<PostSocial>()
                .HasMany(post => post.Likes)
                .WithOne(like => like.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostSocial>()
                .HasMany(post => post.Complains)
                .WithOne(comp => comp.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostSocial>()
                .HasMany(x => x.Likes)
                .WithOne(u => u.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupTags>()
                .HasOne(x => x.Group)
                .WithMany(g => g.Tags);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.FriendRequestReceived)
                .WithOne(x => x.Receiver);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.FriendRequestSent)
                .WithOne(x => x.Sender);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.Files)
                .WithOne(x => x.Owner);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.SendMessages)
                .WithOne(x => x.Sender);

            modelBuilder.Entity<UserSocial>()
                .HasMany(x => x.RecievedMessages)
                .WithOne(x => x.Reciever);

            modelBuilder.Entity<Image>()
                .HasMany(image => image.Comments)
                .WithOne(comment => comment.Image);

            modelBuilder.Entity<Basket>()
               .HasMany(basket => basket.Products)
               .WithMany(product => product.Baskets);

            modelBuilder.Entity<UserSocial>()
             .HasOne(user => user.Basket)
             .WithOne(basket => basket.User);

            modelBuilder.Entity<Product>()
               .HasMany(Product =>Product.StoreImages)
               .WithOne(StoreImage => StoreImage.Product);

            modelBuilder.Entity<UserSocial>()
               .HasMany(user => user.DeliveryAddress)
               .WithOne(DeliveryAddress => DeliveryAddress.User);

            modelBuilder.Entity<Image>()
              .HasMany(image => image.Comments)
              .WithOne(comment => comment.Image);

            modelBuilder.Entity<UserSocial>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User);
            modelBuilder.Entity<UserSocial>(x =>
            {
                x.HasMany(u => u.Friends)
                .WithMany(uf => uf.WhoFriends);
            });

            modelBuilder.Entity<PostSocial>()
                .HasMany(post => post.Comments)
                .WithOne(comment => comment.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSocial>()
                .HasMany(user => user.UsersReports)
                .WithOne(report => report.UserReport);

            modelBuilder.Entity<UserSocial>().Property(u => u.UserPhoto).HasDefaultValue("/images/Social/CalendarUser.jpg");

            base.OnModelCreating(modelBuilder);
        }



      

    }
}
