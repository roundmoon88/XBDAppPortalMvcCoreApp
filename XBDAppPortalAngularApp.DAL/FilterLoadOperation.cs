using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using XBDAppPortalMvcCoreApp.DTO;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public class FilterLoadOperation : Operation, IFilterLoadOperation
    {
        public FilterLoadOperation()
        {
            Initialize();
        }

        public IList<FilterDTO> Resolve(FilterEnum filter)
        {
            IList<FilterDTO> ret = new List<FilterDTO>();
            var filter2 = filter;
            var filterIdentifier = (int)filter;

            CmdTxt = "XDb_App_FilterGet";


            SqlParameter para = new SqlParameter();
            para.ParameterName = "@p1";
            para.Value = filterIdentifier;
            para.SqlDbType = SqlDbType.Int;
            para.Direction = ParameterDirection.Input;

            DataSet ds = Db.GetDataSet(CmdTxt, para);



            ret = ds.Tables[0].AsEnumerable().Select(row => new FilterDTO
            {
                ItemId = Convert.ToInt32(row["Id"]),
                Item = row["Item"] as string
            }).ToList();


            return ret;



        }


    }
}
