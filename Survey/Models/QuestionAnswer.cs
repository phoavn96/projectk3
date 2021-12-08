using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survey.Models
{
    [Table("Question_answers")]
    public class QuestionAnswer
    {
        [Required]
        [Key]
        public int QuestionAnswerId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<AccountAnswer> AccountAnswers { get; set; }
       
    }
}