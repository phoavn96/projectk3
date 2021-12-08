using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    [Table("Questions")]
    public class Question
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int? SurveyId { get; set; }

        public virtual AllSurvey Survey { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }

    }
}