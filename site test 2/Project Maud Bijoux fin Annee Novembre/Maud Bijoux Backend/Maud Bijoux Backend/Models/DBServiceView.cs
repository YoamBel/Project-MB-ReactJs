using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maud_Bijoux_Backend.Models
{
    public class DBServiceView
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["LIVEDNSfromLivedns"].ConnectionString;
        readonly string conStrLocal = ConfigurationManager.ConnectionStrings["LIVEDNSfromLocal"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        bool local = false;

        // Liste de chaque tables

        //liste Article avec famille + sous Familles
        readonly List<Articles> listeArticles = new List<Articles>();

        //liste des bague + sous bagues
        readonly List<Articles> listeArticlesBagues = new List<Articles>();

        readonly List<Articles> listeArticlesBaguesAlliances = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAllianceHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAlliancesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAllianceEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAlliancesMix = new List<Articles>();

        readonly List<Articles> listeArticlesBaguesAutresBagues = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAutresBaguesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAutresBaguesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAutresBaguesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesAutresBaguesMix = new List<Articles>();


        readonly List<Articles> listeArticlesBaguesChevalieres = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesChevalieresHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesChevalieresFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesChevalieresEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesChevalieresMix = new List<Articles>();

        readonly List<Articles> listeArticlesBaguesSolitaires = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesSolitairesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesSolitairesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesSolitairesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBaguesSolitairesMix = new List<Articles>();




        // liste boucle oreilles + sous boucle oreille
        readonly List<Articles> listeArticlesBoucleDoreilles = new List<Articles>();

        readonly List<Articles> listeArticlesBoucleDoreillesAutresBouclesDOreilles = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesAutresBouclesDOreillesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesAutresBouclesDOreillesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesAutresBouclesDOreillesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesAutresBouclesDOreillesMix = new List<Articles>();

        readonly List<Articles> listeArticlesBoucleDoreillesPendantes = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPendantesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPendantesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPendantesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPendantesMix = new List<Articles>();

        readonly List<Articles> listeArticlesBoucleDoreillesCreoles = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesCreolesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesCreolesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesCreolesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesCreolesMix = new List<Articles>();

        readonly List<Articles> listeArticlesBoucleDoreillesPuces = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPucesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPucesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPucesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBoucleDoreillesPucesMix = new List<Articles>();

        // liste des bracelet + sous bracelets
        readonly List<Articles> listeArticlesBracelets = new List<Articles>();


        readonly List<Articles> listeArticlesBraceletsAutresBracelets= new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsAutresBraceletsHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsAutresBraceletsFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsAutresBraceletsEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsAutresBraceletsMix = new List<Articles>();

        readonly List<Articles> listeArticlesBraceletsBraceletsIdentite = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsIdentiteHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsIdentiteFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsIdentiteEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsIdentiteMix = new List<Articles>();

        readonly List<Articles> listeArticlesBraceletsBraceletsRigides = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsRigidesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsRigidesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsRigidesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesBraceletsBraceletsRigidesMix = new List<Articles>();

        // liste collier + sous collier
        readonly List<Articles> listeArticlesColliersEtChaines = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesMix = new List<Articles>();

        readonly List<Articles> listeArticlesColliersEtChainesAutresChaines= new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesAutresChainesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesAutresChainesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesAutresChainesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesAutresChainesMix = new List<Articles>();

        readonly List<Articles> listeArticlesColliersEtChainesChainesFines = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesChainesFinesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesChainesFinesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesChainesFinesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesChainesFinesMix = new List<Articles>();

        readonly List<Articles> listeArticlesColliersEtChainesColliers = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesColliersHomme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesColliersFemme = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesColliersEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesColliersEtChainesColliersMix = new List<Articles>();

        // liste parure + sous parures
        readonly List<Articles> listeArticlesParures = new List<Articles>();
        readonly List<Articles> listeArticlesParuresHomme = new List<Articles>();
        readonly List<Articles> listeArticlesParuresFemme = new List<Articles>();
        readonly List<Articles> listeArticlesParuresEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesParuresMix = new List<Articles>();

        //liste pendentif + sous pendentif
        readonly List<Articles> listeArticlesPendentifs = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsMix = new List<Articles>();

        readonly List<Articles> listeArticlesPendentifsAutresPendentifs = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsAutresPendentifsHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsAutresPendentifsFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsAutresPendentifsEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsAutresPendentifsMix = new List<Articles>();

        readonly List<Articles> listeArticlesPendentifsPendentifsReligieux = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsReligieuxHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsReligieuxFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsReligieuxEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsReligieuxMix = new List<Articles>();

        readonly List<Articles> listeArticlesPendentifsPendentifsPlaques = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsPlaquesHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsPlaquesFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsPlaquesEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPendentifsPendentifsPlaquesMix = new List<Articles>();

        //liste piercings + sous piercings
        readonly List<Articles> listeArticlesPiercings = new List<Articles>();

        readonly List<Articles> listeArticlesPiercingsPiercingsNez = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsNezHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsNezFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsNezEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsNezMix = new List<Articles>();

        readonly List<Articles> listeArticlesPiercingsPiercingsDivers = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsDiversHomme = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsDiversFemme = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsDiversEnfant = new List<Articles>();
        readonly List<Articles> listeArticlesPiercingsPiercingsDiversMix = new List<Articles>();


        readonly List<Metal> listeMetal = new List<Metal>();
        readonly List<Sous_Familles> listeSousFamilles = new List<Sous_Familles>();
        readonly List<Familles> listeFamilles = new List<Familles>();
        readonly List<Pierres> listePierres = new List<Pierres>();
        readonly List<Type_Article> listeTypeArticle = new List<Type_Article>();
        readonly List<Genres> listeGenres = new List<Genres>();
        readonly List<Indicatif_Tel> listeIndicatifTel = new List<Indicatif_Tel>();
        readonly List<Comptes_Clients> listeComptesClients = new List<Comptes_Clients>();
        readonly List<Comptes_Clients> listeComptesClientsUnique = new List<Comptes_Clients>();
        readonly List<Demande_Devis> listeDemandeDevis = new List<Demande_Devis>();
        readonly List<Lignes_Demande_Devis> listeLignesDemandeDevis = new List<Lignes_Demande_Devis>();
        readonly List<Collections> listeCollections = new List<Collections>();
        readonly List<Col_Art> listeColArt = new List<Col_Art>();
        readonly List<Parametres> listeParametres = new List<Parametres>();
        readonly List<Colors> listeColors = new List<Colors>();





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



        //Affichage de l'article complete uniquement
        public List<Articles> Get_Articles_View()
        {
            Connection_Open();
            command.CommandText = "select * from Articles";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticles.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticles;
        }





        //Affichage Bagues
        public List<Articles> Get_Articles_View_Bagues()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='BG'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBagues.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBagues;
        }

        //Affichage Alliance
        public List<Articles> Get_Articles_View_Bagues_Alliances()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='ALL'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAlliances.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAlliances;
        }

        //Affichage Alliance homme
        public List<Articles> Get_Articles_View_Bagues_Alliances_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='ALL' and Genres_Id = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAllianceHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAllianceHomme;
        }

        //Affichage Alliance femme
        public List<Articles> Get_Articles_View_Bagues_Alliances_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='ALL' and Genres_Id = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAlliancesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAlliancesFemme;
        }

        //Affichage Alliance Enfant
        public List<Articles> Get_Articles_View_Bagues_Alliances_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='ALL' and Genres_Id = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAllianceEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAllianceEnfant;
        }

        //Affichage Alliance Mix
        public List<Articles> Get_Articles_View_Bagues_Alliances_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='ALL' and Genres_Id = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAlliancesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAlliancesMix;
        }



        //Affichage autres bagues
        public List<Articles> Get_Articles_View_Bagues_Autres_Bagues()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BGDIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAutresBagues.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAutresBagues;
        }

        //Affichage autres bagues Homme
        public List<Articles> Get_Articles_View_Bagues_Autres_Bagues_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BGDIV' and Genres_Id = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAutresBaguesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAutresBaguesHomme;
        }

        //Affichage autres bagues femme
        public List<Articles> Get_Articles_View_Bagues_Autres_Bagues_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BGDIV' and Genres_Id = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAutresBaguesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAutresBaguesFemme;
        }

        //Affichage autres bagues enfant
        public List<Articles> Get_Articles_View_Bagues_Autres_Bagues_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BGDIV' and Genres_Id = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAutresBaguesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAutresBaguesEnfant;
        }

        //Affichage autres bagues mix
        public List<Articles> Get_Articles_View_Bagues_Autres_Bagues_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BGDIV' and Genres_Id = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesAutresBaguesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesAutresBaguesMix;
        }



        //Affichage chevalieres
        public List<Articles> Get_Articles_View_Bagues_Chevalieres()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesChevalieres.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesChevalieres;
        }
        //Affichage chevalieres homme
        public List<Articles> Get_Articles_View_Bagues_Chevalieres_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHV' and Genres_Id = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesChevalieresHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesChevalieresHomme;
        }
        //Affichage chevalieres femme
        public List<Articles> Get_Articles_View_Bagues_Chevalieres_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHV' and Genres_Id = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesChevalieresFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesChevalieresFemme;
        }
        //Affichage chevalieres enfant
        public List<Articles> Get_Articles_View_Bagues_Chevalieres_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHV' and Genres_Id = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesChevalieresEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesChevalieresEnfant;
        }
        //Affichage chevalieres mix
        public List<Articles> Get_Articles_View_Bagues_Chevalieres_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHV' and Genres_Id = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesChevalieresMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesChevalieresMix;
        }




        //Affichage Solitaire
        public List<Articles> Get_Articles_View_Bagues_Solitaires()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='SOL'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesSolitaires.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesSolitaires;
        }
        //Affichage Solitaire homme
        public List<Articles> Get_Articles_View_Bagues_Solitaires_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='SOL' and Genres_Id = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesSolitairesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesSolitairesHomme;
        }
        //Affichage Solitaire
        public List<Articles> Get_Articles_View_Bagues_Solitaires_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='SOL' and Genres_Id = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesSolitairesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesSolitairesFemme;
        }
        //Affichage Solitaire
        public List<Articles> Get_Articles_View_Bagues_Solitaires_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='SOL' and Genres_Id = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesSolitairesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesSolitairesEnfant;
        }
        //Affichage Solitaire
        public List<Articles> Get_Articles_View_Bagues_Solitaires_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='SOL' and Genres_Id = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBaguesSolitairesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBaguesSolitairesMix;
        }












        //Affichage Boucle oreilles
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='BO'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreilles.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreilles;
        }



        //Affichage autre boucle oreilles
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BODIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesAutresBouclesDOreilles.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesAutresBouclesDOreilles;
        }
        //Affichage autre boucle oreilles homme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BODIV' and Genres_Id = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesAutresBouclesDOreillesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesAutresBouclesDOreillesHomme;
        }
        //Affichage autre boucle oreilles Femme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BODIV' and Genres_Id = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesAutresBouclesDOreillesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesAutresBouclesDOreillesFemme;
        }
        //Affichage autre boucle oreilles enfant
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BODIV' and Genres_Id = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesAutresBouclesDOreillesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesAutresBouclesDOreillesEnfant;
        }
        //Affichage autre boucle oreilles mix
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BODIV' and Genres_Id = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesAutresBouclesDOreillesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesAutresBouclesDOreillesMix;
        }


        //Affichage  pendentes
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Pendentes()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BOPEN'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPendantes.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPendantes;
        }
        //Affichage  pendentes homme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Pendentes_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BOPEN' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPendantesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPendantesHomme;
        }
        //Affichage  pendentes femme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Pendentes_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BOPEN' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPendantesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPendantesFemme;
        }
        //Affichage  pendentes enfant
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Pendentes_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BOPEN' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPendantesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPendantesEnfant;
        }
        //Affichage  pendentes mix
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Pendentes_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BOPEN' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPendantesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPendantesMix;
        }




        //Affichage puces
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Puces()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PUCE'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPuces.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPuces;
        }
        //Affichage puces homme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Puces_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PUCE' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPucesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPucesHomme;
        }
        //Affichage puces femme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Puces_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PUCE' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPucesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPucesFemme;
        }
        //Affichage puces enfant
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Puces_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PUCE' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPucesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPucesEnfant;
        }
        //Affichage puces mix
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Puces_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PUCE' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesPucesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesPucesMix;
        }



        //Affichage creole
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Creoles()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CREO'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesCreoles.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesCreoles;
        }
        //Affichage creole HOMME
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Creoles_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CREO' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesCreolesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesCreolesHomme;
        }
        //Affichage creole femme
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Creoles_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CREO' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesCreolesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesCreolesFemme;
        }
        //Affichage creole enfant
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Creoles_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CREO' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesCreolesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesCreolesEnfant;
        }
        //Affichage creole mix
        public List<Articles> Get_Articles_View_Boucle_D_Oreilles_Creoles_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CREO' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBoucleDoreillesCreolesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBoucleDoreillesCreolesMix;
        }






        //Affichage des bracelets
        public List<Articles> Get_Articles_View_Bracelets()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='BR'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBracelets.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBracelets;
        }

        //Affichage des autres bracelets 
        public List<Articles> Get_Articles_View_Bracelets_Autres_Bracelets()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRDIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsAutresBracelets.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsAutresBracelets;
        }
        //Affichage des autres bracelets homme
        public List<Articles> Get_Articles_View_Bracelets_Autres_Bracelets_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRDIV' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsAutresBraceletsHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsAutresBraceletsHomme;
        }
        //Affichage des autres bracelets femme
        public List<Articles> Get_Articles_View_Bracelets_Autres_Bracelets_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRDIV' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsAutresBraceletsFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsAutresBraceletsFemme;
        }
        //Affichage des autres bracelets enfant
        public List<Articles> Get_Articles_View_Bracelets_Autres_Bracelets_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRDIV' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsAutresBraceletsEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsAutresBraceletsEnfant;
        }
        //Affichage des autres bracelets mix
        public List<Articles> Get_Articles_View_Bracelets_Autres_Bracelets_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRDIV' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsAutresBraceletsMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsAutresBraceletsMix;
        }

        //Affichage des bracelets identite
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Identite()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRID'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsIdentite.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsIdentite;
        }
        //Affichage des bracelets identite homme
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Identite_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRID' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsIdentiteHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsIdentiteHomme;
        }
        //Affichage des bracelets identite femme
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Identite_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRID' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsIdentiteFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsIdentiteFemme;
        }
        //Affichage des bracelets identite enfant
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Identite_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRID' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsIdentiteEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsIdentiteEnfant;
        }
        //Affichage des bracelets identite mix
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Identite_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRID' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsIdentiteMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsIdentiteMix;
        }

        //Affichage des bracelets rigides
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Rigides()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRRGD'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsRigides.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsRigides;
        }
        //Affichage des bracelets rigides homme
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Rigides_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRRGD' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsRigidesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsRigidesHomme;
        }
        //Affichage des bracelets rigides femme
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Rigides_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRRGD' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsRigidesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsRigidesFemme;
        }
        //Affichage des bracelets rigides enfant
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Rigides_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRRGD' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsRigidesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsRigidesEnfant;
        }
        //Affichage des bracelets rigides mix
        public List<Articles> Get_Articles_View_Bracelets_Bracelets_Rigides_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='BRRGD' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesBraceletsBraceletsRigidesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesBraceletsBraceletsRigidesMix;
        }







        //Affichage des collier et chaine
        public List<Articles> Get_Articles_View_Colliers_Chaines()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='CO'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChaines.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChaines;
        }
        //Affichage des collier et chaine homme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='CO' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesHomme;
        }
        //Affichage des collier et chaine femme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='CO' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesFemme;
        }
        //Affichage des collier et chaine enfant
        public List<Articles> Get_Articles_View_Colliers_Chaines_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='CO' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesEnfant;
        }
        //Affichage des collier et chaine mix
        public List<Articles> Get_Articles_View_Colliers_Chaines_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='CO' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesMix;
        }


        //Affichage des chaine fine
        public List<Articles> Get_Articles_View_Colliers_Chaines_Chaine_Fine()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHFIN'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesChainesFines.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesChainesFines;
        }
        //Affichage des chaine fine homme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Chaine_Fine_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHFIN' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesChainesFinesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesChainesFinesHomme;
        }
        //Affichage des chaine fine femme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Chaine_Fine_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHFIN' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesChainesFinesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesChainesFinesFemme;
        }
        //Affichage des chaine fine enfant
        public List<Articles> Get_Articles_View_Colliers_Chaines_Chaine_Fine_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHFIN' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesChainesFinesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesChainesFinesEnfant;
        }
        //Affichage des chaine fine mix
        public List<Articles> Get_Articles_View_Colliers_Chaines_Chaine_Fine_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHFIN' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesChainesFinesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesChainesFinesMix;
        }

        //Affichage des collier
        public List<Articles> Get_Articles_View_Colliers_Chaines_Colliers()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CO'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesColliers.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesColliers;
        }
        //Affichage des collier homme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Colliers_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CO' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesColliersHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesColliersHomme;
        }
        //Affichage des collier femme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Colliers_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CO' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesColliersFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesColliersFemme;
        }
        //Affichage des collier enfant
        public List<Articles> Get_Articles_View_Colliers_Chaines_Colliers_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CO' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesColliersEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesColliersEnfant;
        }
        //Affichage des collier mix
        public List<Articles> Get_Articles_View_Colliers_Chaines_Colliers_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CO' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesColliersMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesColliersMix;
        }

        //Affichage des autre chaine
        public List<Articles> Get_Articles_View_Colliers_Chaines_Autre_Chaines()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHDIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesAutresChaines.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesAutresChaines;
        }
        //Affichage des autre chaine homme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Autre_Chaines_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHDIV' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesAutresChainesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesAutresChainesHomme;
        }
        //Affichage des autre chaine femme
        public List<Articles> Get_Articles_View_Colliers_Chaines_Autre_Chaines_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHDIV'and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesAutresChainesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesAutresChainesFemme;
        }
        //Affichage des autre chaine enfant
        public List<Articles> Get_Articles_View_Colliers_Chaines_Autre_Chaines_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHDIV'and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesAutresChainesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesAutresChainesEnfant;
        }
        //Affichage des autre chaine mix
        public List<Articles> Get_Articles_View_Colliers_Chaines_Autre_Chaines_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='CHDIV'and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesColliersEtChainesAutresChainesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesColliersEtChainesAutresChainesMix;
        }






        //Affichage des parures
        public List<Articles> Get_Articles_View_Parures()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PAR'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesParures.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesParures;
        }
        //Affichage des parures homme
        public List<Articles> Get_Articles_View_Parures_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PAR' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesParuresHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesParuresHomme;
        }
        //Affichage des parures femme
        public List<Articles> Get_Articles_View_Parures_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PAR' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesParuresFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesParuresFemme;
        }
        //Affichage des parures enfant
        public List<Articles> Get_Articles_View_Parures_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PAR' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesParuresEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesParuresEnfant;
        }
        //Affichage des parures mix
        public List<Articles> Get_Articles_View_Parures_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PAR' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesParuresMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesParuresMix;
        }






        //Affichage des pendentif
        public List<Articles> Get_Articles_View_Pendentifs()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PDT'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifs.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifs;
        }



        //Affichage des pendentif religieux
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Religieux()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTRG'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsReligieux.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsReligieux;
        }
        //Affichage des pendentif religieux homme
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Religieux_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTRG' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsReligieuxHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsReligieuxHomme;
        }
        //Affichage des pendentif religieux femme
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Religieux_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTRG' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsReligieuxFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsReligieuxFemme;
        }
        //Affichage des pendentif religieux enfant
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Religieux_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTRG' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsReligieuxEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsReligieuxEnfant;
        }
        //Affichage des pendentif religieux mix
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Religieux_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTRG' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsReligieuxMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsReligieuxMix;
        }



        //Affichage des autres pendentif 
        public List<Articles> Get_Articles_View_Pendentifs_Autres_Pendentifs()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTDIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsAutresPendentifs.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsAutresPendentifs;
        }
        //Affichage des autres pendentif homme
        public List<Articles> Get_Articles_View_Pendentifs_Autres_Pendentifs_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTDIV' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsAutresPendentifsHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsAutresPendentifsHomme;
        }
        //Affichage des autres pendentif femme
        public List<Articles> Get_Articles_View_Pendentifs_Autres_Pendentifs_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTDIV' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsAutresPendentifsFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsAutresPendentifsFemme;
        }
        //Affichage des autres pendentif enfant
        public List<Articles> Get_Articles_View_Pendentifs_Autres_Pendentifs_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTDIV' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsAutresPendentifsEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsAutresPendentifsEnfant;
        }
        //Affichage des autres pendentif mix
        public List<Articles> Get_Articles_View_Pendentifs_Autres_Pendentifs_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PDTDIV' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsAutresPendentifsMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsAutresPendentifsMix;
        }



        //Affichage des pendentif plaques
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Plaques()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PLQ'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsPlaques.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsPlaques;
        }
        //Affichage des pendentif plaques homme
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Plaques_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PLQ' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsPlaquesHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsPlaquesHomme;
        }
        //Affichage des pendentif plaques femme
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Plaques_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PLQ' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsPlaquesFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsPlaquesFemme;
        }
        //Affichage des pendentif plaques enfant
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Plaques_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PLQ' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsPlaquesEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsPlaquesEnfant;
        }
        //Affichage des pendentif plaques mix
        public List<Articles> Get_Articles_View_Pendentifs_Pendentifs_Plaques_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PLQ' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPendentifsPendentifsPlaquesMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPendentifsPendentifsPlaquesMix;
        }







        //Affichage des piercing
        public List<Articles> Get_Articles_View_Percings()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  Familles_Id='PG'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercings.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercings;
        }

        //Affichage des piercing nez 
        public List<Articles> Get_Articles_View_Percings_Piercings_Nez()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGNEZ'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsNez.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsNez;
        }
        //Affichage des piercing nez homme
        public List<Articles> Get_Articles_View_Percings_Piercings_Nez_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGNEZ' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsNezHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsNezHomme;
        }
        //Affichage des piercing nez femme
        public List<Articles> Get_Articles_View_Percings_Piercings_Nez_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGNEZ' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsNezFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsNezFemme;
        }
        //Affichage des piercing nez enfant
        public List<Articles> Get_Articles_View_Percings_Piercings_Nez_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGNEZ' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsNezEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsNezEnfant;
        }
        //Affichage des piercing nez mix
        public List<Articles> Get_Articles_View_Percings_Piercings_Nez_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGNEZ' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsNezMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsNezMix;
        }

        //Affichage des piercing divers
        public List<Articles> Get_Articles_View_Percings_Piercings_Divers()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGDIV'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsDivers.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsDivers;
        }
        //Affichage des piercing divers homme
        public List<Articles> Get_Articles_View_Percings_Piercings_Divers_Homme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGDIV' and Genres_Id  = 'H'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsDiversHomme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsDiversHomme;
        }
        //Affichage des piercing divers femme
        public List<Articles> Get_Articles_View_Percings_Piercings_Divers_Femme()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGDIV' and Genres_Id  = 'F'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsDiversFemme.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsDiversFemme;
        }
        //Affichage des piercing divers enfant
        public List<Articles> Get_Articles_View_Percings_Piercings_Divers_Enfant()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGDIV' and Genres_Id  = 'E'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsDiversEnfant.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsDiversEnfant;
        }
        //Affichage des piercing divers mix
        public List<Articles> Get_Articles_View_Percings_Piercings_Divers_Mix()
        {
            Connection_Open();
            command.CommandText = "select * from Articles where  SS_Fam_Id='PGDIV' and Genres_Id  = 'M'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeArticlesPiercingsPiercingsDiversMix.Add(new Articles(
                    Convert.ToInt32(reader["Art_Num_ID"]), (string)reader["Art_Ref"],
                    (string)reader["Art_Libelle"], (string)reader["Art_Description"],
                    Convert.ToInt32(reader["Art_Premium"]), (string)reader["Familles_Id"], (string)reader["SS_Fam_Id"],
                    (string)reader["Genres_Id"], Convert.ToInt32(reader["Pierres_Id"]),
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Colors_Id"], Convert.ToInt32(reader["Type_Art_Id"]),
                    Convert.ToInt32(reader["Art_Poids"]), Convert.ToInt32(reader["Art_PxVte_PubHT"]),
                     Convert.ToInt32(reader["Art_PxVte_GrosHT"]), Convert.ToInt32(reader["Art_PxVte_Facon"]), (string)reader["Art_Fic_Img1"],
                    (string)reader["Art_Fic_Img2"], (string)reader["Art_Fic_Img3"],
                    Convert.ToDateTime(reader["Art_DatCre"]), Convert.ToDateTime(reader["Art_DatMaj"])));
            }

            connection.Close();
            return listeArticlesPiercingsPiercingsDiversMix;
        }









        //Affichage du Metal complet uniquement
        public List<Metal> Get_Metal_View()
        {
            Connection_Open();
            command.CommandText = "select * from Metal";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeMetal.Add(new Metal(
                    Convert.ToInt32(reader["Metal_Id"]), (string)reader["Metal_Lib"], 
                    Convert.ToInt32(reader["Metal_Cours"]), Convert.ToInt32(reader["Metal_CoursFin"]),
                    Convert.ToInt32(reader["Metal_TauxAlliage"]), Convert.ToInt32(reader["Metal_CoefCours"]),
                    Convert.ToDateTime(reader["Metal_DateCours"])));
            }
            connection.Close();
            return listeMetal;
        }


        //Affichage de la sous Familles complet uniquement
        public List<Sous_Familles> Get_Sous_Familles_View()
        {
            Connection_Open();
            command.CommandText = "select * from Sous_Familles";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeSousFamilles.Add(new Sous_Familles(
                    (string)reader["SS_Fam_Id"], (string)reader["SS_Fam_Lib"], (string)reader["Familles_Id"]));
            }
            connection.Close();
            return listeSousFamilles;
        }


        //Affichage de la Familles complet uniquement
        public List<Familles> Get_Familles_View()
        {
            Connection_Open();
            command.CommandText = "select * from Familles";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeFamilles.Add(new Familles(
                    (string)reader["Familles_Id"], (string)reader["Familles_Lib"]));
            }
            connection.Close();
            return listeFamilles;
        }


        //Affichage de la Pierre complet uniquement
        public List<Pierres> Get_Pierres_View()
        {
            Connection_Open();
            command.CommandText = "select * from Pierres";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listePierres.Add(new Pierres(
                     Convert.ToInt32(reader["Pierres_Id"]), (string)reader["Pierres_Lib"]));
            }
            connection.Close();
            return listePierres;
        }


        //Affichage du Type de Article complet uniquement
        public List<Type_Article> Get_Type_Article_View()
        {
            Connection_Open();
            command.CommandText = "select * from Type_Article";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeTypeArticle.Add(new Type_Article(
                    Convert.ToInt32(reader["Type_Art_Id"]), (string)reader["Type_Art_Lib"]));
            }
            connection.Close();
            return listeTypeArticle;
        }


        //Affichage du genre complet uniquement
        public List<Genres> Get_Genres_View()
        {
            Connection_Open();
            command.CommandText = "select * from Genres";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeGenres.Add(new Genres(
                    (string)reader["Genres_Id"], (string)reader["Genres_Lib"]));
            }
            connection.Close();
            return listeGenres;
        }


        //Affichage de l'indicatif tel complet uniquement
        public List<Indicatif_Tel> Get_Indicatif_Tel_View()
        {
            Connection_Open();
            command.CommandText = "select * from Indicatif_Tel";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeIndicatifTel.Add(new Indicatif_Tel(
                     Convert.ToInt32(reader["Ind_Tel_Num_ID"]), (string)reader["Ind_Tel_Pays"], (string)reader["Ind_Tel_Indicatif"]));
            }
            connection.Close();
            return listeIndicatifTel;
        }


        //Affichage du compte client complet uniquement
        public List<Comptes_Clients> Get_Comptes_Clients_View()
        {
            Connection_Open();
            command.CommandText = "select * from Comptes_Clients";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeComptesClients.Add(new Comptes_Clients(Convert.ToInt32(reader["Cptcli_Num_ID"]), (string)reader["Cptcli_Email_Id"],
                     (string)reader["Cptcli_Password"], Convert.ToInt32(reader["Cptcli_Actif"]), Convert.ToInt32(reader["Cptcli_Acces_Premium"]),
                      (string)reader["Cptcli_Civilite"], (string)reader["Cptcli_Nomcli"], (string)reader["Cptcli_Prenom"],
                      (string)reader["Cptcli_Tel1"], (string)reader["Cptcli_RaiSoc"],
                      (string)reader["Cptcli_No_Siret"], (string)reader["Cptcli_No_TVAintra"], (string)reader["Cptcli_Adr1"],
                      (string)reader["Cptcli_Adr2"], (string)reader["Cptcli_CP"], (string)reader["Cptcli_ville"],
                      (string)reader["Cptcli_Pays"], (string)reader["Cptcli_Tel2"],
                      (string)reader["Cptcli_RefcliMB"], (string)reader["Cptcli_ComptacliMB"], 
                      Convert.ToInt32(reader["Cptcli_Cpteur_Devis"]), (string)reader["Cptcli_Cle_secu"], Convert.ToDateTime(reader["Cptcli_DatCre"]), Convert.ToDateTime(reader["Cptcli_DatMaj"])));
            }
            connection.Close();
            return listeComptesClients;
        }
         
        //Affichage un seul compte client complet uniquement
        public List<Comptes_Clients> Get_Comptes_Clients__Unique_View(string Cptcli_Cle_secu)
        {
            Connection_Open();
            command.CommandText = $"select * from Comptes_Clients Where Cptcli_Cle_secu = '{Cptcli_Cle_secu}'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeComptesClientsUnique.Add(new Comptes_Clients(Convert.ToInt32(reader["Cptcli_Num_ID"]), (string)reader["Cptcli_Email_Id"],
                     (string)reader["Cptcli_Password"], Convert.ToInt32(reader["Cptcli_Actif"]), Convert.ToInt32(reader["Cptcli_Acces_Premium"]),
                      (string)reader["Cptcli_Civilite"], (string)reader["Cptcli_Nomcli"], (string)reader["Cptcli_Prenom"],
                      (string)reader["Cptcli_Tel1"], (string)reader["Cptcli_RaiSoc"],
                      (string)reader["Cptcli_No_Siret"], (string)reader["Cptcli_No_TVAintra"], (string)reader["Cptcli_Adr1"],
                      (string)reader["Cptcli_Adr2"], (string)reader["Cptcli_CP"], (string)reader["Cptcli_ville"],
                      (string)reader["Cptcli_Pays"], (string)reader["Cptcli_Tel2"],
                      (string)reader["Cptcli_RefcliMB"], (string)reader["Cptcli_ComptacliMB"],
                      Convert.ToInt32(reader["Cptcli_Cpteur_Devis"]), (string)reader["Cptcli_Cle_secu"], Convert.ToDateTime(reader["Cptcli_DatCre"]), Convert.ToDateTime(reader["Cptcli_DatMaj"])));
            }
            connection.Close();
            return listeComptesClientsUnique;
        }

        //Affichage de la demande de devis complet uniquement
        public List<Demande_Devis> Get_Demande_Devis_View()
        {
            Connection_Open();
            command.CommandText = "select * from Demande_Devis";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeDemandeDevis.Add(new Demande_Devis(
                     Convert.ToInt32(reader["Demdev_Num_ID"]), Convert.ToInt32(reader["Cptcli_Num_ID"]),(string)reader["Demdev_Statut"], 
                     (string)reader["Demdev_MsgCli"], (string)reader["Demdev_MsgMB"], Convert.ToInt32(reader["Demdev_MontantHT"]),
                      Convert.ToInt32(reader["Demdev_NB_Lig_Art"]), Convert.ToInt32(reader["Demdev_NB_Piece"]), Convert.ToInt32(reader["Demdev_NB_Ligne"]), Convert.ToDateTime(reader["Demdev_DatCre"]),
                     Convert.ToDateTime(reader["Demdev_DatMaj"])));
            }
            connection.Close();
            return listeDemandeDevis;
        }

        //Affichage de la ligne de demande de devis complet uniquement
        public List<Lignes_Demande_Devis> Get_Lignes_Demande_Devis_View()
        {
            Connection_Open();
            command.CommandText = "select * from Lignes_Demande_Devis";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeLignesDemandeDevis.Add(new Lignes_Demande_Devis(
                     Convert.ToInt32(reader["Ligdev_Num_ID"]), Convert.ToInt32(reader["Demdev_Num_ID"]), Convert.ToInt32(reader["Ligdev_Num_Ligne"]), Convert.ToInt32(reader["Art_Num_ID"]),
                     (string)reader["Art_Ref"], Convert.ToInt32(reader["Ligdev_Qte"]),
                     Convert.ToInt32(reader["Ligdev_Poids_TH"]), Convert.ToInt32(reader["Ligdev_Prix_HT"]), (string)reader["Ligdev_MsgCli"],
                     Convert.ToInt32(reader["Ligdev_PrixVteHT"])));
            }
            connection.Close();
            return listeLignesDemandeDevis;
        }


        //Affichage de la collection complet uniquement
        public List<Collections> Get_Collections_View()
        {
            Connection_Open();
            command.CommandText = "select * from Collections";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeCollections.Add(new Collections(
                     Convert.ToInt32(reader["Collections_Id"]),(string)reader["Collections_Lib"]));
            }
            connection.Close();
            return listeCollections;
        }

        //Affichage de la collection article complet uniquement
        public List<Col_Art> Get_Col_Art_View()
        {
            Connection_Open();
            command.CommandText = "select * from Col_Art";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeColArt.Add(new Col_Art(
                     Convert.ToInt32(reader["Collections_Id"]),Convert.ToInt32(reader["Art_Num_ID"])));
            }
            connection.Close();
            return listeColArt;
        }


        //Affichage des parametres complet uniquement
        public List<Parametres> Get_Parametres_View()
        {
            Connection_Open();
            command.CommandText = "select * from Parametres";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listeParametres.Add(new Parametres(Convert.ToInt32(reader["Param_Num_ID"]), (string)reader["Param_RaiSoc"],
                    (string)reader["Param_Email_Soc"], (string)reader["Param_Chemin_Photos"]));
            }
            connection.Close();
            return listeParametres;
        }

        //Affichage des couleurs complet uniquement
        public List<Colors> Get_Colors_View()
        {
            Connection_Open();
            command.CommandText = "select * from Colors";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                listeColors.Add(new Colors(
                    (string)reader["Colors_Id"], (string)reader["Colors_Lib"]));
            }
            connection.Close();
            return listeColors;
        }



    }
}