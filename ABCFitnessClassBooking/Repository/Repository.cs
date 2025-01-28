
using ABCFitnessClassBooking.Models;

namespace ABCFitnessClassBooking.Repository
{
    public class Repository<T> : IRepository<T> where T : IModel
    {
        public readonly List<T> _entityList;

        public Repository(List<T> entityList)
        {
            _entityList = entityList ?? new List<T>();
        }
        public List<T> GetAllDetails()
        {
            return _entityList;
        }

        public T GetDetails(Guid classId)
        {
            return _entityList.FirstOrDefault(c => c.Id == classId);
        }

        public void Update(T entity)
        {
            var T = GetDetails(entity.Id.Value);
            T = entity;

        }

        public T AddDetails(T entity)
        {
            entity.Id = Guid.NewGuid();
            _entityList.Add(entity);
            return entity;
        }
    }
}
