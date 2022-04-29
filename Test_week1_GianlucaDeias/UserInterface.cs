using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias.Entities;
using Test_week1_GianlucaDeias.Interfaces;
using Test_week1_GianlucaDeias.Repositories;

namespace Test_week1_GianlucaDeias
{
    internal class UserInterface
    {

        static IRepositoryAlimentare repositoryAlimentare = new RepositoryAlimentari();
       // static IRepositoryTecnologico repositoryTecnologico = new RepositoryTecnologico();
        static IRepositoryTecnologico repositoryTecnologico = new RepositoryTecnologicoFile();


        private static int Menu()
        {
            Console.WriteLine("\n\n-------------------MENU------------------\n");
            Console.WriteLine("  1.Visualizza tutti prodotti nello store");
            Console.WriteLine("  2.Visualizza tutti prodotti alimentari nello store");
            Console.WriteLine("  3.Visualizza tutti prodotti tecnologici nello store");
            Console.WriteLine("  4.Aggiungi un prodotto alimentare");
            Console.WriteLine("  5.Aggiungi un prodotto tecnologico");
            Console.WriteLine("  6.Cerca un prodotto alimentare per codice");
            Console.WriteLine("  7.Cerca un prodotto tecnologico per marca");
            Console.WriteLine("  8.Visualizza i prodotti tecnologici nuovi");
            Console.WriteLine("  9.Visualizza i prodotti alimentari in scadenza oggi");
            Console.WriteLine("  10.Visualizza i prodotti alimentari che scadono tra 3 giorni o meno");
            Console.WriteLine("\n  0.Exit");
            Console.WriteLine("\n  Inserisci la tua scelta:");

            int sceltaUtente;
            while (!(int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 10))
            {
                Console.WriteLine(" Devi inserire un numero intero.");
            }
            return sceltaUtente;
        }

        public static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                        VisualizzaProdotti();
                        break;
                    case 2:
                        VisualizzaProdottiAlimentari();
                        break;
                    case 3:
                        VisualizzaProdottiTecnologici();
                        break;
                    case 4:
                        AggiungiProdottoAlimentare();
                        break;
                    case 5:
                        AggiungiProdottoTecnologico();
                        break;
                    case 7:
                        CercaProdottoAlimentarePerCodice();
                        break;
                    case 8:
                        CercaProdottoTecnologicoPerMarca();
                        break;
                    case 9:
                        VisualizzaProdottiAlimentariInScadenzaOggi();
                        break;
                    case 10:
                        VisualizzaProdottiAlimentariInScadenzaABreve();
                        break;                    
                    case 0:
                        continua = false;                        
                        break;                    
                }
            }
        }

        private static void VisualizzaProdottiAlimentariInScadenzaABreve()
        {
            var listaProdottiFiltrata = repositoryAlimentare.CercaProdottoPerScadenza(3);

            if (listaProdottiFiltrata.Count == 0)
            {
                Console.WriteLine("\nNon è stato trovato nessun prodotto in scadenza oggi");
            }
            else
            {
                foreach (var item in listaProdottiFiltrata)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void VisualizzaProdottiAlimentariInScadenzaOggi()
        {
            var listaProdottiFiltrata = repositoryAlimentare.CercaProdottoPerScadenza(1);

            if (listaProdottiFiltrata.Count == 0)
            {
                Console.WriteLine("\nNon è stato trovato nessun prodotto in scadenza oggi");
            }
            else
            {
                foreach (var item in listaProdottiFiltrata)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void VisualizzaProdottiTecnologiciNuovi()
        {
            var listaProdottiFiltrata = repositoryTecnologico.CercaProdottiTecnologiciNuovi();

            if (listaProdottiFiltrata.Count == 0)
            {
                Console.WriteLine("\nNon è stato trovato nessun prodotto con quella marca");
            }
            else
            {
                foreach (var item in listaProdottiFiltrata)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void CercaProdottoTecnologicoPerMarca()
        {
            Console.WriteLine("\nInserisci la Marca del prodotto");

            string marca = Console.ReadLine();

            var listaProdottiFiltrata = repositoryTecnologico.CercaProdottoTecnologicoPerMarca(marca);

            if (listaProdottiFiltrata.Count == 0)
            {
                Console.WriteLine("\nNon è stato trovato nessun prodotto con quella marca");
            }
            else
            {
                foreach (var item in listaProdottiFiltrata)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void CercaProdottoAlimentarePerCodice()
        {
            Console.WriteLine("\nInserisci il codice del prodotto");
            
            string codice = Console.ReadLine();
           
            var listaProdottiFiltrata = repositoryAlimentare.CercaProdottoAlimentarePerCodice(codice);
            
            if (listaProdottiFiltrata.Count == 0)
            {
                Console.WriteLine("\nNon è stato trovato nessun prodotto con quel codice");
            }
            else
            {
                foreach (var item in listaProdottiFiltrata)
                {
                    item.StampaDescrizione();
                }
            }
        
        }

        private static void AggiungiProdottoTecnologico()
        {
            Console.WriteLine("\nInserisci il Codice del prodotto\n");

                string codiceProdotto = Console.ReadLine();

                var listaProdottiTecnologici = repositoryTecnologico.GetAll();

                foreach (var item in listaProdottiTecnologici)
                {
                    if (codiceProdotto == item.Codice)
                    {
                        Console.WriteLine("codice prodotto già presente in inventario, si rega di rirovare l'inserimento");
                        return;
                    }

                }

            Console.WriteLine("\nInserisci la Descrizione del prodotto\n");

                string descrizioneProdotto = Console.ReadLine();

            Console.WriteLine("\nInserisci il Prezzo del prodotto\n");

                double prezzoProdotto;

                while (!double.TryParse(Console.ReadLine(), out prezzoProdotto))
                {
                    Console.WriteLine("\nRiprova, Inserimento Prezzo non riuscito\n");
                };

            Console.WriteLine("\nInserisci la Marca del prodotto\n");
            
                string marca = Console.ReadLine();



                string input="";

                while (!(input=="n" || input=="N" || input == "u" || input == "U"))
                {

                    Console.WriteLine("\ndigitare n se il prodotto è nuovo, u se è usato"); 
                    input = Console.ReadLine();
                };

                NuovoUsato novita;

                if (input == "N" || input == "n")
                {
                    novita = NuovoUsato.Nuovo;
                }
                else
                {
                    novita = NuovoUsato.Usato;
                }
            
            
            
            var nuovoProdotto = new ProdottoTecnologico(codiceProdotto, descrizioneProdotto, prezzoProdotto, marca, novita);

            var esito = repositoryTecnologico.Aggiungi(nuovoProdotto);
            if (esito == true)
            {
                Console.WriteLine("\nProdotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("\nErrore nell'inserimento del prodotto");
            }

        }

        private static void AggiungiProdottoAlimentare()
        {
            Console.WriteLine("\nInserisci il Codice del prodotto\n");
            
                string codiceProdotto = Console.ReadLine();

                var listaProdottiAlimentari = repositoryAlimentare.GetAll();
                                    
                foreach (var item in listaProdottiAlimentari)
                {
                    if (codiceProdotto == item.Codice)
                    {                   
                        Console.WriteLine("codice prodotto già presente in inventario, si rega di rirovare l'inserimento");
                        return;
                    }

                }

           
            Console.WriteLine("\nInserisci la Descrizione del prodotto\n");

                string descrizioneProdotto = Console.ReadLine();

            
            Console.WriteLine("\nInserisci il Prezzo del prodotto\n");

                double prezzoProdotto;
            
                while (!double.TryParse(Console.ReadLine(), out prezzoProdotto))
                {
                    Console.WriteLine("\nRiprova, Inserimento Prezzo non riuscito\n");
                };
            
            
            Console.WriteLine("\nInserisci la quantità\n");
            
                int QuantitaProdotto;
                
                while (!int.TryParse(Console.ReadLine(), out QuantitaProdotto))
                    {
                        Console.WriteLine("Riprova, inserimento quantità non riuscito");
                    };

            
            Console.WriteLine("\nInserisci il giorno della data di scadenza");

                int giorno;
                
                while (!(int.TryParse(Console.ReadLine(), out giorno)&& giorno>=1 && giorno<=31) )
                {
                    Console.WriteLine("Riprova, inserimento giorno non riuscito");
                }

            Console.WriteLine("\nInserisci il mese della data di scadenza");

                int mese;

                while (!(int.TryParse(Console.ReadLine(), out mese) && mese >= 1 && giorno <= 31))
                {
                    Console.WriteLine("Riprova, inserimento mese non riuscito");
                }

            Console.WriteLine("\nInserisci l'anno della data di scadenza");

                int anno;

                while (!(int.TryParse(Console.ReadLine(), out anno) && anno >= DateTime.Now.Year ))
                {
                    Console.WriteLine("\nRiprova, inserimento giorno non riuscito");
                }



            var nuovoProdotto = new ProdottoAlimentare(codiceProdotto, descrizioneProdotto, prezzoProdotto, QuantitaProdotto, new DateTime(anno, mese, giorno));
            
            var esito = repositoryAlimentare.Aggiungi(nuovoProdotto);
            if (esito == true)
            {
                Console.WriteLine("\nProdotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("\nErrore nell'inserimento del prodotto");
            }
        }

        private static void VisualizzaProdottiTecnologici()
        {
            var listaProdottiTecnologici = repositoryTecnologico.GetAll();

            if (listaProdottiTecnologici.Count == 0)
            {
                Console.WriteLine("\nNon sono presenti prodotti nello store\n");
            }
            else
            {
                Console.WriteLine("\nlista Prodotti Tecnologici \n");
                foreach (var item in listaProdottiTecnologici)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void VisualizzaProdottiAlimentari()
        {
            var listaProdottiAlimentari = repositoryAlimentare.GetAll();

            if (listaProdottiAlimentari.Count == 0)
            {
                Console.WriteLine("\nNon sono presenti prodotti nello store\n");
            }
            else
            {
                Console.WriteLine("lista Prodotti Alimentari \n");
                foreach (var item in listaProdottiAlimentari)
                {
                    item.StampaDescrizione();
                }
            }
        }

        private static void VisualizzaProdotti()
        {

            var listaProdottiAlimentari = repositoryAlimentare.GetAll();
            var listaProdottiTecnologici = repositoryTecnologico.GetAll();

            if (listaProdottiAlimentari.Count == 0 && listaProdottiTecnologici.Count == 0)
            {
                Console.WriteLine("\nNon sono presenti prodotti nello store\n");
            }
            else
            {
                Console.WriteLine("lista Prodotti Alimentari \n");
                foreach (var item in listaProdottiAlimentari)
                {
                    item.StampaDescrizione();
                }
                
                Console.WriteLine("\nlista Prodotti Tecnologici \n");
                foreach (var item in listaProdottiTecnologici)
                {
                    item.StampaDescrizione();
                }
            }
        }
    }
}
