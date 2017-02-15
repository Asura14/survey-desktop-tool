using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTool
{
    class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<Answer> Answers{get; set; }
        
        public Question(int id, string title, string type)
        {
            Id = id;
            Title = title;
            Type = type;
            Answers = new List<Answer>();
        }
    }
}
