using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreAppPrj.Models
{
    public class FiltersModel
    {
        //public IList<FilterDTO> AppFilters { get; set; }
        public SelectList AppFilters { get; set; }
        //public string AppSlectedValue { get; set; }

        //public IList<FilterDTO> AppTypeFilters { get; set; }
        public SelectList AppTypeFilters { get; set; }
        //public string AppTypeSlectedValue { get; set; }
    }
}
