using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.BLL;
using Assets.Domain;
using Assets.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assets.Presentation.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            var asset = AssetsManager.GetAll();
            var viewModel = asset.Select(a => new AssetsViewModel
            {
                Id = a.Id,
                Description = a.Description,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber
            }).ToList();
            return View(viewModel);
        }

        public IActionResult Search()
        {
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }
        public IActionResult Types(int id)
        {
            //go to the rentals manager, get all the rentals of this property type
            var filteredAssets = AssetsManager.GetAllByAssetType(id);
            var result = $"Asset Count: {filteredAssets.Count}";
            return Content(result);
        }

        public IActionResult Create()
        { 
            ViewBag.AssetTypeId = GetAssetTypes();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetsManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected IEnumerable GetAssetTypes()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var list = new SelectList(types, "Value", "Text");
            return list;
        }
    }
}
