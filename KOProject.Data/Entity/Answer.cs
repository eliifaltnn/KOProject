using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOProject.Data.Entity
{
    public class Answer
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool? IsRight { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
