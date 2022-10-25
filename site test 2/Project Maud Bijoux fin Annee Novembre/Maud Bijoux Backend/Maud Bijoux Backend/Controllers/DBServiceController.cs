using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net;
using Maud_Bijoux_Backend.Models;
using System.IO;

namespace Maud_Bijoux_Backend.Controllers
{
    public class DBServiceController : ApiController
    {

        //-----------------------  VIEW METHODE GET() -----------------------

      
        // Affichages des Articles
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles")]
        public IHttpActionResult Get_Liste_Articles()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------BAGUES-------------

        // bagues
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues")]
        public IHttpActionResult Get_Save_Articles_Bagues()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // Alliance
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Alliances")]
        public IHttpActionResult Get_Save_Articles_Bagues_Alliances()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Alliances());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Alliance homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Alliances/Homme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Alliances_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Alliances_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Alliance femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Alliances/Femme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Alliances_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Alliances_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Alliance enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Alliances/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bagues_Alliances_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Alliances_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Alliance mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Alliances/Mix")]
        public IHttpActionResult Get_Save_Articles_Bagues_Alliances_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Alliances_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }



        // Chevalieres
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Chevalieres")]
        public IHttpActionResult Get_Save_Articles_Bagues_Chevalieres()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Chevalieres());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Chevalieres homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Chevalieres/Homme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Chevalieres_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Chevalieres_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Chevalieres femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Chevalieres/Femme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Chevalieres_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Chevalieres_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Chevalieres enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Chevalieres/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bagues_Chevalieres_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Chevalieres_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Chevalieres mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Chevalieres/Mix")]
        public IHttpActionResult Get_Save_Articles_Bagues_Chevalieres_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Chevalieres_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }




        // Solitaire
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Solitaires")]
        public IHttpActionResult Get_Save_Articles_Bagues_Solitaires()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Solitaires());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Solitaire homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Solitaires/Homme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Solitaires_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Solitaires_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Solitaire femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Solitaires/Femme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Solitaires_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Solitaires_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Solitaire enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Solitaires/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bagues_Solitaires_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Solitaires_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Solitaire mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/Solitaires/Mix")]
        public IHttpActionResult Get_Save_Articles_Bagues_Solitaires_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Solitaires_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }




        // Autre bagues
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/AutresBagues")]
        public IHttpActionResult Get_Save_Articles_Bagues_Autres_Bagues()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Autres_Bagues());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Autre bagues homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/AutresBagues/Homme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Autres_Bagues_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Autres_Bagues_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Autre bagues femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/AutresBagues/Femme")]
        public IHttpActionResult Get_Save_Articles_Bagues_Autres_Bagues_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Autres_Bagues_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Autre bagues enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/AutresBagues/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bagues_Autres_Bagues_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Autres_Bagues_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Autre bagues
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bagues/AutresBagues/Mix")]
        public IHttpActionResult Get_Save_Articles_Bagues_Autres_Bagues_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bagues_Autres_Bagues_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }






        //-------------BOUCLE D'OREILLE-------------


        // boucle d'oreilles
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Pendentes
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Pendentes")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Pendentes()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Pendentes());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        //Pendentes homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Pendentes/Homme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Pendentes_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Pendentes_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        //Pendentes femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Pendentes/Femme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Pendentes_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Pendentes_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        //Pendentes enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Pendentes/Enfant")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Pendentes_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Pendentes_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        //Pendentes mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Pendentes/Mix")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Pendentes_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Pendentes_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }



        // autres boucle d'oreilles
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/AutresBoucleDOreilles")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Autres_Boucle_DOreilles()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres boucle d'oreilles homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/AutresBoucleDOreilles/Homme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres boucle d'oreilles femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/AutresBoucleDOreilles/Femme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres boucle d'oreilles enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/AutresBoucleDOreilles/Enfant")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres boucle d'oreilles mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/AutresBoucleDOreilles/Mix")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Autres_Boucle_DOreilles_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }



        // puces
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Puces")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Puces()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Puces());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // puces homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Puces/Homme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Puces_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Puces_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // puces femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Puces/Femme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Puces_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Puces_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // puces enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Puces/Enfant")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Puces_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Puces_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // puces mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Puces/Mix")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Puces_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Puces_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }




        // creole
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Creoles")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Creoles()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Creoles());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // creole homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Creoles/Homme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Creoles_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Creoles_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // creole femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Creoles/Femme")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Creoles_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Creoles_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // creole enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Creoles/Enfant")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Creoles_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Creoles_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // creole mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/BoucleDOreilles/Creoles/Mix")]
        public IHttpActionResult Get_Save_Articles_Boucle_D_Oreilles_Creoles_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Boucle_D_Oreilles_Creoles_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }




        //-------------BRACELETS-------------


        // bracelets
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets")]
        public IHttpActionResult Get_Save_Articles_Bracelets ()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // autres bracelets
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/AutresBracelets")]
        public IHttpActionResult Get_Save_Articles__Bracelets()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Autres_Bracelets());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres bracelets homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/AutresBracelets/Homme")]
        public IHttpActionResult Get_Save_Articles__Bracelets_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Autres_Bracelets_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres bracelets femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/AutresBracelets/Femme")]
        public IHttpActionResult Get_Save_Articles__Bracelets_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Autres_Bracelets_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres bracelets enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/AutresBracelets/Enfant")]
        public IHttpActionResult Get_Save_Articles__Bracelets_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Autres_Bracelets_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres bracelets mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/AutresBracelets/Mix")]
        public IHttpActionResult Get_Save_Articles__Bracelets_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Autres_Bracelets_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }



        // Bracelets Identité
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsIdentite")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Identite()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Identite());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Identité homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsIdentite/Homme")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Identite_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Identite_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Identité femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsIdentite/Femme")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Identite_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Identite_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Identité enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsIdentite/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Identite_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Identite_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Identité mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsIdentite/Mix")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Identite_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Identite_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // Bracelets Rigides
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsRigides")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Rigides()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Rigides());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Rigides homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsRigides/Homme")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Rigides_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Rigides_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Rigides femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsRigides/Femme")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Rigides_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Rigides_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Rigides enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsRigides/Enfant")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Rigides_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Rigides_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // Bracelets Rigides mix 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Bracelets/BraceletsRigides/Mix")]
        public IHttpActionResult Get_Save_Articles_Bracelets_Bracelets_Rigides_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Bracelets_Bracelets_Rigides());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }





        //-------------COLLIER ET CHAINE-------------


        // collier et chaine
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }


        // collier 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/Colliers")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Colliers()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Colliers());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // collier homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/Colliers/Homme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Colliers_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Colliers_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // collier femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/Colliers/Femme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Colliers_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Colliers_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // collier enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/Colliers/Enfant")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Colliers_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Colliers_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // collier mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/Colliers/Mix")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Colliers_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Colliers_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // autres collier
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/AutreChaines")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Autre_Chaines()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Autre_Chaines());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres collier homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/AutreChaines/Homme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Autre_Chaines_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Autre_Chaines_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres collier femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/AutreChaines/Femme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Autre_Chaines_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Autre_Chaines_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres collier enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/AutreChaines/Enfant")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Autre_Chaines_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Autre_Chaines_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres collier mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/AutreChaines/Mix")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Autre_Chaines_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Autre_Chaines_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // chaine fines
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/ChaineFine")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Chaine_Fine()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Chaine_Fine());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // chaine fines homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/ChaineFine/Homme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Chaine_Fine_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Chaine_Fine_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // chaine fines femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/ChaineFine/Femme")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Chaine_Fine_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Chaine_Fine_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // chaine fines enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/ChaineFine/Enfant")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Chaine_Fine_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Chaine_Fine_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // chaine fines mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/ColliersEtChaines/ChaineFine/Mix")]
        public IHttpActionResult Get_Save_Articles_Colliers_Chaines_Chaine_Fine_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Colliers_Chaines_Chaine_Fine_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }





        //-------------PARURE-------------

        // parure
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Parures")]
        public IHttpActionResult Get_Save_Articles_Parures()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Parures());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // parure homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Parures/Homme")]
        public IHttpActionResult Get_Save_Articles_Parures_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Parures_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // parure femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Parures/Femme")]
        public IHttpActionResult Get_Save_Articles_Parures_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Parures_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // parure enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Parures/Enfant")]
        public IHttpActionResult Get_Save_Articles_Parures_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Parures_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // parure mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Parures/Mix")]
        public IHttpActionResult Get_Save_Articles_Parures_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Parures_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }










        //-------------PENDENTIF-------------



        // pendentif
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs")]
        public IHttpActionResult Get_Save_Articles_Pendentifs()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }


        // pendentif religieux
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsReligieux")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Religieux()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Religieux());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif religieux homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsReligieux/Homme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Religieux_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Religieux_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif religieux femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsReligieux/Femme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Religieux_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Religieux_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif religieux
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsReligieux/Enfant")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Religieux_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Religieux_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif religieux
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsReligieux/Mix")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Religieux_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Religieux_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }



        // autres pendentif 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/AutresPendentifs")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Autres_Pendentifs()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Autres_Pendentifs());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres pendentif homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/AutresPendentifs/Homme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Autres_Pendentifs_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Autres_Pendentifs_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres pendentif femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/AutresPendentifs/Femme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Autres_Pendentifs_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Autres_Pendentifs_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres pendentif enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/AutresPendentifs/Enfant")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Autres_Pendentifs_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Autres_Pendentifs_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // autres pendentif mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/AutresPendentifs/Mix")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Autres_Pendentifs_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Autres_Pendentifs_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }


        // pendentif plaque
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsPlaques")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Plaques()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Plaques());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif plaque homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsPlaques/Homme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Plaques_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Plaques_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif plaque femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsPlaques/Femme")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Plaques_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Plaques_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif plaque enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsPlaques/Enfant")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Plaques_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Plaques_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // pendentif plaque mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Pendentifs/PendentifsPlaques/Mix")]
        public IHttpActionResult Get_Save_Articles_Pendentifs_Pendentifs_Plaques_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Pendentifs_Pendentifs_Plaques_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }






        //-------------PIERCINGS-------------



        // piercings
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings")]
        public IHttpActionResult Get_Save_Articles_Percings()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // piercings nez
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsNez")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Nez()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Nez());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        // piercings nez homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsNez/Homme")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Nez_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Nez_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings nez femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsNez/Femme")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Nez_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Nez_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings nez enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsNez/Enfant")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Nez_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Nez_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings nez mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsNez/Mix")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Nez_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Nez_Mix());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
      

        // piercings divers
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsDivers")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Divers()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Divers());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings divers homme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsDivers/Homme")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Divers_Homme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Divers_Homme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings divers femme
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsDivers/Femme")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Divers_Femme()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Divers_Femme());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings divers enfant
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsDivers/Enfant")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Divers_Enfant()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Divers_Enfant());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        // piercings divers mix
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Articles/Percings/PiercingsDivers/Mix")]
        public IHttpActionResult Get_Save_Articles_Percings_Piercings_Divers_Mix()
        {

            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Articles_View_Percings_Piercings_Divers());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }











        //Affichages du Metal
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Metal")]
        public IHttpActionResult Get_Liste_Metal()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Metal_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de la sous Familles
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/SousFamilles")]
        public IHttpActionResult Get_Liste_Sous_Familles()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Sous_Familles_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de la Familles
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Familles")]
        public IHttpActionResult Get_Liste_Familles()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Familles_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de la Pierre 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Pierres")]
        public IHttpActionResult Get_Liste_Pierres()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Pierres_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages du Type de Article
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/TypeArticle")]
        public IHttpActionResult Get_Liste_Type_Article()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Type_Article_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages du genre 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Genres")]
        public IHttpActionResult Get_Liste_Genres()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Genres_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de l 'indicatif tel 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/IndicatifTel")]
        public IHttpActionResult Get_Liste_Indicatif_Tel()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Indicatif_Tel_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages du compt client
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/ComptesClients")]
        public IHttpActionResult Get_Liste_Comptes_Clients()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Comptes_Clients_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages du compt client unique --------------------------------------------------------------------------------------------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/ComptesClientsUnique/{Cptcli_Cle_secu}")]
        public IHttpActionResult Get_Liste_Comptes_Clients_Unique(string Cptcli_Cle_secu)
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Comptes_Clients__Unique_View(Cptcli_Cle_secu));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }



        //Affichages de la demande de devis
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/DemandeDevis")]
        public IHttpActionResult Get_Liste_Demande_Devis()
        {
           
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Demande_Devis_View());
           
        }

        //Affichages de la ligne de demande de devis
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/LignesDemandeDevis")]
        public IHttpActionResult Get_Liste_Lignes_Demande_Devis()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Lignes_Demande_Devis_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de la collection
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Collections")]
        public IHttpActionResult Get_Liste_Collections()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Collections_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages de la collection article
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/ColArt")]
        public IHttpActionResult Get_Liste_Col_Art()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Col_Art_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages des parametres 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Parametres")]
        public IHttpActionResult Get_Liste_Parametres()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Parametres_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Affichages la Couleur
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Colors")]
        public IHttpActionResult Get_Liste_Colors()
        {
            try
            {
                DBServiceView DBServiceView = new DBServiceView();
                return Ok(DBServiceView.Get_Colors_View());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //-----------------------  SAVE METHODE POST() -----------------------

        //Isertion d'un articles
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Articles")]
        public IHttpActionResult Post_Save_Articles([FromBody] Articles articles)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Articles_Save(articles));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }
        

        //Isertion d'un Metal
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Metal")]
        public IHttpActionResult Post_Save_Metal([FromBody] Metal metal)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Metal_Save(metal));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        
        }

        //Isertion d'une sous famille
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/SousFamilles")]
        public IHttpActionResult Post_Save_Sous_Familles([FromBody] Sous_Familles sousFamilles)
        {

            //try
            //{
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Sous_Familles_Save(sousFamilles));
            //}
            //catch (Exception ex)
            //{
                //return Content(HttpStatusCode.BadRequest, ex);
           // }

        }

        //Isertion d'une famille
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Familles")]
        public IHttpActionResult Post_Save_Familles([FromBody] Familles familles)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Familles_Save(familles));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion d'une pierre
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Pierres")]
        public IHttpActionResult Post_Save_Pierres([FromBody] Pierres pierres)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Pierres_Save(pierres));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion d'un type article
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/TypeArticle")]
        public IHttpActionResult Post_Save_Type_Article([FromBody] Type_Article typeArticle)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Type_Article_Save(typeArticle));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion d'un genres
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Genres")]
        public IHttpActionResult Post_Save_Genres([FromBody] Genres genres)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Genre_Save(genres));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion de l'indicatif tel
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/IndicatifTel")]
        public IHttpActionResult Post_Save_Indicatif_Tel([FromBody] Indicatif_Tel indicatifTel)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Indicatif_Tel_Save(indicatifTel));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }


        //Isertion du Comptes Clients
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/ComptesClients")]
        public IHttpActionResult Post_Save_Comptes_Clients([FromBody] Comptes_Clients comptesClients)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Comptes_Clients_Save(comptesClients));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }


        }

        //Isertion de la Demande Devis
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/DemandeDevis")]
        public IHttpActionResult Post_Save_Demande_Devis([FromBody] Demande_Devis demandeDevis)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Demande_Devis_Save(demandeDevis));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion de Lignes Demande Devis
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/LignesDemandeDevis")]
        public IHttpActionResult Post_Save_Lignes_Demande_Devis([FromBody] Lignes_Demande_Devis lignesDemandeDevis)
        {

            
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Lignes_Demande_Devis_Save(lignesDemandeDevis));
            
          

        }

        //Isertion de la Collections
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Collections")]
        public IHttpActionResult Post_Save_Collections([FromBody] Collections collections)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Collections_Save(collections));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion de la Collection Article
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/ColArt")]
        public IHttpActionResult Post_Save_Col_Art([FromBody] Col_Art colArt)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Col_Art_Save(colArt));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion des parametres
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Parametres")]
        public IHttpActionResult Post_Save_Parametres([FromBody] Parametres parametres)
        {

            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Parametres_Save(parametres));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        //Isertion des colors
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Colors")]
        public IHttpActionResult Post_Save_Colors([FromBody] Colors colors)
        {
            try
            {
                DBServicePost DBServicePost = new DBServicePost();
                return Ok(DBServicePost.Post_Colors_Save(colors));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //-----------------------  SAVE METHODE DELETE() -----------------------


        //supprimer articles
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Articles/{Art_Num_ID}")]
        public IHttpActionResult Delete_Remove_Articles(int Art_Num_ID)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Articles_Remove(Art_Num_ID);
                return Ok("The Articles is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer metal
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Metal/{Metal_Id}")]
        public IHttpActionResult Delete_Remove_Metal(int Metal_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Metal_Remove(Metal_Id);
                return Ok("The Metal is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer sous metal
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/SousFamilles/{SS_Fam_Id}")]
        public IHttpActionResult Delete_Remove_Sous_Familles(string SS_Fam_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Sous_Familles_Remove(SS_Fam_Id);
                return Ok("The sous famille is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer familles
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Familles/{Familles_Id}")]
        public IHttpActionResult Delete_Remove_Familles(string Familles_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Familles_Remove(Familles_Id);
                return Ok("The Famille is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer pierres
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Pierres/{Pierres_Id}")]
        public IHttpActionResult Delete_Remove_Pierres(int Pierres_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Pierres_Remove(Pierres_Id);
                return Ok("The pierres is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer type article
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/TypeArticles/{Type_Art_Id}")]
        public IHttpActionResult Delete_Remove_Type_Article(int Type_Art_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Type_Article_Remove(Type_Art_Id);
                return Ok("The type articles is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer genres
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Genres/{Genres_Id}")]
        public IHttpActionResult Delete_Remove_Genres(string Genres_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Genres_Remove(Genres_Id);
                return Ok("The genres is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer indicatif tel
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/IndicatifTel/{Ind_Tel_Pays}")]
        public IHttpActionResult Delete_Remove_Indicatif_Tel(int Ind_Tel_Pays)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Indicatif_Tel_Remove(Ind_Tel_Pays);
                return Ok("The indicatif tel  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer compte client
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/ComptesClients/{Cptcli_Num_ID}")]
        public IHttpActionResult Delete_Remove_Comptes_Clients(int Cptcli_Num_ID)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Comptes_Clients_Remove(Cptcli_Num_ID);
                return Ok("The compte client  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer demande de devi
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/DemandeDevis/{Demdev_Num_ID}")]
        public IHttpActionResult Delete_Remove_Demande_Devis(int Demdev_Num_ID)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Demande_Devis_Remove(Demdev_Num_ID);
                return Ok("The demande de devis  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer ligne de demande de devis
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/LignesDemandeDevis/{Ligdev_Num_ID}")]
        public IHttpActionResult Delete_Remove_Lignes_Demande_Devis(int Ligdev_Num_ID)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Lignes_Demande_Devis_Remove(Ligdev_Num_ID);
                return Ok("The ligne de demande de devis  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //supprimer collection
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Collections/{Collections_Id}")]
        public IHttpActionResult Delete_Remove_Collections(int Collections_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Collections_Remove(Collections_Id);
                return Ok("The collection  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer collection article
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/ColArt/{Collections_Id}")]
        public IHttpActionResult Delete_Remove_Col_Art(int Collections_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Col_Art_Remove(Collections_Id);
                return Ok("The Col Art  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer parametre
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Parametres/{Param_Num_ID}")]
        public IHttpActionResult Delete_Remove_Parametres(int Param_Num_ID)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Parametres_Remove(Param_Num_ID);
                return Ok("The Parametres  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //supprimer Couleurs
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Colors/{Colors_Id}")]
        public IHttpActionResult Delete_Remove_Colors(string Colors_Id)
        {
            try
            {
                DBServiceDelete DBServiceDelete = new DBServiceDelete();
                DBServiceDelete.Delete_Colors_Remove(Colors_Id);
                return Ok("The Colors  is Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //-----------------------  SAVE METHODE PUT() -----------------------


        //update articles
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Articles/{Art_Ref}")]
        public IHttpActionResult Put_Update_Articles([FromBody] Articles articles, string Art_Ref)
        {

            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Articles_Update(articles, Art_Ref));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //update metal
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Metal/{Metal_Id}")]
        public IHttpActionResult Put_Update_Metal([FromBody] Metal metal , int Metal_Id)
        {

            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Metal_Update(metal, Metal_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update sous familles
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/SousFamilles/{SS_Fam_Id}")]
        public IHttpActionResult Put_Update_Sous_Familles([FromBody] Sous_Familles sousFamilles, string SS_Fam_Id)
        {

            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Sous_Familles_Update(sousFamilles, SS_Fam_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //update familles
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Familles/{Familles_Id}")]
        public IHttpActionResult Put_Update_Familles([FromBody] Familles familles, string Familles_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Familles_Update(familles, Familles_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update pierres
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Pierres/{Pierres_Id}")]
        public IHttpActionResult Put_Update_Pierres([FromBody] Pierres pierres, int Pierres_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Pierres_Update(pierres, Pierres_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update type article
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/TypeArticles/{Type_Art_Id}")]
        public IHttpActionResult Put_Update_Type_Article([FromBody] Type_Article typeArticle, int Type_Art_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Type_Article_Update(typeArticle, Type_Art_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update genres
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Genres/{Genres_Id}")]
        public IHttpActionResult Put_Update_Genres([FromBody] Genres genres, string Genres_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Genres_Update(genres, Genres_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update Indicatif tel
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/IndicatifTel/{Ind_Tel_Pays}")]
        public IHttpActionResult Put_Update_Indicatif_Tel([FromBody] Indicatif_Tel indicatifTel, string Ind_Tel_Pays)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Indicatif_Tel_Update(indicatifTel, Ind_Tel_Pays));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update compte client
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ComptesClients/{Cptcli_Num_ID}")]
        public IHttpActionResult Put_Update_Comptes_Clients([FromBody] Comptes_Clients comptesClients, int Cptcli_Num_ID)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Comptes_Clients_Update(comptesClients, Cptcli_Num_ID));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update compte client validation --------------------------------------------------------
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ComptesClientsValidation/{Cptcli_Cle_secu}")]
        public IHttpActionResult Put_Update_Comptes_Clients_Validation([FromBody] Comptes_Clients comptesClients, string Cptcli_Cle_secu)
        {
            try 
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Comptes_Clients_Validation_Update(comptesClients, Cptcli_Cle_secu));
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

      

        //update demande de devis
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/DemandeDevis/{Demdev_Num_ID}")]
        public IHttpActionResult Put_Update_Demande_Devis([FromBody] Demande_Devis demandeDevis, int Demdev_Num_ID)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Demande_Devis_Update(demandeDevis, Demdev_Num_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update ligne de demande de devis
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/LignesDemandeDevis/{Ligdev_Num_ID}")]
        public IHttpActionResult Put_Update_Lignes_Demande_Devis([FromBody] Lignes_Demande_Devis lignesDemandeDevis, int Ligdev_Num_ID)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Lignes_Demande_Devis_Update(lignesDemandeDevis, Ligdev_Num_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update collection
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Collections/{Collections_Id}")]
        public IHttpActionResult Put_Update_Collections([FromBody] Collections collections, int Collections_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Collections_Update(collections, Collections_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update article colletion
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ColArt/{Collections_Id}")]
        public IHttpActionResult Put_Update_Col_Art([FromBody] Col_Art colArt, int Collections_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Col_Art_Update(colArt, Collections_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //update parametres
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Parametres/{Param_Num_ID}")]
        public IHttpActionResult Put_Update_Parametres([FromBody] Parametres parametres, int Param_Num_ID)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Parametres_Update(parametres, Param_Num_ID));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //update parametres
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Colors/{Colors_Id}")]
        public IHttpActionResult Put_Update_Parametres([FromBody] Colors colors, string Colors_Id)
        {
            try
            {
                DBServicePut DBServicePut = new DBServicePut();
                return Ok(DBServicePut.Put_Colors_Update(colors, Colors_Id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}