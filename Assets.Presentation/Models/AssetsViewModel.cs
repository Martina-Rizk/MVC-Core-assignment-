using System.ComponentModel.DataAnnotations;

namespace Assets.Presentation.Models
{
    public class AssetsViewModel
    {
        // description, asset type, tag number, serial number
        public int Id { get; set; }
       
        public string TagNumber { get; set; }
        
        //public int AssetTypeId { get; set; }
        
        //public string Manufacturer { get; set; }
        //public string Model { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        [Display(Name = "Asset type")]
        public string AssetType { get; set; }
    }
}
