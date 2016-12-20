using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.ViewModels
{
    public class ItemViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Localization")]
        public string Localization { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string Date { get; set; }
        
        [Required]
        [Display(Name = "Reward")]
        public string Reward { get; set; }

        [Display(Name = "Images")]
        public List<string> Images { get; set; }
    }
}