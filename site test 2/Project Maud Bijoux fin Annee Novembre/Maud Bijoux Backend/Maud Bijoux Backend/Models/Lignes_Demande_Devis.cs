using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Lignes_Demande_Devis
    {
        public int Ligdev_Num_ID { get; set; }
        public int Demdev_Num_ID { get; set; }
        public int Ligdev_Num_Ligne { get; set; }
        public int Art_Num_ID { get; set; }
        public string Art_Ref { get; set; }
        public int Ligdev_Qte { get; set; }
        public double Ligdev_Poids_TH { get; set; }
        public double Ligdev_Prix_HT { get; set; }
        public string Ligdev_MsgCli { get; set; }
        public double Ligdev_PrixVteHT { get; set; }


        public Lignes_Demande_Devis() {/*constructor default*/}
        public Lignes_Demande_Devis(int Ligdev_Num_ID, int Demdev_Num_ID,int Ligdev_Num_Ligne, int Art_Num_ID, string Art_Ref, int Ligdev_Qte, double Ligdev_Poids_TH, double Ligdev_Prix_HT, string Ligdev_MsgCli, double Ligdev_PrixVteHT)
        {
            this.Ligdev_Num_ID = Ligdev_Num_ID;
            this.Demdev_Num_ID = Demdev_Num_ID;
            this.Ligdev_Num_Ligne = Ligdev_Num_Ligne;
            this.Art_Num_ID = Art_Num_ID;
            this.Art_Ref = Art_Ref;
            this.Ligdev_Qte = Ligdev_Qte;
            this.Ligdev_Poids_TH = Ligdev_Poids_TH;
            this.Ligdev_Prix_HT = Ligdev_Prix_HT;
            this.Ligdev_MsgCli = Ligdev_MsgCli;
            this.Ligdev_PrixVteHT = Ligdev_PrixVteHT;
        }
    }
}