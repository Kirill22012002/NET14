﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using TeamSocial;

namespace Net14.Web.EfStuff.DbModel.SocialDbModels
{
    public class FileSocial : BaseModel
    {
        public string Name { get; set; } = "Тестовый, дефолтный файл";
        public string Url { get; set; } = "https://auto.ironhorse.ru/wp-content/uploads/2020/10/m3-g80-front.jpg";
        public string Text { get; set; } = "Быстрая и мощная авто";
        public virtual UserSocial Owner { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}