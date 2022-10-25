using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class DBServicePut
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

        //update de l'article complete uniquement
        public Articles Put_Articles_Update(Articles articles, string Art_Ref)
        {
            Connection_Open();
            command.CommandText = "Update Articles" +
                $" Set Art_Ref = @Art_Ref , Art_Libelle = @Art_Libelle , Art_Description = @Art_Description," +
                $" Art_Premium = @Art_Premium,Familles_Id = @Familles_Id , SS_Fam_Id = @SS_Fam_Id, Genres_Id = @Genres_Id , Pierres_Id = @Pierres_Id," +
                $" Metal_Id = @Metal_Id ,Colors_Id =@Colors_Id , Type_Art_Id = @Type_Art_Id, Art_Poids = @Art_Poids ," +
                $" Art_PxVte_PubHT = @Art_PxVte_PubHT,Art_PxVte_GrosHT = @Art_PxVte_GrosHT ,Art_PxVte_Facon = @Art_PxVte_Facon, Art_Fic_Img1 = @Art_Fic_Img1," +
                $" Art_Fic_Img2 = @Art_Fic_Img2 , Art_Fic_Img3 = @Art_Fic_Img3, Art_DatCre = @Art_DatCre , Art_DatMaj = @Art_DatMaj" +
                $" Where Art_Ref = @Art_Ref";

            command.Parameters.Add(new SqlParameter("@Art_Num_ID", articles.Art_Num_ID));
            command.Parameters.Add(new SqlParameter("@Art_Ref", articles.Art_Ref));
            command.Parameters.Add(new SqlParameter("@Art_Libelle", articles.Art_Libelle));
            command.Parameters.Add(new SqlParameter("@Art_Description", articles.Art_Description));
            command.Parameters.Add(new SqlParameter("@Art_Premium", articles.Art_Premium));
            command.Parameters.Add(new SqlParameter("@Familles_Id", articles.Familles_Id));
            command.Parameters.Add(new SqlParameter("@SS_Fam_Id", articles.SS_Fam_Id));
            command.Parameters.Add(new SqlParameter("@Genres_Id", articles.Genres_Id));
            command.Parameters.Add(new SqlParameter("@Pierres_Id", articles.Pierres_Id));
            command.Parameters.Add(new SqlParameter("@Metal_Id", articles.Metal_Id));
            command.Parameters.Add(new SqlParameter("@Colors_Id", articles.Colors_Id));
            command.Parameters.Add(new SqlParameter("@Type_Art_Id", articles.Type_Art_Id));
            command.Parameters.Add(new SqlParameter("@Art_Poids", articles.Art_Poids));
            command.Parameters.Add(new SqlParameter("@Art_PxVte_PubHT", articles.Art_PxVte_PubHT));
            command.Parameters.Add(new SqlParameter("@Art_PxVte_GrosHT", articles.Art_PxVte_GrosHT));
            command.Parameters.Add(new SqlParameter("@Art_PxVte_Facon", articles.Art_PxVte_Facon));
            command.Parameters.Add(new SqlParameter("@Art_Fic_Img1", articles.Art_Fic_Img1));
            command.Parameters.Add(new SqlParameter("@Art_Fic_Img2", articles.Art_Fic_Img2));
            command.Parameters.Add(new SqlParameter("@Art_Fic_Img3", articles.Art_Fic_Img3));
            command.Parameters.Add(new SqlParameter("@Art_DatCre", articles.Art_DatCre));
            command.Parameters.Add(new SqlParameter("@Art_DatMaj", articles.Art_DatMaj));

            command.ExecuteNonQuery();
            command.Connection.Close();
            articles.Art_Ref = Art_Ref;
            return articles;
        }

        //update du metal complete uniquement
        public Metal Put_Metal_Update(Metal metal,int Metal_Id)
        {
            Connection_Open();
            command.CommandText = "Update Metal" +
                $" Set Metal_Id = @Metal_Id , Metal_Lib=@Metal_Lib , Metal_Cours = @Metal_Cours ," +
                $"Metal_CoursFin = @Metal_CoursFin , Metal_TauxAlliage = @Metal_TauxAlliage , " +
                $"Metal_CoefCours = @Metal_CoefCours ,Metal_DateCours = @Metal_DateCours " +
                $" Where Metal_Id = @Metal_Id";

            command.Parameters.Add(new SqlParameter("@Metal_Id", metal.Metal_Id));
            command.Parameters.Add(new SqlParameter("@Metal_Lib", metal.Metal_Lib));
            command.Parameters.Add(new SqlParameter("@Metal_Cours", metal.Metal_Cours));
            command.Parameters.Add(new SqlParameter("@Metal_CoursFin", metal.Metal_CoursFin));
            command.Parameters.Add(new SqlParameter("@Metal_TauxAlliage", metal.Metal_TauxAlliage));
            command.Parameters.Add(new SqlParameter("@Metal_CoefCours", metal.Metal_CoefCours));
            command.Parameters.Add(new SqlParameter("@Metal_DateCours", metal.Metal_DateCours));

            command.ExecuteNonQuery();
            command.Connection.Close();
            metal.Metal_Id = Metal_Id;
            return metal;
        }

        //update de la sous familles
        public Sous_Familles Put_Sous_Familles_Update(Sous_Familles sousFamilles, string SS_Fam_Id)
        {
            Connection_Open();
            command.CommandText = "Update Sous_Familles" +
                $" Set SS_Fam_Id = @SS_Fam_Id , SS_Fam_Lib = @SS_Fam_Lib , Familles_Id = @Familles_Id" +
                $" Where SS_Fam_Id = @SS_Fam_Id";

            command.Parameters.Add(new SqlParameter("@SS_Fam_Id", sousFamilles.SS_Fam_Id));
            command.Parameters.Add(new SqlParameter("@SS_Fam_Lib", sousFamilles.SS_Fam_Lib));
            command.Parameters.Add(new SqlParameter("@Familles_Id", sousFamilles.Familles_Id));

            command.ExecuteNonQuery();
            command.Connection.Close();
            sousFamilles.SS_Fam_Id = SS_Fam_Id;
            return sousFamilles;
        }

        //upadate de la famille complete uniquement
        public Familles Put_Familles_Update(Familles familles, string Familles_Id)
        {
            Connection_Open();
            command.CommandText = "Update Familles" +
                $" Set Familles_Id = @Familles_Id , Familles_Lib = @Familles_Lib " +
                $" Where SS_Fam_Id = @SS_Fam_Id";

            command.Parameters.Add(new SqlParameter("@Familles_Id", familles.Familles_Id));
            command.Parameters.Add(new SqlParameter("@Familles_Lib", familles.Familles_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            familles.Familles_Id = Familles_Id;
            return familles;
        }

        //update de la pierre complete uniquement
        public Pierres Put_Pierres_Update(Pierres pierres, int Pierres_Id)
        {
            Connection_Open();
            command.CommandText = "Update Pierres" +
                $" Set Pierres_Id = @Pierres_Id , Pierres_Lib = @Pierres_Lib " +
                $" Where Pierres_Id = @Pierres_Id";

            command.Parameters.Add(new SqlParameter("@Pierres_Id", pierres.Pierres_Id));
            command.Parameters.Add(new SqlParameter("@Pierres_Lib", pierres.Pierres_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            pierres.Pierres_Id = Pierres_Id;
            return pierres;
        }

        //update du type article complete uniquement
        public Type_Article Put_Type_Article_Update(Type_Article typeArticle, int Type_Art_Id)
        {
            Connection_Open();
            command.CommandText = "Update Type_Article" +
                $" Set Type_Art_Id = @Type_Art_Id , Type_Art_Lib = @Type_Art_Lib " +
                $" Where Type_Art_Id = @Type_Art_Id";

            command.Parameters.Add(new SqlParameter("@Type_Art_Id", typeArticle.Type_Art_Id));
            command.Parameters.Add(new SqlParameter("@Type_Art_Lib", typeArticle.Type_Art_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            typeArticle.Type_Art_Id = Type_Art_Id;
            return typeArticle;
        }

        //update du Genres complete uniquement
        public Genres Put_Genres_Update(Genres genres, string Genres_Id)
        {
            Connection_Open();
            command.CommandText = "Update Genres" +
                $" Set Genres_Id = @Genres_Id , Genres_Lib = @Genres_Lib " +
                $" Where Genres_Id = @Genres_Id";
           
            command.Parameters.Add(new SqlParameter("@Genres_Id", genres.Genres_Id));
            command.Parameters.Add(new SqlParameter("@Genres_Lib", genres.Genres_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            genres.Genres_Id = Genres_Id;
            return genres;
        }

        //update de l'indicatif tel complete uniquement
        public Indicatif_Tel Put_Indicatif_Tel_Update(Indicatif_Tel indicatifTel, string Ind_Tel_Pays)
        {
            Connection_Open();
            command.CommandText = "Update Indicatif_Tel" +
                $" Set Ind_Tel_Pays = @Ind_Tel_Pays , Ind_Tel_Indicatif = @Ind_Tel_Indicatif  " +
                $" Where Ind_Tel_Pays = @Ind_Tel_Pays";

            command.Parameters.Add(new SqlParameter("@Ind_Tel_Num_ID", indicatifTel.Ind_Tel_Num_ID));
            command.Parameters.Add(new SqlParameter("@Ind_Tel_Pays", indicatifTel.Ind_Tel_Pays));
            command.Parameters.Add(new SqlParameter("@Ind_Tel_Indicatif", indicatifTel.Ind_Tel_Indicatif));

            command.ExecuteNonQuery();
            command.Connection.Close();
            indicatifTel.Ind_Tel_Pays = Ind_Tel_Pays;
            return indicatifTel;
        }

        //update du compte client complete uniquement
        public Comptes_Clients Put_Comptes_Clients_Update(Comptes_Clients comptesClients, int Cptcli_Num_ID)
        {
            Connection_Open();
            command.CommandText = "Update Comptes_Clients" +
                $" Set Cptcli_Email_Id = @Cptcli_Email_Id , Cptcli_Password = @Cptcli_Password," +
                $" Cptcli_Actif = @Cptcli_Actif , Cptcli_Acces_Premium = @Cptcli_Acces_Premium," +
                $" Cptcli_Civilite = @Cptcli_Civilite , Cptcli_Nomcli = @Cptcli_Nomcli," +
                $" Cptcli_Prenom = @Cptcli_Prenom , Cptcli_Tel1 = @Cptcli_Tel1," +
                $" Cptcli_RaiSoc = @Cptcli_RaiSoc," +
                $" Cptcli_No_Siret = @Cptcli_No_Siret , Cptcli_No_TVAintra = @Cptcli_No_TVAintra," +
                $" Cptcli_Adr1 = @Cptcli_Adr1 , Cptcli_Adr2 = @Cptcli_Adr2," +
                $" Cptcli_CP = @Cptcli_CP , Cptcli_ville = @Cptcli_ville," +
                $" Cptcli_Pays = @Cptcli_Pays , Cptcli_Tel2 = @Cptcli_Tel2," +
                $" Cptcli_RefcliMB = @Cptcli_RefcliMB," +
                $" Cptcli_ComptacliMB = @Cptcli_ComptacliMB ,Cptcli_Cpteur_Devis = @Cptcli_Cpteur_Devis,Cptcli_Cle_secu = @Cptcli_Cle_secu, Cptcli_DatCre = @Cptcli_DatCre," +
                $" Cptcli_DatMaj = @Cptcli_DatMaj " +
                $" Where Cptcli_Email_Id = @Cptcli_Email_Id";

            command.Parameters.Add(new SqlParameter("@Cptcli_Num_ID", comptesClients.Cptcli_Num_ID));
            command.Parameters.Add(new SqlParameter("@Cptcli_Email_Id", comptesClients.Cptcli_Email_Id));
            command.Parameters.Add(new SqlParameter("@Cptcli_Password", comptesClients.Cptcli_Password));
            command.Parameters.Add(new SqlParameter("@Cptcli_Actif", comptesClients.Cptcli_Actif));
            command.Parameters.Add(new SqlParameter("@Cptcli_Acces_Premium", comptesClients.Cptcli_Acces_Premium));
            command.Parameters.Add(new SqlParameter("@Cptcli_Civilite", comptesClients.Cptcli_Civilite));
            command.Parameters.Add(new SqlParameter("@Cptcli_Nomcli", comptesClients.Cptcli_Nomcli));
            command.Parameters.Add(new SqlParameter("@Cptcli_Prenom", comptesClients.Cptcli_Prenom));
            command.Parameters.Add(new SqlParameter("@Cptcli_Tel1", comptesClients.Cptcli_Tel1));
            command.Parameters.Add(new SqlParameter("@Cptcli_RaiSoc", comptesClients.Cptcli_RaiSoc));
            command.Parameters.Add(new SqlParameter("@Cptcli_No_Siret", comptesClients.Cptcli_No_Siret));
            command.Parameters.Add(new SqlParameter("@Cptcli_No_TVAintra", comptesClients.Cptcli_No_TVAintra));
            command.Parameters.Add(new SqlParameter("@Cptcli_Adr1", comptesClients.Cptcli_Adr1));
            command.Parameters.Add(new SqlParameter("@Cptcli_Adr2", comptesClients.Cptcli_Adr2));
            command.Parameters.Add(new SqlParameter("@Cptcli_CP", comptesClients.Cptcli_CP));
            command.Parameters.Add(new SqlParameter("@Cptcli_ville", comptesClients.Cptcli_ville));
            command.Parameters.Add(new SqlParameter("@Cptcli_Pays", comptesClients.Cptcli_Pays));
            command.Parameters.Add(new SqlParameter("@Cptcli_Tel2", comptesClients.Cptcli_Tel2));
            command.Parameters.Add(new SqlParameter("@Cptcli_RefcliMB", comptesClients.Cptcli_RefcliMB));
            command.Parameters.Add(new SqlParameter("@Cptcli_ComptacliMB", comptesClients.Cptcli_ComptacliMB));
            command.Parameters.Add(new SqlParameter("@Cptcli_Cpteur_Devis", comptesClients.Cptcli_Cpteur_Devis));
            command.Parameters.Add(new SqlParameter("@Cptcli_Cle_secu", comptesClients.Cptcli_Cle_secu));
            command.Parameters.Add(new SqlParameter("@Cptcli_DatCre", comptesClients.Cptcli_DatCre));
            command.Parameters.Add(new SqlParameter("@Cptcli_DatMaj", comptesClients.Cptcli_DatMaj));

            command.ExecuteNonQuery();
            command.Connection.Close();
            comptesClients.Cptcli_Num_ID = Cptcli_Num_ID;
            return comptesClients;
        }

        public Comptes_Clients Put_Comptes_Clients_Validation_Update(Comptes_Clients comptesClients, string Cptcli_Cle_secu)
        {
            Connection_Open();
            command.CommandText = "Update Comptes_Clients" +
                $" Set Cptcli_Email_Id = @Cptcli_Email_Id , Cptcli_Password = @Cptcli_Password," +
                $" Cptcli_Actif = 1 , Cptcli_Acces_Premium = @Cptcli_Acces_Premium," +
                $" Cptcli_Civilite = @Cptcli_Civilite , Cptcli_Nomcli = @Cptcli_Nomcli," +
                $" Cptcli_Prenom = @Cptcli_Prenom , Cptcli_Tel1 = @Cptcli_Tel1," +
                $" Cptcli_RaiSoc = @Cptcli_RaiSoc," +
                $" Cptcli_No_Siret = @Cptcli_No_Siret , Cptcli_No_TVAintra = @Cptcli_No_TVAintra," +
                $" Cptcli_Adr1 = @Cptcli_Adr1 , Cptcli_Adr2 = @Cptcli_Adr2," +
                $" Cptcli_CP = @Cptcli_CP , Cptcli_ville = @Cptcli_ville," +
                $" Cptcli_Pays = @Cptcli_Pays , Cptcli_Tel2 = @Cptcli_Tel2," +
                $" Cptcli_RefcliMB = @Cptcli_RefcliMB," +
                $" Cptcli_ComptacliMB = @Cptcli_ComptacliMB ,Cptcli_Cpteur_Devis = @Cptcli_Cpteur_Devis, Cptcli_Cle_secu = @Cptcli_Cle_secu,Cptcli_DatCre = @Cptcli_DatCre," +
                $" Cptcli_DatMaj = @Cptcli_DatMaj " +
                $" Where Cptcli_Cle_secu = @Cptcli_Cle_secu";

            command.Parameters.Add(new SqlParameter("@Cptcli_Num_ID", comptesClients.Cptcli_Num_ID));
            command.Parameters.Add(new SqlParameter("@Cptcli_Email_Id", comptesClients.Cptcli_Email_Id));
            command.Parameters.Add(new SqlParameter("@Cptcli_Password", comptesClients.Cptcli_Password));
            //command.Parameters.Add(new SqlParameter("@Cptcli_Actif", comptesClients.Cptcli_Actif));
            command.Parameters.Add(new SqlParameter("@Cptcli_Acces_Premium", comptesClients.Cptcli_Acces_Premium));
            command.Parameters.Add(new SqlParameter("@Cptcli_Civilite", comptesClients.Cptcli_Civilite));
            command.Parameters.Add(new SqlParameter("@Cptcli_Nomcli", comptesClients.Cptcli_Nomcli));
            command.Parameters.Add(new SqlParameter("@Cptcli_Prenom", comptesClients.Cptcli_Prenom));
            command.Parameters.Add(new SqlParameter("@Cptcli_Tel1", comptesClients.Cptcli_Tel1));
            command.Parameters.Add(new SqlParameter("@Cptcli_RaiSoc", comptesClients.Cptcli_RaiSoc));
            command.Parameters.Add(new SqlParameter("@Cptcli_No_Siret", comptesClients.Cptcli_No_Siret));
            command.Parameters.Add(new SqlParameter("@Cptcli_No_TVAintra", comptesClients.Cptcli_No_TVAintra));
            command.Parameters.Add(new SqlParameter("@Cptcli_Adr1", comptesClients.Cptcli_Adr1));
            command.Parameters.Add(new SqlParameter("@Cptcli_Adr2", comptesClients.Cptcli_Adr2));
            command.Parameters.Add(new SqlParameter("@Cptcli_CP", comptesClients.Cptcli_CP));
            command.Parameters.Add(new SqlParameter("@Cptcli_ville", comptesClients.Cptcli_ville));
            command.Parameters.Add(new SqlParameter("@Cptcli_Pays", comptesClients.Cptcli_Pays));
            command.Parameters.Add(new SqlParameter("@Cptcli_Tel2", comptesClients.Cptcli_Tel2));
            command.Parameters.Add(new SqlParameter("@Cptcli_RefcliMB", comptesClients.Cptcli_RefcliMB));
            command.Parameters.Add(new SqlParameter("@Cptcli_ComptacliMB", comptesClients.Cptcli_ComptacliMB));
            command.Parameters.Add(new SqlParameter("@Cptcli_Cpteur_Devis", comptesClients.Cptcli_Cpteur_Devis));
            command.Parameters.Add(new SqlParameter("@Cptcli_Cle_secu", comptesClients.Cptcli_Cle_secu));
            command.Parameters.Add(new SqlParameter("@Cptcli_DatCre", comptesClients.Cptcli_DatCre));
            command.Parameters.Add(new SqlParameter("@Cptcli_DatMaj", comptesClients.Cptcli_DatMaj));

            command.ExecuteNonQuery();
            command.Connection.Close();
            comptesClients.Cptcli_Cle_secu = Cptcli_Cle_secu;

            return comptesClients;
        }


        //update du demande de devis complete uniquement
        public Demande_Devis Put_Demande_Devis_Update(Demande_Devis demandeDevis, int Demdev_Num_ID)
        {
            Connection_Open();
            command.CommandText = "Update Demande_Devis" +
                $" Set Cptcli_Num_ID = @Cptcli_Num_ID , Demdev_Statut = @Demdev_Statut, " +
                $" Demdev_MsgCli = @Demdev_MsgCli , Demdev_MsgMB = @Demdev_MsgMB," +
                $" Demdev_MontantHT = @Demdev_MontantHT ,Demdev_NB_Lig_Art = @Demdev_NB_Lig_Art ,Demdev_NB_Piece = @Demdev_NB_Piece " +
                $" Demdev_DatCre = @Demdev_DatCre , Demdev_DatMaj = @Demdev_DatMaj " +
                $" Where Cptcli_Num_ID = @Cptcli_Num_ID";

            command.Parameters.Add(new SqlParameter("@Demdev_Num_ID", demandeDevis.Demdev_Num_ID));
            command.Parameters.Add(new SqlParameter("@Cptcli_Num_ID", demandeDevis.Cptcli_Num_ID));
            command.Parameters.Add(new SqlParameter("@Demdev_Statut", demandeDevis.Demdev_Statut));
            command.Parameters.Add(new SqlParameter("@Demdev_MsgCli", demandeDevis.Demdev_MsgCli));
            command.Parameters.Add(new SqlParameter("@Demdev_MsgMB", demandeDevis.Demdev_MsgMB));
            command.Parameters.Add(new SqlParameter("@Demdev_MontantHT", demandeDevis.Demdev_MontantHT));
            //command.Parameters.Add(new SqlParameter("@Demdev_NB_Lig_Art", demandeDevis.Demdev_NB_Lig_Art));
            //command.Parameters.Add(new SqlParameter("@Demdev_NB_Piece", demandeDevis.Demdev_NB_Piece));
            command.Parameters.Add(new SqlParameter("@Demdev_DatCre", demandeDevis.Demdev_DatCre));
            command.Parameters.Add(new SqlParameter("@Demdev_DatMaj", demandeDevis.Demdev_DatMaj));

            command.ExecuteNonQuery();
            command.Connection.Close();
            demandeDevis.Demdev_Num_ID = Demdev_Num_ID;
            return demandeDevis;
        }

        //update de la ligne de demande de devis complete uniquement
        public Lignes_Demande_Devis Put_Lignes_Demande_Devis_Update(Lignes_Demande_Devis lignesDemandeDevis, int Ligdev_Num_ID)
        {
            Connection_Open();
            command.CommandText = "Update Lignes_Demande_Devis" +
                $" Set Demdev_Num_ID = @Demdev_Num_ID , Art_Num_ID = @Art_Num_ID, " +
                $" Art_Ref = @Art_Ref , Ligdev_Qte = @Ligdev_Qte ,Ligdev_Poids_TH = @Ligdev_Poids_TH ,Ligdev_Prix_HT = @Ligdev_Prix_HT" +
                $" Ligdev_MsgCli = @Ligdev_MsgCli ,Ligdev_PrixVteHT = @Ligdev_PrixVteHT " +
                $" Where Demdev_Num_ID = @Demdev_Num_ID";
         
            command.Parameters.Add(new SqlParameter("@Ligdev_Num_ID", lignesDemandeDevis.Ligdev_Num_ID));
            command.Parameters.Add(new SqlParameter("@Demdev_Num_ID", lignesDemandeDevis.Demdev_Num_ID));
            command.Parameters.Add(new SqlParameter("@Art_Num_ID", lignesDemandeDevis.Art_Num_ID));
            command.Parameters.Add(new SqlParameter("@Art_Ref", lignesDemandeDevis.Art_Ref));
            command.Parameters.Add(new SqlParameter("@Ligdev_Qte", lignesDemandeDevis.Ligdev_Qte));
            command.Parameters.Add(new SqlParameter("@Ligdev_Poids_TH", lignesDemandeDevis.Ligdev_Poids_TH));
            command.Parameters.Add(new SqlParameter("@Ligdev_Prix_HT", lignesDemandeDevis.Ligdev_Prix_HT));
            command.Parameters.Add(new SqlParameter("@Ligdev_MsgCli", lignesDemandeDevis.Ligdev_MsgCli));
            command.Parameters.Add(new SqlParameter("@Ligdev_PrixVteHT", lignesDemandeDevis.Ligdev_PrixVteHT));

            command.ExecuteNonQuery();
            command.Connection.Close();
            lignesDemandeDevis.Ligdev_Num_ID = Ligdev_Num_ID;
            return lignesDemandeDevis;
        }

        //update de la collection complete uniquement
        public Collections Put_Collections_Update(Collections collections, int Collections_Id)
        {
            Connection_Open();
            command.CommandText = "Update Collections" +
                $" Set Collections_Lib = @Collections_Lib " +
                $" Where Collections_Id = @Collections_Id";

            command.Parameters.Add(new SqlParameter("@Collections_Id", collections.Collections_Id));
            command.Parameters.Add(new SqlParameter("@Collections_Lib", collections.Collections_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            collections.Collections_Id = Collections_Id;
            return collections;
        }

        //update de la collection articles complete uniquement  pas besion
        public Col_Art Put_Col_Art_Update(Col_Art colArt, int Collections_Id)
        {
            Connection_Open();
            command.CommandText = "Update Col_Art" +
                $" Set Art_Num_ID = @Art_Num_ID " +
                $" Where Collections_Id = @Collections_Id";

            command.Parameters.Add(new SqlParameter("@Collections_Id", colArt.Collections_Id));
            command.Parameters.Add(new SqlParameter("@Art_Num_ID", colArt.Art_Num_ID));

            command.ExecuteNonQuery();
            command.Connection.Close();
            colArt.Collections_Id = Collections_Id;
            return colArt;
        }

        //update des parametres complete uniquement
        public Parametres Put_Parametres_Update(Parametres parametres, int Param_Num_ID)
        {
            Connection_Open();
            command.CommandText = "Update Parametres" +
                $" Set Param_RaiSoc = @Param_RaiSoc ,  Param_Email_Soc = @Param_Email_Soc ,  Param_Chemin_Photos = @Param_Chemin_Photos " +
                $" Where Param_Num_ID = @Param_Num_ID";

            command.Parameters.Add(new SqlParameter("@Param_Num_ID", parametres.Param_Num_ID));
            command.Parameters.Add(new SqlParameter("@Param_RaiSoc", parametres.Param_RaiSoc));
            command.Parameters.Add(new SqlParameter("@Param_Email_Soc", parametres.Param_Email_Soc));
            command.Parameters.Add(new SqlParameter("@Param_Chemin_Photos", parametres.Param_Chemin_Photos));

            command.ExecuteNonQuery();
            command.Connection.Close();
            parametres.Param_Num_ID = Param_Num_ID;
            return parametres;
        }


        //update de la Colors complete uniquement
        public Colors Put_Colors_Update(Colors colors, string Colors_Id)
        {
            Connection_Open();
            command.CommandText = "Update Colors" +
                $" Set Colors_Id = @Colors_Id , Colors_Lib = @Colors_Lib " +
                $" Where Colors_Id = @Colors_Id";

            command.Parameters.Add(new SqlParameter("@Colors_Id", colors.Colors_Id));
            command.Parameters.Add(new SqlParameter("@Colors_Lib", colors.Colors_Lib));

            command.ExecuteNonQuery();
            command.Connection.Close();
            colors.Colors_Id = Colors_Id;
            return colors;
        }
    }
}