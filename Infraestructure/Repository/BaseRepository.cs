using Infraestructure.Enum;
using Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Infraestructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDbConnection dbConn;
        protected readonly IDbTransaction dbTransaction;
        private readonly IConfiguration cnnconfig;

        protected BaseRepository(DatabaseType type, IConfiguration config)
        {
            cnnconfig = config;
            dbConn = new DbConnection(cnnconfig.GetConnectionString("AppDbMySql"), type).Connection;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> ExecuteAsync(string sql)
        {
            try
            {
                return await dbConn.QueryAsync<T>(sql);
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await dbConn.GetAllAsync<T>();
            }
            catch (Exception ex)
            {
              
                throw new Exception(ex.Message);
            }
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var success = await dbConn.UpdateAsync<T>(entity);

                if (success)
                    return entity;

                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}
