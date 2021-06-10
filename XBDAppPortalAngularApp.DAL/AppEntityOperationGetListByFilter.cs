using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public class AppEntityOperationGetListByFilter : Operation, IAppEntityOperationGetListByFilter<IList<XDbAppDTO>>
    {
        //public IList<XDbAppDTO> Resolve(IList<FilterEnum> fiters)
        public IList<XDbAppDTO> Resolve(IList<FilterDTO> fiters)
        {
            IList<XDbAppDTO> ret = new List<XDbAppDTO>();
            ret = GetListByFilter(fiters);
            return ret;
        }

        //private IList<XDbAppDTO> GetListByFilter(IList<FilterEnum> fiters)
        private IList<XDbAppDTO> GetListByFilter(IList<FilterDTO> fiters)
        {
            IList<XDbAppDTO> ret = new List<XDbAppDTO>();
            DBConnection db = new DBConnection();
            //DataSet ds = db.GetDataSet("XDb_App_List");
            this.CmdTxt = "XDb_App_List";
            //this.CollectGetParameter
            IList<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter parameter;
            foreach (FilterDTO filter in fiters)
            {
                parameter = new SqlParameter();
                if (filter.FilterName == FilterEnum.App && filter.Selected && filter.ItemId != 0)
                {
                    parameter.ParameterName = "@AppId";
                    parameter.Value = filter.ItemId;
                    parameter.SqlDbType = SqlDbType.Int;
                    parameters.Add(parameter);
                }

                if (filter.FilterName == FilterEnum.AppType && filter.Selected && filter.ItemId != 0)
                {
                    parameter.ParameterName = "@AppTypeId";
                    parameter.Value = filter.ItemId;
                    parameter.SqlDbType = SqlDbType.Int;
                    parameters.Add(parameter);
                }



                //parameter.ParameterName = 

            }
            DataSet ds = db.GetDataSet(CmdTxt, parameters);
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
