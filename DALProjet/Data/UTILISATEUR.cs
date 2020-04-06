using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProjet.Data
{
    public class UTILISATEUR
    {
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isPromo { get; set; }
        public bool isFinanceur { get; set; }
        public bool isActive { get; set; }
    }
}
