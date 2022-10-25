using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Articles 
    {
        public int Art_Num_ID { get; set; }
        public string Art_Ref { get; set; }
        public string Art_Libelle { get; set; }
        public string Art_Description { get; set; }
        public int Art_Premium { get; set; }
        public string Familles_Id { get; set; }
        public string SS_Fam_Id { get; set; }
        public string Genres_Id { get; set; }
        public int Pierres_Id { get; set; }
        public int Metal_Id { get; set; }
        public string Colors_Id { get; set; }
        public int Type_Art_Id { get; set; }
        public double Art_Poids { get; set; }
        public double Art_PxVte_PubHT { get; set; }
        public double Art_PxVte_GrosHT { get; set; }
        public double Art_PxVte_Facon { get; set; }
        public string Art_Fic_Img1 { get; set; }
        public string Art_Fic_Img2 { get; set; }
        public string Art_Fic_Img3 { get; set; }
        public DateTime Art_DatCre { get; set; }
        public DateTime Art_DatMaj { get; set; }

        public Articles(){/*constructor default*/}
        public Articles(int Art_Num_ID) {/*constructor default avec une valeur*/}
        public Articles(int Art_Num_ID, string Art_Ref, 
            string Art_Libelle, string Art_Description, 
            int Art_Premium, string Familles_Id, string SS_Fam_Id, string Genres_Id, 
            int Pierres_Id, int Metal_Id, string Colors_Id, int Type_Art_Id, 
            double Art_Poids, double Art_PxVte_PubHT, double Art_PxVte_GrosHT,
            double Art_PxVte_Facon ,string Art_Fic_Img1, string Art_Fic_Img2, 
            string Art_Fic_Img3, DateTime Art_DatCre, DateTime Art_DatMaj)
        {
            this.Art_Num_ID = Art_Num_ID;
            this.Art_Ref = Art_Ref;
            this.Art_Libelle = Art_Libelle;
            this.Art_Description = Art_Description;
            this.Art_Premium = Art_Premium;
            this.Familles_Id = Familles_Id;
            this.SS_Fam_Id = SS_Fam_Id;
            this.Genres_Id = Genres_Id;
            this.Pierres_Id = Pierres_Id;
            this.Metal_Id = Metal_Id;
            this.Colors_Id = Colors_Id;
            this.Type_Art_Id = Type_Art_Id;
            this.Art_Poids = Art_Poids;
            this.Art_PxVte_PubHT = Art_PxVte_PubHT;
            this.Art_PxVte_GrosHT = Art_PxVte_GrosHT;
            this.Art_PxVte_Facon = Art_PxVte_Facon;
            this.Art_Fic_Img1 = Art_Fic_Img1;
            this.Art_Fic_Img2 = Art_Fic_Img2;
            this.Art_Fic_Img3 = Art_Fic_Img3;
            this.Art_DatCre = Art_DatCre;
            this.Art_DatMaj = Art_DatMaj;
        }
    }
}