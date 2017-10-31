using System.Collections.Generic;

namespace SurveyTool
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<Answer> Answers {get; set; }
        
        public Question(int id, string title, string type)
        {
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.Answers = new List<Answer>();
        }
    }
}
