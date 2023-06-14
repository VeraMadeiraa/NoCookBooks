using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MakeRecipe { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string ImgUrl { get; set; }

        [Display (Name = "Favorito")]
        public bool Favorite { get; set; }
        public string Difficult { get; set; }
        public int Time { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
