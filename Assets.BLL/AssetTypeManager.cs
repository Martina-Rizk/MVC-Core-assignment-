using Assets.Data;
using Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BLL
{
    public class AssetTypeManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetsContext();
            var types = context.AssetTypes.Select(a => new
            {
                Value = a.Id,
                Text = a.Name
            }).ToList();
            return types;
        }

        public static List<AssetType> GetAll()
        {
            var context = new AssetsContext();
            var types = context.AssetTypes.ToList();
            return types;
        }

        public static void Add(AssetType type)
        {
            var context = new AssetsContext();
            context.AssetTypes.Add(type);
            context.SaveChanges();
        }
    }
}
