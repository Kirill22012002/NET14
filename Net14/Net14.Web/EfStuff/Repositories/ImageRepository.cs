﻿using Microsoft.EntityFrameworkCore;
using Net14.Web.EfStuff.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.EfStuff.Repositories
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(WebContext context):base(context)
        {
        }
    }
}
