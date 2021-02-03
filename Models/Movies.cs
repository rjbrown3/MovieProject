using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class Movies
    {
        [Required]
        [RegularExpression(@"[^\s]+")]      //ensure user doesn't leave whitespace
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1900,2100, ErrorMessage = "Please enter a valid year")]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        [RegularExpression(@"[^\s]+")]      //ensure user chooses a rating from the drop down
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]                  //limits notes to 25 characters
        public string Notes { get; set; }
    }
}
