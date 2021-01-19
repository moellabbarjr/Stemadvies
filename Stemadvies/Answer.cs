using System;
using System.Collections.Generic;
using System.Text;

namespace Stemadvies
{
    class Answer
    {
        public int antwoord_id { get; set; }

        public int vraag_id { get; set; }

        public int partij_id { get; set; }

        public int eens { get; set; }
    }
}
