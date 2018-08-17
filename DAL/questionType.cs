using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum questionType
    {
        [Display(Name = "One correct answer")]
        oneAnswer = 1,
        [Display(Name = "More correct answers")]
        moreAnswers
    }
}
