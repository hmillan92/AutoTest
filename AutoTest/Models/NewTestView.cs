﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class NewTestView
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public List<TestSummaryDetailTmp> SummaryDetails { get; set; }

        public List<TestQuestionDetailTmp> QuestionDetails { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        //public double TotalSummaryImportance { get { return Details == null ? 0 : Details.Sum(d => d.TestAnswerID)/3; } }

    }
}