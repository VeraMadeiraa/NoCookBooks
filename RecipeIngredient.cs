using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Domain.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Unity { get; set; }

        public int RecipeId { get; set;  }
        public int IngredientId { get; set; }
    }
}
