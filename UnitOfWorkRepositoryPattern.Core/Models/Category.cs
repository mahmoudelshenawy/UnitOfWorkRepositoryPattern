﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepositoryPattern.Core.Models
{
    public class Category : IEntity
    {
        [Required , MaxLength(250)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
