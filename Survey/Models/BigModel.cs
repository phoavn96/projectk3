using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    public class BigModel
    {
        public List<AllSurvey> AllSurvey { get; set; }
        public List<Question> Question { get; set; }
        public List<QuestionAnswer> QuestionAnswer { get; set; }
        public List<QaTemp> QaTemps { get; set; }
    }
}