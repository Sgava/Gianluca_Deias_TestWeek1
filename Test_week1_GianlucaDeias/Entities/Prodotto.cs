using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_week1_GianlucaDeias.Entities
{
    public class Prodotto
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }    
        public double Prezzo { get; set; }

       

        public Prodotto(string codice, string descrizione, double prezzo)
        {
            Codice = codice;    
            Descrizione = descrizione;
            Prezzo = prezzo;
        }

        public virtual string DescrizioneProdotto()
        {
            return ($"\n\n\n codice: {Codice},\n descrizione:  {Descrizione},\n prezzo: {Prezzo},");
        }

        public void StampaDescrizione()
        {
            Console.WriteLine(DescrizioneProdotto());
        }
    }
}
