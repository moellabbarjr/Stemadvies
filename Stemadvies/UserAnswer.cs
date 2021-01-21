using System;
using System.Collections.Generic;
using System.Text;

namespace Stemadvies
{
    public class UserAnswer
    {
        public int? question_id { get; set; }

        public string answer { get; set; }

        public List<Answer> parties { get; set; }
    }
}
