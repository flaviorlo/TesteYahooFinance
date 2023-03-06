using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Obter item do repositorio pelo identificador
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns>Retorna um item do repositorio pelo identificador</returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// Inserir um item no repositório
        /// </summary>
        /// <param name="entity">Entidade do repositório</param>
        /// <returns>Retorna true se obteve sucesso na operação e false se não.</returns>
        Task<int> InsertAsync(T entity);

        /// <summary>
        /// Atualizar um item do repositório
        /// </summary>
        /// <param name="entity">Entidade do repositório</param>
        /// <returns>Retorna uma entidade atualizada</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Deletar um item do repositório
        /// </summary>
        /// <param name="entity">Entidade do repositório</param>
        /// <returns>Retorna true se obteve sucesso na operação e false se não.</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Obter itens do repositorio
        /// </summary>
        /// <returns>Retorna um item do repositorio pelo identificador</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Executa uma query
        /// </summary>
        /// <param name="sql">A query</param>
        Task<IEnumerable<T>> ExecuteAsync(string sql);
    }
}
