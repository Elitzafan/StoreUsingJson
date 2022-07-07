using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace StoreUsingJson
{
    public class Storage<T> : IStorage<T> where T : class, new()
    {
        private JsonSerializer _serializer;
        private StorageFolder _localFolder;
        public Storage()
        {
            _localFolder = ApplicationData.Current.LocalFolder;
            _serializer = new JsonSerializer();
            _serializer.Context = new StreamingContext(StreamingContextStates.File);
            _serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            _serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;
        }
        public async Task<T> Load(string fileName)
        {
            StorageFile file = await _localFolder.GetFileAsync($"{fileName}.txt");
            T o = new T();
            using (StreamReader reader = new StreamReader(file.Path))
                _serializer.Populate(reader, o);
            return o;
        }
        public async void Save(T data, string fileName)
        {
            StorageFile file = await _localFolder.CreateFileAsync($"{fileName}.txt", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(file.Path))
                _serializer.Serialize(writer, data);
        }
    }
}
