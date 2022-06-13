using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class FormRepository : IFormRepository
    {
        protected readonly string ConnectionString;
        public FormRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }
        public async Task SaveFormDetails(Form form)
        {
            using (var cn = GetConnection())
            {
                var formID = await CreateForm(cn, form);

                foreach (var field in form?.Fields ?? Enumerable.Empty<Field>())
                {
                    await CreateFormField(cn, (int) formID, field);
                }
            }
        }

        private async Task<int?> CreateForm(IDbConnection cn, Form form)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FormType", form.FormType);

            if (!string.IsNullOrEmpty(form.Description))
            {
                parameters.Add("@Description", form.Description);
            }

            parameters.Add("@CreatedOn", DateTime.Now);
            parameters.Add("@RETURN_VALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await cn.ExecuteAsync("dbo.CreateForm", parameters, commandType: CommandType.StoredProcedure);

            return GetReturnValue(parameters);
        }

        private async Task CreateFormField(IDbConnection cn, int formID, Field field)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FormID", formID);
            parameters.Add("@FieldID", field.FieldID);
            parameters.Add("@FieldValue", field.FieldValue);

            await cn.ExecuteAsync("dbo.CreateFormDetail", parameters, commandType: CommandType.StoredProcedure);
        }

        private int? GetReturnValue(DynamicParameters parameters)
        {
            if (int.TryParse(parameters.Get<object>("@RETURN_VALUE").ToString(), out var id))
            {
                return id;
            }

            return null;
        }
    }
}
