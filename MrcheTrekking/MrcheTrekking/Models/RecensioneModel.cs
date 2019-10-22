using System;
using System.Collections.Generic;
using System.Text;
using MrcheTrekking.ViewModels;

namespace MrcheTrekking.Models
{
    public class RecensioneModel
    {
        public int IdRecensione { get; set; }
        public string NomePercorso { get; set; }
        public string Recensione { get; set; }
        public string UserName { get; set; }
    }
}