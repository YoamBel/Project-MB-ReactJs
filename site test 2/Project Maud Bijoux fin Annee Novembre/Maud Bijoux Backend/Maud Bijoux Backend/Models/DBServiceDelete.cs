using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class DBServiceDelete
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["LIVEDNSfromLivedns"].ConnectionString;
        readonly string conStrLocal = ConfigurationManager.ConnectionStrings["LIVEDNSfromLocal"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        bool local = true;


        // connection a la base de donnee sql serveur 
        public void Connection_Open()
        {
            string cons = conStr;
            if (local)
            {
                cons = conStrLocal;
            }
            connection = new SqlConnection(cons);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
        }

        //supression de l'article complete uniquement
        public void Delete_Articles_Remove(int Art_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Articles Where Art_Num_ID = '{Art_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Articles does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression du metal complete uniquement
        public void Delete_Metal_Remove(int Metal_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Metal Where Metal_Id = '{Metal_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Metal does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }

        //supression de la sous familles
        public void Delete_Sous_Familles_Remove(string SS_Fam_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Sous_Familles Where SS_Fam_Id = '{SS_Fam_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The sous familles does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }

        //supression de la famille complete uniquement
        public void Delete_Familles_Remove(string Familles_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Familles Where Familles_Id = '{Familles_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Familles does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression de la pierre complete uniquement
        public void Delete_Pierres_Remove(int Pierres_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Pierres Where Pierres_Id = '{Pierres_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The pierres does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression du type article complete uniquement
        public void Delete_Type_Article_Remove(int Type_Art_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Type_Article Where Type_Art_Id = '{Type_Art_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The type article does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression du Genres complete uniquement
        public void Delete_Genres_Remove(string Genres_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Genres Where Genres_Id = '{Genres_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The genres does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression de l'indicatif tel complete uniquement
        public void Delete_Indicatif_Tel_Remove(int Ind_Tel_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Indicatif_Tel Where Ind_Tel_Num_ID = '{Ind_Tel_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The indicatif tel pays does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression du compte client complete uniquement
        public void Delete_Comptes_Clients_Remove(int Cptcli_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Comptes_Clients Where Cptcli_Num_ID = '{Cptcli_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Comptes Clients does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression de la demande de devis complete uniquement
        public void Delete_Demande_Devis_Remove(int Demdev_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Demande_Devis Where Demdev_Num_ID = '{Demdev_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Demande Devis does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression de la ligne de la demande devis complete uniquement
        public void Delete_Lignes_Demande_Devis_Remove(int Ligdev_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Lignes_Demande_Devis Where Ligdev_Num_ID = '{Ligdev_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Lignes Demande Devis does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression de la collection complete uniquement
        public void Delete_Collections_Remove(int Collections_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Collections Where Collections_Id = '{Collections_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Collections does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }

        //supression dela cillection articles complete uniquement
        public void Delete_Col_Art_Remove(int Collections_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Col_Art Where Collections_Id = '{Collections_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Col Art does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }

        //supression des parametres complete uniquement
        public void Delete_Parametres_Remove(int Param_Num_ID)
        {
            Connection_Open();
            command.CommandText = $"Delete from Parametres Where Param_Num_ID = '{Param_Num_ID}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Parametres does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }


        //supression Colors complete uniquement
        public void Delete_Colors_Remove(string Colors_Id)
        {
            Connection_Open();
            command.CommandText = $"Delete from Colors Where Colors_Id = '{Colors_Id}'";
            int res = command.ExecuteNonQuery();
            if (res == 0)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception("The Colors does not exist!");
#pragma warning restore S112 // General exceptions should never be thrown
            }
            command.Connection.Close();
        }

    }
}