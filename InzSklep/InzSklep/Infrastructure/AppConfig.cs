using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InzSklep.Infrastructure
{
    public class AppConfig
    {
        private static string _productIMGFolderRelative = ConfigurationManager.AppSettings["ProductIMGFolder"];

        public static string ProductIMGFolderRelative
        {
            get
            {
                return _productIMGFolderRelative;
            }
        }

        private static string _categoryIMGFolderRelative = ConfigurationManager.AppSettings["CategoryIMGFolder"];

        public static string CategoryIMGFolderRelative
        {
            get
            {
                return _categoryIMGFolderRelative;
            }
        }
        private static string _sliderIMGFolderRelative = ConfigurationManager.AppSettings["SliderIMGFolder"];

        public static string SliderIMGFolderRelative
        {
            get
            {
                return _sliderIMGFolderRelative;
            }
        }
    }
}