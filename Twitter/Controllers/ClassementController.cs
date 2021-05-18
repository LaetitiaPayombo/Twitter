using Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Controllers
{
    public class ClassementController : Controller
    {

        public IActionResult Index(int? id, string message)
        {
            ViewBag.Message = message;
            return View(Tweeto.GetTweetos(id));
        }

        public IActionResult FormClassement()
        {
            return View();
        }

        public IActionResult SubmitFormClassement(Classement classement)
        {
            if (classement.Save())
            {
                return RedirectToAction("Index", new { message = "Sujet ajoutée avec l'id " + classement.Id });
            }
            else
            {
                ViewBag.Message = "Erreur Insertion sujet";
                return View("FormClassement");
            }
        }











    }
}
