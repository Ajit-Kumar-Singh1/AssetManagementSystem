using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AssetManagementSystem.Models.ViewModel;

namespace AssetManagementSystem.Models
{
    public class AssetCategoryModel
    {
        [Key]
        public int AssetCategoryId { get; set; }

        [Display(Name ="Category Name")]
        public string AssetCategoryName { get; set; }

        //public string AssetSubCategoryName { get; internal set; }
        //public string AssetSubCategoryDesc { get; internal set; }
        public List<AssetSubCategoryViewModel> AssetSubCategoryViewModel { get; set; }
    }

}
