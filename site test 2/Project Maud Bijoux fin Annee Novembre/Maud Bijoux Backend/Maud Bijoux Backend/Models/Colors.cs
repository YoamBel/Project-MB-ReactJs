using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Colors
    {
        public string Colors_Id { get; set; }
        public string Colors_Lib { get; set; }

        public Colors(){}
        public Colors(string Colors_Id, string Colors_Lib)
        {
            this.Colors_Id = Colors_Id;
            this.Colors_Lib = Colors_Lib;
        }
    }
}