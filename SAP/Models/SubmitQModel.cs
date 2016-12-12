using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.Models
{
    public class SubmitQModel
    {
        public int correct { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public string question { get; set; }

        public SubmitQModel()
        {

        }

    }
}