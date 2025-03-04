﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net14.Web.EfStuff;

namespace Net14.Web.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20220527143623_addDeliveryAddress")]
    partial class addDeliveryAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketProduct", b =>
                {
                    b.Property<int>("BasketsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("BasketsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("BasketProduct");
                });

            modelBuilder.Entity("GroupSocialUserSocial", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("GroupSocialUserSocial");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.CalendarUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CalendarUsers");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DaysNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarUserId");

                    b.ToTable("DaysNotes");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DeliveryAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<int>("PostСode")
                        .HasColumnType("int");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddress");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.ImageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("ImageComments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandCategories")
                        .HasColumnType("int");

                    b.Property<int>("CoolCategories")
                        .HasColumnType("int");

                    b.Property<int>("CoolColors")
                        .HasColumnType("int");

                    b.Property<int>("CoolMaterial")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.FileSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("fileSocial");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroupSocial");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupTags");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupSocialId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("TypePost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupSocialId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("SocialComments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsViewdByReciever")
                        .HasColumnType("bit");

                    b.Property<int?>("RecieverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("SocialMessages");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserFriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FriendRequestStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsViewedByReceiver")
                        .HasColumnType("bit");

                    b.Property<bool>("IsViewedBySender")
                        .HasColumnType("bit");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("UserFriendRequests");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserPhoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/images/Social/CalendarUser.jpg");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.StoreImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Odrer")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("StoreImages");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProductSize", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SizesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "SizesId");

                    b.HasIndex("SizesId");

                    b.ToTable("ProductSize");
                });

            modelBuilder.Entity("UserSocialUserSocial", b =>
                {
                    b.Property<int>("FriendsId")
                        .HasColumnType("int");

                    b.Property<int>("WhoFriendsId")
                        .HasColumnType("int");

                    b.HasKey("FriendsId", "WhoFriendsId");

                    b.HasIndex("WhoFriendsId");

                    b.ToTable("UserSocialUserSocial");
                });

            modelBuilder.Entity("BasketProduct", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.Basket", null)
                        .WithMany()
                        .HasForeignKey("BasketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14.Web.EfStuff.DbModel.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupSocialUserSocial", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupSocial", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Basket", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "User")
                        .WithOne("Basket")
                        .HasForeignKey("Net14.Web.EfStuff.DbModel.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DaysNote", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.CalendarUser", "CalendarUser")
                        .WithMany("DaysNotes")
                        .HasForeignKey("CalendarUserId");

                    b.Navigation("CalendarUser");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DeliveryAddress", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "User")
                        .WithMany("DeliveryAddress")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.ImageComment", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.Image", "Image")
                        .WithMany("Comments")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.FileSocial", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupTags", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupSocial", "Group")
                        .WithMany("Tags")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupSocial", null)
                        .WithMany("Posts")
                        .HasForeignKey("GroupSocialId");

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialComment", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialMessages", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "Reciever")
                        .WithMany("RecievedMessages")
                        .HasForeignKey("RecieverId");

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "Sender")
                        .WithMany("SendMessages")
                        .HasForeignKey("SenderId");

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserFriendRequest", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "Receiver")
                        .WithMany("FriendRequestReceived")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "Sender")
                        .WithMany("FriendRequestSent")
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.StoreImage", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.Product", "Product")
                        .WithMany("StoreImages")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductSize", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14.Web.EfStuff.DbModel.Size", null)
                        .WithMany()
                        .HasForeignKey("SizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserSocialUserSocial", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", null)
                        .WithMany()
                        .HasForeignKey("WhoFriendsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.CalendarUser", b =>
                {
                    b.Navigation("DaysNotes");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Image", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Product", b =>
                {
                    b.Navigation("StoreImages");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.GroupSocial", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", b =>
                {
                    b.Navigation("Basket");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("Files");

                    b.Navigation("FriendRequestReceived");

                    b.Navigation("FriendRequestSent");

                    b.Navigation("Posts");

                    b.Navigation("RecievedMessages");

                    b.Navigation("SendMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
