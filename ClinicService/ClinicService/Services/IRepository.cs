namespace ClinicService.Services
{
    public interface IRepository<T, TId>
    {
        IList<T> GetAll();
        T GetById(TId id);
        int Create(T item);
        int Update(T item);
        int Delete(TId id);
    }
}
