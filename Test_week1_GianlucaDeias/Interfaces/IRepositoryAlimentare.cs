using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias.Entities;

namespace Test_week1_GianlucaDeias.Interfaces
{
    internal interface IRepositoryAlimentare : IRepository<ProdottoAlimentare>
    {
        List<ProdottoAlimentare> CercaProdottoAlimentarePerCodice(string codice);
        List<ProdottoAlimentare> CercaProdottoPerScadenza(int giorniMancantiScadenza);
    }
}
