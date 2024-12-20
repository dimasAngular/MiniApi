using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Repositoriy.IRepositori
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);

        Task<Villa> Get(Expression<Func<Villa>> filter = null);
        Task Create(Villa entyty);

        Task Remove(Villa entyty);

        Task Save();
    }
}
