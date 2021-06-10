using System;
using System.Collections.Generic;
using System.Text;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public class Factory
    {
        public static IList<XDbAppDTO> GetXBDAppEntityOperationGetList()
        {
            IAppEntityOperation<IList<XDbAppDTO>> appEntityOperationGetList = new AppEntityOperationGetList();
            return appEntityOperationGetList.Resolve();
        }

        public static IList<XDbAppDTO> GetXBDAppEntityOperationListByFilter(IList<FilterDTO> fiters)
        {
            //public IList<XDbAppDTO> Resolve(IList<FilterDTO> fiters)
            IAppEntityOperationGetListByFilter<IList<XDbAppDTO>> appEntityOperationGetListByFilter = new AppEntityOperationGetListByFilter();
            return appEntityOperationGetListByFilter.Resolve(fiters);
        }
        //public static IList<FilterDTO> FilterLoadOperationGet(IList<FilterEnum> filters)
        public static IList<FilterDTO> FilterLoadOperationGet(FilterEnum filter)
        {
            IFilterLoadOperation filterLoadOperation = new FilterLoadOperation();
            //return filterLoadOperation.Resolve(filters);
            return filterLoadOperation.Resolve(filter);
        }
    }
}
