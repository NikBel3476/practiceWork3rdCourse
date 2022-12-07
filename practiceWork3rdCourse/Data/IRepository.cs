namespace practiceWork3rdCourse.Data;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? Get(string id);
    void Create(T item);
    void Update(T item);
    void Delete(string id);
}