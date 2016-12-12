using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int length { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }

        public QuestionModel()
        {
            Options = new List<string>();
        }
    }
}