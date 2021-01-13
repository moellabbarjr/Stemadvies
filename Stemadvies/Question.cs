using System;
using System.Collections.Generic;
using System.Text;

namespace Stemadvies
{
    class Question
    {
        public int vraag_id { get; set; }

        public string vraag { get; set; }

        public int sectie_id { get; set; }

        public string created_at { get; set; }

        public List<Answer> antwoorden { get; set; }
    }
}
