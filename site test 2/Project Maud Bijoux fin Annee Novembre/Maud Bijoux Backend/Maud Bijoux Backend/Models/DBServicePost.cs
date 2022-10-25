using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class DBServicePost
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

        //Save Article
        public int Post_Articles_Save(Articles articles)
        {
            Connection_Open();
            command.CommandText = $"Insert into Articles (Art_Ref,Art_Libelle,Art_Description," +
                $"Art_Premium,Familles_Id,SS_Fam_Id,Genres_Id,Pierres_Id,Metal_Id,Colors_Id,Type_Art_Id,Art_Poids," +
                $"Art_PxVte_PubHT,Art_PxVte_GrosHT,Art_PxVte_Facon,Art_Fic_Img1," +
                $"Art_Fic_Img2,Art_Fic_Img3,Art_DatCre,Art_DatMaj)" +
                        $"Values(@Art_Ref, @Art_Libelle ,@Art_Description,@Art_Premium,@Familles_Id,@SS_Fam_Id,@Genres_Id,@Pierres_Id," +
                        $"@Metal_Id,@Colors_Id,@Type_Art_Id,@Art_Poids," +
                        $"@Art_PxVte_PubHT,@Art_PxVte_GrosHT,@Art_PxVte_Facon,@Art_Fic_Img1,@Art_Fic_Img2,@Art_Fic_Img3,@Art_DatCre,@Art_DatMaj) ";

            //command.Parameters.AddWithValue("@Art_Num_ID", articles.Art_Num_ID);
            command.Parameters.AddWithValue("@Art_Ref", articles.Art_Ref);
            command.Parameters.AddWithValue("@Art_Libelle", articles.Art_Libelle);
            command.Parameters.AddWithValue("@Art_Description", articles.Art_Description);
            command.Parameters.AddWithValue("@Art_Premium", articles.Art_Premium);
            command.Parameters.AddWithValue("@Familles_Id", articles.Familles_Id);
            command.Parameters.AddWithValue("@SS_Fam_Id", articles.SS_Fam_Id);
            command.Parameters.AddWithValue("@Genres_Id", articles.Genres_Id);
            command.Parameters.AddWithValue("@Pierres_Id", articles.Pierres_Id);
            command.Parameters.AddWithValue("@Colors_Id", articles.Colors_Id);
            command.Parameters.AddWithValue("@Metal_Id", articles.Metal_Id);
            command.Parameters.AddWithValue("@Type_Art_Id", articles.Type_Art_Id);
            command.Parameters.AddWithValue("@Art_Poids", articles.Art_Poids);
            command.Parameters.AddWithValue("@Art_PxVte_PubHT", articles.Art_PxVte_PubHT);
            command.Parameters.AddWithValue("@Art_PxVte_GrosHT", articles.Art_PxVte_GrosHT);
            command.Parameters.AddWithValue("@Art_PxVte_Facon", articles.Art_PxVte_Facon);
            command.Parameters.AddWithValue("@Art_Fic_Img1", articles.Art_Fic_Img1);
            command.Parameters.AddWithValue("@Art_Fic_Img2", articles.Art_Fic_Img2);
            command.Parameters.AddWithValue("@Art_Fic_Img3", articles.Art_Fic_Img3);
            command.Parameters.AddWithValue("@Art_DatCre", articles.Art_DatCre);
            command.Parameters.AddWithValue("@Art_DatMaj", articles.Art_DatMaj);


            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Metal
        public int Post_Metal_Save(Metal metal)
        {
            Connection_Open();
            command.CommandText = $"Insert into Metal (Metal_Id,Metal_Lib,Metal_Cours,Metal_CoursFin," +
                                  $"Metal_TauxAlliage ,Metal_CoefCours, Metal_DateCours)" +
                                    $"Values(@Metal_Id,@Metal_Lib,@Metal_Cours,@Metal_CoursFin," +
                                    $"@Metal_TauxAlliage , @Metal_CoefCours ,@Metal_DateCours) ";

            command.Parameters.AddWithValue("@Metal_Id", metal.Metal_Id);
            command.Parameters.AddWithValue("@Metal_Lib", metal.Metal_Lib);
            command.Parameters.AddWithValue("@Metal_Cours", metal.Metal_Cours);
            command.Parameters.AddWithValue("@Metal_CoursFin", metal.Metal_CoursFin);
            command.Parameters.AddWithValue("@Metal_TauxAlliage", metal.Metal_TauxAlliage);
            command.Parameters.AddWithValue("@Metal_CoefCours", metal.Metal_CoefCours);
            command.Parameters.AddWithValue("@Metal_DateCours", metal.Metal_DateCours);




            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save sous Famille
        public int Post_Sous_Familles_Save(Sous_Familles sousFamille)
        {
            Connection_Open();
            command.CommandText = $"Insert into Sous_Familles (SS_Fam_Id,SS_Fam_Lib,Familles_Id)" +
                        $"Values(@SS_Fam_Id,@SS_Fam_Lib,@Familles_Id) ";

            command.Parameters.AddWithValue("@SS_Fam_Id", sousFamille.SS_Fam_Id);
            command.Parameters.AddWithValue("@SS_Fam_Lib", sousFamille.SS_Fam_Lib);
            command.Parameters.AddWithValue("@Familles_Id", sousFamille.Familles_Id);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Famille
        public int Post_Familles_Save(Familles familles)
        {
            Connection_Open();
            command.CommandText = $"Insert into Familles (Familles_Id,Familles_Lib)" +
                        $"Values(@Familles_Id,@Familles_Lib) ";

            command.Parameters.AddWithValue("@Familles_Id", familles.Familles_Id);
            command.Parameters.AddWithValue("@Familles_Lib", familles.Familles_Lib);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Pierres
        public int Post_Pierres_Save(Pierres pierres)
        {
            Connection_Open();
            command.CommandText = $"Insert into Pierres (Pierres_Id,Pierres_Lib)" +
                        $"Values(@Pierres_Id,@Pierres_Lib) ";

            command.Parameters.AddWithValue("@Pierres_Id", pierres.Pierres_Id);
            command.Parameters.AddWithValue("@Pierres_Lib", pierres.Pierres_Lib);
            


            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save type article
        public int Post_Type_Article_Save(Type_Article typeArticle)
        {
            Connection_Open();
            command.CommandText = $"Insert into Type_Article (Type_Art_Id,Type_Art_Lib)" +
                        $"Values(@Type_Art_Id,@Type_Art_Lib) ";

            command.Parameters.AddWithValue("@Type_Art_Id", typeArticle.Type_Art_Id);
            command.Parameters.AddWithValue("@Type_Art_Lib", typeArticle.Type_Art_Lib);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Genres
        public int Post_Genre_Save(Genres genres)
        {
            Connection_Open();
            command.CommandText = $"Insert into Genres (Genres_Id,Genres_Lib)" +
                        $"Values(@Genres_Id,@Genres_Lib) ";

            command.Parameters.AddWithValue("@Genres_Id", genres.Genres_Id);
            command.Parameters.AddWithValue("@Genres_Lib", genres.Genres_Lib);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Indicatif tel
        public int Post_Indicatif_Tel_Save(Indicatif_Tel indicatifTel)
        {
            Connection_Open();
            command.CommandText = $"Insert into Indicatif_Tel (Ind_Tel_Pays,Ind_Tel_Indicatif)" +
                        $"Values(@Ind_Tel_Pays,@Ind_Tel_Indicatif) ";

            command.Parameters.AddWithValue("@Ind_Tel_Pays", indicatifTel.Ind_Tel_Pays);
            command.Parameters.AddWithValue("@Ind_Tel_Indicatif", indicatifTel.Ind_Tel_Indicatif);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Comptes Clients
        public int Post_Comptes_Clients_Save(Comptes_Clients comptesClients)
        {
            Connection_Open();
            command.CommandText = $"Insert into Comptes_Clients (Cptcli_Email_Id,Cptcli_Password,Cptcli_Actif," +
                $"Cptcli_Acces_Premium,Cptcli_Civilite,Cptcli_Nomcli,Cptcli_Prenom,Cptcli_Tel1,Cptcli_RaiSoc," +
                $"Cptcli_No_Siret,Cptcli_No_TVAintra,Cptcli_Adr1,Cptcli_Adr2,Cptcli_CP,Cptcli_ville,Cptcli_Pays," +
                $"Cptcli_Tel2,Cptcli_RefcliMB,Cptcli_ComptacliMB,Cptcli_Cpteur_Devis,Cptcli_Cle_secu,Cptcli_DatCre,Cptcli_DatMaj)" +
                        $"Values(@Cptcli_Email_Id,@Cptcli_Password, @Cptcli_Actif,@Cptcli_Acces_Premium," +
                        $"@Cptcli_Civilite,@Cptcli_Nomcli,@Cptcli_Prenom,@Cptcli_Tel1,@Cptcli_RaiSoc," +
                        $"@Cptcli_No_Siret,@Cptcli_No_TVAintra,@Cptcli_Adr1,@Cptcli_Adr2,@Cptcli_CP,@Cptcli_ville," +
                        $"@Cptcli_Pays,@Cptcli_Tel2,@Cptcli_RefcliMB,@Cptcli_ComptacliMB,@Cptcli_Cpteur_Devis,@Cptcli_Cle_secu,@Cptcli_DatCre,@Cptcli_DatMaj) ";

            //command.Parameters.AddWithValue("@Cptcli_Num_ID", comptesClients.Cptcli_Num_ID);
            command.Parameters.AddWithValue("@Cptcli_Email_Id", comptesClients.Cptcli_Email_Id);
            command.Parameters.AddWithValue("@Cptcli_Password", comptesClients.Cptcli_Password);
            command.Parameters.AddWithValue("@Cptcli_Actif", comptesClients.Cptcli_Actif);
            command.Parameters.AddWithValue("@Cptcli_Acces_Premium", comptesClients.Cptcli_Acces_Premium);
            command.Parameters.AddWithValue("@Cptcli_Civilite", comptesClients.Cptcli_Civilite);
            command.Parameters.AddWithValue("@Cptcli_Nomcli", comptesClients.Cptcli_Nomcli);
            command.Parameters.AddWithValue("@Cptcli_Prenom", comptesClients.Cptcli_Prenom);
            command.Parameters.AddWithValue("@Cptcli_Tel1", comptesClients.Cptcli_Tel1);
            command.Parameters.AddWithValue("@Cptcli_RaiSoc", comptesClients.Cptcli_RaiSoc);
            command.Parameters.AddWithValue("@Cptcli_No_Siret", comptesClients.Cptcli_No_Siret);
            command.Parameters.AddWithValue("@Cptcli_No_TVAintra", comptesClients.Cptcli_No_TVAintra);
            command.Parameters.AddWithValue("@Cptcli_Adr1", comptesClients.Cptcli_Adr1);
            command.Parameters.AddWithValue("@Cptcli_Adr2", comptesClients.Cptcli_Adr2);
            command.Parameters.AddWithValue("@Cptcli_CP", comptesClients.Cptcli_CP);
            command.Parameters.AddWithValue("@Cptcli_ville", comptesClients.Cptcli_ville);
            command.Parameters.AddWithValue("@Cptcli_Pays", comptesClients.Cptcli_Pays);
            command.Parameters.AddWithValue("@Cptcli_Tel2", comptesClients.Cptcli_Tel2);
            command.Parameters.AddWithValue("@Cptcli_RefcliMB", comptesClients.Cptcli_RefcliMB);
            command.Parameters.AddWithValue("@Cptcli_ComptacliMB", comptesClients.Cptcli_ComptacliMB);
            command.Parameters.AddWithValue("@Cptcli_Cpteur_Devis", comptesClients.Cptcli_Cpteur_Devis);
            command.Parameters.AddWithValue("@Cptcli_Cle_secu", comptesClients.Cptcli_Cle_secu);
            command.Parameters.AddWithValue("@Cptcli_DatCre", comptesClients.Cptcli_DatCre);
            command.Parameters.AddWithValue("@Cptcli_DatMaj", comptesClients.Cptcli_DatMaj);

            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;


        }

        //Save Demande Devis
        public int Post_Demande_Devis_Save(Demande_Devis demandeDevis)
        {
            Connection_Open();
            command.CommandText = $"Insert into Demande_Devis (Demdev_Num_ID,Cptcli_Num_ID,Demdev_Statut,Demdev_MsgCli," +
                $"Demdev_MsgMB,Demdev_MontantHT,Demdev_NB_Lig_Art,Demdev_NB_Piece,Demdev_NB_Ligne,Demdev_DatCre,Demdev_DatMaj)" +
                        $"Values(@Demdev_Num_ID,@Cptcli_Num_ID,@Demdev_Statut,@Demdev_MsgCli,@Demdev_MsgMB,@Demdev_MontantHT,@Demdev_NB_Lig_Art,@Demdev_NB_Piece,@Demdev_NB_Ligne,@Demdev_DatCre," +
                        $"@Demdev_DatMaj) ";

            command.Parameters.AddWithValue("@Demdev_Num_ID", demandeDevis.Demdev_Num_ID);
            command.Parameters.AddWithValue("@Cptcli_Num_ID", demandeDevis.Cptcli_Num_ID);
            command.Parameters.AddWithValue("@Demdev_Statut", demandeDevis.Demdev_Statut);
            command.Parameters.AddWithValue("@Demdev_MsgCli", demandeDevis.Demdev_MsgCli);
            command.Parameters.AddWithValue("@Demdev_MsgMB", demandeDevis.Demdev_MsgMB);
            command.Parameters.AddWithValue("@Demdev_MontantHT", demandeDevis.Demdev_MontantHT);
            command.Parameters.AddWithValue("@Demdev_NB_Lig_Art", demandeDevis.Demdev_NB_Lig_Art);
            command.Parameters.AddWithValue("@Demdev_NB_Piece", demandeDevis.Demdev_NB_Piece);
            command.Parameters.AddWithValue("@Demdev_NB_Ligne", demandeDevis.Demdev_NB_Ligne);
            command.Parameters.AddWithValue("@Demdev_DatCre", demandeDevis.Demdev_DatCre);
            command.Parameters.AddWithValue("@Demdev_DatMaj", demandeDevis.Demdev_DatMaj);


            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }

        //Save Lignes Demande Devis
        public int Post_Lignes_Demande_Devis_Save(Lignes_Demande_Devis lignesDemandeDevis)
        {
            Connection_Open();
            command.CommandText = $"Insert into Lignes_Demande_Devis (Ligdev_Num_ID,Demdev_Num_ID,Ligdev_Num_Ligne,Art_Num_ID,Art_Ref,Ligdev_Qte,Ligdev_Poids_TH,Ligdev_Prix_HT,Ligdev_MsgCli,Ligdev_PrixVteHT)" +
                        $"Values(@Ligdev_Num_ID,@Demdev_Num_ID,@Ligdev_Num_Ligne,@Art_Num_ID,@Art_Ref,@Ligdev_Qte,@Ligdev_Poids_TH,@Ligdev_Prix_HT,@Ligdev_MsgCli,@Ligdev_PrixVteHT) ";

            command.Parameters.AddWithValue("@Ligdev_Num_ID", lignesDemandeDevis.Ligdev_Num_ID);
            command.Parameters.AddWithValue("@Demdev_Num_ID", lignesDemandeDevis.Demdev_Num_ID);
            command.Parameters.AddWithValue("@Ligdev_Num_Ligne", lignesDemandeDevis.Ligdev_Num_Ligne);
            command.Parameters.AddWithValue("@Art_Num_ID", lignesDemandeDevis.Art_Num_ID);
            command.Parameters.AddWithValue("@Art_Ref", lignesDemandeDevis.Art_Ref);
            command.Parameters.AddWithValue("@Ligdev_Qte", lignesDemandeDevis.Ligdev_Qte);
            command.Parameters.AddWithValue("@Ligdev_Poids_TH", lignesDemandeDevis.Ligdev_Poids_TH);
            command.Parameters.AddWithValue("@Ligdev_Prix_HT", lignesDemandeDevis.Ligdev_Prix_HT);
            command.Parameters.AddWithValue("@Ligdev_MsgCli", lignesDemandeDevis.Ligdev_MsgCli);
            command.Parameters.AddWithValue("@Ligdev_PrixVteHT", lignesDemandeDevis.Ligdev_PrixVteHT);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }

        //Save Collections
        public int Post_Collections_Save(Collections collections)
        {
            Connection_Open();
            command.CommandText = $"Insert into Collections (Collections_Lib)" +
                        $"Values(@Collections_Lib) ";

            command.Parameters.AddWithValue("@Collections_Lib", collections.Collections_Lib);
           
            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }

        //Save Collection Article
        public int Post_Col_Art_Save(Col_Art colArt)
        {
            Connection_Open();
            command.CommandText = $"Insert into Col_Art (Collections_Id,Art_Num_ID)" +
                        $"Values(@Collections_Id,@Art_Num_ID) ";

            command.Parameters.AddWithValue("@Collections_Id", colArt.Collections_Id);
            command.Parameters.AddWithValue("@Art_Num_ID", colArt.Art_Num_ID);

            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }

        //Save Parametres
        public int Post_Parametres_Save(Parametres parametres)
        {
            Connection_Open();
            command.CommandText = $"Insert into Parametres (Param_RaiSoc,Param_Email_Soc,Param_Chemin_Photos)" +
                        $"Values(@Param_RaiSoc,@Param_Email_Soc,@Param_Chemin_Photos) ";

            command.Parameters.AddWithValue("@Param_RaiSoc", parametres.Param_RaiSoc);
            command.Parameters.AddWithValue("@Param_Email_Soc", parametres.Param_Email_Soc);
            command.Parameters.AddWithValue("@Param_Chemin_Photos", parametres.Param_Chemin_Photos);

            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }


        //Save Genres
        public int Post_Colors_Save(Colors colors)
        {
            Connection_Open();
            command.CommandText = $"Insert into Colors (Colors_Id,Colors_Lib)" +
                        $"Values(@Colors_Id,@Colors_Lib) ";

            command.Parameters.AddWithValue("@Colors_Id", colors.Colors_Id);
            command.Parameters.AddWithValue("@Colors_Lib", colors.Colors_Lib);



            int res = command.ExecuteNonQuery();
            command.Connection.Close();
            return res;
        }
    }
}