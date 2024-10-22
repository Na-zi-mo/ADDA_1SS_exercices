using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceInjection.ViewModels.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T? Get(long id);
        bool Insert(T record);
        bool Update(T record);
        bool Delete(T record);
    }
}
