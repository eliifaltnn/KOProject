using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOProject.Data.Entity
{
    public class Question
    {
        public int ID { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }

        public string Content { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public int ExamID { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
