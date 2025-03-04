﻿using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
namespace Net14.Web.EfStuff.Repositories
{
    public class SocialPostRepository : BaseRepository<PostSocial>
    {
        public SocialPostRepository(WebContext context) : base(context)
        {
        }

        public bool AddLike(PostSocial post, UserSocial currentUser)
        {
            if (post.Likes.Any(like => like.User.Id == currentUser.Id)) 
            {
                return false;
            }

            var like = new SocialLike()
            {
                Post = post,
                User = currentUser
            };

            post.Likes.Add(like);

            _webContext.SaveChanges();

            return true;
        }

        public bool RemoveLike(PostSocial post, UserSocial currentUser)
        {

            var like = post.Likes.SingleOrDefault(like => like.User.Id == currentUser.Id);
            if (like == null) 
            {
                return false;
            }
            post.Likes.Remove(like);

            _webContext.SaveChanges();

            return true;
        }

        public List<PostSocial> GetPostsWithComplains()
        {
            var posts = _webContext.Posts
                .Where(post => post.Complains.Any())
                .OrderBy(post => post.Complains.Count).ToList();

            return posts;
        }
    }
}
