using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Demande_Devis 
    {
        public int Demdev_Num_ID { get; set; }
        public int Cptcli_Num_ID { get; set; }
        public string Demdev_Statut { get; set; }
        public string Demdev_MsgCli { get; set; }
        public string Demdev_MsgMB { get; set; }
        public double Demdev_MontantHT { get; set; }
        public int Demdev_NB_Lig_Art { get; set; }
        public int Demdev_NB_Piece { get; set; }
        public int Demdev_NB_Ligne { get; set; }
        public DateTime Demdev_DatCre { get; set; }
        public DateTime Demdev_DatMaj { get; set; }
        public Demande_Devis() {/*constructor default*/}
        public Demande_Devis(int Demdev_Num_ID, int Cptcli_Num_ID, string Demdev_Statut, 
            string Demdev_MsgCli, string Demdev_MsgMB, double Demdev_MontantHT, int Demdev_NB_Lig_Art, int Demdev_NB_Piece,int Demdev_NB_Ligne ,DateTime Demdev_DatCre,
            DateTime Demdev_DatMaj)
        {
            this.Demdev_Num_ID = Demdev_Num_ID;
            this.Cptcli_Num_ID = Cptcli_Num_ID;
            this.Demdev_Statut = Demdev_Statut;
            this.Demdev_MsgCli = Demdev_MsgCli;
            this.Demdev_MsgMB = Demdev_MsgMB;
            this.Demdev_MontantHT = Demdev_MontantHT;
            this.Demdev_NB_Lig_Art = Demdev_NB_Lig_Art;
            this.Demdev_NB_Piece = Demdev_NB_Piece;
            this.Demdev_NB_Ligne = Demdev_NB_Ligne;
            this.Demdev_DatCre = Demdev_DatCre;
            this.Demdev_DatMaj = Demdev_DatMaj;
        }
    }
}