using FileChecker.Data;

namespace FileChecker.Core.AccessLayers
{
    /// <summary>
    /// Abstract generic base access layer class for AppFileAccessLayer and ScanAccessLayer to inherit from, that includes all 
    /// needed base functions: GetAll, GetById, Add, Update, Delete and an instance of FileCheckerDbContext class 
    /// inheriting classes can access.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseAccessLayer<T>
    {
        public FileCheckerDbContext Context = new();
        public abstract List<T> GetAll();
        public abstract T? GetById(int id);
        public abstract void Add(T entity);
        public abstract void Update(int id, T entity);
        public abstract void Delete(int id);
    }
}