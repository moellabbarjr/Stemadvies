using System;
using System.Collections.Generic;
using System.Text;

namespace Stemadvies
{
    class Answer
    {
        public int antwoord_id { get; set; }

        public string antwoord { get; set; }

        public int vraag_id { get; set; }

        public int score { get; set; }
    }
}
