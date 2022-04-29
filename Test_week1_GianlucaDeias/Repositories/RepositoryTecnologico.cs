using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias.Entities;
using Test_week1_GianlucaDeias.Interfaces;

namespace Test_week1_GianlucaDeias.Repositories
{
    internal class RepositoryTecnologico : IRepositoryTecnologico
    {
        private static List<ProdottoTecnologico> prodottiTecnologici = new List<ProdottoTecnologico>()
        {
            new ProdottoTecnologico("1010", "telefono", 100, "samsung", NuovoUsato.Usato),
            new ProdottoTecnologico("abc", "tv", 50, "sony", NuovoUsato.Nuovo)
        };

        public bool Aggiungi(ProdottoTecnologico item)
        {
            if (item == null)
                return false;
            prodottiTecnologici.Add(item);
            return true;
        }

        public List<ProdottoTecnologico> CercaProdottiTecnologiciNuovi()
        {
            List<ProdottoTecnologico> prodottiFiltrati = new List<ProdottoTecnologico>();
            foreach (var item in prodottiTecnologici)
            {
                if (item.Novita == NuovoUsato.Nuovo)
                {
                    prodottiFiltrati.Add(item);
                }
            }
            return prodottiFiltrati;
        }

        public List<ProdottoTecnologico> CercaProdottoTecnologicoPerMarca(string marca)
        {
            List<ProdottoTecnologico> prodottiFiltrati = new List<ProdottoTecnologico>();
            foreach (var item in prodottiTecnologici)
            {
                if (item.Marca == marca)
                {
                    prodottiFiltrati.Add(item);
                }
            }
            return prodottiFiltrati;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            return prodottiTecnologici;
        }
    }
}
