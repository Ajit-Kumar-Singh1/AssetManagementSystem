using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Models.ViewModel
{

    public class AssetSubCategoryViewModel
    {
        [Key]
        public int AssetCategoryId { get; set; }

        [Required(ErrorMessage = "Please enter asset sub category name")]
        public string AssetSubCategoryName { get; set; }

        [Required(ErrorMessage = "Please enter description details.")]
        public string AssetSubCategoryDesc { get; set; }

    }
}
