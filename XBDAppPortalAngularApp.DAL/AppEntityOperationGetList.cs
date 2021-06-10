using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public class AppEntityOperationGetList : IAppEntityOperation<IList<XDbAppDTO>>
    {
        public IList<XDbAppDTO> Resolve()
        {
            IList<XDbAppDTO> ret = new List<XDbAppDTO>();
            ret = GetList();

            return ret;
        }

        private IList<XDbAppDTO> GetList()
        {
            IList<XDbAppDTO> ret = new List<XDbAppDTO>();
            DBConnection db = new DBConnection();
            DataSet ds = db.GetDataSet("XDb_App_List");
            ret = ds.Tables[0].AsEnumerable().Select(row => new XDbAppDTO
            {
                AppId = Convert.ToInt32(row["AppId"]),
                AppName = row["AppName"] as string,
                AppTypeId = Convert.ToInt32(row["AppTypeId"]),
                AppType = row["AppType"] as string
            }).ToList();


            return ret;
        }
    }
}
