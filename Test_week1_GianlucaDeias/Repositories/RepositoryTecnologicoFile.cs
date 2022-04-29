using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias;
using Test_week1_GianlucaDeias.Entities;
using Test_week1_GianlucaDeias.Interfaces;
using Test_week1_GianlucaDeias.Repositories;

namespace Test_week1_GianlucaDeias.Repositories
{
    public class RepositoryTecnologicoFile : IRepositoryTecnologico
    {         
        string path = @"C:\Users\gianluca.deias\source\repos\Test_week1_GianlucaDeias\Test_week1_GianlucaDeias\Repositories\InventarioAlimentari.txt";
        public bool Aggiungi(ProdottoTecnologico item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice},{item.Descrizione},{item.Prezzo},{item.Marca},{item.Novita}");
            }
            return true;
        }

        public List<ProdottoTecnologico> CercaProdottiTecnologiciNuovi()
        {
            
            List<ProdottoTecnologico> prodottiTecnologici = this.GetAll();
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
            List<ProdottoTecnologico> prodottiTecnologici = this.GetAll();
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
            List<ProdottoTecnologico> prodottiTecnologici = new List<ProdottoTecnologico>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();

                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return prodottiTecnologici;
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(",");

                        string codice = campiDellaRiga[0];
                        string descrizione = campiDellaRiga[1];
                        double prezzo = double.Parse(campiDellaRiga[2]);
                        string marca = campiDellaRiga[3];
                        NuovoUsato novita = (NuovoUsato)Enum.Parse(typeof(NuovoUsato), campiDellaRiga[4]);

                        ProdottoTecnologico prodotto = new ProdottoTecnologico(codice, descrizione, prezzo, marca, novita);

                        prodottiTecnologici.Add(prodotto);
                    }
                }
                return prodottiTecnologici;
            }
        }
    }
}
