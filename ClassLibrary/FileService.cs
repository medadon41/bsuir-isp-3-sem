using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public async Task<IEnumerable<T>> ReadFile(string fileName)
        {
            await using var fileStream = new FileStream(fileName, FileMode.Open);
            return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(fileStream);
        }

        public async void SaveData(IEnumerable<T> data, string fileName)
        {
            await using var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(fileStream, data);
        }
    }
}
