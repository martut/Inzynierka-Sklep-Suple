using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InzSklep.Infrastructure
{
    public static class URLHelpers
    {
        public static string ProductIMGFolderPath(this UrlHelper helper, string productFileName)
        {
            var productIMGFileFolder = AppConfig.ProductIMGFolderRelative;
            var path = Path.Combine(productIMGFileFolder, productFileName);
            var constPath = helper.Content(path);
            return constPath;
        }

        public static string CategoryIMGFolderPath(this UrlHelper helper, string iconFileName)
        {
            var categoryIMGFileFolder = AppConfig.CategoryIMGFolderRelative;
            var path = Path.Combine(categoryIMGFileFolder, iconFileName);
            var constPath = helper.Content(path);
            return constPath;
        }
        public static string SliderIMGFolderPath(this UrlHelper helper, string offerIMGFile)
        {
            var sliderIMGFileFolder = AppConfig.SliderIMGFolderRelative;
            var path = Path.Combine(sliderIMGFileFolder, offerIMGFile);
            var constPath = helper.Content(path);
            return constPath;
        }

    }
}