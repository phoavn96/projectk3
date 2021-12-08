using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    [Table("AllSurveys")]
    public class AllSurvey
    {
        [Required]
        [Key]
        public int SurveyId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public SurveyStatus Status { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
    public enum SurveyStatus
    {
        NOT_HAPPENNING_YET, HAPPENNING, DELETED,DONE
    }
}