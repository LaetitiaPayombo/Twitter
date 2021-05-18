using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Utilisateur
    {

        private List<Tweeto> tweetos;

        public List<Tweeto> Tweetos { get => tweetos; set => tweetos = value; }


        public Utilisateur()
        {
            Tweetos = new List<Tweeto>();
        }


    }
}
