using Twitter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Controllers
{
    public class TweetoController : Controller
    {
        IWebHostEnvironment _env;

        public TweetoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult FormTweeto()
        {
            ViewBag.Classements = Classement.GetClassements();
            return View();
        }

        public IActionResult SubmitFormTweeto (Tweeto tweeto, IFormFile[] images)
        {
            foreach (IFormFile image in images)
            {
                tweeto.Images.Add(UploadImage(image));
            }
            if (tweeto.Save())
            {
                return RedirectToAction("Index", "Classement", new { message = "Commentaire ajouté" });
            }
            else
            {
                ViewBag.Message = "Erreur ajout commentaire";
                return View("FormTweeto");
            }
        }



        public IActionResult Detail(int id)
        {
            return View(Tweeto.GetTweeto(id));
        }

        private Image UploadImage(IFormFile image)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + image.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            Stream stream = System.IO.File.Create(path);
            image.CopyTo(stream);
            stream.Close();
            return new Image() { Url = "images/" + fileName };
        }











    }
}
