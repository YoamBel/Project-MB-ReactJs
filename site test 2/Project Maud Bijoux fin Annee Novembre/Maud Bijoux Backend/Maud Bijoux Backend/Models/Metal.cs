using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Metal
    {
        public int Metal_Id { get; set; }
        public string Metal_Lib { get; set; }
        public double Metal_Cours { get; set; }
        public double Metal_CoursFin { get; set; }
        public double Metal_TauxAlliage { get; set; }
        public double Metal_CoefCours { get; set; }
        public DateTime Metal_DateCours { get; set; }

        public Metal() {/*constructor default*/}
        public Metal(int Metal_Id, string Metal_Lib, double Metal_Cours, double Metal_CoursFin,
            double Metal_TauxAlliage, double Metal_CoefCours, DateTime Metal_DateCours)
        {
            this.Metal_Id = Metal_Id;
            this.Metal_Lib = Metal_Lib;
            this.Metal_Cours = Metal_Cours;
            this.Metal_CoursFin = Metal_CoursFin;
            this.Metal_TauxAlliage = Metal_TauxAlliage;
            this.Metal_CoefCours = Metal_CoefCours;
            this.Metal_DateCours = Metal_DateCours;
        }



        //public Metal(int Art_Num_ID, string Art_Ref,
        //    string Art_Libelle, string Art_Description,
        //    int Art_Premium, string SS_Fam_Id, string Genres_Id,
        //    int Pierres_Id, int Metal_Id, int Type_Art_Id,
        //    double Art_Poids, string Art_Fic_Img1, string Art_Fic_Img2,
        //    string Art_Fic_Img3, DateTime Art_DatCre, DateTime Art_DatMaj,
        //    string Metal_Lib): 
        //    base(Art_Num_ID, Art_Ref, Art_Libelle, Art_Description,
        //        Art_Premium, SS_Fam_Id, Genres_Id, Pierres_Id, Metal_Id, Type_Art_Id,
        //        Art_Poids, Art_Fic_Img1, Art_Fic_Img2, Art_Fic_Img3, Art_DatCre,
        //        Art_DatMaj)
        //{
        //    this.Metal_Lib = Metal_Lib;
        //}


    }
}