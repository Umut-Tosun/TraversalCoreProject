using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.title = featureManager.TGetList().FirstOrDefault().Title;
            ViewBag.price = featureManager.TGetList().FirstOrDefault().Description;
            ViewBag.Image = featureManager.TGetList().FirstOrDefault().Image;

            var values = featureManager.TGetList().TakeLast(4).ToList();
            return View(values);
        }
    }
}
