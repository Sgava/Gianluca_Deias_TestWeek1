using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_week1_GianlucaDeias.Entities
{
    public enum NuovoUsato
    {

        Nuovo,
        Usato

    }


    public class ProdottoTecnologico : Prodotto
    {
        public string Marca { get; set; }  
        
        public NuovoUsato Novita { get; set; }

        public ProdottoTecnologico(string codice, string descrizione, double prezzo, string marca, NuovoUsato stato) : base(codice, descrizione, prezzo)
        {
            Marca = marca;  
            Novita = stato;

        }

        public override string DescrizioneProdotto()
        {
            return (base.DescrizioneProdotto() + $"\n marca: {Marca},\n Nuovo o Usato: {Novita}");
        }

    }
}
