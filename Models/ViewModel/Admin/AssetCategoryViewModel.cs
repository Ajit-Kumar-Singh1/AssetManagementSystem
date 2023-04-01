using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Models.ViewModel
{
    public class AssetCategoryViewModel
    {

        [Required(ErrorMessage = "Please enter asset category name")]
        public string AssetCategoryName { get; set; }

        [Required(ErrorMessage = "Please enter description details.")]
        public string AssetCategoryDesc { get; set; }

    }
}
