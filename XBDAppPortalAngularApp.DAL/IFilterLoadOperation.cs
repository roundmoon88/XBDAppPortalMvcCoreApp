using System;
using System.Collections.Generic;
using System.Text;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.DAL
{
    interface IFilterLoadOperation
    {
        //IList<FilterEnum> filters used to list what kinds of filters to request
        //IList<FilterDTO> Resolve(IList<FilterEnum> filters);
        IList<FilterDTO> Resolve(FilterEnum filter);
    }
}
