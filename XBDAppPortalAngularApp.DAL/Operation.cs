using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public abstract class Operation
    {
        private DBConnection db;

        public DBConnection Db
        {
            get
            {
                return GetDb();
            }
            set { db = value; }
        }
        private DBConnection GetDb()
        {
            if (db != null)
                return db;
            else
            {
                db = new DBConnection();
                return db;
            }
        }
        public IList<SqlParameter> Paras;
        public SqlParameter para;

        public string CmdTxt;
        protected void Initialize()
        {
            db = new DBConnection();
            Paras = new List<SqlParameter>();

        }
        protected void CollectParameter(string paraName, SqlDbType paraType, object paraValue)
        {
            CollectParameter(paraName, paraType, paraValue, ParameterDirection.Input);
        }

        protected void CollectParameter(string paraName, SqlDbType paraType, object paraValue, ParameterDirection paraDirection)
        {
            para = new SqlParameter();
            para.ParameterName = paraName;
            para.SqlDbType = paraType;
            para.SqlValue = paraValue;

            //<Ticket75>
            if (para.SqlValue == null)
                para.SqlValue = DBNull.Value;
            //</Ticket75>

            para.Direction = paraDirection;
            Paras.Add(para);
        }

    }
}
