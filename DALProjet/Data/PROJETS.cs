using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProjet.Data
{
    public class PROJETS
    {
        public int ProjetId { get; set; }
        public string Nom { get; set; }
        public double plafondFinancement { get; set; }
        public string Description { get; set; }
        public string numeroCompte { get; set; }
        public string urlVideo { get; set; }

       
    }
}
