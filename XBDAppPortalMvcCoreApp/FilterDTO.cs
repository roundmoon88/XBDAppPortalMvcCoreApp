using System;
using System.Collections.Generic;
using System.Text;

namespace XBDAppPortalMvcCoreApp.DTO
{
    public class FilterDTO
    {
        public int ItemId { get; set; }
        public string Item { get; set; }
        public bool Selected { get; set; }
        public FilterEnum FilterName { get; set; }
    }

    public enum FilterEnum
    {
        App = 1,
        AppType = 2
    }
}
