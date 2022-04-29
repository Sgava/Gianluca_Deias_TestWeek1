using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_week1_GianlucaDeias.Entities
{
    public class ProdottoAlimentare : Prodotto
    {
        public static int QuantitaInMagazzino { get; set; }
        public DateTime DataDiScadenza { get; set; }
        public double GiorniMancantiAllaScadenza 
        {
            get
            {
                DateTime DataDiOggi = DateTime.Now;
                var NumeroGiorniMancanti = (DataDiScadenza - DataDiOggi).TotalDays;
                return NumeroGiorniMancanti;

            }
        }



        public ProdottoAlimentare(string codice, string descrizione, double prezzo, int quantita, DateTime dataDiScadenza) : base( codice, descrizione, prezzo)
        {
           
            QuantitaInMagazzino = quantita;
            DataDiScadenza = dataDiScadenza;
        }

        public override string DescrizioneProdotto()
        {            
            return (base.DescrizioneProdotto() + $"\n quantità in magazzino {QuantitaInMagazzino},\n scade il {DataDiScadenza.ToShortDateString()}");
        }

    }
}
