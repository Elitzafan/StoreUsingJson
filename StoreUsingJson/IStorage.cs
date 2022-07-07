using System.Threading.Tasks;

namespace StoreUsingJson
{
    public interface IStorage<T> where T : class
    {
        void Save(T data, string fileName);
        Task<T> Load(string fileName);
    }
}
