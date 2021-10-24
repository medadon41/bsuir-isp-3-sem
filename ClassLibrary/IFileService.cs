using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IFileService<T> where T : class
    {
        Task<IEnumerable<T>> ReadFile(string fileName);

        void SaveData(IEnumerable<T> data, string fileName);
    }
}
