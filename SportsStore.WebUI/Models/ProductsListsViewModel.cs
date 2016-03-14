﻿using System.Collections.Generic;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Models
{
    public class ProductsListsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}