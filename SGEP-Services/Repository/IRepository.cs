using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGEP_Services.Repository
{
    public interface IRepository<TModel>
    {
        void Add(TModel model);
        Task AddAsync(TModel model);
        void Update(TModel model);
        Task UpdateAsync(TModel model);
        TModel Get(ulong id);
        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
