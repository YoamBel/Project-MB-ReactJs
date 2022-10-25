using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Type_Article 
    {
        public int Type_Art_Id { get; set; }
        public string Type_Art_Lib { get; set; }
        public Type_Article() {/*constructor default*/}
        public Type_Article(int Type_Art_Id, string Type_Art_Lib) 
        {
            this.Type_Art_Id = Type_Art_Id;
            this.Type_Art_Lib = Type_Art_Lib;
        }


        //public Type_Article(string Type_Art_Lib, int Art_Num_ID, string Art_Ref,
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
        //    this.Type_Art_Lib = Type_Art_Lib;
        //}
    }
}