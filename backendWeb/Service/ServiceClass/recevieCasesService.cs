﻿using backendWeb.Models.Repositories;
using backendWeb.Models.ViewModel;
using backendWeb.Service.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace backendWeb.Service.ServiceClass
{
    public class recevieCasesService : IBaseCrudService<viewModelRecevieCases>
    {
        public viewModelRecevieCases Delete(viewModelRecevieCases model)
        {
            throw new NotImplementedException();
        }

        public IList<viewModelRecevieCases> GetList(viewModelRecevieCases model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM recevieCases WHERE 1 = 1" + Environment.NewLine);
            List<SqlParameter> parameters = new List<SqlParameter>();
            //if (!string.IsNullOrWhiteSpace(model.searchIn_authorize_code))
            //{
            //    builder.Append(" AND authorize_code in (");
            //    string[] group_codes = model.searchIn_authorize_code.Split(new char[] { ',' });
            //    for (int i = 0; i < group_codes.Length; i++)
            //    {
            //        builder.Append($"@authCode{(i == group_codes.Length - 1 ? i.ToString() : i.ToString() + ",")}");
            //        parameters.Add(new SqlParameter { ParameterName = $"authCode{i}", Value = group_codes[i] });
            //    }
            //    builder.Append(")");
            //}
            if (model.start.HasValue)
            {
                builder.Append(" ORDER BY recevie_date DESC OFFSET @skip ROWS");
                parameters.Add(new SqlParameter("@skip", DbType.Int32) { Value = model.start.Value });
                if (model.length.HasValue)
                {
                    builder.Append(" FETCH NEXT @take ROWS ONLY");
                    parameters.Add(new SqlParameter("@take", DbType.Int32) { Value = model.length.Value });
                }                
            }

            return new baseRepository<viewModelRecevieCases>(new List<string> { builder.ToString() }, new List<List<SqlParameter>> { parameters }).GetList().ToList();
        }

        public viewModelRecevieCases GetOnly(viewModelRecevieCases model)
        {
            throw new NotImplementedException();
        }

        public viewModelRecevieCases Save(viewModelRecevieCases model)
        {
            throw new NotImplementedException();
        }
    }
}