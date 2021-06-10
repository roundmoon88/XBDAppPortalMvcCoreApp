using System;
using System.Collections.Generic;
using XBDAppPortalMvcCoreApp.DAL;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.BLL
{
    public class XBDAppPortalListBLL
    {
        //private Factory Factory;
        public IList<XDbAppDTO> GetXBDAppList()
        {
            ////var temp = FilterFactory.
            ////load filter
            ////test load filters
            //IList<FilterEnum> filters = new List<FilterEnum>();
            //FilterEnum filter = FilterEnum.App;
            //filters.Add(filter);
            //filter = FilterEnum.AppType;
            //filters.Add(filter);
            ////FilterFactory.FilterLoadOperationGet(filters);



            return Factory.GetXBDAppEntityOperationGetList();
        }
        public IList<FilterDTO> FilterGet(FilterEnum filterName)
        {
            //var appFilter = FilterFactory.FilterLoadOperationGet(FilterEnum.App);
            //var appTypeFilter = FilterFactory.FilterLoadOperationGet(FilterEnum.AppType);
            var filterList = Factory.FilterLoadOperationGet(filterName);
            return filterList;
        }

        //IList<FilterDTO> fiters
        public IList<XDbAppDTO> GetXBDAppListByFilter(IList<FilterDTO> fiters)
        {
            var appList = Factory.GetXBDAppEntityOperationListByFilter(fiters);
            return appList;
        }
    }
}
