using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Models
{
    public class CategoryModel
    {
        
        public Category Category { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}

