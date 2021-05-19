using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSCS_Cameras_Server.Services
{
    public interface IEntityService<T>
    {
        public T Get(int Id);
        public Task<T> GetAsync(int Id);
        
        public IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        
        public T Add(T item);
        public Task<T> AddAsync(T item);
        public void Remove(T item);
    }
}