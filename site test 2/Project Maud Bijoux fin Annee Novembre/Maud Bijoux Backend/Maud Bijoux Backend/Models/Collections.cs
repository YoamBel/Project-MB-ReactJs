using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Collections
    {
        public int Collections_Id { get; set; }
        public string Collections_Lib { get; set; }
       
        public Collections(int Collections_Id, string Collections_Lib)
        {
            this.Collections_Id = Collections_Id;
            this.Collections_Lib = Collections_Lib;
        }

       
    }
}