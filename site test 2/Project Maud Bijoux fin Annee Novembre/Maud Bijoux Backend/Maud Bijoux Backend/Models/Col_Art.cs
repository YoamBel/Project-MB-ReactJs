using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Col_Art
    {
        public int Collections_Id { get; set; }
        public int Art_Num_ID { get; set; }

        public Col_Art(int Collections_Id, int Art_Num_ID)
        {
            this.Collections_Id = Collections_Id;
            this.Art_Num_ID = Art_Num_ID;
        }

        //public Col_Art(int Art_Num_ID, string Art_Ref,
        //    string Art_Libelle, string Art_Description,
        //    int Art_Premium, string SS_Fam_Id, string Genres_Id,
        //    int Pierres_Id, int Metal_Id, int Type_Art_Id,
        //    double Art_Poids, string Art_Fic_Img1, string Art_Fic_Img2,
        //    string Art_Fic_Img3, DateTime Art_DatCre, DateTime Art_DatMaj,
        //    string Collections_Id) : base(Art_Num_ID, Art_Ref, Art_Libelle, Art_Description,
        //        Art_Premium, SS_Fam_Id, Genres_Id, Pierres_Id, Metal_Id, Type_Art_Id,
        //        Art_Poids, Art_Fic_Img1, Art_Fic_Img2, Art_Fic_Img3, Art_DatCre,
        //        Art_DatMaj)
        //{
        //    this.Collections_Id = Collections_Id;
        //}
    }
}