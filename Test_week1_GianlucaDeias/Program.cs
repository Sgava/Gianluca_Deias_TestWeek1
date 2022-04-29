
/*       Risposte quesiti:
 *       1)
 *          a) inizializzazione
 *          b) dichiarazione
 *          c) assegnazione
 *       
 *       2)
 *          b
 *       
 *       3)
 *          c 
 *
 *
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_week1_GianlucaDeias;
using Test_week1_GianlucaDeias.Entities;
using Test_week1_GianlucaDeias.Interfaces;
using Test_week1_GianlucaDeias.Repositories;


ProdottoAlimentare prova = new ProdottoAlimentare("ewe", "lolo", 12, 3, new DateTime(2022, 5, 10));

ProdottoTecnologico prova2 = new ProdottoTecnologico("1010", "telefono", 100, "samsung", NuovoUsato.Usato);

UserInterface.Start();
