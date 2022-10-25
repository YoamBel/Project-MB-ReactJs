using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Indicatif_Tel
    {
        public int Ind_Tel_Num_ID { get; set; }
        public string Ind_Tel_Pays { get; set; }
        public string Ind_Tel_Indicatif { get; set; }

        public Indicatif_Tel(int Ind_Tel_Num_ID, string Ind_Tel_Pays, string Ind_Tel_Indicatif)
        {
            this.Ind_Tel_Num_ID = Ind_Tel_Num_ID;
            this.Ind_Tel_Pays = Ind_Tel_Pays;
            this.Ind_Tel_Indicatif = Ind_Tel_Indicatif;
        }
    }
}