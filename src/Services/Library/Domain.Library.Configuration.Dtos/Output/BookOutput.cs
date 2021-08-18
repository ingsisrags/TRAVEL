using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Output
{
   public class BookOutput
    {
        public int ISBN { get; set; }

        public string Tittle { get; set; }

        public string Synopsis { get; set; }
        public int Pages { get; set; }
    }
}
