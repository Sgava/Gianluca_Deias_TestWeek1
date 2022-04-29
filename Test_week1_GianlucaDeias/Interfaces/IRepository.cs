using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_week1_GianlucaDeias.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        bool Aggiungi(T item);
    }
}
