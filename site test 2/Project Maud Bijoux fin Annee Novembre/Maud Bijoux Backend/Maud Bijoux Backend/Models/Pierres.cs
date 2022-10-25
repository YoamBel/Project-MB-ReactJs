using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Pierres 
    {
        public int Pierres_Id { get; set; }
        public string Pierres_Lib { get; set; }
        public Pierres() {/*constructor default*/}
        public Pierres(int Pierres_Id, string Pierres_Lib) 
        {
            this.Pierres_Id = Pierres_Id;
            this.Pierres_Lib = Pierres_Lib;
        }



        //public Pierres(string Pierres_Lib, int Art_Num_ID, string Art_Ref,
        //    string Art_Libelle, string Art_Description,
        //    int Art_Premium, string SS_Fam_Id, string Genres_Id,
        //    int Pierres_Id, int Metal_Id, int Type_Art_Id,
        //    double Art_Poids, string Art_Fic_Img1, string Art_Fic_Img2,
        //    string Art_Fic_Img3, DateTime Art_DatCre, DateTime Art_DatMaj)
        //    : base(Art_Num_ID, Art_Ref, Art_Libelle, Art_Description,
        //        Art_Premium, SS_Fam_Id, Genres_Id, Pierres_Id, Metal_Id, Type_Art_Id,
        //        Art_Poids, Art_Fic_Img1, Art_Fic_Img2, Art_Fic_Img3, Art_DatCre,
        //        Art_DatMaj)
        //{
        //    this.Pierres_Lib = Pierres_Lib;
        //}
    }
}