﻿using Net14.Web.EfStuff.DbModel;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.store
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public List<DeliveryAddress> DeliveryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public Language Language { get; set; }
    }
}
