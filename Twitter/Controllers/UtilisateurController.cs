using Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Twitter.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            Utilisateur utilisateur = null;
            string stringUtilisateur = HttpContext.Session.GetString("utilisateur");
            if (stringUtilisateur != null)
            {
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(stringUtilisateur);
            }
            return View(utilisateur);
        }


        public IActionResult AddTweeto(int id)
        {
            string stringUtilisateur = HttpContext.Session.GetString("utilisateur");
            Utilisateur utilisateur = new Utilisateur();
            if (stringUtilisateur != null)
            {
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(stringUtilisateur);
            }
            Tweeto t = Tweeto.GetTweeto(id);
            if (t != null)
            {
                utilisateur.Tweetos.Add(t);
                HttpContext.Session.SetString("utilisateur", JsonConvert.SerializeObject(utilisateur));
            }

            return RedirectToAction("Index");
        }

    }
}
