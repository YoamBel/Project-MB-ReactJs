using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class Comptes_Clients
    {
        public int Cptcli_Num_ID { get; set; }
        public string Cptcli_Email_Id { get; set; }
        public string Cptcli_Password { get; set; }
        public int Cptcli_Actif { get; set; }
        public int Cptcli_Acces_Premium { get; set; }
        public string Cptcli_Civilite { get; set; }
        public string Cptcli_Nomcli { get; set; }
        public string Cptcli_Prenom { get; set; }
        public string Cptcli_Tel1 { get; set; }
        public string Cptcli_RaiSoc { get; set; }
        public string Cptcli_No_Siret { get; set; }
        public string Cptcli_No_TVAintra { get; set; }
        public string Cptcli_Adr1 { get; set; }
        public string Cptcli_Adr2 { get; set; }
        public string Cptcli_CP { get; set; }
        public string Cptcli_ville { get; set; }
        public string Cptcli_Pays { get; set; }
        public string Cptcli_Tel2 { get; set; }
        public string Cptcli_RefcliMB { get; set; }
        public string Cptcli_ComptacliMB { get; set; }
        public int Cptcli_Cpteur_Devis { get; set; }
        public string Cptcli_Cle_secu { get; set; }
        public DateTime Cptcli_DatCre { get; set; }
        public DateTime Cptcli_DatMaj { get; set; }


        public Comptes_Clients(int Cptcli_Num_ID, string Cptcli_Email_Id, string Cptcli_Password,
            int Cptcli_Actif,
           int Cptcli_Acces_Premium, string Cptcli_Civilite, string Cptcli_Nomcli,
           string Cptcli_Prenom, string Cptcli_Tel1, string Cptcli_RaiSoc, string Cptcli_No_Siret, string Cptcli_No_TVAintra,
           string Cptcli_Adr1, string Cptcli_Adr2, string Cptcli_CP, string Cptcli_ville, string Cptcli_Pays, string Cptcli_Tel2,
           string Cptcli_RefcliMB, string Cptcli_ComptacliMB, int Cptcli_Cpteur_Devis,string Cptcli_Cle_secu, DateTime Cptcli_DatCre, DateTime Cptcli_DatMaj)
        {
            this.Cptcli_Num_ID = Cptcli_Num_ID;
            this.Cptcli_Email_Id = Cptcli_Email_Id;
            this.Cptcli_Password = Cptcli_Password;
            this.Cptcli_Actif = Cptcli_Actif;
            this.Cptcli_Acces_Premium = Cptcli_Acces_Premium;
            this.Cptcli_Civilite = Cptcli_Civilite;
            this.Cptcli_Nomcli = Cptcli_Nomcli;
            this.Cptcli_Prenom = Cptcli_Prenom;
            this.Cptcli_Tel1 = Cptcli_Tel1;
            this.Cptcli_RaiSoc = Cptcli_RaiSoc;
            this.Cptcli_No_Siret = Cptcli_No_Siret;
            this.Cptcli_No_TVAintra = Cptcli_No_TVAintra;
            this.Cptcli_Adr1 = Cptcli_Adr1;
            this.Cptcli_Adr2 = Cptcli_Adr2;
            this.Cptcli_CP = Cptcli_CP;
            this.Cptcli_ville = Cptcli_ville;
            this.Cptcli_Pays = Cptcli_Pays;
            this.Cptcli_Tel2 = Cptcli_Tel2;
            this.Cptcli_RefcliMB = Cptcli_RefcliMB;
            this.Cptcli_ComptacliMB = Cptcli_ComptacliMB;
            this.Cptcli_Cpteur_Devis = Cptcli_Cpteur_Devis;
            this.Cptcli_Cle_secu = Cptcli_Cle_secu;
            this.Cptcli_DatCre = Cptcli_DatCre;
            this.Cptcli_DatMaj = Cptcli_DatMaj;
        }
    }
}