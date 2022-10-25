using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Parametres
    {
        public int Param_Num_ID { get; set; }
        public string Param_RaiSoc { get; set; }
        public string Param_Email_Soc { get; set; }
        public string Param_Chemin_Photos { get; set; }

        public Parametres(){}
        public Parametres(int Param_Num_ID, string Param_RaiSoc, string Param_Email_Soc, string Param_Chemin_Photos)
        {
            this.Param_Num_ID = Param_Num_ID;
            this.Param_RaiSoc = Param_RaiSoc;
            this.Param_Email_Soc = Param_Email_Soc;
            this.Param_Chemin_Photos = Param_Chemin_Photos;
        }
    }
}