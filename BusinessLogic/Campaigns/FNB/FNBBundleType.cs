﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic.Campaigns.FNB
{
   public class FNBBundleType
    {
        public int FNBBundleTypeID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static FNBBundleType MakeObject(DataRow inputRow)
        {
            FNBBundleType retValue = new FNBBundleType();

            retValue.FNBBundleTypeID = (int)inputRow["FNBBundleTypeID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<FNBBundleType> GetAllFNBBundleTypes()
        {
            List<FNBBundleType> retVal = new List<FNBBundleType>();
            string sql = "select * from FNBBundleType where IsActive = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }

    }
}
