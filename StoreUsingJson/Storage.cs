using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace StoreUsingJson
{
    /// <summary>
    /// Represents a <see cref="Storage{T}"/> instance that saves and loads data of type <typeparamref name="T"/>, to and from a file.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Storage<T> /*: IStorage<T>*/ where T : class, new()
    {
        private readonly JsonSerializer _serializer;
        private StorageFolder _localFolder;
        public Storage()
        {
            _localFolder = ApplicationData.Current.LocalFolder;
            _serializer = new JsonSerializer();
            _serializer.Context = new StreamingContext(StreamingContextStates.File);
            _serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
        }
        /// <summary>
        /// The <see cref="StorageFolder"/> that contains the file. The path is: C:\Users\USER_ACCOUNT\AppData\Local\Packages\StoreUsingJson_yy5qmf57p1xxr\LocalState
        /// </summary>
        public StorageFolder Folder => _localFolder;
        /// <summary>
        /// Loads data from file
        /// </summary>
        /// <param name="fileName">The name of the file (no extension needed)</param>
        /// <returns></returns>
        public async Task<T> Load(string fileName)
        {
            StorageFile file = await _localFolder.GetFileAsync($"{fileName}.txt");
            T o = new T();
            using (StreamReader reader = new StreamReader(file.Path))
                _serializer.Populate(reader, o);
            return o;
        }
        /// <summary>
        /// Saves the instance data to the file
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="fileName">The name of the file</param>
        public async void Save(T data, string fileName)
        {
            StorageFile file = await _localFolder.CreateFileAsync($"{fileName}.txt", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(file.Path))
                _serializer.Serialize(writer, data);
        }
    }
}
