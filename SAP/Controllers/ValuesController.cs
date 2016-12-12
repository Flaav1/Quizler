using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using System.Web;
using SAP.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SAP.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var rnd = new Random();
            int id;
            try
            {
                using (var db = new QuizGameEntities())
                {
                   
                    var question = new QuestionModel();
                    var opt = new Option();
                    var question1 = db.Questions.ToList();
                    id = rnd.Next(0, question1.Count);


                    var fromdb = question1[id];
                    question.Id = fromdb.Id;
                    question.Question = fromdb.Question1;
                    var ans = db.Answers.FirstOrDefault(x => x.QuestionId == fromdb.Id);
                    question.Answer = ans.Answer1;
                    opt = db.Options.FirstOrDefault(x => x.QuestionId == fromdb.Id);
                    if (question != null)
                    {
                        question.length = db.Questions.Count();
                        question.Options.Add(opt.Option1);
                        question.Options.Add(opt.Option2);
                        question.Options.Add(opt.Option3);
                        question.Options.Add(opt.Option4);
                        return Ok(question);

                    }

                    return NotFound();

                }
            }

            catch (Exception ex)
            {

                return BadRequest("An error has occured!" + ex);
            }

        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var db = new QuizGameEntities())
                {
                    var question = new QuestionModel();
                    var opt = new Option();
                    var fromdb = db.Questions.FirstOrDefault(x => x.Id == id);
                    question.Id = fromdb.Id;
                    question.Question = fromdb.Question1;
                    var ans = db.Answers.FirstOrDefault(x => x.QuestionId == id);
                    question.Answer = ans.Answer1;
                    opt = db.Options.FirstOrDefault(x => x.QuestionId == id);
                    if (question != null)
                    {
                        question.length = db.Questions.Count();
                        question.Options.Add(opt.Option1);
                        question.Options.Add(opt.Option2);
                        question.Options.Add(opt.Option3);
                        question.Options.Add(opt.Option4);
                        System.Threading.Thread.Sleep(1500);
                        return Ok(question);

                    }
                  
                        return NotFound();
                 
                }
            }

            catch (Exception ex)
            {

                return BadRequest("An error has occured!" + ex);
            }

            

                
        }

                
        

        // POST api/values
        public IHttpActionResult Post(dynamic DynamicClass)
        {

            string input = JsonConvert.SerializeObject(DynamicClass);
            if(input == null)
            {
                return BadRequest("Unnacceptable data type!");
            }


            int cor;
            string[,] answer = new string[6, 2];
            string srlzd = "";

            foreach (var chr in input)
            {
                if (chr == '[' || chr == '{' || chr == '\\' || chr == '"' || chr == '}' || chr == ']')
                {

                }
                else
                {
                    srlzd = srlzd + chr;
                }
            }

            string[] qanda = srlzd.Split(',');

            for (int i = 0; i < qanda.Length; i++)
            {
                string[] temp = qanda[i].Split(':');

                answer[i, 0] = temp[0];
                answer[i, 1] = temp[1];
            }

            Question qq = new Question();
            qq.Question1 = answer[0, 1];

            Answer ans = new Answer();
            cor = Convert.ToInt16(answer[5, 1]);
            if(cor == 0)
            {
                return BadRequest("You must Select One Correct Answer!");
            }
            ans.Answer1 = answer[cor, 1];

            Option op = new Option();

            op.Option1 = answer[1, 1];
            op.Option2 = answer[2, 1];
            op.Option3 = answer[3, 1];
            op.Option4 = answer[4, 1];

            if(String.IsNullOrEmpty(qq.Question1) || string.IsNullOrEmpty(op.Option1) || string.IsNullOrEmpty(op.Option2) 
               || string.IsNullOrEmpty(op.Option3) || string.IsNullOrEmpty(op.Option4))
            {
                return BadRequest("You Can't Have Empty Question or Answers!");
            }


            try
            {
                using (var db = new QuizGameEntities())
                {
                    var myq = db.Questions.ToList();

                    foreach (var item in myq)
                    {

                      if(item.Question1 == qq.Question1)
                        {
                            return BadRequest("This Question Already Exists!");
                        }
                    }



                    db.Questions.Add(qq);
                    db.Options.Add(op);
                    db.Answers.Add(ans);
                    db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Something wrong with the database!");
            }
           

          
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
