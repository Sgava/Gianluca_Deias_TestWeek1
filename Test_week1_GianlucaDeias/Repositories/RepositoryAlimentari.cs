using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias.Entities;
using Test_week1_GianlucaDeias.Interfaces;

namespace Test_week1_GianlucaDeias.Repositories
{
    internal class RepositoryAlimentari : IRepositoryAlimentare
    {
        private static List<ProdottoAlimentare> prodottiAlimentari = new List<ProdottoAlimentare>()
        {
            new ProdottoAlimentare("ewe", "fagiuolo", 12, 3, new DateTime(2022, 5, 10)),
            new ProdottoAlimentare("1200", "zucchina",2,120,new DateTime(2022, 6,30)),
            new ProdottoAlimentare("300", "farro",2,120,new DateTime(2022, 4,30))
        };

        public bool Aggiungi(ProdottoAlimentare item)
        {
            if (item == null)
                return false;
            prodottiAlimentari.Add(item);
            return true;
        }

        public List<ProdottoAlimentare> CercaProdottoAlimentarePerCodice(string codice)
        {
            List<ProdottoAlimentare> prodottiFiltrati = new List<ProdottoAlimentare>();
            foreach (var item in prodottiAlimentari)
            {
                if (item.Codice == codice)
                {
                    prodottiFiltrati.Add(item);
                }
            }
            return prodottiFiltrati;
        }

        public List<ProdottoAlimentare> CercaProdottoPerScadenza(int giorniMancantiScadenza)
        {
            List<ProdottoAlimentare> prodottiFiltrati = new List<ProdottoAlimentare>();
            foreach (var item in prodottiAlimentari)
            {
                if (item.GiorniMancantiAllaScadenza <= giorniMancantiScadenza && DateTime.Today <= item.DataDiScadenza)
                {
                    prodottiFiltrati.Add(item);
                }
            }
            return prodottiFiltrati;

        }

        public List<ProdottoAlimentare> GetAll()
        {
            return prodottiAlimentari;
        }

    }
}
