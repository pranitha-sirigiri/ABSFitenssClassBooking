using ABCFitnessClassBooking.Models;
using Microsoft.AspNetCore.SignalR;

namespace ABCFitnessClassBooking.Repository
{
    public interface IRepository<T> where T : IModel
    {
        List<T> GetAllDetails();
        T GetDetails(Guid classId);
        void Update(T entity);

        T AddDetails(T entity);
    }
}
