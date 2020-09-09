using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.BLL;
using Assets.Domain;
using Assets.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assets.Presentation.Controllers
{
    public class AssetTypeController : Controller
    {
        public IActionResult Index()
        {
            var type = AssetTypeManager.GetAll();
            var viewModel = type.Select(t => new AssetTypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            //var types = AssetTypeManager.GetAsKeyValuePairs();
            //var list = new SelectList(types, "Value", "Text");
            //ViewBag.AssetTypeId = list;

            return View();
        }
        [HttpPost]
        public IActionResult Create(AssetType type)
        {
            try
            {
                AssetTypeManager.Add(type);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
