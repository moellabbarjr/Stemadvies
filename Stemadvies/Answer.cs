using System;
using System.Collections.Generic;
using System.Text;

namespace Stemadvies
{
    public class Answer
    {
        public int antwoord_id { get; set; }

        public int vraag_id { get; set; }

        public int partij_id { get; set; }

        public string partij_naam { get; set; }

        public string partij_logo { get; set; }

        public int eens { get; set; }
    }
}
