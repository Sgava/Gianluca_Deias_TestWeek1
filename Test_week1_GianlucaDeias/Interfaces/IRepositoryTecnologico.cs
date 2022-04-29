using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias.Entities;

namespace Test_week1_GianlucaDeias.Interfaces
{
    internal interface IRepositoryTecnologico : IRepository<ProdottoTecnologico>
    {
        List<ProdottoTecnologico> CercaProdottoTecnologicoPerMarca(string marca);
        List<ProdottoTecnologico> CercaProdottiTecnologiciNuovi();
    }
}
