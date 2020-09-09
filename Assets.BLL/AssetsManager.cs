using Assets.Data;
using Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.BLL
{
    public class AssetsManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetsContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList();
            return assets;
        }

        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetsContext();
            var assets = context.Assets.
                Where(ast => ast.AssetTypeId == id).
                Include(at => at.AssetType).ToList();
            return assets;
        }

        public static void Add(Asset asset)
        {
            var context = new AssetsContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }
}
