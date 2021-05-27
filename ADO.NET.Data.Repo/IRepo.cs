using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Data.Repo
{
    public interface IRepo<T> where T:class
    {
        int Insert(T obj);

        int Delete(int id);
        int Update(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
